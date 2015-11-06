# atom.Class.Options

Let you add options property to your class

	MyClass = atom.Class({
		Implements: [ atom.Class.Options ],
		options : { // default options
			foo: 15,
			bar: 42
		}
	});

	var my = new MyClass();

	my.setOptions({
		foo: 3,
		qux: 100
	});

	atom.log(my.options); // {foo: 3, bar: 42, qux: 100}

*note* never set options property, or one of the option directly. Always use `setOptions` for it.

You can add several arguments to `setOptions`, which will be apply one-by-one

	MyClass = atom.Class({
		Implements: [ atom.Class.Options ]
	});

	var my = MyClass.factory();
	my.setOptions({ a: 15 }, { b: 33 });
	atom.log(my.options); // { a: 15, b: 33 };

### With events

When class also implement `atom.Class.Events` - you can set events using `on*`

	MyClass = atom.Class({
		Implements: [
			atom.Class.Options,
			atom.Class.Events
		]
	});

	var my = new MyClass;

	my.setOptions({
		onClick: atom.log
	});

	// equals to

	my.addEvent('click', atom.log);