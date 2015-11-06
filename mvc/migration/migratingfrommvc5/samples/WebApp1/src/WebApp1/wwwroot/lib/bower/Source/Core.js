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