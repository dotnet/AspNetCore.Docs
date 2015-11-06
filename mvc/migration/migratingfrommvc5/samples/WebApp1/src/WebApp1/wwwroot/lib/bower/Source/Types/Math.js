/*
---

name: "Types.Math"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core

provides: Types.Math

...
*/

(function () {

var
	degree = Math.PI / 180,
	deg360 = Math.PI * 2;

atom.math = {

	DEGREE360: deg360,

	/**
	 * Cast degrees to radians
	 * atom.math.degree(90) == Math.PI/2
	 */
	degree: function (degrees) {
		return degrees * degree;
	},

	/**
	 * Cast radians to degrees
	 * atom.math.getDegree(Math.PI/2) == 90
	 */
	getDegree: function (radians, round) {
		radians /= degree;

		return round ? Math.round(radians) : radians;
	},
	normalizeAngle : function (radians) {
		radians %= deg360;

		return radians + ( radians < 0 ? deg360 : 0 );
	},

	hypotenuse: function (cathetus1, cathetus2)  {
		return Math.sqrt(cathetus1*cathetus1 + cathetus2*cathetus2);
	},
	cathetus: function (hypotenuse, cathetus2)  {
		return Math.sqrt(hypotenuse*hypotenuse - cathetus2*cathetus2);
	}
};

})();
