/*
---

name: "AtomJS"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

authors:
	- Pavel Ponomarenko aka Shock <shocksilien@gmail.com>

inspiration:
	- "[JQuery](http://jquery.com)"
	- "[MooTools](http://mootools.net)"

...
*/

(function (Object, Array, undefined) { // AtomJS
// Safari 5 bug:
// 'use strict';

var
	toString  = Object.prototype.toString,
	hasOwn    = Object.prototype.hasOwnProperty,
	slice     = Array .prototype.slice,
	atom = this.atom = function () {
		if (atom.initialize) return atom.initialize.apply(this, arguments);
	};

atom.global = this;

/*** [Code] ***/

}.call(typeof exports == 'undefined' ? window : exports, Object, Array));