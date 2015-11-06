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