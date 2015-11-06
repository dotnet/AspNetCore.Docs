/*
---

name: "Color"

description: "Provides Color class"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- declare

provides: Color

...
*/
/** @class atom.Color */
declare( 'atom.Color', {
	initialize: function (value) {
		var a = arguments, type;
		if (a.length == 4 || a.length == 3) {
			value = slice.call(a);
		} else if (value && value.length == 1) {
			value = value[0];
		}

		type = typeof value;
		if (Array.isArray(value)) {
			this.fromArray(value);
		} else if (type == 'number') {
			this.fromNumber(value);
		} else if (type == 'string') {
			this.fromString(value);
		} else if (type == 'object') {
			this.fromObject(value);
		} else {
			throw new TypeError('Unknown type in atom.Color: ' + typeof value + ';\n' + value);
		}
	},

	/** @private */
	r: 0,
	/** @private */
	g: 0,
	/** @private */
	b: 0,
	/** @private */
	a: 1,

	/**
	 * We are array-like object (looks at accessors at bottom of class)
	 * @constant
	 */
	length: 4,

	noLimits: false,

	get red   () { return this.r; },
	get green () { return this.g; },
	get blue  () { return this.b; },
	get alpha () { return this.a; },

	set red   (v) { this.setValue('r', v) },
	set green (v) { this.setValue('g', v) },
	set blue  (v) { this.setValue('b', v) },
	set alpha (v) { this.setValue('a', v, true) },

	/** @private */
	safeAlphaSet: function (v) {
		if (v != null) {
			this.alpha = Math.round(v*1000)/1000;
		}
	},

	/** @private */
	setValue: function (prop, value, isFloat) {
		value = Number(value);
		if (value != value) { // isNaN
			throw new TypeError('Value is NaN (' + prop + '): ' + value);
		}

		if (!isFloat) value = Math.round(value);
		// We don't want application down, if user script (e.g. animation)
		// generates such wrong array: [150, 125, -1]
		// `noLimits` switch off this check
		this[prop] = this.noLimits ? value :
			atom.number.limit( value, 0, isFloat ? 1 : 255 );
	},

	// Parsing

	/**
	 * @param {int[]} array
	 * @returns {atom.Color}
	 */
	fromArray: function (array) {
		if (!array || array.length < 3 || array.length > 4) {
			throw new TypeError('Wrong array in atom.Color: ' + array);
		}
		this.red   = array[0];
		this.green = array[1];
		this.blue  = array[2];
		this.safeAlphaSet(array[3]);
		return this;
	},
	/**
	 * @param {Object} object
	 * @param {number} object.red
	 * @param {number} object.green
	 * @param {number} object.blue
	 * @returns {atom.Color}
	 */
	fromObject: function (object) {
		if (typeof object != 'object') {
			throw new TypeError( 'Not object in "fromObject": ' + typeof object );
		}

		function fetch (p1, p2) {
			return object[p1] != null ? object[p1] : object[p2]
		}

		this.red   = fetch('r', 'red'  );
		this.green = fetch('g', 'green');
		this.blue  = fetch('b', 'blue' );
		this.safeAlphaSet(fetch('a', 'alpha'));
		return this;
	},
	/**
	 * @param {string} string
	 * @returns {atom.Color}
	 */
	fromString: function (string) {
		if (!this.constructor.isColorString(string)) {
			throw new TypeError( 'Not color string in "fromString": ' + string );
		}

		var hex, array;

		string = string.toLowerCase();
		string = this.constructor.colorNames[string] || string;

		if (hex = string.match(/^#(\w{1,2})(\w{1,2})(\w{1,2})(\w{1,2})?$/)) {
			array = atom.array.clean(hex.slice(1));
			array = array.map(function (part) {
				if (part.length == 1) part += part;
				return parseInt(part, 16);
			});
			if (array.length == 4) array[3] /= 255;
		} else {
			array = string.match(/([\.\d]{1,})/g).map( Number );
		}
		return this.fromArray(array);
	},
	/**
	 * @param {number} number
	 * @returns {atom.Color}
	 */
	fromNumber: function (number) {
		if (typeof number != 'number' || number < 0 || number > 0xffffffff) {
			throw new TypeError( 'Not color number in "fromNumber": ' + (number.toString(16)) );
		}

		return this.fromArray([
			(number>>24) & 0xff,
			(number>>16) & 0xff,
			(number>> 8) & 0xff,
			(number      & 0xff) / 255
		]);
	},

	// Casting

	/** @returns {int[]} */
	toArray: function () {
		return [this.r, this.g, this.b, this.a];
	},
	/** @returns {string} */
	toString: function (type) {
		var arr = this.toArray();
		if (type == 'hex' || type == 'hexA') {
			return '#' + arr.map(function (color, i) {
				if (i == 3) { // alpha
					if (type == 'hex') return '';
					color = Math.round(color * 255);
				}
				var bit = color.toString(16);
				return bit.length == 1 ? '0' + bit : bit;
			}).join('');
		} else {
			return 'rgba(' + arr + ')';
		}
	},
	/** @returns {number} */
	toNumber: function () {
		// maybe needs optimizations
		return parseInt( this.toString('hexA').substr(1) , 16)
	},
	/** @returns {object} */
	toObject: function (abbreviationNames) {
		return abbreviationNames ?
			{ r  : this.r, g    : this.g, b   : this.b, a    : this.a } :
			{ red: this.r, green: this.g, blue: this.b, alpha: this.a };
	},

	// manipulations

	/**
	 * @param {atom.Color} color
	 * @returns {atom.Color}
	 */
	diff: function (color) {
		// we can't use this.constructor, because context exists in such way
		// && invoke is not called
		color = atom.Color( color );
		return new atom.Color.Shift([
			color.red   - this.red  ,
			color.green - this.green,
			color.blue  - this.blue ,
			color.alpha - this.alpha
		]);
	},
	/**
	 * @param {atom.Color} color
	 * @returns {atom.Color}
	 */
	move: function (color) {
		color = atom.Color.Shift(color);
		this.red   += color.red  ;
		this.green += color.green;
		this.blue  += color.blue ;
		this.alpha += color.alpha;
		return this;
	},
	/** @deprecated - use `clone`+`move` instead */
	shift: function (color) {
		return this.clone().move(color);
	},
	map: function (fn) {
		var color = this;
		['red', 'green', 'blue', 'alpha'].forEach(function (component) {
			color[component] = fn.call( color, color[component], component, color );
		});
		return color;
	},
	add: function (factor) {
		return this.map(function (value) {
			return value + factor;
		});
	},
	mul: function (factor) {
		return this.map(function (value) {
			return value * factor;
		});
	},
	/**
	 * @param {atom.Color} color
	 * @returns {boolean}
	 */
	equals: function (color) {
		return color &&
			color instanceof this.constructor &&
			color.red   == this.red   &&
			color.green == this.green &&
			color.blue  == this.blue  &&
			color.alpha == this.alpha;
	},

	/** @private */
	dump: function () {
		return '[atom.Color(' + this.toString('hexA') + ')]';
	},

	/**
	 * @returns {atom.Color}
	 */
	clone: function () {
		return new this.constructor(this);
	}
}).own({
	invoke: declare.castArguments,

	/**
	 * Checks if string is color description
	 * @param {string} string
	 * @returns {boolean}
	 */
	isColorString : function (string) {
		if (typeof string != 'string') return false;
		return Boolean(
			string in this.colorNames  ||
			string.match(/^#\w{3,6}$/) ||
			string.match(/^rgba?\([\d\., ]+\)$/)
		);
	},

	colorNames: {
		white:  '#ffffff',
		silver: '#c0c0c0',
		gray:   '#808080',
		black:  '#000000',
		red:    '#ff0000',
		maroon: '#800000',
		yellow: '#ffff00',
		olive:  '#808000',
		lime:   '#00ff00',
		green:  '#008000',
		aqua:   '#00ffff',
		teal:   '#008080',
		blue:   '#0000ff',
		navy:   '#000080',
		fuchsia:'#ff00ff',
		purple: '#800080',
		orange: '#ffa500'
	},

	/**
	 * @param {boolean} [html=false] - only html color names
	 * @returns {atom.Color}
	 */
	random: function (html) {
		var source, random = atom.number.random;

		if (html) {
			source = atom.array.random( this.colorNamesList );
		} else {
			source = [ random(0, 255), random(0, 255), random(0, 255) ];
		}

		return new this(source);
	}
});

atom.Color.colorNamesList = Object.keys(atom.Color.colorNames);

/** @class atom.Color.Shift */
declare( 'atom.Color.Shift', atom.Color, { noLimits: true });