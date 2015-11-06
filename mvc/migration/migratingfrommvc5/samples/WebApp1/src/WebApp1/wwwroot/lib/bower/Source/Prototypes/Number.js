/*
---

name: "Prototypes.Number"

description: "Contains Number Prototypes like limit, round, times, and ceil."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Types.Number
	- Types.Math
	- Prototypes.Abstract

provides: Prototypes.Number

...
*/

prototypize.add(function (globalObject) {

var Number = globalObject.Number;

prototypize
	.own(Number, atom.number, 'random randomFloat')
	.proto(Number, prototypize.fn(atom.number), 'between equals limit round stop' )
	.proto(Number, prototypize.fn(atom.math  ), 'degree getDegree normalizeAngle' );

coreAppend(Number.prototype, {
	toFloat: function(){
		return parseFloat(this);
	},
	toInt: function(base){
		return parseInt(this, base || 10);
	}
});

'abs acos asin atan atan2 ceil cos exp floor log max min pow sin sqrt tan'
	.split(' ')
	.forEach(function(method) {
		if (Number[method]) return;
		
		Number.prototype[method] = function() {
			return Math[method].apply(null, [this].append(arguments));
		};
	});
});