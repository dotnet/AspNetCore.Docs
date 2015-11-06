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