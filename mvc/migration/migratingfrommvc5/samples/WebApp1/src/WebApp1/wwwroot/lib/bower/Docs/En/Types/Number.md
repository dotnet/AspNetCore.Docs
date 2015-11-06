atom.number
===========

Provides methods to operate with numbers

### random(min, max) {
Returns random number between `min` & `max` inclusive

	atom.number.random(1, 3); // returns 1 or 2 or 3

### randomFloat(min, max) {
Returns random float number between `min` & `max`

	atom.number.randomFloat(1, 3.5); // returns 1.4152 or 3.672, or smth else

### between(number, left, right, equals) {

Checks if `number` is greater than `left` & less than `right`. 
`Equals` can be used if `number` can be equals to one or both of sides

`Equals` can be:
* false or '' - not equals to anyone `number => (left, right)`
* 'L' - can be equals to left side, but not equals right `number => [left, right)` 
* 'R' - can be equals to right side, but not equals left `number => (left, right]` 
* true or 'LR' - can be equals to both side `number => [left, right]` 

##### Examples

	atom.number.between( 5, 3, 7       ); // true
	atom.number.between( 5, 3, 7, 'L'  ); // true
	atom.number.between( 5, 3, 7, 'R'  ); // true
	atom.number.between( 5, 3, 7, true ); // true
	
	atom.number.between( 7, 3, 7       ); // false
	atom.number.between( 7, 3, 7, 'L'  ); // false
	atom.number.between( 7, 3, 7, 'R'  ); // true
	atom.number.between( 7, 3, 7, true ); // true
	
	atom.number.between( 3, 3, 7       ); // false
	atom.number.between( 3, 3, 7, 'L'  ); // true
	atom.number.between( 3, 3, 7, 'R'  ); // false
	atom.number.between( 3, 3, 7, true ); // true
	
	atom.number.between( 0, 3, 7       ); // false
	atom.number.between( 0, 3, 7, 'L'  ); // false
	atom.number.between( 0, 3, 7, 'R'  ); // false
	atom.number.between( 0, 3, 7, true ); // false

### equals(left, right, accuracy = 8)

Allows to compare two float numbers (which can't be done with ==) with `accuracy` digits after dot


	(0.7 + 0.1) * 10 == 8; // false
	atom.number.equals((0.7 + 0.1) * 10, 8); // true
	
	atom.number.equals(1.15177354, 1.1517, 2); // true (1.152 == 1.152)

### limit(number, min, max)

Returns `number` limited by `min` & `max` values. `max` can be null & only `min` will be used

	atom.number.limit(  42, 0, 100 ); // 42
	atom.number.limit( 666, 0, 100 ); // 100
	atom.number.limit( -13, 0, 100 ); // 0
	
	atom.number.limit( -13, 0 ); // 0
	atom.number.limit( 183, 0 ); // 183


### round(number, precision = 0)

Rounds number to `precision` digits after dots if `precision > 0`
Rounds number to `precision` digits before dots if `precision < 0`

	
	atom.number.round( 84139.234567    ); // 84139
	
	atom.number.round( 84139.234567, 1 ); // 84139.2
	atom.number.round( 84139.234567, 3 ); // 84139.235
	atom.number.round( 84139.234567, 9 ); // 84139.234567
	
	atom.number.round( 84139.234567, -1 ); // 84140
	atom.number.round( 84139.234567, -3 ); // 84000
	atom.number.round( 84139.234567, -9 ); // 0
	