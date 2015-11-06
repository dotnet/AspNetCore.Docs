Atom Core
=========

* title: ore
* group: core


## atom.core.isFunction(fn)

Checks if `fn` is function

	if (atom.core.isFunction(object.method)) {
		object.method();
	}

## atom.core.objectize(key, value)

If `key` is not object - returns object, where `key` is single key & `value` is value of this key.
Else - returns `key`

	atom.core.objectize( 'test', 'foo' ); // { test: 'foo' )
	atom.core.objectize({ test: 'foo' }); // { test: 'foo' )

Can be used, when you what to be sure, you works with object:

	method: function (callback, nameOrHash, value) {
		var hash = atom.core.objectize(nameOrHash, value);
		for (var i in hash) {
			// do
		}
	}

## atom.core.contains(array, value)

Checks is array contains value. Is similar to `array.indexOf(value) != -1`

	if (atom.core.contains(['first', 'second'], value)) {
		// do smth
	}

## atom.core.includeUnique(array, value)

Push `value` to `array` if it doesn't contains it;

	atom.core.includeUnique( [1,2,3], 1 ); // [1,2,3  ]
	atom.core.includeUnique( [1,2,3], 4 ); // [1,2,3,4]

## atom.core.eraseOne(array, value)

Erase first `value` from `array`

	atom.core.eraseOne( [1,2,3,2,1], 2 ); // [1,3,2,1]

## atom.core.eraseAll(array, value)

Erase all `value` from `array`

	atom.core.eraseAll( [1,2,3,2,1], 2 ); // [1,3,1]

## atom.core.toArray(arrayLikeObject)

Cast `arrayLikeObject` (array, DomCollection, arguments) to `Array`

	var args = atom.core.toArray(arguments);

## atom.core.isArrayLike(object)

Checks if `object` is arrayLike

	if (atom.core.isArrayLike(object)) {
		for (var i = 0; i < object.length; i++) {
			// do
		}
	}

## atom.core.append(target, source)

Append all properties from sourceto target

	var target = { a: 1 };
	var source = { b: 2 };
	atom.core.append( target, source );
	console.log(target); // { a: 1, b: 2 }




JavaScript 1.8.5 Compatiblity
=============================

Browsers, which do not have JavaScript 1.8.5 compatibility, will get those methods implemented:

* [Function.prototype.bind](https://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Function/bind)
* [Object.keys](https://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Object/keys)
* [Array.isArray](https://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Array/isArray)
