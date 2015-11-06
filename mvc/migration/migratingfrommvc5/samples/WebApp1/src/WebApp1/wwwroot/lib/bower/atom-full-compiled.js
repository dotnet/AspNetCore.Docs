
/*
---

name: "AtomJS"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

authors:
	- Pavel Ponomarenko aka Shock <shocksilien@gmail.com>

inspiration:
	- "[JQuery](http://jquery.com)"
	- "[MooTools](http://mootools.net)"

...
*/

(function (Object, Array, undefined) { // AtomJS
// Safari 5 bug:
// 'use strict';

var
	toString  = Object.prototype.toString,
	hasOwn    = Object.prototype.hasOwnProperty,
	slice     = Array .prototype.slice,
	atom = this.atom = function () {
		if (atom.initialize) return atom.initialize.apply(this, arguments);
	};

atom.global = this;

/*
---

name: "JavaScript 1.8.5"

description: "JavaScript 1.8.5 Compatiblity."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

inspiration:
  - "[JQuery](http://jquery.com)"
  - "[MooTools](http://mootools.net)"

provides: js185

...
*/

// https://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Function/bind
if (!Function.prototype.bind) {
	Function.prototype.bind = function(context /*, arg1, arg2... */) {
		if (typeof this !== "function") throw new TypeError("Function.prototype.bind - what is trying to be bound is not callable");

		var args   = slice.call(arguments, 1),
			toBind = this,
			Nop    = function () {},
			Bound  = function () {
				var isInstance;
				// Opera & Safari bug fixed. I must fix it in right way
				// TypeError: Second argument to 'instanceof' does not implement [[HasInstance]]
				try {
					isInstance = this instanceof Nop;
				} catch (ignored) {
					// console.log( 'bind error', Nop.prototype );
					isInstance = false;
				}
				return toBind.apply(
					isInstance ? this : ( context || {} ),
					args.concat( slice.call(arguments) )
				);
			};
		Nop.prototype   = toBind.prototype;
		Bound.prototype = new Nop();
		return Bound;
	};
}

// https://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Object/keys
if (!Object.keys) (function (has) {

	Object.keys = function(obj) {
		if (obj !== Object(obj)) throw new TypeError('Object.keys called on non-object');

		var keys = [], i;
		for (i in obj) if (has.call(obj, i)) keys.push(i);
		return keys;
	};
})({}.hasOwnProperty);

// https://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Array/isArray
if (!Array.isArray) {
	Array.isArray = function(o) {
		return o && toString.call(o) === '[object Array]';
	};
}

// https://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Object/create
if (!Object.create) {
	Object.create = function (o) {
		if (arguments.length > 1) {
			throw new Error('Object.create implementation only accepts the first parameter.');
		}
		function F() {}
		F.prototype = o;
		return new F();
	};
}

if (!String.prototype.trim) {
	String.prototype.trim = function () {
		return this.replace(/^\s+|\s+$/g, '');
	}
}

if (!String.prototype.trimLeft) {
	String.prototype.trimLeft = function () {
		return this.replace(/^\s+/, '');
	}
}

if (!String.prototype.trimRight) {
	String.prototype.trimRight = function () {
		return this.replace(/\s+$/g, '');
	}
}

/*
---

name: "Core"

description: "The core of AtomJS."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

inspiration:
  - "[JQuery](http://jquery.com)"
  - "[MooTools](http://mootools.net)"

provides: Core

requires:
	- js185

...
*/

function coreIsFunction (item) {
	return item && toString.call(item) == '[object Function]';
}

function coreObjectize (properties, value) {
	if (typeof properties != 'object') {
		var key = properties;
		properties = {};
		if (key != null) {
			properties[key] = value;
		}
	}
	return properties;
}

function coreContains (array, element) {
	return array.indexOf(element) >= 0;
}

function includeUnique(array, element) {
	if (!coreContains(array, element)) {
		array.push(element);
	}
	return array;
}

function coreEraseOne(array, element) {
	element = array.indexOf(element);
	if (element != -1) {
		array.splice( element, 1 );
	}
	return array;
}

function coreEraseAll(array, element) {
	for (var i = array.length; i--;) {
		if (array[i] == element) {
			array.splice( i, 1 );
		}
	}
	return array;
}
function coreToArray (elem) { return slice.call(elem) }
function coreIsArrayLike (item) {
	return item && (Array.isArray(item) || (
		typeof item != 'string' &&
		!coreIsFunction(item) &&
		typeof item.nodeName != 'string' &&
		typeof item.length == 'number'
	));
}
function coreAppend(target, source) {
	if (source) for (var key in source) if (hasOwn.call(source, key)) {
		target[key] = source[key];
	}
	return target;
}

new function () {

	function ensureObjectSetter (fn) {
		return function (properties, value) {
			return fn.call(this, coreObjectize(properties, value))
		}
	}
	function overloadSetter (fn) {
		return function (properties, value) {
			properties = coreObjectize(properties, value);
			for (var i in properties) fn.call( this, i, properties[i] );
			return this;
		};
	}
	function overloadGetter (fn, ignoreEmpty) {
		return function (properties) {
			if (Array.isArray(properties)) {
				var result = {}, name, value;
				for (var i = properties.length; i--;) {
					name = properties[i];
					value = fn.call(this, name);
					if (!ignoreEmpty || typeof value !== 'undefined') {
						result[name] = value;
					}
				}
				return result;
			}
			return fn.call(this, properties);
		};
	}
	/**
	 * Returns function that calls callbacks.get
	 * if first parameter is primitive & second parameter is undefined
	 *     object.attr('name')          - get
	 *     object.attr('name', 'value') - set
	 *     object.attr({name: 'value'}) - set
	 * @param {Object} callbacks
	 * @param {Function} callbacks.get
	 * @param {Function} callbacks.set
	 */
	function slickAccessor (callbacks) {
		var setter =  atom.core.overloadSetter(callbacks.set);

		return function (properties, value) {
			if (typeof value === 'undefined' && typeof properties !== 'object') {
				return callbacks.get.call(this, properties);
			} else {
				return setter.call(this, properties, value);
			}
		};
	}

	atom.core = {
		isFunction: coreIsFunction,
		objectize : coreObjectize,
		contains  : coreContains,
		eraseOne  : coreEraseOne,
		eraseAll  : coreEraseAll,
		toArray   : coreToArray,
		append    : coreAppend,
		isArrayLike   : coreIsArrayLike,
		includeUnique : includeUnique,
		slickAccessor : slickAccessor,
		overloadSetter: overloadSetter,
		overloadGetter: overloadGetter,
		ensureObjectSetter: ensureObjectSetter
	};

	/** @deprecated - use atom.core.toArray instead */
	atom.toArray   = coreToArray;
	/** @deprecated - use console-cap instead: https://github.com/theshock/console-cap/ */
	atom.log = function () { throw new Error('deprecated') };
	/** @deprecated - use atom.core.isArrayLike instead */
	atom.isArrayLike = coreIsArrayLike;
	/** @deprecated - use atom.core.append instead */
	atom.append = coreAppend;

};

/*
---

name: "Accessors"

description: "Implementing accessors"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core

provides: accessors

...
*/

(function (Object) {
	var standard = !!Object.getOwnPropertyDescriptor, nonStandard = !!{}.__defineGetter__;

	if (!standard && !nonStandard) throw new Error('Accessors are not supported');

	var lookup = nonStandard ?
		function (from, key, bool) {
			var g = from.__lookupGetter__(key), s = from.__lookupSetter__(key), has = !!(g || s);

			if (bool) return has;

			return has ? { get: g, set: s } : null;
		} :
		function (from, key, bool) {
			var descriptor = Object.getOwnPropertyDescriptor(from, key);
			if (!descriptor) {
				// try to find accessors according to chain of prototypes
				var proto = Object.getPrototypeOf(from);
				if (proto) return atom.accessors.lookup(proto, key, bool);
			} else if ( descriptor.set || descriptor.get ) {
				if (bool) return true;

				return {
					set: descriptor.set,
					get: descriptor.get
				};
			}
			return bool ? false : null;
		}; /* lookup */

	var define = nonStandard ?
		function (object, prop, descriptor) {
			if (descriptor) {
				if (descriptor.get) object.__defineGetter__(prop, descriptor.get);
				if (descriptor.set) object.__defineSetter__(prop, descriptor.set);
			}
			return object;
		} :
		function (object, prop, descriptor) {
			if (descriptor) {
				var desc = {
					get: descriptor.get,
					set: descriptor.set,
					configurable: true,
					enumerable: true
				};
				Object.defineProperty(object, prop, desc);
			}
			return object;
		};

	atom.accessors = {
		lookup: lookup,
		define: function (object, prop, descriptor) {
			if (typeof prop == 'object') {
				for (var i in prop) define(object, i, prop[i]);
			} else {
				define(object, prop, descriptor);
			}
			return object;
		},
		has: function (object, key) {
			return atom.accessors.lookup(object, key, true);
		},
		inherit: function (from, to, key) {
			var a = atom.accessors.lookup(from, key);

			if ( a ) {
				atom.accessors.define(to, key, a);
				return true;
			}
			return false;
		}
	};
})(Object);

/*
---

name: "Dom"

description: "todo"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- accessors

inspiration:
  - "[JQuery](http://jquery.org)"

provides: dom

...
*/
(function (window, document) {
	var
		regexp = {
			Tag  : /^[-_a-z0-9]+$/i,
			Class: /^\.[-_a-z0-9]+$/i,
			Id   : /^#[-_a-z0-9]+$/i
		},
		isArray = Array.isArray,
		prevent = function (e) {
			e.preventDefault();
			return false;
		},
		ignoreCssPostfix = {
			zIndex: true,
			fontWeight: true,
			opacity: true,
			zoom: true,
			lineHeight: true
		},
		domReady = false,
		onDomReady = [],
		camelCase = function (str) {
			return String(str).replace(/-\D/g, function(match){
				return match[1].toUpperCase();
			});
		},
		hyphenate = function (str) {
			return String(str).replace(/[A-Z]/g, function(match){
				return '-' + match[0].toLowerCase();
			});
		},
		readyCallback = function () {
			if (domReady) return;
			
			domReady = true;
			
			for (var i = 0; i < onDomReady.length;) {
				onDomReady[i++]();
			}
			
			onDomReady = [];
		},
		findParentByLevel = function (elem, level) {
			if (level == null || level < 0) level = 1;

			if (!elem || level <= 0) return atom.dom(elem);

			return findParentByLevel(elem.parentNode, level-1);
		};
		
	document.addEventListener('DOMContentLoaded', readyCallback, false);
	window.addEventListener('load', readyCallback, false);

	var Dom = function (sel, context) {
		if (! (this instanceof Dom)) {
			return new Dom(sel, context);
		}

		if (!arguments.length) {
			this.elems = [document];
			return this;
		}

		if (!context && sel === 'body') {
			this.elems = [document.body];
			return this;
		}

		if (context !== undefined) {
			return new Dom(context || document).find(sel);
		}
		context = context || document;

		if (typeof sel == 'function' && !(sel instanceof Dom)) {
			// onDomReady
			var fn = sel.bind(this, atom, Dom);
			domReady ? setTimeout(fn, 1) : onDomReady.push(fn);
			return this;
		}

		var elems = this.elems =
			  sel == window          ? [ document ]
			: sel instanceof Dom     ? coreToArray(sel.elems)
			: coreIsArrayLike(sel)   ? coreToArray(sel)
			: typeof sel == 'string' ? Dom.query(context, sel)
			:                          Dom.find(context, sel);

		if (elems.length == 1 && elems[0] == null) {
			elems.length = 0;
		}

		return this;
	};
	coreAppend(Dom, {
		query : function (context, sel) {
			return sel.match(regexp.Id)    ? [(context.getElementById ? context : document).getElementById(sel.substr(1))] :
			       sel.match(regexp.Class) ? coreToArray(context.getElementsByClassName(sel.substr(1))) :
			       sel.match(regexp.Tag)   ? coreToArray(context.getElementsByTagName  (sel)) :
			                                 coreToArray(context.querySelectorAll      (sel));
		},
		find: function (context, sel) {
			if (!sel) return context == null ? [] : [context];

			var result = sel.nodeName ? [sel]
				: typeof sel == 'string' ? Dom.query(context, sel) : [context];
			return (result.length == 1 && result[0] == null) ? [] : result;
		},
		create: function (tagName, attr) {
			var elem = new Dom(document.createElement(tagName));
			if (attr) elem.attr(attr);
			return elem;
		},
		isElement: function (node) {
			return !!(node && node.nodeName);
		}
	});
	Dom.prototype = {
		constructor: Dom,
		elems: [],
		get length() {
			return this.elems ? this.elems.length : 0;
		},
		get body() {
			return this.find('body');
		},
		get first() {
			return this.elems[0];
		},
		get : function (index) {
			return this.elems[Number(index) || 0];
		},
		parent : function(step) {
			return findParentByLevel(this.first, step);
		},
		contains: function (child) {
			var parent = this.first;
			child = atom.dom(child).first;
			if ( child ) while ( child = child.parentNode ) {
				if( child == parent ) {
					return true;
				}
			}
			return false;
		},
		filter: function (selector) {
			var property = null;
			// speed optimization for "tag" & "id" filtering
			if (selector.match(regexp.Tag)) {
				selector = selector.toUpperCase();
				property = 'tagName';
			} else if (selector.match(regexp.Id)) {
				selector = selector.substr(1).toUpperCase();
				property = 'id';
			}

			return new Dom(this.elems.filter(function (elem) {
				if (property) {
					return elem[property].toUpperCase() == selector;
				} else {
					return elem.parentNode && coreToArray(
						elem.parentNode.querySelectorAll(selector)
					).indexOf(elem) >= 0;
				}
			}));
		},
		is: function (selector) {
			return this.filter(selector).length > 0;
		},
		html : function (value) {
			if (value != null) {
				this.first.innerHTML = value;
				return this;
			} else {
				return this.first.innerHTML;
			}
		},
		text : function (value) {
			var property = document.body.innerText == null ? 'textContent' : 'innerText';
			if (value == null) {
				return this.first[property];
			}
			this.first[property] = value;
			return this;
		},
		create : function (tagName, index, attr) {
			if (typeof index == 'object') {
				attr  = index;
				index = 0;
			}
			atom.dom.create(tagName, attr).appendTo( this.get(index) );
			return this;
		},
		each : function (fn) {
			this.elems.forEach(fn.bind(this));
			return this;
		},
		attr : atom.core.slickAccessor({
			get: function (name) {
				return this.first.getAttribute(name);
			},
			set: function (name, value) {
				var e = this.elems, i = e.length;
				while (i--) {
					e[i].setAttribute(name, value)
				}
			}
		}),
		css : atom.core.slickAccessor({
			get: function (name) {
				return window.getComputedStyle(this.first, "").getPropertyValue(hyphenate(name));
			},
			set: function (name, value) {
				var e = this.elems, i = e.length;
				while (i--) {
					if (typeof value == 'number' && !ignoreCssPostfix[name]) {
						value += 'px';
					}
					e[i].style[camelCase(name)] = value;
				}
			}
		}),

		addEvent: atom.core.overloadSetter(function (event, callback) {
			if (callback === false) callback = prevent;

			this.each(function (elem) {
				if (elem == document && event == 'load') elem = window;
				elem.addEventListener(event, callback, false);
			});

			return this;
		}),
		removeEvent : atom.core.overloadSetter(function (event, callback) {
			if (callback === false) callback = prevent;

			this.each(function (elem) {
				if (elem == document && event == 'load') elem = window;
				elem.removeEventListener(event, callback, false);
			});

			return this;
		}),
		/** @deprecated */
		bind : function (event, callback) {
			return this.addEvent.apply(this, arguments)
		},
		/** @deprecated */
		unbind : function (event, callback) {
			return this.removeEvent.apply(this, arguments)
		},
		delegate : function (selector, event, fn) {
			return this.bind(event, function (e) {
				if (new Dom(e.target).is(selector)) {
					fn.apply(this, arguments);
				}
			});
		},
		wrap : function (wrapper) {
			wrapper = new Dom(wrapper).first;
			return this.replaceWith(wrapper).appendTo(wrapper);
		},
		replaceWith: function (element) {
			var obj = this.first;
			element = Dom(element).first;
			obj.parentNode.replaceChild(element, obj);
			return this;
		},
		find : function (selector) {
			var result = [];
			this.each(function (elem) {
				var i = 0,
					found = Dom.find(elem, selector),
					l = found.length;
				while (i < l) includeUnique(result, found[i++]);
			});
			return new Dom(result);
		},
		appendTo : function (to) {
			var fr = document.createDocumentFragment();
			this.each(function (elem) {
				fr.appendChild(elem);
			});
			Dom(to).first.appendChild(fr);
			return this;
		},
        appendBefore: function (elem) {
			var fr = document.createDocumentFragment();
			this.each(function (elem) {
				fr.appendChild(elem);
			});
			Dom(elem).parent().first.insertBefore(fr, Dom(elem).first);
			return this;
		},
		appendAfter: function (elem) {
			var parent = Dom(elem).parent().first;
			var next = Dom(elem).first.nextSibling;
			var fr = document.createDocumentFragment();
			this.each(function (elem) {
				fr.appendChild(elem);
			});
			
			if (next) {
				parent.insertBefore(fr, next);
			} else {
				parent.appendChild(fr);
			}
			
			return this;
		},
		/** @private */
		manipulateClass: function (classNames, fn) {
			if (!classNames) return this;
			if (!isArray(classNames)) classNames = [classNames];

			return this.each(function (elem) {
				var i, all = elem.className.split(/\s+/);

				for (i = classNames.length; i--;) {
					fn.call(this, all, classNames[i]);
				}

				elem.className = all.join(' ').trim();
			});
		},
		addClass: function (classNames) {
			return this.manipulateClass(classNames, includeUnique);
		},
		removeClass: function (classNames) {
			return this.manipulateClass(classNames, coreEraseAll);
		},
		toggleClass: function(classNames) {
			return this.manipulateClass(classNames, function (all, c) {
				var i = all.indexOf(c);
				if (i === -1) {
					all.push(c);
				} else {
					all.splice(i, 1);
				}
			});
		},
		hasClass: function(classNames) {
			if (!classNames) return this;
			if (!isArray(classNames)) classNames = [classNames];
			
			var result = false;
			this.each(function (elem) {
				if (result) return;
				
				var i = classNames.length,
					all = elem.className.split(/\s+/);

				while (i--) if (!coreContains(all, classNames[i])) {
					return;
				}

				result = true;
			});
			return result;
		},
		offset: function () {
			var element = this.first;
			if (element.offsetX != null) {
				return { x: element.offsetX, y: element.offsetY };
			}

			var box = element.getBoundingClientRect(),
				body    = document.body,
				docElem = document.documentElement,
				scrollLeft = window.pageXOffset || docElem.scrollLeft || body.scrollLeft,
				scrollTop  = window.pageYOffset || docElem.scrollTop  || body.scrollTop,
				clientLeft = docElem.clientLeft || body.clientLeft || 0,
				clientTop  = docElem.clientTop  || body.clientTop  || 0;

			return {
				x: Math.round(box.left + scrollLeft - clientLeft),
				y: Math.round(box.top  + scrollTop  - clientTop )
			};
		},
		clone: function (deep) {
			var i = 0, elements = [];

			if (deep == null) deep = true;

			for (; i < this.elems.length; i++) {
				elements.push(this.elems[i].cloneNode(deep));
			}

			return atom.dom(elements);
		},
		empty: function () {
			return this.each(function (elem) {
				while (elem.hasChildNodes()) {
					elem.removeChild( elem.firstChild );
				}
			});
		},
		log : function () {
			console.log('atom.dom: ', this.elems);
			return this;
		},
		destroy : function () {
			return this.each(function (elem) {
				if (elem.parentNode) {
					elem.parentNode.removeChild(elem);
				}
			});
		}
	};

	atom.dom = Dom;
}(window, window.document));


/*
---

name: "CoreExtended"

description: "Extended core of AtomJS  - extend, implements, clone, typeOf"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

inspiration:
  - "[JQuery](http://jquery.com)"
  - "[MooTools](http://mootools.net)"

provides: CoreExtended

requires:
	- js185
	- Core

...
*/

new function () {

function innerExtend (proto) {
	return function (elem, from) {
		if (from == null) {
			from = elem;
			elem = atom;
		}

		var ext = proto ? elem.prototype : elem,
		    accessors = atom.accessors && atom.accessors.inherit;

		for (var i in from) if (i != 'constructor') {
			if ( accessors && accessors(from, ext, i) ) continue;

			ext[i] = clone(from[i]);
		}
		return elem;
	};
}

function typeOf (item) {
	if (item == null) return 'null';

	var string = toString.call(item);
	for (var i in typeOf.types) if (i == string) return typeOf.types[i];

	if (item.nodeName){
		if (item.nodeType == 1) return 'element';
		if (item.nodeType == 3) return /\S/.test(item.nodeValue) ? 'textnode' : 'whitespace';
	}

	var type = typeof item;

	if (item && type == 'object') {
		if (atom.Class && item instanceof atom.Class) return 'class';
		if (coreIsArrayLike(item)) return 'arguments';
	}

	return type;
}

typeOf.types = {};
['Boolean', 'Number', 'String', 'Function', 'Array', 'Date', 'RegExp', 'Class'].forEach(function(name) {
	typeOf.types['[object ' + name + ']'] = name.toLowerCase();
});


function clone (object) {
	var type = typeOf(object);
	return type in clone.types ? clone.types[type](object) : object;
}
clone.types = {
	'array': function (array) {
		var i = array.length, c = new Array(i);
		while (i--) c[i] = clone(array[i]);
		return c;
	},
	'class':function (object) {
		return typeof object.clone == 'function' ?
			object.clone() : object;
	},
	'object': function (object) {
		if (typeof object.clone == 'function') return object.clone();

		var c = {}, accessors = atom.accessors && atom.accessors.inherit;
		for (var key in object) {
			if (accessors && accessors(object, c, key)) continue;
			c[key] = clone(object[key]);
		}
		return c;
	}
};

atom.core.extend    = innerExtend(false);
atom.core.implement = innerExtend(true);
atom.core.typeOf    = typeOf;
atom.core.clone     = clone;

atom.extend    = atom.core.extend;
atom.implement = atom.core.implement;
atom.typeOf    = atom.core.typeOf;
atom.clone     = atom.core.clone;

};

/*
---

name: "Ajax"

description: "todo"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- CoreExtended

provides: ajax

...
*/

(function () {
	var extend = atom.core.extend, emptyFn = function () {};

	var ajax = function (userConfig) {
		var data, config, method, req, url;
		config = {};
		extend(config, ajax.defaultProps);
		extend(config, userConfig);
		config.headers = {};
		extend(config.headers, ajax.defaultHeaders);
		extend(config.headers, userConfig.headers);

		data = ajax.stringify( config.data );
		req  = new XMLHttpRequest();
		url  = config.url;
		method = config.method.toUpperCase();
		if (method == 'GET' && data) {
			url += (url.indexOf( '?' ) == -1 ? '?' : '&') + data;
		}
		if (!config.cache) {
			url += (url.indexOf( '?' ) == -1 ? '?' : '&') + '_no_cache=' + Date.now();
		}
		req.onreadystatechange = ajax.onready(req, config);
		req.open(method, url, true);
		for (var i in config.headers) {
			req.setRequestHeader(i, config.headers[i]);
		}
		req.send( method == 'POST' && data ? data : null );
	};

	ajax.stringify = function (object) {
		if (!object) return '';
		if (typeof object == 'string' || typeof object == 'number') return String( object );

		var array = [], e = encodeURIComponent;
		for (var i in object) if (object.hasOwnProperty(i)) {
			array.push( e(i) + '=' + e(object[i]) );
		}
		return array.join('&');
	};

	ajax.defaultProps = {
		interval: 0,
		type    : 'plain',
		method  : 'post',
		data    : {},
		headers : {},
		cache   : false,
		url     : location.href,
		onLoad  : emptyFn,
		onError : emptyFn
	};

	ajax.defaultHeaders = {
		'X-Requested-With': 'XMLHttpRequest',
		'Accept': 'text/javascript, text/html, application/xml, text/xml, */*'
	};
	/** @type {function} */
	ajax.onready = function (req, config) {
		return function (e) {
			if (req.readyState == 4) {
				if (req.status != 200) return config.onError(e);

				var result = req.responseText;
				if (config.type.toLowerCase() == 'json') {
					result = JSON.parse(result);
				}
				if (config.interval > 0) setTimeout(function () {
					atom.ajax(config);
				}, config.interval * 1000);
				config.onLoad(result);
			}
		};
	};

	atom.ajax = ajax;
})();


/*
---

name: "Ajax.Dom"

description: todo

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- dom
	- ajax

provides: ajax.dom

...
*/

atom.dom.prototype.ajax = function (config) {
	config = coreAppend({}, config);

	var $dom = this;

	if (config.onLoad ) {
		config.onLoad  = config.onLoad.bind($dom);
	} else {
		config.onLoad = function (r) { $dom.first.innerHTML = r };
	}
	if (config.onError) config.onError = config.onError.bind($dom);
	
	atom.ajax(config);
	return $dom;
};


/*
---

name: "Cookie"

description: "todo"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core

provides: cookie

...
*/

atom.cookie = {
	get: function (name) {
		var matches = document.cookie.match(new RegExp(
		  "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
		));
		return matches ? decodeURIComponent(matches[1]) : null;
	},
	set: function (name, value, options) {
		options = options || {};
		var exp = options.expires;
		if (exp) {
			if (typeof exp == 'number') {
				exp = new Date(exp * 1000 + Date.now());
			}
			if (exp.toUTCString) {
				exp = exp.toUTCString();
			}
			options.expires = exp;
		}

		var cookie = [name + "=" + encodeURIComponent(value)];
		for (var o in options) cookie.push(
			options[o] === true ? o : o + "=" + options[o]
		);
		document.cookie = cookie.join('; ');

		return atom.cookie;
	},
	del: function (name) {
		return atom.cookie.set(name, '', { expires: -1 });
	}
};

/*
---

name: "Frame"

description: "Provides cross-browser interface for requestAnimationFrame"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core

provides: frame

...
*/
(function () {

	var previous,
		started   = false,
		callbacks = [],
		remove    = [],
		frameTime = 16, // 62 fps
		// we'll switch to real `requestAnimationFrame` here
		// when all browsers will be ready
		requestAnimationFrame = function (callback) {
			window.setTimeout(callback, frameTime);
		};

	function startAnimation () {
		if (!started) {
			previous  = Date.now();
			requestAnimationFrame(frame);
			started = true;
		}
	}

	function invokeFrame () {
		var fn, i, l,
			now = Date.now(),
			// 1 sec is max time for frame to avoid some bugs with too large time
			delta = Math.min(now - previous, 1000);

		for (i = 0, l = remove.length; i < l; i++) {
			coreEraseOne(callbacks, remove[i]);
		}
		remove.length = 0;

		for (i = 0, l = callbacks.length; i < l; i++) {
			fn = callbacks[i];
			// one of previous calls can remove our fn
			if (remove.indexOf(fn) == -1) {
				fn.call(null, delta);
			}
		}

		previous = now;
	}

	function frame() {
		requestAnimationFrame(frame);

		if (callbacks.length == 0) {
			remove.length = 0;
			previous = Date.now();
		} else invokeFrame();
	}

	atom.frame = {
		add: function (fn) {
			startAnimation();
			includeUnique(callbacks, fn);
		},
		// we dont want to fragmentate callbacks, so remove only before frame started
		remove: function (fn) {
			if (started) includeUnique(remove, fn);
		}
	};

}());

/*
---

name: "PointerLock"

description: "Provides cross-browser interface for locking pointer"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core

provides: PointerLock

...
*/
(function (document) {
	var prefix =
	      'pointerLockElement' in document ? '':
	   'mozPointerLockElement' in document ? 'moz':
	'webkitPointerLockElement' in document ? 'webkit': null;

    function PointerLock (supports) {
        this.supports = supports;
    }

    function p (string) {
        return prefix ? prefix + string :
        string[0].toLowerCase() + string.substr(1);
    }

    function isLocked (element) {
        return document[p('PointerLockElement')] === element;
    }

	if (prefix == null) {
		PointerLock.prototype = {
			locked  : function () { return false },
			request : function () {},
			exit    : function () {}
		};
	} else {

		document.addEventListener("mousemove", function onMove (e) {
			if (lockedElement && isLocked(lockedElement)) {
				e.movementX = e[p('MovementX')] || 0;
				e.movementY = e[p('MovementY')] || 0;

				callback && callback(e);
			}
		}, false);


		var lockedElement = false, callback = null;

		PointerLock.prototype = {
			locked: function (element) {
				return isLocked(element || lockedElement);
			},
			request: function (element, fn) {
				lockedElement = element;
				callback = fn;
				element[p('RequestPointerLock')]();
			},
			exit: function () {
				lockedElement = null;
				callback = null;
				document[p('ExitPointerLock')]();
			}
		};
	}

	atom.pointerLock = new PointerLock(prefix != null);

}(document));

/*
---

name: "Uri"

description: "Port of parseUri function"

license: "MIT License"

author: "Steven Levithan <stevenlevithan.com>"

requires:
	- Core

provides: uri

...
*/
new function () {

var uri = function (str) {
	var	o   = atom.uri.options,
		m   = o.parser.exec(str || window.location.href),
		uri = {},
		i   = 14;

	while (i--) uri[o.key[i]] = m[i] || "";

	uri[o.q.name] = {};
	uri[o.key[12]].replace(o.q.parser, function ($0, $1, $2) {
		if ($1) uri[o.q.name][$1] = $2;
	});

	return uri;
};
uri.options = {
	key: ["source","protocol","authority","userInfo","user","password","host","port","relative","path","directory","file","query","anchor"],
	q:   {
		name:   "queryKey",
		parser: /(?:^|&)([^&=]*)=?([^&]*)/g
	},
	parser: /^(?:(?![^:@]+:[^:@\/]*@)([^:\/?#.]+):)?(?:\/\/)?((?:(([^:@]*)(?::([^:@]*))?)?@)?([^:\/?#]*)(?::(\d*))?)(((\/(?:[^?#](?![^?#\/]*\.[^?#\/.]+(?:[?#]|$)))*\/?)?([^?#\/]*))(?:\?([^#]*))?(?:#(.*))?)/
};

atom.uri = uri;

};

/*
---

name: "Class"

description: "Contains the Class Function for easily creating, extending, and implementing reusable Classes."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- CoreExtended
	- accessors
	- Array

inspiration:
  - "[MooTools](http://mootools.net)"

provides: Class

deprecated: "Use declare instead"

...
*/


(function(atom){

var typeOf = atom.core.typeOf,
	extend = atom.core.extend,
	accessors = atom.accessors.inherit,
	prototype = 'prototype',
	lambda    = function (value) { return function () { return value; }},
	prototyping = false;

var Class = function (params) {
	if (prototyping) return this;

	if (typeof params == 'function' && typeOf(params) == 'function') params = { initialize: params };

	var Constructor = function(){
		if (this instanceof Constructor) {
			if (prototyping) return this;
			return this.initialize ? this.initialize.apply(this, arguments) : this;
		} else {
			return Constructor.invoke.apply(Constructor, arguments);
		}
	};
	extend(Constructor, Class);
	Constructor.prototype = getInstance(Class);

	Constructor
		.implement(params, false)
		.reserved(true, {
			parent: parent,
			self  : Constructor
		})
		.reserved({
			factory : function() {
				function Factory(args) { return Constructor.apply(this, args); }
				Factory.prototype = Constructor.prototype;
				return function(args) { return new Factory(args || []); }
			}()
		});

	Constructor.prototype.constructor = Constructor;

	return Constructor;
};

var parent = function(){
	if (!this.$caller) throw new Error('The method «parent» cannot be called.');
	var name    = this.$caller.$name,
		parent   = this.$caller.$owner.parent,
		previous = parent && parent.prototype[name];
	if (!previous) throw new Error('The method «' + name + '» has no parent.');
	return previous.apply(this, arguments);
};

var wrap = function(self, key, method){
	// if method is already wrapped
	if (method.$origin) method = method.$origin;
	
	var wrapper = function() {
		if (!this || this == atom.global) throw new TypeError('Context lost');
		if (method.$protected && !this.$caller) throw new Error('The method «' + key + '» is protected.');
		var current = this.$caller;
		this.$caller = wrapper;
		var result = method.apply(this, arguments);
		this.$caller = current;
		return result;
	};
	wrapper.$owner  = self;
	wrapper.$origin = method;
	wrapper.$name   = key;
	
	return wrapper;
};

var getInstance = function(Class){
	if (atom.declare && Class instanceof atom.declare) {
		return atom.declare.config.methods.proto(Class);
	}

	prototyping = true;
	var proto = new Class;
	prototyping = false;
	return proto;
};

Class.extend =  function (name, fn) {
	if (typeof name == 'string') {
		var object = {};
		object[name] = fn;
	} else {
		object = name;
	}

	for (var i in object) if (!accessors(object, this, i)) {
		 this[i] = object[i];
	}
	return this;
};

Class.extend({
	implement: function(name, fn, retain){
		if (typeof name == 'string') {
			var params = {};
			params[name] = fn;
		} else {
			params = name;
			retain = fn;
		}

		for (var key in params) {
			if (!accessors(params, this.prototype, key)) {
				var value = params[key];

				if (Class.Mutators.hasOwnProperty(key)){
					value = Class.Mutators[key].call(this, value);
					if (value == null) continue;
				}

				if (typeof value == 'function' && typeOf(value) == 'function'){
					if (value.$origin) value = value.$origin;
					if (value.$hidden == 'next') {
						value.$hidden = true
					} else if (value.$hidden) {
						continue;
					}
					this.prototype[key] = (retain) ? value : wrap(this, key, value);
				} else {
					this.prototype[key] = atom.clone(value);
				}
			}
		}
		return this;
	},
	mixin: function () {
		Array.from(arguments).forEach(function (item) {
			this.implement(getInstance(item));
		}.bind(this));
		return this;
	},
	reserved: function (toProto, props) { // use careful !!
		if (arguments.length == 1) {
			props = toProto;
			toProto = false;
		}
		var target = toProto ? this.prototype : this;
		for (var name in props) {
			atom.accessors.define(target, name, { get: lambda(props[name]) });
		}
		return this;
	},
	isInstance: function (object) {
		return object instanceof this;
	},
	invoke: function () {
		return this.factory( arguments );
	},
	Mutators: {
		Extends: function(parent){
			if (parent == null) throw new TypeError('Cant extends from null');
			this.extend(parent).reserved({ parent: parent });
			this.prototype = getInstance(parent);
		},

		Implements: function(items){
			this.mixin.apply(this, Array.from(items));
		},

		Static: function(properties) {
			this.extend(properties);
		}
	},
	abstractMethod: function () {
		throw new Error('Abstract Method «' + this.$caller.$name + '» called');
	},
	protectedMethod: function (fn) {
		return extend(fn, { $protected: true });
	},
	hiddenMethod: function (fn) {
		return extend(fn, { $hidden: 'next' });
	}
});

Class.abstractMethod.$abstract = true;
atom.Class = Class;

})(atom);

/*
---

name: "Class.BindAll"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- Class

inspiration:
  - "[MooTools](http://mootools.net)"

provides: Class.BindAll

...
*/

atom.Class.bindAll = function (object, methods) {
	if (typeof methods == 'string') {
		if (
			methods != '$caller' &&
			!atom.accessors.has(object, methods) &&
			coreIsFunction(object[methods])
		) {
			object[methods] = object[methods].bind( object );
		}
	} else if (methods) {
		for (var i = methods.length; i--;) atom.Class.bindAll( object, methods[i] );
	} else {
		for (var i in object) atom.Class.bindAll( object, i );
	}
	return object;
};


/*
---

name: "Class.Events"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- Class

inspiration:
  - "[MooTools](http://mootools.net)"

provides: Class.Events

...
*/

new function () {

var Class = atom.Class;

var fire = function (name, fn, args) {
	var result = fn.apply(this, Array.from(args || []));
	if (typeof result == 'string' && result.toLowerCase() == 'removeevent') {
		this.removeEvent(name, fn);
	}
};

var removeOn = function(string){
	return (string || '').replace(/^on([A-Z])/, function(full, first){
		return first.toLowerCase();
	});
};

var initEvents = function (object, reset) {
	if (reset || !object._events) object._events = { $ready: {} };
};

var nextTick = function (fn) {
	nextTick.fn.push(fn);
	if (!nextTick.id) {
		nextTick.id = function () {
			nextTick.reset().invoke();
		}.delay(1);
	}
};
nextTick.reset = function () {
	var fn = nextTick.fn;
	nextTick.fn = [];
	nextTick.id = 0;
	return fn;
};
nextTick.reset();

coreAppend(Class, {
	Events: Class({
		addEvent: function(name, fn) {
			initEvents(this);

			var i, l, onfinish = [];
			if (arguments.length == 1 && typeof name != 'string') {
				for (i in name) {
					this.addEvent(i, name[i]);
				}
			} else if (Array.isArray(name)) {
				for (i = 0, l = name.length; i < l; i++) {
					this.addEvent(name[i], fn);
				}
			} else {
				name = removeOn(name);
				if (name == '$ready') {
					throw new TypeError('Event name «$ready» is reserved');
				} else if (!fn) {
					throw new TypeError('Function is empty');
				} else {
					Object.ifEmpty(this._events, name, []);

					this._events[name].include(fn);

					var ready = this._events.$ready[name];
					if (ready) fire.apply(this, [name, fn, ready, onfinish]);
					onfinish.invoke();
				}
			}
			return this;
		},
		removeEvent: function (name, fn) {
			if (!arguments.length) {
				initEvents( this, true );
				return this;
			}

			initEvents(this);

			if (Array.isArray(name)) {
				for (var i = name.length; i--;) {
					this.removeEvent(name[i], fn);
				}
			} else if (arguments.length == 1 && typeof name != 'string') {
				for (i in name) {
					this.removeEvent(i, name[i]);
				}
			} else {
				name = removeOn(name);
				if (name == '$ready') {
					throw new TypeError('Event name «$ready» is reserved');
				} else if (arguments.length == 1) {
					this._events[name] = [];
				} else if (name in this._events) {
					this._events[name].erase(fn);
				}
			}
			return this;
		},
		isEventAdded: function (name) {
			initEvents(this);
			
			var e = this._events[name];
			return !!(e && e.length);
		},
		fireEvent: function (name, args) {
			initEvents(this);
			
			name = removeOn(name);
			// we should prevent skipping next event on removing this in different fireEvents
			var funcs = atom.clone(this._events[name]);
			if (funcs) {
				var l = funcs.length,
					i = 0;
				for (;i < l; i++) fire.call(this, name, funcs[i], args || []);
			}
			return this;
		},
		readyEvent: function (name, args) {
			initEvents(this);
			
			nextTick(function () {
				name = removeOn(name);
				this._events.$ready[name] = args || [];
				this.fireEvent(name, args || []);
			}.bind(this));
			return this;
		}
	})
});

};

/*
---

name: "Class.Mutators.Generators"

description: "Provides Generators mutator"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

authors:
	- "Shock <shocksilien@gmail.com>"

requires:
	- Core
	- accessors
	- Class

provides: Class.Mutators.Generators

...
*/

new function () {

var getter = function (key, fn) {
	return function() {
		var pr = '_' + key, obj = this;
		return pr in obj ? obj[pr] : (obj[pr] = fn.call(obj));
	};
};

atom.Class.Mutators.Generators = function(properties) {
	atom.Class.Mutators.Generators.init(this, properties);
};

atom.Class.Mutators.Generators.init = function (Class, properties) {
	for (var i in properties) atom.accessors.define(Class.prototype, i, { get: getter(i, properties[i]) });
};

};

/*
---

name: "Class.Options"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- Class

inspiration:
  - "[MooTools](http://mootools.net)"

provides: Class.Options

...
*/

atom.Class.Options = atom.Class({
	options: {},
	fastSetOptions: false,
	setOptions: function(){
		if (!this.options) {
			this.options = {};
		} else if (this.options == this.self.prototype.options) {
			// it shouldn't be link to static options
			if (this.fastSetOptions) {
				this.options = coreAppend({}, this.options);
			} else {
				this.options = atom.clone(this.options);
			}
		}
		var options = this.options;

		for (var a = arguments, i = 0, l = a.length; i < l; i++) {
			if (typeof a[i] == 'object') {
				if (this.fastSetOptions) {
					coreAppend(options, a[i]);
				} else {
					atom.extend(options, a[i]);
				}
			}
		}
		
		if (this.addEvent) for (var option in options){
			if (atom.typeOf(options[option]) == 'function' && (/^on[A-Z]/).test(option)) {
				this.addEvent(option, options[option]);
				delete options[option];
			}
		}
		return this;
	}
});

/*
---

name: "Declare"

description: "Contains the Class Function for easily creating, extending, and implementing reusable Classes."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- accessors

provides: declare

...
*/

var declare = (function(atom){

var
	declare, methods,
	accessors   = atom.accessors.inherit,
	factory     = false,
	prototyping = false,
	mutators    = [];

declare = function (declareName, Parent, params) {
	if (prototyping) return this;

	params = methods.prepareParams(declareName, Parent, params);

	// line break for more user-friendly debug string
	var Constructor = function ()
	{ return methods.construct.call(this, Constructor, arguments) };

	// <debug> - should be removed on production
	if (params.name) {
		Constructor = new Function('con', 'return {"' + params.name + '": ' +
			function(){ return con.apply(this, arguments) }
		 + '}["' + params.name + '"];')(Constructor);
	}
	// </debug>

	for (var i = 0, l = mutators.length; i < l; i++) {
		mutators[i].fn( Constructor, params[mutators[i].name] );
	}

	Constructor.prototype.constructor = Constructor;

	if (params.declareName) methods.define( params.declareName, Constructor );

	return Constructor;
};

declare.prototype.bindMethods = function (methods) {
	var i;

	if (typeof methods == 'string') {
		if (typeof this[methods] == 'function') {
			this[methods] = this[methods].bind(this);
		}
		return this;
	}

	if (!methods) {
		for (i in this) this.bindMethods(i);
		return this;
	}

	for (i = methods.length; i--;) this.bindMethods( methods[i] );
	return this;
};

declare.prototype.toString = function () {
	return '[object ' + (this.constructor.NAME || 'Declare') + ']';
};

declare.NAME = 'atom.declare';

declare.invoke = function () {
	return this.factory( arguments );
};

declare.own = function (properties) {
	methods.addTo(this, properties, this.NAME + '.');
	return this;
};

declare.factory = function (args) {
	factory = true;
	return new this(args);
};

declare.castArguments = function (args) {
	if (args == null) return null;

	var constructor = this;

	return (args != null && args[0] && args[0] instanceof constructor) ?
		args[0] : args instanceof constructor ? args : new constructor( args );
};

methods = {
	define: function (path, value) {
		var key, part, target = atom.global;

		path = path.split('.');
		key  = path.pop();

		while (path.length) {
			part = path.shift();
			if (!target[part]) {
				target = target[part] = {};
			} else {
				target = target[part];
			}
		}

		target[key] = value;
	},
	mixin: function (target, items) {
		if (!Array.isArray(items)) items = [ items ];
		for (var i = 0, l = items.length; i < l; i++) {
			methods.addTo( target.prototype, methods.proto(items[i]) );
		}
		return this;
	},
	addTo: function (target, source, name) {
		var i, property;
		if (source) for (i in source) if (source.hasOwnProperty(i)) {
			if (!accessors(source, target, i) && source[i] != declare.config) {
				property = source[i];
				if (coreIsFunction(property)) {
					if (name) property.path = name + i;
					if (!property.previous && coreIsFunction(target[i])) {
						property.previous = target[i];
					}
				}
				target[i] = property;
			}
		}
		return target;
	},
	prepareParams: function (declareName, Parent, params) {
		if (typeof declareName != 'string') {
			params = Parent;
			Parent = declareName;
			declareName = null;
		}

		if (params == null && typeof Parent != 'function') {
			params = Parent;
			Parent = null;
		}

		if (!params                 ) params = {};
		if (!params.prototype       ) params = { prototype: params };
		if (!params.name            ) params.name = declareName;
		if (!params.declareName     ) params.declareName = declareName;
		if (!params.parent && Parent) params.parent = Parent;

		if (!params.prototype.initialize) {
			params.prototype.initialize = function () {
				if (!params.parent) return;
				return params.parent.prototype.initialize.apply(this, arguments);
			};
		}
		return params;
	},
	proto: function (Fn) {
		prototyping = true;
		var result = new Fn;
		prototyping = false;
		return result;
	},
	construct: function (Constructor, args) {
		if (factory) {
			args = args[0];
			factory = false;
		}

		if (prototyping) return this;

		if (this instanceof Constructor) {
			if (Constructor.NAME) this.Constructor = Constructor.NAME;
			return this.initialize.apply(this, args);
		} else {
			return Constructor.invoke.apply(Constructor, args);
		}
	}
};

declare.config = {
	methods: methods,
	mutator: atom.core.overloadSetter(function (name, fn) {
		mutators.push({ name: name, fn: fn });
		return this;
	})
};

declare.config
	.mutator( 'parent', function (Constructor, parent) {
		parent = parent || declare;
		methods.addTo( Constructor, parent );
		Constructor.prototype = methods.proto( parent );
		Constructor.Parent    = parent;
	})
	.mutator( 'mixin', function (Constructor, mixins) {
		if (mixins) methods.mixin( Constructor, mixins );
	})
	.mutator( 'name', function (Constructor, name) {
		if (!name) return;
		Constructor.NAME = name;
	})
	.mutator( 'own', function (Constructor, properties) {
		Constructor.own(properties);
	})
	.mutator( 'prototype', function (Constructor, properties) {
		methods.addTo(Constructor.prototype, properties, Constructor.NAME + '#');
	});

return atom.declare = declare;

})(atom);

/*
---

name: "Transition"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- declare
	
inspiration:
  - "[MooTools](http://mootools.net)"

provides: Transition

...
*/

atom.Transition = function (method, noEase) {
	var easeIn = function (progress) {
		return method(progress);
	};

	if (noEase) {
		return coreAppend( easeIn, {
			easeIn   : easeIn,
			easeOut  : easeIn,
			easeInOut: easeIn
		});
	}

	return coreAppend( easeIn, {
		easeIn: easeIn,
		easeOut: function(progress){
			return 1 - method(1 - progress);
		},
		easeInOut: function(progress){
			if (progress > 0.5) {
				return ( 2 - method(2 * (1 - progress)) ) /2
			} else {
				return method(2 * progress)/2;
			}
		}
	});
};

atom.Transition.set = atom.core.overloadSetter(function (id, fn) {
	atom.Transition[id] = atom.Transition(fn);
});

atom.Transition.get = function (fn) {
	if (typeof fn != 'string') return fn;
	var method = fn.split('-')[0], ease = 'easeInOut', In, Out;
	if (method != fn) {
		In  = fn.indexOf('-in' ) > 0;
		Out = fn.indexOf('-out') > 0;
		if (In ^ Out) {
			if (In ) ease = 'easeIn';
			if (Out) ease = 'easeOut';
		}
	}
	method = method[0].toUpperCase() + method.substr(1);
	if (!atom.Transition[method]) {
		throw new Error('No Transition method: ' + method);
	}
	return atom.Transition[method][ease];
};

atom.Transition.Linear = atom.Transition(function(p) { return p }, true);

atom.Transition.set({
	Expo: function(p){
		return Math.pow(2, 8 * (p - 1));
	},

	Circ: function(p){
		return 1 - Math.sin(Math.acos(p));
	},

	Sine: function(p){
		return 1 - Math.cos(p * Math.PI / 2);
	},

	Back: function(p){
		var x = 1.618;
		return Math.pow(p, 2) * ((x + 1) * p - x);
	},

	Bounce: function(p){
		var value, a = 0, b = 1;
		for (;;){
			if (p >= (7 - 4 * a) / 11){
				value = b * b - Math.pow((11 - 6 * a - 11 * p) / 4, 2);
				break;
			}
			a += b, b /= 2
		}
		return value;
	},

	Elastic: function(p){
		return Math.pow(2, 10 * --p) * Math.cos(12 * p);
	}

});

['Quad', 'Cubic', 'Quart', 'Quint'].forEach(function(transition, i){
	atom.Transition.set(transition, function(p){
		return Math.pow(p, i + 2);
	});
});

/*
---

name: "Events"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- declare

inspiration:
  - "[MooTools](http://mootools.net)"

provides: Events

...
*/

/** @class atom.Events */
declare( 'atom.Events', {

	/** @constructs */
	initialize: function (context) {
		this.context   = context || this;
		this.locked    = [];
		this.events    = {};
		this.actions   = {};
		this.readyList = {};
	},

	/**
	 * @param {String} name
	 * @return Boolean
	 */
	exists: function (name) {
		var array = this.events[this.removeOn( name )];
		return !!(array && array.length);
	},

	/**
	 * @param {String} name
	 * @param {Function} callback
	 * @return Boolean
	 */
	add: function (name, callback) {
		this.run( 'addOne', name, callback );
		return this;
	},

	/**
	 * @param {String} name
	 * @param {Function} [callback]
	 * @return Boolean
	 */
	remove: function (name, callback) {
		if (typeof name == 'string' && !callback) {
			this.removeAll( name );
		} else {
			this.run( 'removeOne', name, callback );
		}
		return this;
	},

	/**
	 * @param {String} name
	 * @param {Array} args
	 * @return atom.Events
	 */
	fire: function (name, args) {
		args = args ? slice.call( args ) : [];
		name = this.removeOn( name );

		this.locked.push(name);
		var i = 0, l, events = this.events[name];
		if (events) for (l = events.length; i < l; i++) {
			events[i].apply( this.context, args );
		}
		this.unlock( name );
		return this;
	},

	/**
	 * @param {String} name
	 * @param {Array} [args=null]
	 * @return atom.Events
	 */
	ready: function (name, args) {
		name = this.removeOn( name );
		this.locked.push(name);
		if (name in this.readyList) {
			throw new Error( 'Event «'+name+'» is ready' );
		}
		this.readyList[name] = args;
		this.fire(name, args);
		this.removeAll(name);
		this.unlock( name );
		return this;
	},

	/**
	 * @param {String} name
	 * @param {Array} [args=null]
	 * @return atom.Events
	 */
	ensureReady: function (name, args) {
		if (!(name in this.readyList)) {
			this.ready(name, args);
		}
		return this;
	},


	// only private are below

	/** @private */
	context: null,
	/** @private */
	events: {},
	/** @private */
	readyList: {},
	/** @private */
	locked: [],
	/** @private */
	actions: {},

	/** @private */
	removeOn: function (name) {
		return (name || '').replace(/^on([A-Z])/, function(full, first){
			return first.toLowerCase();
		});
	},
	/** @private */
	removeAll: function (name) {
		var events = this.events[name];
		if (events) for (var i = events.length; i--;) {
			this.removeOne( name, events[i] );
		}
	},
	/** @private */
	unlock: function (name) {
		var action,
			all    = this.actions[name],
			index  = this.locked.indexOf( name );

		this.locked.splice(index, 1);

		if (all) for (index = 0; index < all.length; index++) {
			action = all[index];

			this[action.method]( name, action.callback );
		}
	},
	/** @private */
	run: function (method, name, callback) {
		var i = 0, l = 0;

		if (Array.isArray(name)) {
			for (i = 0, l = name.length; i < l; i++) {
				this[method](name[i], callback);
			}
		} else if (typeof name == 'object') {
			for (i in name) {
				this[method](i, name[i]);
			}
		} else if (typeof name == 'string') {
			this[method](name, callback);
		} else {
			throw new TypeError( 'Wrong arguments in Events.' + method );
		}
	},
	/** @private */
	register: function (name, method, callback) {
		var actions = this.actions;
		if (!actions[name]) {
			actions[name] = [];
		}
		actions[name].push({ method: method, callback: callback })
	},
	/** @private */
	addOne: function (name, callback) {
		var events, ready, context;

		name = this.removeOn( name );

		if (this.locked.indexOf(name) == -1) {
			ready = this.readyList[name];
			if (ready) {
				context = this.context;
				setTimeout(function () {
					callback.apply(context, ready);
				}, 0);
				return this;
			} else {
				events = this.events;
				if (!events[name]) {
					events[name] = [callback];
				} else {
					events[name].push(callback);
				}
			}
		} else {
			this.register(name, 'addOne', callback);
		}
	},
	/** @private */
	removeOne: function (name, callback) {
		name = this.removeOn( name );

		if (this.locked.indexOf(name) == -1) {
			var events = this.events[name], i = events.length;
			while (i--) if (events[i] == callback) {
				events.splice(i, 1);
			}
		} else {
			this.register(name, 'removeOne', callback);
		}
	}
});

// local alias
var Events = atom.Events;

/*
---

name: "Settings"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- declare

provides: Settings

...
*/

/** @class atom.Settings */
declare( 'atom.Settings', {
	/** @private */
	recursive: false,

	/** @private */
	values: {},

	/**
	 * @constructs
	 * @param {Object} [initialValues]
	 */
	initialize: function (initialValues) {
		this.values    = {};

		if (initialValues) this.set(initialValues);
	},

	/**
	 * @param {atom.Events} events
	 * @return atom.Options
	 */
	addEvents: function (events) {
		this.events = events;
		return this.invokeEvents();
	},

	/**
	 * @param {string|Array} name
	 */
	get: function (name, defaultValue) {
		if (Array.isArray(name)) return this.subset(name, defaultValue);

		return name in this.values ? this.values[name] : defaultValue;
	},

	/**
	 * @param {object} target
	 * @param {string[]} [names=undefined]
	 * @return {atom.Settings}
	 */
	properties: function (target, names) {
		var originalNames = this.propertiesNames;

		if (typeof names == 'string') {
			names = names.split(' ');
		}

		if (names == null || names === true) {
			this.propertiesNames = true;
		} else if (originalNames == null) {
			this.propertiesNames = names;
		} else if (originalNames !== true) {
			atom.array.append(originalNames, names);
		}

		this.propertiesTarget = target;

		for (var i in this.values) {
			this.exportProperty(i, this.values);
		}

		return this;
	},

	subset: function (names, defaultValue) {
		var i, values = {};

		for (i = names.length; i--;) {
			values[names[i]] = this.get( names[i], defaultValue );
		}

		return values;
	},

	/** @private */
	propertiesNames : null,
	/** @private */
	propertiesTarget: null,

	/**
	 * @param {Object} options
	 * @return atom.Options
	 */
	set: function (options, value) {
		var i, values = this.values;

		options = this.prepareOptions(options, value);

		for (i in options) {
			value = options[i];
			if (values[i] != value) {
				values[i] = value;
				this.exportProperty(i, values);
			}
		}

		this.invokeEvents();

		return this;
	},

	/** @private */
	exportProperty: function (i, values) {
		var
			target = this.propertiesTarget,
			names  = this.propertiesNames;

		if (target && (names === true || names.indexOf(i) >= 0)) {
			target[i] = values[i];
		}
	},

	/** @private */
	prepareOptions: function (options, value) {
		if (typeof options == 'string') {
			var i = options;
			options = {};
			options[i] = value;
		} else if (options instanceof this.constructor) {
			options = options.values;
		}
		return options;
	},

	/**
	 * @param {String} name
	 * @return atom.Options
	 */
	unset: function (name) {
		delete this.values[name];
		return this;
	},

	/** @private */
	invokeEvents: function () {
		if (!this.events) return this;

		var values = this.values, name, option;
		for (name in values) if (values.hasOwnProperty(name)) {
			option = values[name];
			if (this.isInvokable(name, option)) {
				this.events.add(name, option);
				this.unset(name);
			}
		}
		return this;
	},

	/** @private */
	isInvokable: function (name, option) {
		return name &&
			option &&
			coreIsFunction(option) &&
			(/^on[A-Z]/).test(name);
	}
});

var Settings = atom.Settings;

/*
---

name: "Types.Object"

description: "Object generic methods"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core

provides: Types.Object

...
*/

atom.object = {
	append: function (target, source1, source2) {
		for (var i = 1, l = arguments.length; i < l; i++) {
			atom.core.append(target, arguments[i]);
		}
		return target;
	},
	invert: function (object) {
		var newObj = {};
		for (var i in object) newObj[object[i]] = i;
		return newObj;
	},
	collect: function (obj, props, Default) {
		var newObj = {};
		props.forEach(function (i){
			newObj[i] = i in obj ? obj[i] : Default;
		});
		return newObj;
	},
	values: function (obj) {
		var values = [];
		for (var i in obj) values.push(obj[i]);
		return values;
	},
	/** @deprecated */
	isDefined: function (obj) {
		return typeof obj !== 'undefined';
	},
	/** @deprecated */
	isReal: function (obj) {
		return obj != null;
	},
	map: function (obj, fn) {
		var mapped = {};
		for (var i in obj) if (obj.hasOwnProperty(i)) {
			mapped[i] = fn( obj[i], i, obj );
		}
		return mapped;
	},
	max: function (obj) {
		var max = null, key = null;
		for (var i in obj) if (max == null || obj[i] > max) {
			key = i;
			max = obj[i];
		}
		return key;
	},
	min: function (obj) {
		var min = null, key = null;
		for (var i in obj) if (min == null || obj[i] < min) {
			key = i;
			min = obj[i];
		}
		return key;
	},
	deepEquals: function (first, second) {
		if (!first || (typeof first) !== (typeof second)) return false;

		for (var i in first) {
			var f = first[i], s = second[i];
			if (typeof f === 'object') {
				if (!s || !Object.deepEquals(f, s)) return false;
			} else if (f !== s) {
				return false;
			}
		}

		for (i in second) if (!(i in first)) return false;

		return true;
	},
	isEmpty: function (object) {
		for (var i in object) if (object.hasOwnProperty(i)) {
			return false;
		}
		return true;
	},
	ifEmpty: function (object, key, defaultValue) {
		if (!(key in object)) {
			object[key] = defaultValue;
		}
		return object;
	},
	path: {
		parts: function (path, delimiter) {
			return Array.isArray(path) ? path : String(path).split( delimiter || '.' );
		},
		get: function (object, path, delimiter) {
			if (!path) return object;

			path = atom.object.path.parts( path, delimiter );

			for (var i = 0; i < path.length; i++) {
				if (object != null && path[i] in object) {
					object = object[path[i]];
				} else {
					return;
				}
			}

			return object;
		},
		set: function (object, path, value, delimiter) {
			path = atom.object.path.parts( path, delimiter );

			var key = path.pop();

			while (path.length) {
				var current = path.shift();
				if (object[current]) {
					object = object[current];
				} else {
					object = object[current] = {};
				}
			}

			object[key] = value;
		}
	}
};

/*
---

name: "Animatable"

description: "Provides Color class"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- declare
	- frame
	- Transition
	- Events
	- Settings
	- Types.Object

provides: Animatable

...
*/

/** @class atom.Animatable */
declare( 'atom.Animatable', {
	
	element: null,

	initialize: function (callbacks, context) {
		this.bindMethods('animate');
		this.context = context || null;

		if (!callbacks) throw new TypeError( 'callbacks cant be null' );

		this.animations = [];
		if (this.isValidCallbacks(callbacks)) {
			this.callbacks = callbacks;
		} else {
			this.callbacks = this.getDefaultCallbacks(callbacks);
		}
	},

	get current () {
		return this.animations[0];
	},

	/**
	 * Binded to `Animatable`
	 * @returns {atom.Animatable.Animation}
	 */
	animate: atom.core.ensureObjectSetter(function (properties) {
		return this.next(new atom.Animatable.Animation(this, properties));
	}),

	stop: function (all) {
		var current = this.current;
		if (current) {
			if (all) this.animations.length = 0;
			current.destroy('stop');
		}
		return this;
	},

	/** @private */
	getDefaultCallbacks: function (element) {
		return {
			get: function (property) {
				return atom.object.path.get(element, property);
			},
			set: atom.core.overloadSetter(function (property, value) {
				return atom.object.path.set(element, property, value);
			})
		};
	},
	/** @private */
	isValidCallbacks: function (callbacks) {
		return typeof callbacks == 'object' &&
			Object.keys(callbacks).length == 2 &&
			coreIsFunction(callbacks.set) &&
			coreIsFunction(callbacks.get);
	},

	/** @private */
	animations: null,

	/** @private */
	next: function (animation) {
		var queue = this.animations;
		if (animation) {
			queue.push(animation);
			if (queue.length == 1) {
				this.launch(animation);
			}
		} else if (queue.length) {
			this.launch(this.current);
		}
		return animation;
	},
	/** @private */
	launch: function (animation) {
		var queue = this.animations, animatable = this;
		animation.events.add('destroy', function remove () {
			queue.splice(queue.indexOf(animation), 1);
			animation.events.remove('destroy', remove);
			animatable.next();
		});
		animation.start();
	},
	/** @private */
	get: function (name) {
		return this.callbacks.get.apply(this.context, arguments);
	},
	/** @private */
	set: function (name, value) {
		return this.callbacks.set.apply(this.context, arguments);
	}
});

/** @class atom.Animatable.Animation */
declare( 'atom.Animatable.Animation', {
	/** @property {atom.Animatable} */
	animatable: null,

	/**
	 * initial values of properties
	 * @property {Object}
	 */
	initial: null,

	/**
	 * target values of properties
	 * @property {Object}
	 */
	target: null,

	initialize: function (animatable, settings) {
		this.bindMethods([ 'tick', 'start' ]);

		if (!settings.props) settings = {props: settings};
		this.events   = new atom.Events(animatable);
		this.settings = new atom.Settings({
				fn  : 'linear',
				time: 500
			})
			.set(settings)
			.addEvents(this.events);
		this.animatable = animatable;
		this.transition = atom.Transition.get(this.settings.get('fn'));
		this.allTime = this.settings.get('time');
		this.target  = this.settings.get('props');
	},

	start: function () {
		this.initial  = this.fetchInitialValues();
		this.delta    = this.countValuesDelta();
		this.timeLeft = this.allTime;
		this.events.fire( 'start', [ this ]);
		atom.frame.add(this.tick);
		return this;
	},

	/** @private */
	countValuesDelta: function () {
		var initial = this.initial;
		return atom.object.map(this.target, function (value, key) {
			var start = initial[key];
			if (atom.Color && start instanceof atom.Color) {
				return start.diff( new atom.Color(value) );
			} else {
				return value - start;
			}
		});
	},

	/** @private */
	fetchInitialValues: function () {
		var animatable = this.animatable;
		return atom.object.map(this.target, function (value, key) {
			var v = animatable.get(key);
			if (atom.Color && atom.Color.isColorString(value) || value instanceof atom.Color) {
				if (!v) {
					v = new atom.Color(value);
					v.alpha = 0;
					return v;
				}
				return new atom.Color(v);
			} else if (isNaN(v)) {
				throw new Error('value is not animatable: ' + v);
			} else {
				return v;
			}
		});
	},

	/** @private */
	changeValues: function (progress) {
		var delta = this.delta, animatable = this.animatable, initial, target;
		for (var i in delta) if (delta.hasOwnProperty(i)) {
			if (progress == null) {
				target = this.target[i];
				animatable.set( i,
					atom.Color && target instanceof atom.Color
						? target.toString() : target
				);
			} else {
				initial = this.initial[i];
				animatable.set( i,
					atom.Color && initial instanceof atom.Color ?
						initial.clone().move(delta[i].clone().mul(progress)).toString() :
						initial + delta[i] * progress
				);
			}
		}
	},

	/** @private */
	tick: function (time) {
		var lastTick = time >= this.timeLeft;
		this.timeLeft = lastTick ? 0 : this.timeLeft - time;

		this.changeValues(this.transition(
			lastTick ? 1 : (this.allTime - this.timeLeft) / this.allTime
		));
		this.events.fire( 'tick', [ this ]);

		if (lastTick) this.destroy('complete');
	},

	destroy: function (type) {
		if (!type) type = 'error';
		this.events.fire( type, [ this ]);
		this.events.fire( 'destroy', [ this ]);
		atom.frame.remove(this.tick);
		return this;
	}
});

if (atom.dom) (function (animatable) {
	var accessors = {
		get: function (name) {
			var value = this.css(name);
			return atom.Color && atom.Color.isColorString(value) ? value : parseFloat(value);
		},
		set: function (name, value) {
			this.css(name, value);
		}
	};

	atom.dom.prototype.animate = atom.core.ensureObjectSetter(function (params) {
		this.each(function (elem) {
			if (!elem[animatable]) {
				elem[animatable] = new atom.Animatable(accessors, atom.dom(elem));
			}
			elem[animatable].animate(params);
		});
		return this
	});

	atom.dom.prototype.stopAnimation = function (force) {
		this.each(function (elem) {
			if (elem[animatable]) {
				elem[animatable].stop(force);
			}
		});
		return this;
	};
})('atom.animatable');

/*
---

name: "ClassCompat"

description: "Contains the Class Function for easily creating, extending, and implementing reusable Classes."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- CoreExtended
	- declare

provides: ClassCompat
...
*/

declare( 'atom.Settings.Mixin',
/** @deprecated */
{
	/**
	 * @private
	 * @property atom.Settings
	 */
	settings: null,
	options : {},

	setOptions: function (options) {
		if (!this.settings) {
			this.settings = new atom.Settings(
				atom.clone(this.options || {})
			);
			this.options = this.settings.values;
		}

		for (var i = 0; i < arguments.length; i++) {
			this.settings.set(arguments[i]);
		}

		return this;
	}
});

declare( 'atom.Events.Mixin', new function () {
	var init = function () {
		var events = this.__events;
		if (!events) events = this.__events = new atom.Events(this);
		if (this._events) {
			for (var name in this._events) if (name != '$ready') {
				this._events[name].forEach(function (fn) {
					events.add(name, fn);
				});
			}
		}
		return events;
	};

	var method = function (method, useReturn) {
		return function () {
			var result, events = init.call(this);

			result = events[method].apply( events, arguments );
			return useReturn ? result : this;
		}
	};

	return {
		get events ( ) { return init.call(this); },
		set events (e) { this.__events = e;       },
		isEventAdded: method( 'exists', true ),
		addEvent    : method( 'add'   , false ),
		removeEvent : method( 'remove', false ),
		fireEvent   : method( 'fire'  , false ),
		readyEvent  : method( 'ready' , false )
	};
});

/*
---

name: "Color"

description: "Provides Color class"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- declare

provides: Color

...
*/
/** @class atom.Color */
declare( 'atom.Color', {
	initialize: function (value) {
		var a = arguments, type;
		if (a.length == 4 || a.length == 3) {
			value = slice.call(a);
		} else if (value && value.length == 1) {
			value = value[0];
		}

		type = typeof value;
		if (Array.isArray(value)) {
			this.fromArray(value);
		} else if (type == 'number') {
			this.fromNumber(value);
		} else if (type == 'string') {
			this.fromString(value);
		} else if (type == 'object') {
			this.fromObject(value);
		} else {
			throw new TypeError('Unknown type in atom.Color: ' + typeof value + ';\n' + value);
		}
	},

	/** @private */
	r: 0,
	/** @private */
	g: 0,
	/** @private */
	b: 0,
	/** @private */
	a: 1,

	/**
	 * We are array-like object (looks at accessors at bottom of class)
	 * @constant
	 */
	length: 4,

	noLimits: false,

	get red   () { return this.r; },
	get green () { return this.g; },
	get blue  () { return this.b; },
	get alpha () { return this.a; },

	set red   (v) { this.setValue('r', v) },
	set green (v) { this.setValue('g', v) },
	set blue  (v) { this.setValue('b', v) },
	set alpha (v) { this.setValue('a', v, true) },

	/** @private */
	safeAlphaSet: function (v) {
		if (v != null) {
			this.alpha = Math.round(v*1000)/1000;
		}
	},

	/** @private */
	setValue: function (prop, value, isFloat) {
		value = Number(value);
		if (value != value) { // isNaN
			throw new TypeError('Value is NaN (' + prop + '): ' + value);
		}

		if (!isFloat) value = Math.round(value);
		// We don't want application down, if user script (e.g. animation)
		// generates such wrong array: [150, 125, -1]
		// `noLimits` switch off this check
		this[prop] = this.noLimits ? value :
			atom.number.limit( value, 0, isFloat ? 1 : 255 );
	},

	// Parsing

	/**
	 * @param {int[]} array
	 * @returns {atom.Color}
	 */
	fromArray: function (array) {
		if (!array || array.length < 3 || array.length > 4) {
			throw new TypeError('Wrong array in atom.Color: ' + array);
		}
		this.red   = array[0];
		this.green = array[1];
		this.blue  = array[2];
		this.safeAlphaSet(array[3]);
		return this;
	},
	/**
	 * @param {Object} object
	 * @param {number} object.red
	 * @param {number} object.green
	 * @param {number} object.blue
	 * @returns {atom.Color}
	 */
	fromObject: function (object) {
		if (typeof object != 'object') {
			throw new TypeError( 'Not object in "fromObject": ' + typeof object );
		}

		function fetch (p1, p2) {
			return object[p1] != null ? object[p1] : object[p2]
		}

		this.red   = fetch('r', 'red'  );
		this.green = fetch('g', 'green');
		this.blue  = fetch('b', 'blue' );
		this.safeAlphaSet(fetch('a', 'alpha'));
		return this;
	},
	/**
	 * @param {string} string
	 * @returns {atom.Color}
	 */
	fromString: function (string) {
		if (!this.constructor.isColorString(string)) {
			throw new TypeError( 'Not color string in "fromString": ' + string );
		}

		var hex, array;

		string = string.toLowerCase();
		string = this.constructor.colorNames[string] || string;

		if (hex = string.match(/^#(\w{1,2})(\w{1,2})(\w{1,2})(\w{1,2})?$/)) {
			array = atom.array.clean(hex.slice(1));
			array = array.map(function (part) {
				if (part.length == 1) part += part;
				return parseInt(part, 16);
			});
			if (array.length == 4) array[3] /= 255;
		} else {
			array = string.match(/([\.\d]{1,})/g).map( Number );
		}
		return this.fromArray(array);
	},
	/**
	 * @param {number} number
	 * @returns {atom.Color}
	 */
	fromNumber: function (number) {
		if (typeof number != 'number' || number < 0 || number > 0xffffffff) {
			throw new TypeError( 'Not color number in "fromNumber": ' + (number.toString(16)) );
		}

		return this.fromArray([
			(number>>24) & 0xff,
			(number>>16) & 0xff,
			(number>> 8) & 0xff,
			(number      & 0xff) / 255
		]);
	},

	// Casting

	/** @returns {int[]} */
	toArray: function () {
		return [this.r, this.g, this.b, this.a];
	},
	/** @returns {string} */
	toString: function (type) {
		var arr = this.toArray();
		if (type == 'hex' || type == 'hexA') {
			return '#' + arr.map(function (color, i) {
				if (i == 3) { // alpha
					if (type == 'hex') return '';
					color = Math.round(color * 255);
				}
				var bit = color.toString(16);
				return bit.length == 1 ? '0' + bit : bit;
			}).join('');
		} else {
			return 'rgba(' + arr + ')';
		}
	},
	/** @returns {number} */
	toNumber: function () {
		// maybe needs optimizations
		return parseInt( this.toString('hexA').substr(1) , 16)
	},
	/** @returns {object} */
	toObject: function (abbreviationNames) {
		return abbreviationNames ?
			{ r  : this.r, g    : this.g, b   : this.b, a    : this.a } :
			{ red: this.r, green: this.g, blue: this.b, alpha: this.a };
	},

	// manipulations

	/**
	 * @param {atom.Color} color
	 * @returns {atom.Color}
	 */
	diff: function (color) {
		// we can't use this.constructor, because context exists in such way
		// && invoke is not called
		color = atom.Color( color );
		return new atom.Color.Shift([
			color.red   - this.red  ,
			color.green - this.green,
			color.blue  - this.blue ,
			color.alpha - this.alpha
		]);
	},
	/**
	 * @param {atom.Color} color
	 * @returns {atom.Color}
	 */
	move: function (color) {
		color = atom.Color.Shift(color);
		this.red   += color.red  ;
		this.green += color.green;
		this.blue  += color.blue ;
		this.alpha += color.alpha;
		return this;
	},
	/** @deprecated - use `clone`+`move` instead */
	shift: function (color) {
		return this.clone().move(color);
	},
	map: function (fn) {
		var color = this;
		['red', 'green', 'blue', 'alpha'].forEach(function (component) {
			color[component] = fn.call( color, color[component], component, color );
		});
		return color;
	},
	add: function (factor) {
		return this.map(function (value) {
			return value + factor;
		});
	},
	mul: function (factor) {
		return this.map(function (value) {
			return value * factor;
		});
	},
	/**
	 * @param {atom.Color} color
	 * @returns {boolean}
	 */
	equals: function (color) {
		return color &&
			color instanceof this.constructor &&
			color.red   == this.red   &&
			color.green == this.green &&
			color.blue  == this.blue  &&
			color.alpha == this.alpha;
	},

	/** @private */
	dump: function () {
		return '[atom.Color(' + this.toString('hexA') + ')]';
	},

	/**
	 * @returns {atom.Color}
	 */
	clone: function () {
		return new this.constructor(this);
	}
}).own({
	invoke: declare.castArguments,

	/**
	 * Checks if string is color description
	 * @param {string} string
	 * @returns {boolean}
	 */
	isColorString : function (string) {
		if (typeof string != 'string') return false;
		return Boolean(
			string in this.colorNames  ||
			string.match(/^#\w{3,6}$/) ||
			string.match(/^rgba?\([\d\., ]+\)$/)
		);
	},

	colorNames: {
		white:  '#ffffff',
		silver: '#c0c0c0',
		gray:   '#808080',
		black:  '#000000',
		red:    '#ff0000',
		maroon: '#800000',
		yellow: '#ffff00',
		olive:  '#808000',
		lime:   '#00ff00',
		green:  '#008000',
		aqua:   '#00ffff',
		teal:   '#008080',
		blue:   '#0000ff',
		navy:   '#000080',
		fuchsia:'#ff00ff',
		purple: '#800080',
		orange: '#ffa500'
	},

	/**
	 * @param {boolean} [html=false] - only html color names
	 * @returns {atom.Color}
	 */
	random: function (html) {
		var source, random = atom.number.random;

		if (html) {
			source = atom.array.random( this.colorNamesList );
		} else {
			source = [ random(0, 255), random(0, 255), random(0, 255) ];
		}

		return new this(source);
	}
});

atom.Color.colorNamesList = Object.keys(atom.Color.colorNames);

/** @class atom.Color.Shift */
declare( 'atom.Color.Shift', atom.Color, { noLimits: true });

/*
---

name: "ImagePreloader"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- declare
	- Events
	- Settings

provides: ImagePreloader

...
*/

atom.declare( 'atom.ImagePreloader', {
	processed : 0,
	number    : 0,

	initialize: function (settings) {
		this.events   = new Events(this);
		this.settings = new Settings(settings).addEvents(this.events);

		this.count = {
			error: 0,
			abort: 0,
			load : 0
		};

		this.suffix    = this.settings.get('suffix') || '';
		this.usrImages = this.prefixImages(this.settings.get('images'));
		this.imageUrls = this.fetchUrls();
		this.domImages = {};
		//this.domImages = this.createDomImages();
		this.images    = {};
		this.createNext();
	},
	get isReady () {
		return this.number == this.processed;
	},
	get info () {
		var stat = atom.string.substitute(
			"Images loaded: {load}; Errors: {error}; Aborts: {abort}",
			this.count
		);
		if (this.isReady) stat = "Image preloading has completed;\n" + stat;
		return stat;
	},
	get progress () {
		return this.isReady ? 1 : atom.number.round(this.processed / this.number, 4);
	},
	append: function (preloader) {
		for (var i in preloader.images) {
			this.images[i] = preloader.images[i];
		}
		return this;
	},
	exists: function (name) {
		return !!this.images[name];
	},
	get: function (name) {
		var image = this.images[name];
		if (image) {
			return image;
		} else {
			throw new Error('No image «' + name + '»');
		}
	},

	/** @private */
	cropImage: function (img, c) {
		if (!c) return img;

		var canvas = document.createElement('canvas');
		canvas.width  = c[2];
		canvas.height = c[3];
		canvas.getContext('2d').drawImage( img,
			c[0], c[1], c[2], c[3], 0, 0, c[2], c[3]
		);
		return canvas;
	},
	/** @private */
	withoutPrefix: function (src) {
		return src.indexOf('http://') === 0 || src.indexOf('https://') === 0;
	},
	/** @private */
	prefixImages: function (images) {
		var prefix = this.settings.get('prefix');
		if (!prefix) return images;

		return atom.object.map(images, function (src) {
			return this.withoutPrefix(src) ? src : prefix + src;
		}.bind(this));
	},
	/** @private */
	cutImages: function () {
		var i, parts, img;
		for (i in this.usrImages) if (this.usrImages.hasOwnProperty(i)) {
			parts = this.splitUrl( this.usrImages[i] );
			img   = this.domImages[ parts.url ];
			this.images[i] = this.cropImage(img, parts.coords);
		}
		return this;
	},
	/** @private */
	splitUrl: function (str) {
		var url = str, size, cell, match, coords = null;

				// searching for pattern 'url [x:y:w:y]'
		if (match = str.match(/ \[(\d+):(\d+):(\d+):(\d+)\]$/)) {
			coords = match.slice( 1 );
				// searching for pattern 'url [w:y]{x:y}'
		} else if (match = str.match(/ \[(\d+):(\d+)\]\{(\d+):(\d+)\}$/)) {
			coords = match.slice( 1 ).map( Number );
			size = coords.slice( 0, 2 );
			cell = coords.slice( 2, 4 );
			coords = [ cell[0] * size[0], cell[1] * size[1], size[0], size[1] ];
		}
		if (match) {
			url = str.substr(0, str.lastIndexOf(match[0]));
			coords = coords.map( Number );
		}
		if (this.suffix) {
			if (typeof this.suffix == 'function') {
				url = this.suffix( url );
			} else {
				url += this.suffix;
			}
		}

		return { url: url, coords: coords };
	},
	/** @private */
	fetchUrls: function () {
		var i, result = [], hash = {}, url, images = this.usrImages;
		for (i in images) if (images.hasOwnProperty(i)) {
			url = this.splitUrl( images[i] ).url;
			if (!hash[url]) {
				result.push(url);
				hash[url] = true;
				this.number++;
			}
		}
		return result;
	},
	/** @private */
	createDomImage : function (src) {
		var img = new Image();
		img.src = src;
		if (window.opera && img.complete) {
			setTimeout(this.onProcessed.bind(this, 'load', img), 10);
		} else {
			['load', 'error', 'abort'].forEach(function (event) {
				img.addEventListener( event, this.onProcessed.bind(this, event, img), false );
			}.bind(this));
		}
		return img;
	},
	createNext: function () {
		if (this.imageUrls.length) {
			var url = this.imageUrls.shift();
			this.domImages[url] = this.createDomImage(url);
		}
	},
	resetImage: function (img) {
		// opera fullscreen bug workaround
		img.width  = img.width;
		img.height = img.height;
		img.naturalWidth  = img.naturalWidth;
		img.naturalHeight = img.naturalHeight;
	},
	/** @private */
	onProcessed : function (type, img) {
		if (type == 'load' && window.opera) {
			this.resetImage(img);
		}
		this.count[type]++;
		this.processed++;
		this.events.fire('progress', [this, img]);

		if (this.isReady) {
			this.cutImages();
			this.events.ensureReady('ready', [this]);
		} else {
			this.createNext();
		}
		return this;
	}
}).own({
	run: function (images, callback, context) {
		var preloader = new this({ images: images });

		preloader.events.add( 'ready', context ? callback.bind(context) : callback );

		return preloader;
	}
});

/*
---

name: "Keyboard"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- declare
	- Events

provides: Keyboard

...
*/

var Keyboard = function () {

var
	keyName,
	codeNames = {},
	keyCodes  = {
		// Alphabet
		a:65, b:66, c:67, d:68, e:69,
		f:70, g:71, h:72, i:73, j:74,
		k:75, l:76, m:77, n:78, o:79,
		p:80, q:81, r:82, s:83, t:84,
		u:85, v:86, w:87, x:88, y:89, z:90,
		// Numbers
		n0:48, n1:49, n2:50, n3:51, n4:52,
		n5:53, n6:54, n7:55, n8:56, n9:57,
		// Controls
		tab:  9, enter:13, shift:16, backspace:8,
		ctrl:17, alt  :18, esc  :27, space    :32,
		menu:93, pause:19, cmd  :91,
		insert  :45, home:36, pageup  :33,
		'delete':46, end :35, pagedown:34,
		// F*
		f1:112, f2:113, f3:114, f4 :115, f5 :116, f6 :117,
		f7:118, f8:119, f9:120, f10:121, f11:122, f12:123,
		// numpad
		np0: 96, np1: 97, np2: 98, np3: 99, np4:100,
		np5:101, np6:102, np7:103, np8:104, np9:105,
		npslash:11,npstar:106,nphyphen:109,npplus:107,npdot:110,
		// Lock
		capslock:20, numlock:144, scrolllock:145,

		// Symbols
		equals: 61, hyphen   :109, coma  :188, dot:190,
		gravis:192, backslash:220, sbopen:219, sbclose:221,
		slash :191, semicolon: 59, apostrophe: 222,

		// Arrows
		aleft:37, aup:38, aright:39, adown:40
	};

for (keyName in keyCodes) if (keyCodes.hasOwnProperty(keyName)) {
	codeNames[ keyCodes[keyName] ] = keyName;
}

/** @class atom.Keyboard */
return declare( 'atom.Keyboard', {
	initialize : function (element, preventDefault) {
		if (Array.isArray(element)) {
			preventDefault = element;
			element = null;
		}
		if (element == null) element = document;

		if (element == document) {
			if (this.constructor.instance) {
				return this.constructor.instance;
			}
			this.constructor.instance = this;
		}

		this.events = new Events(this);
		this.keyStates = {};
		this.preventDefault = preventDefault;

		atom.dom(element).bind({
			keyup:    this.keyEvent('up'),
			keydown:  this.keyEvent('down'),
			keypress: this.keyEvent('press')
		});
	},
	/** @private */
	keyEvent: function (event) {
		return this.onKeyEvent.bind(this, event);
	},
	/** @private */
	onKeyEvent: function (event, e) {
		var key = this.constructor.keyName(e),
			prevent = this.prevent(key);

		e.keyName = key;

		if (prevent) e.preventDefault();
		this.events.fire( event, [e] );

		if (event == 'down') {
			this.events.fire(key, [e]);
			this.keyStates[key] = true;
		} else if (event == 'up') {
			this.events.fire(key + ':up', [e]);
			delete this.keyStates[key];
		} else if (event == 'press') {
			this.events.fire(key + ':press', [e]);
		}

		return !prevent;
	},
	/** @private */
	prevent : function (key) {
		var pD = this.preventDefault;
		return pD && (pD === true || pD.indexOf(key) >= 0);
	},
	key: function (keyName) {
		return !!this.keyStates[ this.constructor.keyName(keyName) ];
	}
}).own({
	keyCodes : keyCodes,
	codeNames: codeNames,
	keyName: function (code) {
		if (code && code.keyCode != null) {
			code = code.keyCode;
		}

		var type = typeof code;

		if (type == 'number') {
			return this.codeNames[code];
		} else if (type == 'string' && code in this.keyCodes) {
			return code;
		}

		return null;
	}
});

}();


/*
---

name: "Registry"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- declare

provides: Registry

...
*/

/** @class atom.Registry */
declare( 'atom.Registry', {
	items: {},
	initialize: function (initial) {
		this.items = {};
		if (initial) this.set(initial);
	},
	set: atom.core.overloadSetter(function (name, value) {
		this.items[name] = value;
	}),
	get: atom.core.overloadGetter(function (name) {
		return this.items[name];
	})
});

var Registry = atom.Registry;

/*
---

name: "trace"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- declare
	- dom
	- CoreExtended

provides: trace

...
*/

atom.trace = declare( 'atom.trace', {
	initialize : function (object) {
		this.value = object;
		this.stopped = false;
	},
	set value (value) {
		if (!this.stopped) {
			var html = atom.string.replaceAll( this.constructor.dump(value), {
				'\t': '&nbsp;'.repeat(3),
				'\n': '<br />'
			});
			this.createNode().html(html);
		}
	},
	destroy : function (force) {
		var trace = this;
		if (force) this.stop();
		if (trace.node) {
			trace.node.addClass('atom-trace-node-destroy');
			trace.timeout = setTimeout(function () {
				if (trace.node) {
					trace.node.destroy();
					trace.node = null;
				}
			}, 500);
		}
		return trace;
	},
	/** @private */
	stop  : function () {
		this.stopped = true;
		return this;
	},
	/** @private */
	getContainer : function () {
		var cont = atom.dom('#atom-trace-container');
		return cont.length ? cont :
			atom.dom.create('div', { 'id' : 'atom-trace-container'})
				.appendTo('body');
	},
	/** @deprecated */
	trace : function (value) {
		this.value = value;
		return this;
	},
	/** @private */
	createNode : function () {
		var trace = this, node = trace.node;

		if (node) {
			if (trace.timeout) {
				clearTimeout(trace.timeout);
				node.removeClass('atom-trace-node-destroy');
			}
			return node;
		}

		return trace.node = atom.dom
			.create('div')
			.addClass('atom-trace-node')
			.appendTo(trace.getContainer())
			.bind({
				click    : function () { trace.destroy(0) },
				dblclick : function () { trace.destroy(1) }
			});
	}
}).own({
	dumpRec : function dumpRec (obj, level, plain) {
		var html = '', type, tabs;

		level  = parseInt(level) || 0;

		if (level > 5) return '*TOO_DEEP*';

		if (obj && typeof obj == 'object' && coreIsFunction(obj.dump)) return obj.dump();

		function escape (v) {
			return plain ? v : atom.string.safeHtml(v);
		}

		function subDump (elem, index) {
			return tabs + '\t' + index + ': ' + dumpRec(elem, level+1, plain) + '\n';
		}

		type = atom.typeOf(obj);
		tabs = '\t'.repeat(level);

		switch (type) {
			case 'object':
				for (var index in obj) if (obj.hasOwnProperty(index)) {
					html += subDump(obj[index], index);
				}
				return '{\n' + html + tabs + '}';

			case 'element':
				var prop = (obj.width && obj.height) ? '('+obj.width+'×'+obj.height+')' : '';
				return '[DOM ' + obj.tagName.toLowerCase() + prop + ']';

			case 'textnode':
			case 'whitespace':
				return '[DOM ' + type + ']';

			case 'array'  : return '[\n' + obj.map(subDump).join('') + tabs + ']';
			case 'null'   : return 'null';
			case 'boolean': return obj ? 'true' : 'false';
			case 'string' : return escape('"' + obj + '"');
			default       : return escape('' + obj);
		}
	},
	dumpPlain: function (object) {
		return (this.dumpRec(object, 0, true));
	},
	dump : function (object) {
		return (this.dumpRec(object, 0));
	}
});

/*
---

name: "Types.Number"

description: "Contains number-manipulation methods like limit, round, times, and ceil."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core

provides: Types.Number

...
*/

atom.number = {
	randomFloat: function (max, min) {
		return Math.random() * (max - min) + min;
	},
	random : function (min, max) {
		return Math.floor(Math.random() * (max - min + 1) + min);
	},
	between: function (number, n1, n2, equals) {
		number = Number(number);
		n1 = Number(n1);
		n2 = Number(n2);
		return (n1 <= n2) && (
			(equals == 'L' && number == n1) ||
			(equals == 'R' && number == n2) ||
			(number  > n1  && number  < n2) ||
			([true,'LR','RL'].indexOf(equals) != -1 && (n1 == number || n2 == number))
		);
	},
	equals : function (number, to, accuracy) {
		if (accuracy == null) accuracy = 8;
		return number.toFixed(accuracy) == to.toFixed(accuracy);
	},
	limit: function(number, min, max){
		var bottom = Math.max(min, Number(number));
		return max != null ? Math.min(max, bottom) : bottom;
	},
	round: function(number, precision){
		if (!precision) return Math.round(number);

		if (precision < 0) {
			precision = Number( Math.pow(10, precision).toFixed( -precision ) );
		} else {
			precision = Math.pow(10, precision);
		}
		return Math.round(number * precision) / precision;
	},
	stop: function(num) {
		num = Number(num);
		if (num) {
			clearInterval(num);
			clearTimeout (num);
		}
		return this;
	}
};

/*
---

name: "Types.Array"

description: "Contains array-manipulation methods like include, contains, and erase."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- Types.Number

provides: Types.Array

...
*/

atom.array = {
	/**
	 * Checks if arguments is array
	 * @param {Array} array
	 * @returns {boolean}
	 */
	is: function (array) {
		return Array.isArray(array);
	},
	/**
	 * Creates rangearray
	 * @param {int} from
	 * @param {int} to
	 * @param {int} [step=1] - should be
	 * @returns {int[]}
	 */
	range: function (from, to, step) {
		from = Number(from);
		to   = Number(to  );
		step = Number(step);

		if (typeof from != 'number') throw new TypeError( '`from` should be number' );
		if (typeof to   != 'number') throw new TypeError(   '`to` should be number' );

		var increase = to > from, stepIncrease = step > 0;

		if (!step) {
			step = increase ? 1 : -1;
		} else if ( increase != stepIncrease ) {
			throw new RangeError( 'step direction is wrong' );
		}

		var result = [];
		do {
			result.push(from);
			from += step;
		} while (increase ? from <= to : from >= to);

		return result;
	},
	/**
	 * @param {*} item
	 * @returns {Array}
	 */
	from: function (item) {
		if (item == null) return [];
		return (!coreIsArrayLike(item)) ? [item] :
			Array.isArray(item) ? item : slice.call(item);
	},
	/**
	 * @private
	 * @param {Array} args
	 * @returns {Array}
	 */
	pickFrom: function (args) {
		var fromZeroArgument = args && args.length == 1
			&& coreIsArrayLike( args[0] );

		return atom.array.from( fromZeroArgument ? args[0] : args );
	},
	/**
	 * @param {number|Array} array
	 * @param {*} fill
	 * @returns {Array}
	 */
	fill: function (array, fill) {
		array = Array.isArray(array) ? array : new Array(Number(array));
		for (var i = array.length; i--;) array[i] = fill;
		return array;
	},
	/**
	 * @param {number} width
	 * @param {number} height
	 * @param {*} fill
	 * @returns {Array[]}
	 */
	fillMatrix: function (width, height, fill) {
		var array = new Array(height);
		while (height--) {
			array[height] = Array.fill(width, fill);
		}
		return array;
	},
	/**
	 * It returns array, atom.object.collect returns hash
	 * @param {Object} source
	 * @param {Array} props
	 * @param {*} [defaultValue=undefined]
	 * @returns {Array}
	 */
	collect: function (source, props, defaultValue) {
		var array = [], i = 0, l = props.length, prop;
		for (;i < l; i++) {
			prop = props[i];
			array.push(prop in source ? source[prop] : defaultValue);
		}
		return array;
	},
	/**
	 * @param {Number} length
	 * @param {function} callback
	 * @param {Object} [context=undefined]
	 * @returns {Array}
	 */
	create: function (length, callback, context) {
		if (!coreIsFunction(callback)) {
			throw new TypeError('callback should be function');
		}
		var array = new Array(Number(length));
		for (var i = 0; i < length; i++) {
			array[i] = callback.call(context, i, array);
		}
		return array;
	},
	/**
	 * @param {Array} array
	 * @returns {Object}
	 */
	toHash: function (array) {
		var hash = {}, i = 0, l = array.length;
		for (; i < l; i++) {
			hash[i] = array[i];
		}
		return hash;
	},
	/**
	 * @param {Array} array
	 * @returns {*}
	 */
	last: function (array) {
		return array.length ? array[array.length - 1] : null;
	},
	/**
	 * @param {Array} array
	 * @returns number
	 */
	randomIndex: function (array) {
		if (array.length == 0) return null;

		return atom.number.random(0, array.length - 1);
	},
	/**
	 * @param {Array} array
	 * @param {boolean} erase - erase element after splice, or leave at place
	 * @returns {*}
	 */
	random: function (array, erase) {
		if (array.length == 0) return null;

		var index = atom.array.randomIndex(array);

		return erase ? array.splice(index, 1)[0] : array[index];
	},
	/**
	 * Return array of property `name` values of objects
	 * @param {Array} array
	 * @param {string} name
	 * @returns {Array}
	 */
	property: function (array, name) {
		return array.map(function (elem) {
			return elem != null ? elem[ name ] : null;
		});
	},
	/** @deprecated - use `create` instead */
	fullMap: function (array, fn, bind) {
		var mapped = new Array(array.length);
		for (var i = 0, l = mapped.length; i < l; i++) {
			mapped[i] = fn.call(bind, array[i], i, array);
		}
		return mapped;
	},
	/**
	 * Check, if array contains elem
	 * @param {Array} array
	 * @param {*} elem
	 * @param {number} [fromIndex=0]
	 * @returns {boolean}
	 */
	contains: function (array, elem, fromIndex) {
		return array.indexOf(elem, fromIndex) != -1;
	},
	/**
	 * Push element to array, if it doesn't contains such element
	 * @param {Array} target
	 * @param {*} item
	 * @returns {Array} - target array
	 */
	include: includeUnique,
	/**
	 * Erase item from array
	 * @param {Array} target
	 * @param {*} item
	 * @returns {Array} - target array
	 */
	erase: coreEraseAll,
	/**
	 * `push` source array values to the end of target array
	 * @param {Array} target
	 * @param {Array} source
	 * @returns {Array} - target array
	 */
	append: function (target, source) {
		for (var i = 1, l = arguments.length; i < l; i++) if (arguments[i]) {
			target.push.apply(target, arguments[i]);
		}
		return target;
	},
	/** @deprecated */
	toKeys: function (value) {
		var useValue = arguments.length == 1, obj = {};
		for (var i = 0, l = this.length; i < l; i++)
			obj[this[i]] = useValue ? value : i;
		return obj;
	},
	/**
	 * `include` source array values to the end of target array
	 * @param {Array} target
	 * @param {Array} source
	 * @returns {Array} - target array
	 */
	combine: function(target, source){
		for (var i = 0, l = source.length; i < l; i++) {
			atom.array.include(target, source[i]);
		}
		return target;
	},
	/**
	 * returns first not-null value, or returns null
	 * @param {Array} source
	 * @returns {*}
	 */
	pick: function(source){
		for (var i = 0, l = source.length; i < l; i++) {
			if (source[i] != null) return source[i];
		}
		return null;
	},
	/**
	 * You can invoke array of functions with context "context"
	 * Or all methods of objects in array
	 * all params except zero & first will be sed as argument
	 * @param {Array} array
	 * @param {Object|string} [context=null]
	 * @returns {Array} - array of results
	 */
	invoke: function(array, context){
		var args = slice.call(arguments, 2);
		if (typeof context == 'string') {
			var methodName = context;
			context = null;
		}
		return array.map(function(item){
			return item && (methodName ? item[methodName] : item).apply(methodName ? item : context, args);
		});
	},
	/**
	 * shuffle array with smart algorithm
	 * @param {Array} array
	 * @returns {Array}
	 */
	shuffle : function (array) {
		var tmp, moveTo, index = array.length;
		while (index--) {
			moveTo = atom.number.random( 0, index );
			tmp           = array[index ];
			array[index]  = array[moveTo];
			array[moveTo] = tmp;
		}
		return array;
	},
	/**
	 * sort array by property value or method returns
	 * @param {Array} array
	 * @param {string} method
	 * @param {boolean} [reverse=false] (if true) first - smallest, last - biggest
	 * @returns {Array}
	 */
	sortBy : function (array, method, reverse) {
		var get = function (elem) {
			return (coreIsFunction(elem[method]) ? elem[method]() : elem[method]) || 0;
		};
		var multi = reverse ? -1 : 1;
		return array.sort(function ($0, $1) {
			var diff = get($1) - get($0);
			return diff ? (diff < 0 ? -1 : 1) * multi : 0;
		});
	},
	/**
	 * Returns min value in array
	 * @param {Array} array
	 * @returns {Array}
	 */
	min: function(array){
		return Math.min.apply(null, array);
	},
	/**
	 * Returns max value in array
	 * @param {Array} array
	 * @returns {Array}
	 */
	max: function(array){
		return Math.max.apply(null, array);
	},
	/**
	 * Multiply all values in array to factor & returns result array
	 * @param {Array} array
	 * @param {number} factor
	 * @returns {Array}
	 */
	mul: function (array, factor) {
		for (var i = array.length; i--;) array[i] *= factor;
		return array;
	},
	/**
	 * Add to all values in array number & returns result array
	 * @param {Array} array
	 * @param {number} number
	 * @returns {Array}
	 */
	add: function (array, number) {
		for (var i = array.length; i--;) array[i] += number;
		return array;
	},
	/**
	 * Returns sum of all elements in array
	 * @param {Array} array
	 * @returns {number}
	 */
	sum: function (array) {
		for (var result = 0, i = array.length; i--;) result += array[i];
		return result;
	},
	/**
	 * Returns product (result of multiplying) of all elements in array
	 * @param {Array} array
	 * @returns {number}
	 */
	product: function (array) {
		for (var result = 1, i = array.length; i--;) result *= array[i];
		return result;
	},
	/**
	 * Returns average value in array ( sum / length )
	 * @param {Array} array
	 * @returns {number}
	 */
	average: function (array) {
		return array.length ? atom.array.sum(array) / array.length : 0;
	},
	/**
	 * returns array with only unique values ( [1,2,2,3] => [1,2,3] )
	 * @param {Array} array
	 * @returns {Array}
	 */
	unique: function(array){
		return atom.array.combine([], array);
	},
	/**
	 * associate array values with keys
	 * if `keys` is array it used as keys names, and array used as values
	 * if `keys` if function it used as function, generated values & array used as keys
	 * @param {Array} array
	 * @param {Function|Array} keys
	 * @returns {Object}
	 */
	associate: function(array, keys){
		var
			i = 0,
			obj = {},
			length = array.length,
			isFn = coreIsFunction(keys),
			keysSource = isFn ? array : keys;

		if (!isFn) length = Math.min(length, keys.length);
		for (;i < length; i++) {
			obj[ keysSource[i] ] = isFn ? keys(array[i], i) : array[i];
		}
		return obj;
	},
	/**
	 * clean array from empty values & returns empty array
	 * @param {Array} array
	 * @returns {Array}
	 */
	clean: function (array){
		return array.filter(function (item) { return item != null });
	},
	/**
	 * quickly erase all values from array
	 * @param {Array} array
	 * @returns {Array}
	 */
	empty: function (array) {
		array.length = 0;
		return array;
	},
	/** @deprecated */
	clone: function (array) { return atom.clone(array) },
	/**
	 * @param array
	 * @param {boolean} [asArray=false] - returns result as array, or as string
	 * @returns {Array|string}
	 */
	hexToRgb: function(array, asArray){
		if (array.length != 3) return null;
		var rgb = array.map(function(value){
			if (value.length == 1) value += value;
			return parseInt(value, 16);
		});
		return asArray ? rgb : 'rgb(' + rgb + ')';
	},
	/**
	 * @param array
	 * @param {boolean} [asArray=false] - returns result as array, or as string
	 * @returns {Array|string}
	 */
	rgbToHex: function(array, asArray) {
		if (array.length < 3) return null;
		if (array.length == 4 && array[3] == 0 && !asArray) return 'transparent';
		var hex = [], i = 0, bit;
		for (; i < 3; i++){
			bit = (array[i] - 0).toString(16);
			hex.push((bit.length == 1) ? '0' + bit : bit);
		}
		return asArray ? hex : '#' + hex.join('');
	},

	/**
	 * @param {Array} array
	 * @param {Function} callback
	 * @param {*} value
	 * @returns {*}
	 */
	reduce: function(array, callback, value){
		if (coreIsFunction(array.reduce)) return array.reduce(callback, value);

		for (var i = 0, l = array.length; i < l; i++) if (i in array) {
			value = value === undefined ? array[i] : callback.call(null, value, array[i], i, array);
		}
		return value;
	},

	/**
	 * @param {Array} array
	 * @param {Function} callback
	 * @param {*} value
	 * @returns {*}
	 */
	reduceRight: function(array, callback, value){
		if (coreIsFunction(array.reduceRight)) return array.reduceRight(callback, value);

		for (var i = array.length; i--;) if (i in array) {
			value = value === undefined ? array[i] : callback.call(null, value, array[i], i, array);
		}
		return value;
	}
};

/*
---

name: "Prototypes.Abstract"

description: "Contains office methods for prototypes extension."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- Types.Array
	- Types.Object

provides: Prototypes.Abstract

...
*/

var prototypize = {
	callbacks: [],
	fn: function (source) {
		return function (methodName) {
			return function () {
				var args = slice.call(arguments);
				args.unshift(this);
				return source[methodName].apply(source, args);
			};
		};
	},
	proto: function (object, proto, methodsString) {
		coreAppend(object.prototype, atom.array.associate(
			methodsString.split(' '), proto
		));
		return prototypize;
	},
	own: function (object, source, methodsString) {
		coreAppend(object, atom.object.collect( source, methodsString.split(' ') ));
		return prototypize;
	},
	add: function (callback) {
		this.callbacks.push(callback);
	}
};

atom.patching = function (globalObject) {
	prototypize.callbacks.forEach(function (callback) {
		callback(globalObject);
	});
};

/*
---

name: "Prototypes.Array"

description: "Contains Array Prototypes like include, contains, and erase."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Types.Array
	- Prototypes.Abstract

provides: Prototypes.Array

...
*/

prototypize.add(function (globalObject) {

var Array = globalObject.Array;

var proto = prototypize.fn(atom.array);

prototypize
	.own(Array, atom.array, 'range from pickFrom fill fillMatrix collect create toHash')
	.proto(Array, proto, 'randomIndex property contains include append erase combine pick invoke shuffle sortBy min max mul add sum product average unique associate clean empty clone hexToRgb rgbToHex' );

atom.accessors.define(Array.prototype, {
	last  : { get: function () {
		return atom.array.last(this);
	}},
	random: { get: function () {
		return atom.array.random(this, false);
	}}
});

coreAppend(Array.prototype, {
	popRandom: function () {
		return atom.array.random(this, true);
	},
	/** @deprecated */
	toKeys: function () {
		console.log( '[].toKeys is deprecated. Use forEach instead' );
		return atom.array.toKeys(this);
	},
	/** @deprecated */
	fullMap: function (callback, context) {
		console.log( '[].fullMap is deprecated. Use atom.array.create instead' );
		return atom.array.create(this.length, callback, context);
	}
});

if (!Array.prototype.reduce     ) Array.prototype.reduce      = proto('reduce');
if (!Array.prototype.reduceRight) Array.prototype.reduceRight = proto('reduceRight');

});

/*
---

name: "Types.Function"

description: "Contains function manipulation methods."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- Types.Array

provides: Types.Function

...
*/

atom.fn = {
	lambda: function (value) {
		var returnThis = (arguments.length == 0);
		return function () { return returnThis ? this : value; };
	},

	after: function (onReady, fnName) {
		var after = {}, ready = {};
		function checkReady (){
			for (var i in after) if (!ready[i]) return;
			onReady(ready);
		}
		slice.call(arguments, 1).forEach(function (key) {
			after[key] = function () {
				ready[key] = slice.call(arguments);
				ready[key].context = this;
				checkReady();
			};
		});
		return after;
	}
};


/*
---

name: "Prototypes.Function"

description: "Contains Function Prototypes like after, periodical and delay."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- Types.Function
	- Prototypes.Abstract

provides: Prototypes.Function

...
*/

prototypize.add(function (globalObject) {

	var Function = globalObject.Function;

	Function.lambda = atom.fn.lambda;

	function timer (periodical) {
		var set = periodical ? setInterval : setTimeout;

		return function (time, bind, args) {
			var fn = this;
			return set(function () {
				fn.apply( bind, args || [] );
			}, time);
		};
	}
	
	coreAppend(Function.prototype, {
		after: prototypize.fn(atom.fn)('after'),
		delay     : timer(false),
		periodical: timer(true )
	});

});


/*
---

name: "Types.Math"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core

provides: Types.Math

...
*/

(function () {

var
	degree = Math.PI / 180,
	deg360 = Math.PI * 2;

atom.math = {

	DEGREE360: deg360,

	/**
	 * Cast degrees to radians
	 * atom.math.degree(90) == Math.PI/2
	 */
	degree: function (degrees) {
		return degrees * degree;
	},

	/**
	 * Cast radians to degrees
	 * atom.math.getDegree(Math.PI/2) == 90
	 */
	getDegree: function (radians, round) {
		radians /= degree;

		return round ? Math.round(radians) : radians;
	},
	normalizeAngle : function (radians) {
		radians %= deg360;

		return radians + ( radians < 0 ? deg360 : 0 );
	},

	hypotenuse: function (cathetus1, cathetus2)  {
		return Math.sqrt(cathetus1*cathetus1 + cathetus2*cathetus2);
	},
	cathetus: function (hypotenuse, cathetus2)  {
		return Math.sqrt(hypotenuse*hypotenuse - cathetus2*cathetus2);
	}
};

})();


/*
---

name: "Prototypes.Number"

description: "Contains Number Prototypes like limit, round, times, and ceil."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Types.Number
	- Types.Math
	- Prototypes.Abstract

provides: Prototypes.Number

...
*/

prototypize.add(function (globalObject) {

var Number = globalObject.Number;

prototypize
	.own(Number, atom.number, 'random randomFloat')
	.proto(Number, prototypize.fn(atom.number), 'between equals limit round stop' )
	.proto(Number, prototypize.fn(atom.math  ), 'degree getDegree normalizeAngle' );

coreAppend(Number.prototype, {
	toFloat: function(){
		return parseFloat(this);
	},
	toInt: function(base){
		return parseInt(this, base || 10);
	}
});

'abs acos asin atan atan2 ceil cos exp floor log max min pow sin sqrt tan'
	.split(' ')
	.forEach(function(method) {
		if (Number[method]) return;
		
		Number.prototype[method] = function() {
			return Math[method].apply(null, [this].append(arguments));
		};
	});
});

/*
---

name: "Prototypes.Object"

description: "Object generic methods"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Types.Object

provides: Prototypes.Object

...
*/

prototypize.add(function (globalObject) {
	coreAppend(globalObject.Object, atom.object);
});

/*
---

name: "Types.String"

description: "Contains string-manipulation methods like repeat, substitute, replaceAll and begins."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core

provides: Types.String

...
*/

new function () {

var UID = Date.now();

atom.string = {
	/**
	 * @returns {string} - unique for session value in 36-radix
	 */
	uniqueID: function () {
		return (UID++).toString(36);
	},
	/**
	 * escape all html unsafe characters - & ' " < >
	 * @param {string} string
	 * @returns {string}
	 */
	safeHtml: function (string) {
		return this.replaceAll(string, /[<'&">]/g, {
			'&'  : '&amp;',
			'\'' : '&#039;',
			'\"' : '&quot;',
			'<'  : '&lt;',
			'>'  : '&gt;'
		});
	},
	/**
	 * repeat string `times` times
	 * @param {string} string
	 * @param {int} times
	 * @returns {string}
	 */
	repeat: function(string, times) {
		return new Array(times + 1).join(string);
	},
	/**
	 * @param {string} string
	 * @param {Object} object
	 * @param {RegExp} [regexp=null]
	 * @returns {string}
	 */
	substitute: function(string, object, regexp){
		return string.replace(regexp || /\\?\{([^{}]+)\}/g, function(match, name){
			return (match[0] == '\\') ? match.slice(1) : (object[name] == null ? '' : object[name]);
		});
	},
	/**
	 * @param {string} string
	 * @param {Object|RegExp|string} find
	 * @param {Object|string} [replace=null]
	 * @returns {String}
	 */
	replaceAll: function (string, find, replace) {
		if (toString.call(find) == '[object RegExp]') {
			return string.replace(find, function (symb) { return replace[symb]; });
		} else if (typeof find == 'object') {
			for (var i in find) string = this.replaceAll(string, i, find[i]);
			return string;
		}
		return string.split(find).join(replace);
	},
	/**
	 * Checks if string contains such substring
	 * @param {string} string
	 * @param {string} substr
	 */
	contains: function (string, substr) {
		return string ? string.indexOf( substr ) >= 0 : false;
	},
	/**
	 * Checks if string begins with such substring
	 * @param {string} string
	 * @param {string} substring
	 * @param {boolean} [caseInsensitive=false]
	 * @returns {boolean}
	 */
	begins: function (string, substring, caseInsensitive) {
		if (!string) return false;
		return (!caseInsensitive) ? substring == string.substr(0, substring.length) :
			substring.toLowerCase() == string.substr(0, substring.length).toLowerCase();
	},
	/**
	 * Checks if string ends with such substring
	 * @param {string} string
	 * @param {string} substring
	 * @param {boolean} [caseInsensitive=false]
	 * @returns {boolean}
	 */
	ends: function (string, substring, caseInsensitive) {
		if (!string) return false;
		return (!caseInsensitive) ? substring == string.substr(string.length - substring.length) :
			substring.toLowerCase() == string.substr(string.length - substring.length).toLowerCase();
	},
	/**
	 * Uppercase first character
	 * @param {string} string
	 * @returns {string}
	 */
	ucfirst : function (string) {
		return string ? string[0].toUpperCase() + string.substr(1) : '';
	},
	/**
	 * Lowercase first character
	 * @param {string} string
	 * @returns {string}
	 */
	lcfirst : function (string) {
		return string ? string[0].toLowerCase() + string.substr(1) : '';
	}
};

}();

/*
---

name: "Prototypes.String"

description: "Contains String Prototypes like repeat, substitute, replaceAll and begins."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Types.String
	- Prototypes.Abstract

provides: Prototypes.String

...
*/

prototypize.add(function (globalObject) {
	prototypize.proto(globalObject.String, prototypize.fn(atom.string),
		'safeHtml repeat substitute replaceAll contains begins ends ucfirst lcfirst'
	);
});

}.call(typeof exports == 'undefined' ? window : exports, Object, Array)); 
