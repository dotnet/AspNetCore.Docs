atom.Color
==========

`atom.Color` allows you to manipulate with colors. 

## Own:

### colorNames
Set of color names & hex values

* `#ffffff` - white
* `#c0c0c0` - silver
* `#808080` - gray
* `#000000` - black
* `#ff0000` - red
* `#800000` - maroon
* `#ffff00` - yellow
* `#808000` - olive
* `#00ff00` - lime
* `#008000` - green
* `#00ffff` - aqua
* `#008080` - teal
* `#0000ff` - blue
* `#000080` - navy
* `#ff00ff` - fuchsia
* `#800080` - purple
* `#ffa500` - orange

### atom.Color.isColorString( string string );
Checks if `string` is hex/rgba or color name

	atom.Color.isColorString( [42,0,13] ) // false
	atom.Color.isColorString( 'foobar'  ) // false
	atom.Color.isColorString( '#dec0de' ) // true
	atom.Color.isColorString( 'red'     ) // true

### random( bool html )

Returns `atom.Color` instance with random color value.
If `html` is `true` - gets value only from `colorNames`

	atom.Color.random().toString('hex'); // #61f405

## Prototype

### constructing

	var color = new atom.Color( value );

Value can be array, object, string or number according to `from*` methods.

### from* methods

#### fromArray( Array color )
Sets values , parsing array as `[ red, green, blue, alpha=1 ]`, where `alpha` is optional

	color.fromArray([ 41, 55, 231, 0.5 ]);


#### fromObject( Object color )
Sets values from object keys `red, green, blue, alpha`

	color.fromObject({
		red  : 14,
		green: 63,
		blue : 151,
		alpha: 0.5
	});

#### fromString( String color )
Parse valid (`true` in `atom.Color.isColorString`) string as color:

	color.fromString( '#dead13' );
	color.fromString( 'cyan'    );
	
#### fromNumber( Number number )
Parse number as color string. Format is `0xRRGGBBAA`

	color.fromNumber( 0xDECODEFF );

Note that color `0xFFFF00` is not yellow, because it equals to `0x00FFFF00` - cyan color with zero alpha. Correct yellow color is `0xFFFF00FF`

### to* methods

#### toArray()
Returns array `[red, green, blue, alpha]` of color. E.G.:

	console.log( new atom.Color('orange').toArray() ); // [255, 165, 0, 1]

#### toObject(abbreviationNames)
Returns object `{red, green, blue, alpha}` of color. E.G.:

	console.log( new atom.Color('orange').toObject() ); // {red:255, green:165, blue:0, alpha:1}
	console.log( new atom.Color('orange').toObject(true) ); // {r:255, g:165, b:0, a:1}

#### toString(type)
Returns string '#RRGGBB' is `type=='hex'` &t 'rgba(red, green, blue, alpha)' if hex otherwise

	console.log( new atom.Color('orange').toString()      ); // 'rgba(255,165,0,1)'
	console.log( new atom.Color('orange').toString('hex') ); // '#ffa500'

#### toNumber()
Returns number

	console.log( new atom.Color('orange').toNumber() ); // 4289003775
	console.log( new atom.Color('orange').toNumber() == 0xffa500ff ); // true
	

### properties

This properties can get or set values of color with checking limits

* `red`
* `green`
* `blue`
* `alpha`

	var color = new atom.Color('orange');
	color.red  = -1000;
	color.blue =  1000;
	color.toArray(); // [0, 165, 255, 1]

### manipulations

#### equals()
Checks, if colors are similar.

	var a = new atom.Color('red');
	var b = new atom.Color('#ff0000');
	
	console.log( a == b ); // false
	console.log( a.equals(b) ); // true
	
#### clone()
Clones color

	var a = new atom.Color('red');
	var b = a.clone();
	
	console.log( a == b ); // false
	console.log( a.equals(b) ); // true
	
	b.green = 150;
	
	console.log( a.equals(b) ); // false
	
