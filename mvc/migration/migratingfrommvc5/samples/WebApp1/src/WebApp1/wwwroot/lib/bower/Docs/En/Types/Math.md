atom.math
=========

### atom.math.degree( degrees )

Cast degrees to radians

	atom.math.degree(90) == Math.PI/2

### atom.math.getDegree( radians )

Cast radians to degrees. If second argument is `true` - result will be rounded

	atom.math.getDegree(Math.PI/2) == 90

### atom.math.normalizeAngle( radians )

Ensure, angle is between 0 & 360 degrees:

	var angle  = atom.math.degree( 1000 );
	var normal = atom.math.normalizeAngle( angle );
	console.log( atom.math.getDegree( normal, true ) ); // 280

### atom.math.hypotenuse( cathetus1, cathetus2 )

Returns hypotenuse of right triangle from two cathetus

	atom.math.hypotenuse( 5, 12 ); // 13

### atom.math.cathetus( hypotenuse, cathetus2 )

Returns cathetus of right triangle from hypotenuse & cathetus

	atom.math.cathetus( 13, 12 ); // 5