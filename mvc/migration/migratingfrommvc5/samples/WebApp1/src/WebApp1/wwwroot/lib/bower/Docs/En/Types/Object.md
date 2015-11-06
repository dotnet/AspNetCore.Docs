atom.object
===========

Provides methods to operate with object

#### append(target, source1, source2, ... )

Appends source objects content to target

	var source = { a: 1, b: 2, c: 3 };

	atom.object.append( source, {d:4}, {e:5} );

	console.log( source ); // { a: 1, b: 2, c: 3, d: 4, e: 5 };

#### invert(object)

Returns inverted object - where keys is values & values is keys.

	var source = { a: 1, b: 2, c: 3 };
	var result = atom.object.invert( source );

	console.log( result ); // { 1: 'a', 2: 'b', 3: 'c' };


#### collect(object, Array properties, mixed default = undefined)

Returns subset with only `properties` as keys

	var source = { a: 1, b: 2, c: 3 };
	var result = atom.object.collect( source, [ 'a', 'b', 'e', 'x' ], 42 );
	
	console.log( result ); // { a: 1, b: 2, e: 42, x: 42 };

#### values(object)

Returns array of object values

	var source = { a: 1, b: 2, c: 3 };
	var result = atom.object.values( source );
	console.log( result ); // [1,2,3]

#### map(object, callback)

Returns new object, which has mapped with `callback` values:

	
	var source = { a: 1, b: 2, c: 3 };
	var result = atom.object.map( source, function (value, key) {
		return value * value;
	});

	console.log( result ); // { a: 1, b: 4, c: 9};

#### max(object)

Returns key, where max value contains

	var source = { x: 42, a: 1, b: 2, c: 3 };
	console.log( atom.object.max(source) ); // 'x'

#### min(object)

Returns key, where min value contains

	var source = { x: 42, a: 1, b: 2, c: 3 };
	console.log( atom.object.max(source) ); // 'a'
	
#### isEmpty(object)

Checks if object is empty

	console.log( atom.object.isEmpty({   }) ); // true
	console.log( atom.object.isEmpty({a:1}) ); // false
	
#### path.get(object, path)

Returns value by the path.

	var source = {
		foo: {
			bar: {
				qux: 123
			}
		}
	};
	
	console.log( atom.object.path.get(source, 'foo.bar.qux') ); // 123
	console.log( atom.object.path.get(source, 'nil.bar.qux') ); // undefined

#### path.set(object, path)

Sets value by the path.

	var source = {
		foo: {
			bar: {
				qux: 123
			}
		}
	};
	
	atom.object.path.set(source, 'foo.bar.qux', 42 );
	atom.object.path.set(source, 'nil.bar.qux', 13 );
	atom.object.path.set(source, 'foo.bar.qwe', 99 );
	atom.object.path.set(source, 'foo.sub'  , 9126 );
	
	console.log( source ); /* {
		foo: {
			bar: {
				qux: 42,
				qwe: 99
			},
			sub: 9126
		},
		nil: {
			bar: { qux: 13 }
		}
	} */

Can be used to safely create namespaces:

	atom.object.path.set( window, 'My.Namespace.Foo', function () {
		// My.Namespace.Foo function
	});

	atom.object.path.set( window, 'My.Namespace.Bar', function () {
		// My.Namespace.Bar function
	});