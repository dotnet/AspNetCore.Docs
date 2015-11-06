Atom Accessors
==============

## atom.accessors.has(object, prop)

Checks if `object` has getter or setter for property `prop` as own property, or in prototype chain

#### Example:
	var object = {
		set foo () {}
	};

	atom.accessors.has(object, 'foo'); // true
	atom.accessors.has(object, 'bar'); // false

## atom.accessors.define(object, prop, value)

Defines setter or getter of `object` with name `prop`

#### Example:
	var object = {};

	atom.accessors.define(object, 'foo', {
		set: function (value) { console.log('object.foo Setter'); )
		get: function ()      { console.log('object.foo Getter'); )
	});

	object.foo = 123; // object.foo Setter
	object.foo + 123; // object.foo Getter

## atom.accessors.lookup(object, prop)

Get accessors from `object` with name `prop`

#### Examples:
	var object = {
		set foo(value) { console.log('object.foo Setter'); ),
		get foo()      { console.log('object.foo Getter'); ),

		bar: 123
	};
	
	console.log(atom.accessors.lookup(object, 'bar')); // null

	var accessors = atom.accessors.lookup(object, 'foo');
	/* accessors equals to object:
	 * {
	 *   set: function (value) { console.log('object.foo Setter'); )
	 *   get: function ()      { console.log('object.foo Getter'); )
	 * }
	 */

## atom.accessors.inherit(from, to, prop)
Inherit accessors from `from` to `to` with name `prop` and return `true`, or return `false`

	var Parent = {
		get foo() { return 'Parent.foo'; },
		bar: 'Parent.bar'
	};

	var Child = {};

	atom.accessors.inherit(Parent, Child, 'foo'); // true
	atom.accessors.inherit(Parent, Child, 'bar'); // false

	/* accessors equals to:
	 * {
	 *   get foo() { return 'Parent.foo'; }
	 * }
	 */