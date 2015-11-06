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
