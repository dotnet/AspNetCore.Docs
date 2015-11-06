/*
---

name: "Types.Array"

description: "Contains array-manipulation methods like include, contains, and erase."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- Types.Number

provides: Types.Array

...
*/

atom.array = {
	/**
	 * Checks if arguments is array
	 * @param {Array} array
	 * @returns {boolean}
	 */
	is: function (array) {
		return Array.isArray(array);
	},
	/**
	 * Creates rangearray
	 * @param {int} from
	 * @param {int} to
	 * @param {int} [step=1] - should be
	 * @returns {int[]}
	 */
	range: function (from, to, step) {
		from = Number(from);
		to   = Number(to  );
		step = Number(step);

		if (typeof from != 'number') throw new TypeError( '`from` should be number' );
		if (typeof to   != 'number') throw new TypeError(   '`to` should be number' );

		var increase = to > from, stepIncrease = step > 0;

		if (!step) {
			step = increase ? 1 : -1;
		} else if ( increase != stepIncrease ) {
			throw new RangeError( 'step direction is wrong' );
		}

		var result = [];
		do {
			result.push(from);
			from += step;
		} while (increase ? from <= to : from >= to);

		return result;
	},
	/**
	 * @param {*} item
	 * @returns {Array}
	 */
	from: function (item) {
		if (item == null) return [];
		return (!coreIsArrayLike(item)) ? [item] :
			Array.isArray(item) ? item : slice.call(item);
	},
	/**
	 * @private
	 * @param {Array} args
	 * @returns {Array}
	 */
	pickFrom: function (args) {
		var fromZeroArgument = args && args.length == 1
			&& coreIsArrayLike( args[0] );

		return atom.array.from( fromZeroArgument ? args[0] : args );
	},
	/**
	 * @param {number|Array} array
	 * @param {*} fill
	 * @returns {Array}
	 */
	fill: function (array, fill) {
		array = Array.isArray(array) ? array : new Array(Number(array));
		for (var i = array.length; i--;) array[i] = fill;
		return array;
	},
	/**
	 * @param {number} width
	 * @param {number} height
	 * @param {*} fill
	 * @returns {Array[]}
	 */
	fillMatrix: function (width, height, fill) {
		var array = new Array(height);
		while (height--) {
			array[height] = Array.fill(width, fill);
		}
		return array;
	},
	/**
	 * It returns array, atom.object.collect returns hash
	 * @param {Object} source
	 * @param {Array} props
	 * @param {*} [defaultValue=undefined]
	 * @returns {Array}
	 */
	collect: function (source, props, defaultValue) {
		var array = [], i = 0, l = props.length, prop;
		for (;i < l; i++) {
			prop = props[i];
			array.push(prop in source ? source[prop] : defaultValue);
		}
		return array;
	},
	/**
	 * @param {Number} length
	 * @param {function} callback
	 * @param {Object} [context=undefined]
	 * @returns {Array}
	 */
	create: function (length, callback, context) {
		if (!coreIsFunction(callback)) {
			throw new TypeError('callback should be function');
		}
		var array = new Array(Number(length));
		for (var i = 0; i < length; i++) {
			array[i] = callback.call(context, i, array);
		}
		return array;
	},
	/**
	 * @param {Array} array
	 * @returns {Object}
	 */
	toHash: function (array) {
		var hash = {}, i = 0, l = array.length;
		for (; i < l; i++) {
			hash[i] = array[i];
		}
		return hash;
	},
	/**
	 * @param {Array} array
	 * @returns {*}
	 */
	last: function (array) {
		return array.length ? array[array.length - 1] : null;
	},
	/**
	 * @param {Array} array
	 * @returns number
	 */
	randomIndex: function (array) {
		if (array.length == 0) return null;

		return atom.number.random(0, array.length - 1);
	},
	/**
	 * @param {Array} array
	 * @param {boolean} erase - erase element after splice, or leave at place
	 * @returns {*}
	 */
	random: function (array, erase) {
		if (array.length == 0) return null;

		var index = atom.array.randomIndex(array);

		return erase ? array.splice(index, 1)[0] : array[index];
	},
	/**
	 * Return array of property `name` values of objects
	 * @param {Array} array
	 * @param {string} name
	 * @returns {Array}
	 */
	property: function (array, name) {
		return array.map(function (elem) {
			return elem != null ? elem[ name ] : null;
		});
	},
	/** @deprecated - use `create` instead */
	fullMap: function (array, fn, bind) {
		var mapped = new Array(array.length);
		for (var i = 0, l = mapped.length; i < l; i++) {
			mapped[i] = fn.call(bind, array[i], i, array);
		}
		return mapped;
	},
	/**
	 * Check, if array contains elem
	 * @param {Array} array
	 * @param {*} elem
	 * @param {number} [fromIndex=0]
	 * @returns {boolean}
	 */
	contains: function (array, elem, fromIndex) {
		return array.indexOf(elem, fromIndex) != -1;
	},
	/**
	 * Push element to array, if it doesn't contains such element
	 * @param {Array} target
	 * @param {*} item
	 * @returns {Array} - target array
	 */
	include: includeUnique,
	/**
	 * Erase item from array
	 * @param {Array} target
	 * @param {*} item
	 * @returns {Array} - target array
	 */
	erase: coreEraseAll,
	/**
	 * `push` source array values to the end of target array
	 * @param {Array} target
	 * @param {Array} source
	 * @returns {Array} - target array
	 */
	append: function (target, source) {
		for (var i = 1, l = arguments.length; i < l; i++) if (arguments[i]) {
			target.push.apply(target, arguments[i]);
		}
		return target;
	},
	/** @deprecated */
	toKeys: function (value) {
		var useValue = arguments.length == 1, obj = {};
		for (var i = 0, l = this.length; i < l; i++)
			obj[this[i]] = useValue ? value : i;
		return obj;
	},
	/**
	 * `include` source array values to the end of target array
	 * @param {Array} target
	 * @param {Array} source
	 * @returns {Array} - target array
	 */
	combine: function(target, source){
		for (var i = 0, l = source.length; i < l; i++) {
			atom.array.include(target, source[i]);
		}
		return target;
	},
	/**
	 * returns first not-null value, or returns null
	 * @param {Array} source
	 * @returns {*}
	 */
	pick: function(source){
		for (var i = 0, l = source.length; i < l; i++) {
			if (source[i] != null) return source[i];
		}
		return null;
	},
	/**
	 * You can invoke array of functions with context "context"
	 * Or all methods of objects in array
	 * all params except zero & first will be sed as argument
	 * @param {Array} array
	 * @param {Object|string} [context=null]
	 * @returns {Array} - array of results
	 */
	invoke: function(array, context){
		var args = slice.call(arguments, 2);
		if (typeof context == 'string') {
			var methodName = context;
			context = null;
		}
		return array.map(function(item){
			return item && (methodName ? item[methodName] : item).apply(methodName ? item : context, args);
		});
	},
	/**
	 * shuffle array with smart algorithm
	 * @param {Array} array
	 * @returns {Array}
	 */
	shuffle : function (array) {
		var tmp, moveTo, index = array.length;
		while (index--) {
			moveTo = atom.number.random( 0, index );
			tmp           = array[index ];
			array[index]  = array[moveTo];
			array[moveTo] = tmp;
		}
		return array;
	},
	/**
	 * sort array by property value or method returns
	 * @param {Array} array
	 * @param {string} method
	 * @param {boolean} [reverse=false] (if true) first - smallest, last - biggest
	 * @returns {Array}
	 */
	sortBy : function (array, method, reverse) {
		var get = function (elem) {
			return (coreIsFunction(elem[method]) ? elem[method]() : elem[method]) || 0;
		};
		var multi = reverse ? -1 : 1;
		return array.sort(function ($0, $1) {
			var diff = get($1) - get($0);
			return diff ? (diff < 0 ? -1 : 1) * multi : 0;
		});
	},
	/**
	 * Returns min value in array
	 * @param {Array} array
	 * @returns {Array}
	 */
	min: function(array){
		return Math.min.apply(null, array);
	},
	/**
	 * Returns max value in array
	 * @param {Array} array
	 * @returns {Array}
	 */
	max: function(array){
		return Math.max.apply(null, array);
	},
	/**
	 * Multiply all values in array to factor & returns result array
	 * @param {Array} array
	 * @param {number} factor
	 * @returns {Array}
	 */
	mul: function (array, factor) {
		for (var i = array.length; i--;) array[i] *= factor;
		return array;
	},
	/**
	 * Add to all values in array number & returns result array
	 * @param {Array} array
	 * @param {number} number
	 * @returns {Array}
	 */
	add: function (array, number) {
		for (var i = array.length; i--;) array[i] += number;
		return array;
	},
	/**
	 * Returns sum of all elements in array
	 * @param {Array} array
	 * @returns {number}
	 */
	sum: function (array) {
		for (var result = 0, i = array.length; i--;) result += array[i];
		return result;
	},
	/**
	 * Returns product (result of multiplying) of all elements in array
	 * @param {Array} array
	 * @returns {number}
	 */
	product: function (array) {
		for (var result = 1, i = array.length; i--;) result *= array[i];
		return result;
	},
	/**
	 * Returns average value in array ( sum / length )
	 * @param {Array} array
	 * @returns {number}
	 */
	average: function (array) {
		return array.length ? atom.array.sum(array) / array.length : 0;
	},
	/**
	 * returns array with only unique values ( [1,2,2,3] => [1,2,3] )
	 * @param {Array} array
	 * @returns {Array}
	 */
	unique: function(array){
		return atom.array.combine([], array);
	},
	/**
	 * associate array values with keys
	 * if `keys` is array it used as keys names, and array used as values
	 * if `keys` if function it used as function, generated values & array used as keys
	 * @param {Array} array
	 * @param {Function|Array} keys
	 * @returns {Object}
	 */
	associate: function(array, keys){
		var
			i = 0,
			obj = {},
			length = array.length,
			isFn = coreIsFunction(keys),
			keysSource = isFn ? array : keys;

		if (!isFn) length = Math.min(length, keys.length);
		for (;i < length; i++) {
			obj[ keysSource[i] ] = isFn ? keys(array[i], i) : array[i];
		}
		return obj;
	},
	/**
	 * clean array from empty values & returns empty array
	 * @param {Array} array
	 * @returns {Array}
	 */
	clean: function (array){
		return array.filter(function (item) { return item != null });
	},
	/**
	 * quickly erase all values from array
	 * @param {Array} array
	 * @returns {Array}
	 */
	empty: function (array) {
		array.length = 0;
		return array;
	},
	/** @deprecated */
	clone: function (array) { return atom.clone(array) },
	/**
	 * @param array
	 * @param {boolean} [asArray=false] - returns result as array, or as string
	 * @returns {Array|string}
	 */
	hexToRgb: function(array, asArray){
		if (array.length != 3) return null;
		var rgb = array.map(function(value){
			if (value.length == 1) value += value;
			return parseInt(value, 16);
		});
		return asArray ? rgb : 'rgb(' + rgb + ')';
	},
	/**
	 * @param array
	 * @param {boolean} [asArray=false] - returns result as array, or as string
	 * @returns {Array|string}
	 */
	rgbToHex: function(array, asArray) {
		if (array.length < 3) return null;
		if (array.length == 4 && array[3] == 0 && !asArray) return 'transparent';
		var hex = [], i = 0, bit;
		for (; i < 3; i++){
			bit = (array[i] - 0).toString(16);
			hex.push((bit.length == 1) ? '0' + bit : bit);
		}
		return asArray ? hex : '#' + hex.join('');
	},

	/**
	 * @param {Array} array
	 * @param {Function} callback
	 * @param {*} value
	 * @returns {*}
	 */
	reduce: function(array, callback, value){
		if (coreIsFunction(array.reduce)) return array.reduce(callback, value);

		for (var i = 0, l = array.length; i < l; i++) if (i in array) {
			value = value === undefined ? array[i] : callback.call(null, value, array[i], i, array);
		}
		return value;
	},

	/**
	 * @param {Array} array
	 * @param {Function} callback
	 * @param {*} value
	 * @returns {*}
	 */
	reduceRight: function(array, callback, value){
		if (coreIsFunction(array.reduceRight)) return array.reduceRight(callback, value);

		for (var i = array.length; i--;) if (i in array) {
			value = value === undefined ? array[i] : callback.call(null, value, array[i], i, array);
		}
		return value;
	}
};