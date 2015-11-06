new function () {
var undefined;
module('[Atom Plugins] Class');

test('Creating', function(){
	var Foo = atom.Class({
		name: null,
		initialize: function (name) {
			this.name = name;
		},

		property: 0,
		setProperty: function(property) { this.property = property; },
		getProperty: function() { return this.property; },

		_etter: 0,
		set etter(etter) { this._etter = etter * 2; },
		get etter() { return this._etter + 5; }
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
	foo.etter = 9;
	equal(foo._etter, 18, 'Property setter');
	equal(foo.etter, 23, 'Property getter');
});

test('Extending', function(){
	var Foo = atom.Class({
		name: null,
		initialize: function (name) { this.name = name; },

		property: 0,
		setProperty: function(property) { this.property = property; },
		getProperty: function() { return this.property; },

		_etter: 0,
		set etter(etter) { this._etter = etter * 2; },
		get etter() { return this._etter + 5; },

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

	var Bar = atom.Class({
		Extends: Foo,

		// test overload
		setProperty: function(property) { this.property = property * 2; },
		getProperty: function() { return this.property + 2; },

		// test independent properties
		barProperty: 0,
		setBarProperty: function(fooProperty) { this.barProperty = fooProperty; },
		getBarProperty: function() { return this.barProperty; },

		// test calling "parent" function
		setParentProperty: function(parentProperty) { this.parent(parentProperty + 3); },
		getParentProperty: function() { return this.parent() + 4; }
	});

	var Qux = atom.Class({
		Extends : Bar,
		initialize: function (name) { this.parent(name) },
		setParentProperty: function(parentProperty) { this.parent(parentProperty + 3); },
		getParentProperty: function() { return this.parent() + 4; }
	});


	var foo = new Foo('fooName');
	var bar = new Bar('barName');
	var qux = new Qux('quxName');

	// instanceof
	ok(  foo instanceof Foo , '  foo instanceof Foo');
	ok(!(foo instanceof Bar), '!(foo instanceof Bar)');
	ok(!(foo instanceof Qux), '!(foo instanceof Qux)');
	ok(  bar instanceof Foo , '  bar instanceof Foo');
	ok(  bar instanceof Bar , '  bar instanceof Bar');
	ok(!(bar instanceof Qux), '!(bar instanceof Qux)');
	ok(  qux instanceof Foo , '  qux instanceof Foo');
	ok(  qux instanceof Bar , '  qux instanceof Bar');
	ok(  qux instanceof Qux , '  qux instanceof Qux');

	// methods
	equal(foo.name, 'fooName', 'Foo.initialize');
	equal(bar.name, 'barName', 'Bar.initialize');
	equal(qux.name, 'quxName', 'Qux.initialize');

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

	// chain of .parent
	equal(qux.parentProperty, 1, 'Qux.parentProperty default value');
	equal(qux.getParentProperty(), 9, 'Qux.getParentProperty() overloaded');
	qux.setParentProperty(7);
	equal(qux.parentProperty, 13, 'Qux.parentProperty new value (overloaded)');
	equal(qux.getParentProperty(), 21, 'Qux.getParentProperty() new value (overloaded)');

	// parent of parent method
	equal(qux.fooProperty, 21, 'parent of parent method');

	// Setters/getters
	bar.etter = 9;
	equal(bar._etter, 18, 'Property setter is implemented');
	equal(bar.etter,  23, 'Property getter is implemented');
	

});

test('Factory', function(){
	var Foo = atom.Class({
		firstname: null,
		lastname : null,
		initialize: function (firstname, lastname) {
			this.firstname = firstname;
			this.lastname  = lastname;
		}
	});

	var Bar = atom.Class({
		Extends: Foo,
		surname : null,
		initialize: function (firstname, lastname, surname) {
			this.parent(firstname, lastname);
			this.surname = surname;
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
	var Foo = atom.Class({
		Static: {
			fooStat: 'fooStatValue',
			qweStat: 'qweStatValue'
		}
	});

	var Bar = atom.Class({
		Extends: Foo,
		Static: {
			qweStat: 'qweStat[Bar]',
			barStat: 'barStatValue'
		}
	});

	var foo = new Foo();
	var bar = new Bar();

	equal(foo.self.fooStat, 'fooStatValue', 'foo.self.fooStat');
	equal(foo.self.qweStat, 'qweStatValue', 'foo.self.qweStat');
	equal(foo.self.barStat,      undefined, 'foo.self.barStat');
	equal(bar.self.fooStat, 'fooStatValue', 'bar.self.fooStat');
	equal(bar.self.qweStat, 'qweStat[Bar]', 'bar.self.qweStat');
	equal(bar.self.barStat, 'barStatValue', 'bar.self.barStat');
});

test('hiddenMethod', function () {
	var Foo = atom.Class({
		value: 'original',
		initialize: atom.Class.hiddenMethod(function () {
			this.value = 42;
		}),
		method: atom.Class.hiddenMethod(function () {
			this.value = 123;
		})
	});

	var Bar = atom.Class({
		Implements: [ Foo ]
	});

	var bar = new Bar();

	equal( bar.value, 'original', 'hidden constructor hide correctly');
	equal( typeof bar.method, 'undefined', 'hidden method hide correctly');
});

test('invoke', function () {

	var Foo = atom.Class({
		initialize: function (x) {
			this.x = x;
		}
	});

	var foo = Foo(42);
	ok( foo instanceof Foo, 'Class invokation successful' );
	equal( foo.x, 42, 'Class construction successful' );

	var Bar = atom.Class({
		Static: {
			invoke: function () {
				return Foo.factory(arguments);
			}
		}
	});

	var bar = Bar(13);

	ok( !(bar instanceof Bar), 'Class invokation rewritten' );
	equal( bar.x, 13, 'Class invokation rewritten successful' );
});


module('[Atom Plugins] Class Plugins');

test('Events', function(){
	// todo: write tests.
	expect(2);

	var Eventable = atom.Class({
		Implements: [atom.Class.Events]
	});

	var eventable = new Eventable();

	eventable.addEvent('foo', function (arg) {
		ok(true, 'Event fired!');
		equal(arg, 'bar', 'Argument is correct!');
	});

	eventable.fireEvent('foo', ['bar']);
});

test('Options', function(){
	var Foo = atom.Class({
		Implements: [ atom.Class.Options ]
	});

	var foo = new Foo();
	var fooOptions = { a: 15, b: 31, c: { m : 12 } };
	deepEqual(foo.options, {}, 'Empty options object');
	foo.setOptions(fooOptions);
	deepEqual(foo.options, fooOptions, 'Recursive setting options');
	notEqual (foo.options, fooOptions, 'Options cloned');
	fooOptions.b = 3;
	fooOptions.d = 4;
	foo.setOptions({ b : 3 } , { d : 4 });
	deepEqual(foo.options, fooOptions, 'Several arguments added');

	var Bar = atom.Class({
		Implements: [ atom.Class.Options ],
		options: { k: 15 }
	});
	var bar  = new Bar();
	var bar2 = new Bar();
	bar.setOptions({ z: 5 });

	deepEqual( bar.options, { k: 15, z: 5 }, 'default options linked success');
	deepEqual(bar2.options, { k: 15 },       'options cloned');
});

test('bindAll', function(){
	var Overall = atom.Class({
		initialize: function (title) { this.title = title; },
		getTitle  : function (     ) { return this.title; },
		getTitle2 : function (     ) { return this.title; }
	});

	var BindAll = atom.Class({
		Extends: Overall,

		initialize: function (title) {
			atom.Class.bindAll( this );
			this.parent(title);
		}
	});

	var BindOne = atom.Class({
		Extends: Overall,

		initialize: function (title) {
			atom.Class.bindAll( this, [ 'getTitle' ]);
			this.parent(title);
		}
	});

	var overall = new Overall('oa');
	var bindAll = new BindAll('ba');
	var bindOne = new BindOne('bo');

	raises(function () {
		(1, overall.getTitle )();
	}, TypeError, 'Plain - context losted');
	raises(function () {
		(1, overall.getTitle2 )();
	}, TypeError, 'Plain - context losted');
	equal( (1, bindAll.getTitle )(),      'ba', 'bindAll - context saved' );
	equal( (1, bindAll.getTitle2)(),      'ba', 'bindAll - context saved' );
	equal( (1, bindOne.getTitle )(),      'bo', 'bindOne - context saved' );
	raises(function () {
		(1, bindOne.getTitle2 )();
	}, TypeError, 'bindOne - context losted');
});

};