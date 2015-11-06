Atom Extended Core
==================

## atom.extend(object = atom, from)

Extend `object` with `from` properties.

#### Example: config
	config = atom.core.extend({
		// default values for config
		a : 15,
		b : 20
	}, config);

#### Example: extending atom
	atom.core.extend({
		value: 123
	});
	alert(atom.value); // 123


## atom.core.implement(object = atom, from)

Extend `object.prototype` with `from` properties.

#### Example: class extends
	atom.core.implement(child, parent);

#### Example: expanding atom
	atom.core.implement({
		test: function () {
			alert(123);
		}
	});
	var a = atom();
	a.test(); // 123

## atom.clone(object)
Returns clone of object

	var cloneArray = atom.core.clone(oldArray);

## atom.typeOf(object)
Returns type of object:

	atom.core.typeOf( document.body ) == 'element'
	atom.core.typeOf(  function(){} ) == 'function'
	atom.core.typeOf(    new Date() ) == 'date'
	atom.core.typeOf(          null ) == 'null'
	atom.core.typeOf(     arguments ) == 'arguments'
	atom.core.typeOf(        /abc/i ) == 'regexp'
	atom.core.typeOf(            [] ) == 'array'
	atom.core.typeOf(            {} ) == 'object'
	atom.core.typeOf(            15 ) == 'number'
	atom.core.typeOf(          true ) == 'boolean'

	var MyClass = atom.Class({});
	atom.core.typeOf( new MyClass() ) == 'class'