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