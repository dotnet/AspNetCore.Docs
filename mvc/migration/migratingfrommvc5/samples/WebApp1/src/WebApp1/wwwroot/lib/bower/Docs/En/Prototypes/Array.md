Array extending
===============

Generally build-in type extending use `atom.%type%.*` methods, so here you will only see links to manual and examples

### See: [atom.array](https://github.com/theshock/atomjs/blob/master/Docs/En/Types/Math.md)

### Own properties

Next list of properties mixin to Array:

* range
* from
* pickFrom
* fill
* fillMatrix
* collect
* create
* toHash

##### example

	Array.range( from, to );
	// equals to:
	atom.array.range( from, to );
	
### prototype extending

Next properties mixed in to prototype, where first property is `this` array:

* randomIndex
* property
* contains
* include
* append
* erase
* combine
* pick
* invoke
* shuffle
* sortBy
* min
* max
* mul
* add
* sum
* product
* average
* unique
* associate
* clean
* empty
* clone
* hexToRgb
* rgbToHex

##### example
	var myArray = [1,2,3];

	myArray.include( 4 );
	// equals to:
	atom.array.include( myArray, 4 );
	
	// and
	
	myArray.sum()
	// equals to:
	atom.array.sum( myArray );
	
### Own properties

* `last` - returns last element in array

		var myArray = ['foo','bar','qux'];
		console.log( myArray.last ); // 'qux'

* `random` - returns random property of array:

		var myArray = ['foo','bar','qux'];
		console.log( myArray.random ); // 'foo' or 'bar' or 'qux'


