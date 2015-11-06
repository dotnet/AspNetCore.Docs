atom.Animatable
===============

`atom.Animatable` provides you the way to change properies of objects during time. 

	var animatable = new atom.Animatable( targetObject );

### get current

Contains current animation

	var currentAnimation = animatable.current;
	
### animate

	atom.Animatable.Animation animate( object config )

Push new animation to stack & starts it when all previous animations will finish

`Config` properies: 
* `props`  - properies on object, you want to animate
* `time`   - time in seconds animation should continue
* `fn`     - `atom.Transition` method (`linear` is default)
* `onTick` - callback, should be runned each property change
* `onComplete` - callback, should be runned, when animation successfully complete
* `onDestroy`  - callback, should be runned, when animation complete

First argument in callback is always `animation`

### stop

	atom.Animatable stop( boolean all )

Stops current animation if `all=false` & all animations if `all=true`

	animatable.stop( true );
	
atom.Animatable.Animation
=========================

Private class, which represents animation. It returns by `atom.Animatable#animate` & shouldn't be created manual

	var animation = animatable.animate(animateConfig);

### Properties:

* `transition` - animation transition function
* `initial`    - values of properties, object contains on animation start
* `target`     - animation target values of properties
* `delta`      - difference between source & target values
* `allTime`    - time, which animation should continue
* `timeLeft`   - time, animation left to continue

atom.dom.animate
================

### atom.dom().animate()

Provides the way to animate dom properties

	atom.dom('div').animate({ width: 150 });

### atom.dom().stopAnimation(all)

Stops current animation

	atom.dom('div').stopAnimation(true);

atom.Color
==========

You can animate colors if `atom.Color` class used.

	var object = { color: 'red' };
	
	new atom.Animatable( object ).animate({ color: 'blue' });


