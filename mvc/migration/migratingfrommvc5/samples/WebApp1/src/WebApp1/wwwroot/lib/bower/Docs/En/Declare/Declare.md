atom.declare
============

Light and fast wrapper for native prototype-based OOP.

	Function atom.declare( String declareName = null, Function parent = null, Object params = null )
	Function atom.declare( Object params )

Each argument is optional. Returns constructor that can be called with "new".

#### Example:

	var Foo = atom.declare({
		fooMethod: function () {}
	});
	
	var Bar = atom.declare( Foo );

### params

`params` object without `prototype` property is recognized as `prototype`, otherwise it is parsed with the following rules:

* `name` - name of the resulting constructor and instances. Can be used for debugging, and is returned by `toString` method
		
		var C = atom.declare({
			name: 'FooQux',
			prototype: {}
		});
		console.log( new C().toString() ); // '[object FooQux]'

* `declareName` - property created by library. Can be used for easy namespace creation. It will automaticaly create all nessesary objects

		atom.declare({
			declareName: 'Foo.Qux.Bar',
			name: 'FQB',
			prototype: {}
		});
		console.log( new Foo.Qux.Bar().toString() ); // '[object FQB]'
	
* `prototype` - with object will be mixed to constructor prototype

		var Foo = atom.declare({
			prototype: {
				fooMethod: function () {
					return 'Foo#fooMethod';
				}
			}
		});
		
		console.log( new Foo().fooMethod() ); // 'Foo#fooMethod'
	
* `parent` - this constructor will be parent of result constructor

		var Foo = atom.declare({
			prototype: {
				fooMethod: function () {
					return 'Foo#fooMethod';
				}
			}
		});
		var Bar = atom.declare({
			parent: Foo,
		
			prototype: {
				barMethod: function () {
					return 'Bar#barMethod';
				}
			}
		});
		
		var foo = new Foo();
		var bar = new Bar();
		
		console.log( foo instanceof Foo ); // true
		console.log( foo instanceof Bar ); // false
		console.log( bar instanceof Foo ); // true
		console.log( bar instanceof Bar ); // true
		
		console.log( foo.fooMethod() ); // 'Foo#fooMethod'
		console.log( bar.fooMethod() ); // 'Foo#fooMethod'
		console.log( bar.barMethod() ); // 'Bar#barMethod'
	
* `own` - this properties will be mixed to constructor as static:

		var Foo = atom.declare({
		
			own: { fooProp: 'foo-static-prop' },
			prototype: {}
		});
		
		var Bar = atom.declare({
			parent: Foo,
			own: { barProp: 'bar-static-prop' },
			prototype: { }
		});
		
		console.log( Foo.fooProp ); // 'foo-static-prop'
		console.log( Bar.fooProp ); // 'foo-static-prop'
		console.log( Bar.barProp ); // 'bar-static-prop'
	
### alternate constructor params

You can use alternate optional constructor params.

	Function atom.declare( String declareName = null, Function parent = null, Object params = null )
	
* `declareName` - will set `name` & `declareName` of original params, so:

		atom.declare( 'Foo.Bar', {
			prototype: { test: 1241 } 
		});
		
		// equals to:
		
		atom.declare({
			declareName: 'Foo.Bar',
			name: 'Foo.Bar',
			prototype: { test: 1241 }
		});

* `parent` - will set `parent` of original params, so:

		atom.declare( Foo );
		
		// equals to: 
		
		atom.declare({
			parent: Foo,
			prototype: {}
		});

Also, you can skip `prototype` property in `params` if you want `params` to be `prototype`:

	atom.declare({
		prototype: {
			foo: 123,
			bar: function () {
				return this.foo;
			}
		}
	});
	
	// equals to:
	
	atom.declare({
		foo: 123,
		bar: function () {
			return this.foo;
		}
	});

That's why if you want empty `prototype` - you should set it manualy:

	// wrong way: 
	atom.declare({
		own: {/* static methods here */}
	});
	// it equals to: 
	atom.declare({
		prototype: {
			own: {/* static methods here */}
		}
	});
	// right way:
	atom.declare({
		own: {/* static methods here */},
		prototype: {}
	});
	
### static methods of result constructor:

* `own` - will mixin properties as static to constructor:

		var Foo = atom.declare({});
		Foo.own({ a: 123 });
		console.log( Foo.a ); // 123

* `factory` - will produce object from array of params. It can be used, if you want to construct object from array (as `.apply` method of function):

		Foo.factory( [42, 'string', {test: null}] )
		// equals to:
		new Foo(42, 'string', {test: null});

### initialize

`initialize` method in prototype will be called on instance construction:

	var Foo = atom.declare({
		initialize: function (id) {
			console.log( 'Foo#initialize', id );
			this.id = id;
		}
 	});
	
	var foo = new Foo(42); // Foo#initialize 42
	console.log( foo.id ); // 42

### extended methods

Library mixin two properties to your methods - `path` & `previous` (if exists). You can access to them by named function:

	atom.declare( 'Foo', {
		method: function YOUR_NAME_HERE () {
			// use YOUR_NAME_HERE.%property%
		}
	});

Such way is fast & easy for debug.

`path` property shows full path to method & can be used for logging:

	atom.declare( 'Foo.Bar', {
		testPathProperty: function method () {
			console.log( 'Invoke: ', method.path, arguments );
		}
	});
	
	new Foo.Bar().testPathProperty(); // Invoke: Foo.Bar#testPathProperty [13, 42]

`previous` can be used for calling parent method. It contains link to method, that way previous with that name or null. You should call it with manual context set using `.call` or `.apply`

	atom.declare( 'Foo', {
		testPrevious: function method (arg) {
			console.log( method.path, arg );
		}
	});

	atom.declare( 'Bar', Foo, {
		testPrevious: function method (arg) {
			method.previous.call(this, arg);
			console.log( method.path, arg );
			method.previous.call(this, 95612);
		}
	});
	
	new Bar().testPrevious(42);
	/* Foo#testPrevious 42
	 * Bar#testPrevious 42
	 * Foo#testPrevious 95612
	 */

Use `previous` property carefull - calling without `.call(this)` will provide wrong context & calling `null` property will throw an error:

	
	atom.declare( 'Fail', {
		testPrevious: function method () {
			method.previous.call(this);
		}
	});
	
	new Fail().testPrevious(); // TypeError: Cannot call method 'call' of undefined

	



