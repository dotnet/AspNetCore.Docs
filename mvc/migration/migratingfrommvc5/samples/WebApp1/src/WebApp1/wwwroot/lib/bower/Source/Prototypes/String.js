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