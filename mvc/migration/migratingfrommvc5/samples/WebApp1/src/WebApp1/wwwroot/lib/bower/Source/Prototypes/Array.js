/*
---

name: "Prototypes.Array"

description: "Contains Array Prototypes like include, contains, and erase."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Types.Array
	- Prototypes.Abstract

provides: Prototypes.Array

...
*/

prototypize.add(function (globalObject) {

var Array = globalObject.Array;

var proto = prototypize.fn(atom.array);

prototypize
	.own(Array, atom.array, 'range from pickFrom fill fillMatrix collect create toHash')
	.proto(Array, proto, 'randomIndex property contains include append erase combine pick invoke shuffle sortBy min max mul add sum product average unique associate clean empty clone hexToRgb rgbToHex' );

atom.accessors.define(Array.prototype, {
	last  : { get: function () {
		return atom.array.last(this);
	}},
	random: { get: function () {
		return atom.array.random(this, false);
	}}
});

coreAppend(Array.prototype, {
	popRandom: function () {
		return atom.array.random(this, true);
	},
	/** @deprecated */
	toKeys: function () {
		console.log( '[].toKeys is deprecated. Use forEach instead' );
		return atom.array.toKeys(this);
	},
	/** @deprecated */
	fullMap: function (callback, context) {
		console.log( '[].fullMap is deprecated. Use atom.array.create instead' );
		return atom.array.create(this.length, callback, context);
	}
});

if (!Array.prototype.reduce     ) Array.prototype.reduce      = proto('reduce');
if (!Array.prototype.reduceRight) Array.prototype.reduceRight = proto('reduceRight');

});