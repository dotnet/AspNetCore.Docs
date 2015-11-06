
module('[Atom Plugins] Color');

test('Color Constructing', function(){
	var color;

	color = new atom.Color('#ac45de');

	equal(color.r, 172, 'Hex:   red is correct');
	equal(color.g,  69, 'Hex: green is correct');
	equal(color.b, 222, 'Hex:  blue is correct');
	equal(color.a,   1, 'Hex: alpha is default');

	color = new atom.Color(24, 56, 12, 0.7);

	equal(color.r,  24, 'Arguments:   red is correct');
	equal(color.g,  56, 'Arguments: green is correct');
	equal(color.b,  12, 'Arguments:  blue is correct');
	equal(color.a, 0.7, 'Arguments: alpha is correct');

	color = new atom.Color.Shift(-24, 56, -12, 0.7);

	equal(color.r, -24, 'No limits:   red is correct');
	equal(color.g,  56, 'No limits: green is correct');
	equal(color.b, -12, 'No limits:  blue is correct');
	equal(color.a, 0.7, 'No limits: alpha is correct');

	color = new atom.Color([174, 41, 62, 0.4]);

	equal(color.r, 174, 'Array:   red is correct');
	equal(color.g,  41, 'Array: green is correct');
	equal(color.b,  62, 'Array:  blue is correct');
	equal(color.a, 0.4, 'Array: alpha is correct');

	color = new atom.Color({ r: 46, g: 72, b: 0, a: 0.6 });

	equal(color.r,  46, 'Object short:   red is correct');
	equal(color.g,  72, 'Object short: green is correct');
	equal(color.b,   0, 'Object short:  blue is correct');
	equal(color.a, 0.6, 'Object short: alpha is correct');

	color = new atom.Color({ red: 12, green: 34, blue: 50 });

	equal(color.r, 12, 'Object long:   red is correct');
	equal(color.g, 34, 'Object long: green is correct');
	equal(color.b, 50, 'Object long:  blue is correct');
	equal(color.a,  1, 'Object long: alpha is default');

	color = new atom.Color(0x2246dd66);

	equal(color.r,  34, 'Number:   red is correct');
	equal(color.g,  70, 'Number: green is correct');
	equal(color.b, 221, 'Number:  blue is correct');
	equal(color.a, 0.4, 'Number: alpha is correct');

	color = new atom.Color(0xff000000);

	equal(color.r, 255, 'Big Int: red is correct');
});

test('Color Casting', function(){
	var color = new atom.Color(0x2246dd66);

	deepEqual( color.toArray(), [34, 70, 221, 0.4], 'color.toArray()');
	deepEqual( color.toString(), 'rgba(34,70,221,0.4)', 'color.toString()');
	deepEqual( color.toString('hex'), '#2246dd', 'color.toString("hex")');
	deepEqual( color.toString('hexA'), '#2246dd66', 'color.toString("hexA")');
	deepEqual( color.toObject(), {red:34, green:70, blue:221, alpha:0.4}, 'color.toObject()');
	deepEqual( color.toObject(true), {r:34, g:70, b:221, a:0.4}, 'color.toObject(true)');
	deepEqual( color.toNumber(), 0x2246dd66, 'color.toNumber()');
});

test('Color Equals', function(){
	var foo = new atom.Color(0x2246dd66);
	var bar = new atom.Color(0x2246dd66);
	var red = new atom.Color(0xff0000ff);

	notEqual(foo, bar, 'foo & bar are different objects');
	ok( foo.equals(bar), 'foo equals bar');
	ok(!foo.equals(red), 'foo not equals red');
	ok(!foo.equals(null),'foo not equals null');
});

test('Color maniplations', function () {
	var foo, bar;

	foo = 0x12345678, bar = new atom.Color(foo);

	ok( atom.Color(foo).equals(bar), 'Color.invoke' );

	foo = new atom.Color(foo);

	ok( atom.Color(foo).equals(bar), 'Color.invoke empty' );

	foo = new atom.Color([ 255, 240, 225, 0.8 ]);
	bar = new atom.Color([ 220, 240, 250, 0.4 ]);
	var diff = new atom.Color.Shift([ -35, 0, 25, -0.4 ]);

	ok( foo.diff(bar).equals(diff), 'foo.diff(bar) is correct' );
	ok( foo.move(diff).equals(bar), 'foo.move(bar) is correct' );
});