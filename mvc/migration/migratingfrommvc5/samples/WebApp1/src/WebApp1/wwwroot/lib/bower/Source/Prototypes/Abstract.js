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