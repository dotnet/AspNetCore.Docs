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
