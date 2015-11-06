# Methods for manipulations with Array

### is
	boolean atom.array.is(array)
Checks is `array` is real Array

	atom.array.is([]); // true
	atom.array.is({}); // false

### range
	Array atom.array.range(Number from, Number to, Number step = 0)

Creates array of values from `from` to `to` with step `step`

	atom.array.range(5, 8); // [5,6,7,8]
	atom.array.range(5, 15, 3); // [5,8,11,14]

### from
	Array atom.array.from(item)

Cast `item` to Array is item is array-like-object
Returns `item` if item is Array
Wrap item into array in other case

	(function () {
		atom.array.from(arguments); // [1,2,3]
		atom.array.from( 'foo' );   // ['foo']
		atom.array.from(['zzz']);   // ['zzz']
	})(1,2,3);

### pickFrom
	Array Array atom.array.pickFrom(args)

Returns first element of `args` if it is array-like object, or `args` in other case

	function foo () {
		return atom.array.pickFrom(arguments);
	}

	foo( 1,2,3 );
	// equals to
	foo([1,2,3]);

### fill
	Array atom.array.fill(Array|number array, value)

Fill array `array`, or create new array with length `array` and fill it with values `value`

	atom.array.fill(3, null); // [null, null, null]

	var test = [1, 2, 3];
	atom.array.fill(test, 5);
	console.log(test); // [5, 5, 5]

### fillMatrix
	Array atom.array.fillMatrix(Number width, Number height, mixed fill)
Create and fill matrix with values

	var matrix = atom.array.fillMatrix(3, 2, null);
	/* result is [
		[null, null, null],
		[null, null, null],
		[null, null, null]
	] */

### collect
	Array atom.array.collect(object, Array properties, defaultValue = null)

Collect `properties` from `object` (or set `defaultValue` if empty)

	var object = { a: 5, b: 8, c: 13 };
	console.log(
		atom.array.collect(object, ['a', 'x', 'c'], -1)
	); // [5, -1, 13]

### create
	Array atom.array.create(Number length, Function fn)

Make array of length `length` by function `fn`

	var array = atom.array.create(5, function (i) {
		return atom.number.random(i, 10);
	});

### toHash
	Object atom.array.toHash(Array array)
Make hash from array-like object

	atom.array.toHash([1, 5, null]); // { 0: 1, 1: 5, 2: null }

### last
	atom.array.last(Array array)

Returns last element of `array` or `null

	atom.array.last([0,1,2,3,4]); // 4
	atom.array.last([]); // null

### randomIndex
	Number atom.array.randomIndex(Array array)

Returns random index of `array` or `null`

	atom.array.randomIndex([1,2,3,4,5,6]); // 3
	atom.array.randomIndex([]); // null

### random
	Number atom.array.random(Array array, boolean erase = false)

Returns random element of `array` or `null`, if `array` is empty;
Erase this element rom array if `erase` is true

	atom.array.random([1,2,3,4,5,6]); // 4

	var array = [1,2,3,4];
	atom.array.random(array, true); // 3
	array; // [1,2,4]

### property
	Array atom.array.property(Array array, String name)
Returns all values of property `name` of each element of `array`

	[ { foo: 1, bar: 3 }
	, { foo: 3, bar: 1 }
	, { foo: 2, bar: 2 }
	, { foo: 4, bar: 6 }
	].property('foo'); // [1,3,2,4]

### contains
	boolean atom.array.contains(Array array, item, Number fromIndex = 0)
Tests an `array` for the presence of an `item`.

	atom.array.contains([1,2,3,4], 1   ); // true
	atom.array.contains([1,2,3,4], 1, 2); // false

### include
	Array atom.array.include(Array array, elem)

Push element to array, if it doesn't contains such element

	atom.array.include([1,2,3], 1); // [1,2,3]
	atom.array.include([1,2,3], 4); // [1,2,3,4]

### erase
	Array atom.array.erase(Array array, item)
Removes all occurrences of an item from the array.

	atom.array.erase([1,2,3,1], 1); // [2,3]

### append
	Array atom.array.append(Array target, Array source1, Array source2 ...)

Appends the passed array to the end of the current array.

	var myOtherArray = ['green', 'yellow'];
	atom.array.append(myOtherArray, ['red', 'blue']); // returns ['red', 'blue', 'green', 'yellow'];
	myOtheArray; // is now ['red', 'blue', 'green', 'yellow'];

	atom.array.append([0, 1, 2], [3, [4]], [6, 7]); // [0, 1, 2, 3, [4], 6, 7]

### combine
	Array atom.array.combine(Array target, Array source)

Includes to `target` all items from `source` excluding those already contained in `target`

	atom.array.combine([1, 2, 3], [2, 3, 4]); //[1, 2, 3, 4]

### pick
	atom.array.pick(Array source)

Returns first not an undefined item from `source` or null.

	atom.array.pick([null, undefined, 1, 2]); // 1
	atom.array.pick([]); // null

### invoke
	Array atom.array.invoke(Array array, Object|String context|methodName, ..args)

If `methodName` is string then applies method with name `methodName` of every item in `array` to item.
Else apply every item in `array` to context.

	atom.array.invoke([ [2,3,4], [35, 23, 4] ], 'sort', function (a, b) {
		return a > b ? 1 : a < b ? -1 : 0
	}); // [ [2,3,4], [4, 23, 35] ]

### shuffle
	Array atom.array.shuffle(Array array)

Shuffles items in `array`

### sortBy
	atom.array.sortBy(Array array, String property, Boolean reverse = false)

Sort array by property `property` value or method `property` returns value

	var array = [
		{ a: 15 },
		{ a: 32 },
		{ a: 10 }
	];

	atom.array.sortBy(array, 'a');

	/* result: [
		{ a: 10 },
		{ a: 15 },
		{ a: 32 }
	] */

	atom.array.sortBy(array, 'a', true);

	/* result: [
		{ a: 32 },
		{ a: 15 },
		{ a: 10 }
	] */


### min
	Number atom.array.min(Array array)

Returns minimum item in `array`, if array contain at least one not a number item then returns NaN.

	atom.array.min([2, 7, 5, 3]); // 2
	atom.array.min(["foo", 23 ]); // NaN

### max
	Number atom.array.max(Array array)

Returns maximum item in `array`, if array contain at least one not a number item then returns NaN.

	atom.array.max([2, 7, 5, 3]); // 7
	atom.array.max(["foo", 23 ]); // NaN

### mul
	Array atom.array.mul(Array array, Number factor)

Multiply all items of `array` to `factor`

	atom.array.mul([1,2,3], 3); // [3,6,9]

### add
	Array atom.array.add(Array array, Number number)

Add `number` to all items of `array`

	atom.array.add([1,2,3], 3); // [4,5,6]

### sum
	Number atom.array.sum(Array array)

Count sum of all items in `array`, if `array` contain not a number then returns NaN, if `array` is empty then returns 0.
	atom.array.sum([1,2,3,4]); // 10

### product
	Number atom.array.product(Array array)

Returns result of multiplying of all items in array, if `array` contain not a number then returns NaN, if `array` is empty then returns 1.
	atom.array.product([1,2,3,4]); // 24

### average
	Number atom.array.average(Array array)

Returns average value from all items from `array`, if `array` contain not a number then returns NaN, if `array` is empty then returns 0.

	atom.array.average([1, 2, 3, 4, 5 ]); // 3
	atom.array.average([1, 2, 3, "foo"]); // [3, NaN, 0]
	atom.array.average([              ]); // 0

### unique
	Array atom.array.unique(Array array)

Returns array with only unique values

	atom.array.unique([1,2,3,3,4,4,5]); // [1,2,3,4,5]

### associate
	Array atom.array.associate(Array array, Function|Array keys)

Associate array values with keys
if `keys` is `Array` it used as keys names, and array used as values
if `keys` if `Function` it used as function, generated values & array used as keys

	atom.array.accociate([1,2,3], ['a','b','c']); // {a:1,b:2,c:3}
	atom.array.accociate([1,2,3], function (item) {
		return item * 2;
	}); // {1:2,2:4,3:6}

### clean
	Array atom.array.clean(Array array)

Clean `array` from empty values & returns clear array

	atom.array.clean([1,2,3,null,undefined,4]); // [1,2,3,4]

### empty
	Array atom.array.empty(Array array)

Quickly erase all values from array

	var array = [1,2,3];
	atom.array.empty(array);
	array; // []
	
### hexToRgb
	String|Array atom.array.hexToRgb(Array array, boolean asArray = false)

Map `array` of hex strings to rgb values

	var hex = [ 'ff', '00', 'ff' ];

	atom.array.hexToRgb( hex ); // 'rgb(255,0,255)'
	atom.array.hexToRgb( hex, true ); // [255,0,255]


### rgbToHex
	String|Array atom.array.rgbToHex(Array array, boolean asArray = false)

Map `array` of rgb numbers to hex string

	var rgb = [ 255, 0, 255 ];

	atom.array.rgbToHex( rgb ); // '#ff00ff'
	atom.array.rgbToHex( rgb, true ); // ['ff', '00', 'ff']
	atom.array.rgbToHex( [0,0,0,0] ); // 'transparent'
