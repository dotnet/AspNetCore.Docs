new function () {

var undefined;

module('[Atom Plugins] Declare');

test('Creating', function(){

	var Foo = atom.declare({
		name: 'default',

		initialize: function (name) {
			this.name = name;
		},

		property: 0,
		setProperty: function(property) { this.property = property; },
		getProperty: function() { return this.property; },

		_accessor: 0,
		set accessor(accessor) { this._accessor = accessor * 2; },
		get accessor() { return this._accessor + 5; }
	});

	var foo = new Foo('fooName');
	var bar = new Foo('barName');

	// instance
	equal(typeof foo, 'object', 'typeof foo == "object"');
	ok(foo instanceof Foo, 'foo instanceof Foo');

	// methods
	equal(foo.name, 'fooName', 'Foo.initialize');

	equal(foo.property, 0, 'Foo.property default value');
	equal(foo.getProperty(), 0, 'Foo.getProperty() default value');

	foo.setProperty(7);
	equal(foo.property, 7, 'Foo.property new value');
	equal(foo.getProperty(), 7, 'Foo.getProperty() new value');

	// getters/setters
	foo.accessor = 9;
	equal(foo._accessor, 18, 'Property setter');
	equal(foo.accessor , 23, 'Property getter');
});

test('Extending', function(){
	var Foo = atom.declare({
		name: null,
		initialize: function (name) { this.name = name; },

		property: 0,
		setProperty: function(property) { this.property = property; },
		getProperty: function() { return this.property; },

		_accessor: 0,
		set accessor(accessor) { this._accessor = accessor * 2; },
		get accessor() { return this._accessor + 5; },

		fooProperty: 21,
		setFooProperty: function(fooProperty) { this.fooProperty = fooProperty; },
		getFooProperty: function() { return this.fooProperty; },

		parentProperty: 1,
		setParentProperty: function(parentProperty) { this.parentProperty = parentProperty; },
		getParentProperty: function() { return this.parentProperty; },

		_parentSetterTest: 0,
		set parentSetterTest(value) { this._parentSetterTest = value * 2; },
		get parentSetterTest() { return this._parentSetterTest * 3; }
	});

	var Bar = atom.declare({
		parent: Foo,

		prototype: {
			// test overload
			setProperty: function(property) {
				this.property = property * 2;
			},
			getProperty: function() { return this.property + 2; },

			// test independent properties
			barProperty: 0,
			setBarProperty: function(fooProperty) {
				this.barProperty = fooProperty;
			},
			getBarProperty: function() {
				return this.barProperty;
			},

			// test calling "parent" function
			setParentProperty: function method(parentProperty) {
				method.previous.call(this, parentProperty + 3);
			},
			getParentProperty: function method() {
				return method.previous.call(this) + 4;
			}
		}
	});


	var foo = new Foo('fooName');
	var bar = new Bar('barName');

	// instanceof
	ok(  foo instanceof Foo , '  foo instanceof Foo');
	ok(!(foo instanceof Bar), '!(foo instanceof Bar)');
	ok(  bar instanceof Foo , '  bar instanceof Foo');
	ok(  bar instanceof Bar , '  bar instanceof Bar');

	// methods
	equal(foo.name, 'fooName', 'Foo.initialize');
	equal(bar.name, 'barName', 'Bar.initialize');

	// Same in Foo
	equal(foo.property, 0, 'Foo.property default value');
	equal(foo.getProperty(), 0, 'Foo.getProperty() default value');
	foo.setProperty(7);
	equal(foo.property, 7, 'Foo.property new value');
	equal(foo.getProperty(), 7, 'Foo.getProperty() new value');

	// overloaded in Bar
	equal(bar.property, 0, 'Bar.property default value');
	equal(bar.getProperty(), 2, 'Bar.getProperty() overloaded');
	bar.setProperty(7);
	equal(bar.property, 14, 'Bar.property new value (overloaded)');
	equal(bar.getProperty(), 16, 'Bar.getProperty() new value (overloaded)');

	// Mathod "parent"
	equal(bar.parentProperty, 1, 'Bar.parentProperty default value');
	equal(bar.getParentProperty(), 5, 'Bar.getParentProperty() overloaded');
	bar.setParentProperty(7);
	equal(bar.parentProperty, 10, 'Bar.parentProperty new value (overloaded)');
	equal(bar.getParentProperty(), 14, 'Bar.getParentProperty() new value (overloaded)');

	// Setters/getters
	bar.accessor = 9;
	equal(bar._accessor, 18, 'Property setter is implemented');
	equal(bar.accessor,  23, 'Property getter is implemented');

});

test('Factory', function(){
	var Foo = atom.declare({
		name: 'Foo',

		firstname: null,
		lastname : null,
		initialize: function (firstname, lastname) {
			this.firstname = firstname;
			this.lastname  = lastname;
		}
	});

	var Bar = atom.declare({
		name: 'Bar',

		parent: Foo,

		prototype: {
			surname : null,
			initialize: function (firstname, lastname, surname) {
				Foo.prototype.initialize.call(this, firstname, lastname);
				this.surname = surname;
			}
		}
	});

	var foo = Foo.factory(['fooFN', 'fooLN']);
	var bar = Bar.factory(['barFN', 'barLN', 'barSN']);

	// instanceof
	ok(  foo instanceof Foo , '  foo instanceof Foo');
	ok(!(foo instanceof Bar), '!(foo instanceof Bar)');
	ok(  bar instanceof Foo , '  bar instanceof Foo');
	ok(  bar instanceof Bar , '  bar instanceof Bar');

	equal(foo.firstname, 'fooFN', 'foo.firstname');
	equal(foo.lastname , 'fooLN', 'foo.lastname');
	equal(bar.firstname, 'barFN', 'bar.firstname');
	equal(bar.lastname , 'barLN', 'bar.lastname');
	equal(bar.surname  , 'barSN', 'bar.surname');
});

test('Static', function(){

	var Foo = atom.declare({
		own: {
			fooStat: 'fooStatValue',
			qweStat: 'qweStatValue'
		},

		prototype: {}
	});

	var Bar = atom.declare({
		parent: Foo,
		own: {
			qweStat: 'qweStat[Bar]',
			barStat: 'barStatValue'
		},
		prototype: {}
	});

	var foo = new Foo();
	var bar = new Bar();

	equal(foo.constructor, Foo, 'correct Foo constructor');
	equal(bar.constructor, Bar, 'correct Bar constructor');

	equal(foo.constructor.fooStat, 'fooStatValue', 'foo.constructor.fooStat');
	equal(foo.constructor.qweStat, 'qweStatValue', 'foo.constructor.qweStat');
	equal(foo.constructor.barStat,      undefined, 'foo.constructor.barStat');

	equal(bar.constructor.fooStat, 'fooStatValue', 'bar.constructor.fooStat');
	equal(bar.constructor.qweStat, 'qweStat[Bar]', 'bar.constructor.qweStat');
	equal(bar.constructor.barStat, 'barStatValue', 'bar.constructor.barStat');
});

test('invoke', function () {

	var Foo = atom.declare( 'Foo', {
		initialize: function (x) {
			this.x = x;
		}
	});

	var foo = Foo(42);
	ok( foo instanceof Foo, 'Class invokation successful' );
	equal( foo.x, 42, 'Class construction successful' );

	var Bar = atom.declare( 'Bar', {
		own: {
			invoke: function iiinvoke () {
				return Foo.factory(arguments);
			}
		},

		prototype: {}
	});

	var bar = Bar(13);

	ok( !(bar instanceof Bar), 'Class invokation rewritten' );
	equal( bar.x, 13, 'Class invokation rewritten successful' );
});

test('bind', function () {

	var Foo = atom.declare({
		value: 'proto',
		initialize: function () {
			this.bindMethods([ 'foo' ]);
		},
		foo: function () {
			return this.value;
		},
		bar: function () {
			return this.value;
		}
	});

	var foo = new Foo();

	var cache = {
		value: 'object',
		foo: foo.foo,
		bar: foo.bar
	};

	equal( cache.foo(), 'proto' , 'method is binded' );
	equal( cache.bar(), 'object', 'method is not binded' );
});

test('AutoDefine', function () {

	var Foo = atom.declare( 'DeclareAutoDefine.Qux.Foo' );

	equal( Foo, DeclareAutoDefine.Qux.Foo, 'declare auto define' );
	equal( Foo.NAME, 'DeclareAutoDefine.Qux.Foo', 'defineName as constructor name' );

});

test('With Class', function () {

	var Foo = atom.declare({
		own: {
			nop: 'noob'
		},
		prototype: {
			initialize: function (value) {
				this.qwe = 'qwe ' + value;
			},
			method: function (value) {
				this.asd = 'asd ' + value;
			},
			another: function (value) {
				this.qux = 'qux ' + value;
			}
		}
	});

	var Bar = atom.Class({
		Extends: Foo,
		initialize: function (value) {
			this.parent('barI ' + value);
		},
		method: function (value) {
			this.parent('barM ' + value);
		}
	});

	equal(Bar.nop, 'noob', 'correct static extend');

	var bar = new Bar('ii');
	bar.method('mm');
	bar.another('aa');

	equal(bar.qwe, 'qwe barI ii', 'correct initialize parent');
	equal(bar.asd, 'asd barM mm', 'correct method parent');
	equal(bar.qux, 'qux aa'     , 'correct method without override');


});

module('[Atom Plugins] Declare Plugins');

asyncTest('Events', 9, function(){
	var events = new atom.Events({ foo: 'fooValue' });

	var callback = function (arg) {
		ok(true, 'Event fired!');
		equal(arg, 'bar', 'Argument is correct');
		equal(this.foo, 'fooValue', 'Context is correct');
	};

	events.add('foo', callback);
	events.fire( 'foo', ['bar'] );

	events.remove('foo', callback);
	events.fire( 'foo', ['qux'] );

	events.add( 'qwe', function (arg) {
		ok(true, 'Ready event pre-binded');
		equal(arg, 'rush', 'Ready event pre-binded argument is correct');
		equal(this.foo, 'fooValue', 'Ready event pre-binded context is correct');
	});
	events.ready( 'qwe', [ 'rush' ]);
	events.add( 'qwe', function (arg) {
		ok(true, 'Ready event post-binded');
		equal(arg, 'rush', 'Ready event post-binded argument is correct');
		equal(this.foo, 'fooValue', 'Ready event post-binded context is correct');
	});


	setTimeout(function () {
		start();
	}, 20);
});

test('Settings', function(){
	var settings = atom.Settings();

	var foo = { a: 15, b: 31, c: { m : 12 } };
	deepEqual(settings.values, {}, 'Empty options object');
	settings.set(foo);
	deepEqual(settings.values, foo, 'Recursive setting options');
	notEqual (settings.values, foo, 'Options cloned');

	var another = atom.Settings({ k: 15 });
	another.set({ z: 5 });
	deepEqual( another.values, { k: 15, z: 5 }, 'default options linked success');
});

};