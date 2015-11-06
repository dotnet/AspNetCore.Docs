# atom.Class

Wrapper for native prototype-based OOP

### Base class creating
	var NameLogger = atom.Class({
		log : function (msg) {
			atom.log(this.name, msg);
			return this;
		}
	});

### Class creating with constuctor, static variable
	var Animal = atom.Class({
		Extends: NameLogger,
		Static: {
			staticProperty: 'animal'
		},
		initialize : function (name) {
			this.name = name;
			this.log('Animal.initialize');
		},
		walk : function () {
			this.log('Animal.walk');
		}
	});

### Extending classes
	var Dog = atom.Class({
		Extends: Animal,
		initialize : function (name, breed) {
			this.parent(name);
			this.breed = breed;
			this.log('Dog.initialize');
		},
		bark : function () {
			return this.log('Dog.bark');
		},
		logStatic : function () {
			this.log(this.self.staticProperty);
		},
		isSelf : function () {
			return this instanceof this.self; // always true
		}
	});

### using
	var dog = new Dog('Box', 'shepherd');
	dog.bark();
	dog.walk();
	atom.log(dog instanceof Animal); // true
	atom.log(dog instanceof Dog); // true

### Factory method:
	var cat = Animal.factory(['Tom']);
	var dog = Dog.factory(['Max', 'dalmatian']);

### Invoking Class
You can invoke your Class without `new`. As default it just creates new instance:

	var MyClass = atom.Class({});

	new MyClass(5, 42);
	// similar to
	MyClass(5, 42);

But you can change this behaviour, changing Static method `invoke`:

	var MyClass = atom.Class({
		Static: {
			invoke: function (first, second) {
				alert( first + second );
				return this.factory( arguments );
			}
		}
	});

	// Just creates new instance:
	var mc = new MyClass(5, 42);

	// Alerts 47, than create instance
	var mc = MyClass(5, 42);

You even can create width this way instances of another class:

	var Foo = atom.Class({});

	var Bar = atom.Class({
		Static: {
			invoke: function () {
				return Foo.factory( arguments );
			}
		}
	});

	var bar = new Bar();
	var foo =     Bar();

	console.log(
		bar instanceof Bar, // true
		bar instanceof Foo, // false
		foo instanceof Bar, // false
		foo instanceof Foo  // true
	);

### Properties
`self` You can use property "self" to get the link to the class as in methods `logStatic` and `isSelf`

`parent` You can use method `parent` to call method with the same name of the parent

`factory` You can use static factory property to create instance of object with array of arguments

	new Point(3, 8);
	// equals to
	Point.factory([3, 8]);

*note*: `self`, `parent` & `factory` are reserved properties and you can't override them

### Methods
Available some methods helpers:

`abstractMethod`, which thrown mistake if is not overriden

`protectedMethod`, which can be called only with parents

`hiddenMethod`, which not implemented in children (not equals to private)

	var MyClass = atom.Class({
		abstr: atom.Class.abstractMethod,

		initialize: atom.Class.hiddenMethod(function () {
			atom.log('initilize will not be implemented by children (hidden)');
		}),

		prot: atom.Class.protectedMethod(function() {
			atom.log('this is protected method');
		})
	});

### Accessors
You can use accessors!

	var Foo = atom.Class({
		_bar: 0,
		set bar (value) {
			this._bar = value * 2;
		},
		get bar () {
			return 'Foo.bar: ' + this._bar;
		}
	});

	var foo = new Foo;
	foo.bar = 21;
	log(foo.bar); // 'Foo.bar: 42'

### Expanding prototype, no reset
Unlike the MooTools we dont reset each object. So the objects are links in prototype:

	var MyClass = atom.Class({
		settings: {},
		initialize: function (width, height) {
			this.settings.width  = width;
			this.settings.height = height;
		}
	});

	var small = new MyClass(100, 100);
	var big   = new MyClass(555, 555);

	atom.log(small.settings. == big.settings); // true
	atom.log(small.settings.width, small.settings.height); // (555, 555)

So, use constructor object creating instead:

	var MyClass = atom.Class({
		initialize: function (width, height) {
			this.settings = {};
			this.settings.width  = width;
			this.settings.height = height;
		}
	});

	var small = new MyClass(100, 100);
	var big   = new MyClass(555, 555);

	atom.log(small.settings. == big.settings); // false
	atom.log(small.settings.width, small.settings.height); // (100, 100), as expected

# Default Mutators

### Static
Let you to add static properties:

	MyClass = atom.Class({
		Static: {
			staticProperty: 15,
			staticMethod  : function () { return 88; }
		}
	});

	atom.log(MyClass.staticProperty); // 15
	atom.log(MyClass.staticMethod()); // 88

### Extends
Let you to extends one class from another. You can call `parent` to access method with same name of parent class.
Unlimited nesting is available. Accessors are implemented, but you can't call `parent` from them

	var Foo = atom.Class({
		initialize: function () {
			log('Foo.initialize');
		},
		fooMethod: function () {
			log('Foo.fooMethod');
		},
		genMethod: function (arg) {
			log('genMethod: ' + arg);
		},
		get accessor () {
			return 100;
		}
	});

	var Bar = atom.Class({
		Extends: Foo,
		initialize: function () {
			this.parent(); // 'Foo.initialize'
			log('Bar.initialize');
			this.fooMethod(); // 'Foo.fooMethod'
		},
		genMethod: function () {
			this.parent(42); // 'genMethod: 42'
			alert(this.accessor); // 100
		}
	});

	var Qux = atom.Class({
		Extends: Bar,
		initialize: function () {
			this.parent(); // 'Foo.initialize', 'Bar.initialize'
			log('Qux.initialize');
		},
		get accessor () {
			return this.parent() + 1; // Error
		}
	});

	var foo = new Foo();
	var qux = new Qux();

	foo instanceof Foo; // true
	foo instanceof Qux; // false

	qux instanceof Foo; // true
	qux instanceof Qux; // true

### Implements
Let you mixin properties from some classes. You can't access mixin properties using "parent"

	Bar = atom.Class({
		barMethod: function () {
			log('Bar.barMethod');
		}
	});
	Qux = atom.Class({
		quxMethod: function () {
			log('Qux.quxMethod');
		}
	});

	Foo = atom.Class({
		Implements: [ Bar, Qux ],
		fooMethod: function () {
			log('Foo.fooMethod');
			this.quxMethod(); // 'Qux.quxMethod'
		},
		barMethod: function () {
			this.parent(); // Error('The method «barMethod» has no parent.');
		}
	});

	var foo = new Foo;
	foo instanceof Foo; // true
	foo instanceof Bar; // false
	foo instanceof Qux; // false

