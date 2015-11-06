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
