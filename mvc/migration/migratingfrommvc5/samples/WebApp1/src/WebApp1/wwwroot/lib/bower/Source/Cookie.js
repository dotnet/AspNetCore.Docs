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