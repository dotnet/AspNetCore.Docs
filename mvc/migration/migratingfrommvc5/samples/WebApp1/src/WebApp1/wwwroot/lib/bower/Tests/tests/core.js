
new function(undefined) {

module('[Atom Core]');

test('Initialize', function(){
	ok( atom, 'atom' );
});
test('JavaScript 1.8.5 Compatiblity', function(){
	equal( typeof (function(){}.bind) , 'function', 'typeof function(){}.bind' );
	equal( typeof Object.keys  , 'function', 'typeof Object.keys' );
	equal( typeof Array.isArray, 'function', 'typeof Array.isArray' );

	ok(  Array.isArray([]), ' Array.isArray([])' );
	ok( !Array.isArray({}), '!Array.isArray({})' );

	deepEqual( Object.keys({3:3,a:1,b:2}), ['3','a','b'], 'Object.keys({a:1,b:2,3:3})' );
});
test('atom.typeOf', function(){
	equal( atom.typeOf(document.body), 'element'  , 'atom.typeOf(document.body)');
	equal( atom.typeOf(function(){}) , 'function' , 'atom.typeOf(function(){})');
	equal( atom.typeOf(new Date())   , 'date'     , 'atom.typeOf(new Date())');
	equal( atom.typeOf(null)     , 'null'     , 'atom.typeOf(null)');
	equal( atom.typeOf(arguments), 'arguments', 'atom.typeOf(arguments)');
	equal( atom.typeOf(/abc/i)   , 'regexp'   , 'atom.typeOf(/abc/i)');
	equal( atom.typeOf([])       , 'array'    , 'atom.typeOf([])');
	equal( atom.typeOf({})       , 'object'   , 'atom.typeOf({})');
	equal( atom.typeOf(15)       , 'number'   , 'atom.typeOf(15)');
	equal( atom.typeOf(true)     , 'boolean'  , 'atom.typeOf(true)');
});
test('atom.clone', function(){
	// array cloning
	var mixed, object, array, clone;
	array = [1,2,3,[4,5]];
	clone = atom.clone(array);
	notStrictEqual(clone, array, 'array !== clone');
	deepEqual(clone, array, 'clone is same to array');
	clone[4] = 'changed';
	notDeepEqual(clone, array, 'clone is changed');

	// hash cloning
	object = {a:'2', b:'3', array: [1,2,3], object: {foo:'bar'}};
	clone = atom.clone(object);
	notStrictEqual(clone, object, 'object !== clone');
	deepEqual(clone, object, 'clone is same to object');
	clone['prop'] = 'changed';
	notDeepEqual(clone, object, 'clone is changed');

	// object cloning
	var Foo = function (name) { this.name = name; };
	var Bar = function (name) {
		this.name = name;
		this.clone = function () {
			return new Bar('clone of ' + this.name);
		};
	};

	object = {foo: new Foo('fooName'), bar: new Bar('barName')};
	clone  = atom.clone(object);
	notStrictEqual(object.bar, clone.bar, 'Objects with "clone" - cloning');
	equal(clone.bar.name, 'clone of barName', 'Objects with "clone" - cloning');

	// todo: [qtest] accessors
});


// todo: [qtest] atom.merge
test('atom.extend', function(){
	atom.extend({
		get testProp() { return 'testPropValue:static'; },
		testMethod: function () { return 'testMethodValue:static'; }
	});
	equal(atom.testProp,     'testPropValue:static'  , 'atom.extend getter');
	equal(atom.testMethod(), 'testMethodValue:static', 'atom.extend method');

	var testObject = {};
	atom.extend(testObject, { prop : 'Yes' });
	equal(testObject.prop, 'Yes', 'atom object extend');
});


};