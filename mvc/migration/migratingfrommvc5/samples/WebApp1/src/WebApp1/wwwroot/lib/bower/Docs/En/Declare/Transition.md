atom.Transition
===============

`atom.Transition` specifies the speed curves of the transition effects.

### atom.Transition.set

	atom.Transition.set( id, fn );

Sets new transition function:

	atom.Transition.set( 'Special', function(p){
		return Math.sqrt( Math.atan(p*Math.PI/2) );
	});

### atom.Transition.get

	atom.Transition.get( id );

Returns transition function. Returns 'ease-in-out' as default, 'ease-in' if `-in` prefix contains & 'ease-out' if `out` prefix contains;

	var transitionInOut = atom.Transition.get( 'special'     );
	var transitionIn    = atom.Transition.get( 'special-in'  );
	var transitionOut   = atom.Transition.get( 'special-out' );
	
	console.log( transitionInOut(0.5) ); // 0.5

### Build-in timing functions

* linear
* sine
* asine
* back
* bounce
* elastic
* expo
* circ
* quad
* cubic
* quart
* quint

![Transition Graph](https://github.com/theshock/atomjs/raw/master/Docs/En/Declare/transition-graph.png)