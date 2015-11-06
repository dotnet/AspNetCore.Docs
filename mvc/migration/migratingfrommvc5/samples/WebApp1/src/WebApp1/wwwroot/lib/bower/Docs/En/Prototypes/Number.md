Number extending
================

Generally build-in type extending use `atom.%type%.*` methods, so here you will only see links to manual and examples

### See: [atom.number](https://github.com/theshock/atomjs/blob/master/Docs/En/Types/Number.md), [atom.math](https://github.com/theshock/atomjs/blob/master/Docs/En/Types/Math.md)

### Own properties

* Number.random

	Equivalent to `atom.number.random`:

		Number.random(5, 100);
		// equals to
		atom.number.random(5, 100);

* Number.randomFloat

	Equivalent to `atom.number.randomFloat`:

		Number.randomFloat(5, 100);
		// equals to
		atom.number.randomFloat(5, 100);
		
### prototype extending

Next properties mixed into prototype from `atom.number`, where first property is `this` array:

* between
* equals
* limit
* round
* stop


Next properties mixed into prototype from `atom.math`, where first property is `this` array:

* degree
* getDegree
* normalizeAngle


##### example
	var myNumber = 10;

	myNumber.between( 5, 15 );
	// equals to:
	atom.number.between( myNumber, 5, 15 );
	
	// and
	
	myNumber.degree()
	// equals to:
	atom.math.degree( myNumber );
	

Next properties mixed into prototype from javascript build-in `Math`, where first property is `this` array:

* abs
* acos
* asin
* atan
* atan2
* ceil
* cos
* exp
* floor
* log
* max
* min
* pow
* sin
* sqrt
* tan

	
##### example

	var myNumber = -5.123;
	
	myNumber.abs();
	// equals to
	Math.abs( myNumber );
	
	// and
	
	myNumber.pow(3);
	// equals to:
	Math.pow( myNumber, 3 );

