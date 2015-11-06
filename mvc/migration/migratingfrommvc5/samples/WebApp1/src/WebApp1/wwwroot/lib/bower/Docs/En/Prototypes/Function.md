Function extending
==================

Generally build-in type extending use `atom.%type%.*` methods, so here you will only see links to manual and examples

### See: [atom.fn](https://github.com/theshock/atomjs/blob/master/Docs/En/Types/Function.md)

### Own properties

* `after` - Equals to `atom.fn.after`
* `lambda` - Equals to `atom.fn.lambda`

### Prototype extending

#### delay

	Function delay( Number time, mixed context = null, Array arguments = [] );
	
equivalent to `setTimeout`, easy wat to launch function `time` later.

	object.method.delay( 500, object, [ 1, 'foo' ] );
	// equals to:
	setTimeout( object.method.bind( object, 1, 'foo' ), 500 );

#### periodical

	Function periodical( Number time, mixed context = null, Array arguments = [] );
	
equivalent to `setInterval`, easy wat to launch function `time` later.

	object.method.periodical( 500, object, [ 1, 'foo' ] );
	// equals to:
	setInterval( object.method.bind( object, 1, 'foo' ), 500 );
