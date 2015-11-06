atom.Events
===========

`atom.Events` is class, which provides easy events manipulations

  var events = new atom.Events();

### add

`add` - add callback for event.

	atom.Events add( string name, function callback );

#### example:

	events.add( 'activate', function () {
		console.log( 'activate event fired' );
	});

#### returns `this`

### remove

`remove` - remove callback, binded for event.

	atom.Events remove( string name, function callback );

#### example:

	function listenActivate () {
		console.log( 'activate event fired' );
	}

	events.add( 'activate', listenActivate );
	
	// event now
	events.remove( 'activate', listenActivate );

#### returns `this`

### add/remove alternate:

`add` & `remove` callbacks can be called with different arguments. `name` argument can be array, so we can bind or unbind for several events with one callback

	events.add( [ 'rotate', 'move' ], function () {
		console.log( 'position changed' );
	});

instead of two arguments we can send object of arguments, where key will be name & value will be callback:

	events.add({
		rotate: function () { console.log('rotated') },
		move  : function () { console.log('moved') },
	});

### exists

`exists` checks if someone binded for event.

	events.add( 'complete', onComplete );
	console.log(
		events.exists('comlete'), // true
		events.exists('error')    // false
	);

### fire

	atom.Events fire( string name, Array arguments );

`fire` invokes all callback, that was binded for that name.

	events.add( 'foo', function (arg) { console.log(13, arg) });
	events.add( 'foo', function (arg) { console.log(42, arg) });
	events.add( 'bar', function (arg) { console.log(99, arg) });
	
	events.fire( 'foo', 5 );
	// 13, 5
	// 42, 5

### ready

	atom.Events ready( string name, Array arguments );

`ready` fires events once & fire all callbacks immedeatly, when they are binded. Can be used for some kind of "ready" events such as `image.onload` and so on, which fires only once.

	events.add( 'complete', function () { console.log(13) }); // wait event
	
	events.ready('complete'); // log 13
	
	events.add( 'complete', function () { console.log(42) }); // immedeatly log 42

### changing context

You can change context(value of `this`) in fired callbacks by setting in in constructor:

	atom.declare( 'Foo', {
		property: 42,
	
		initialize: function () {
			this.events = new atom.Events(this);
		},
		
		run: function () {
			this.events.fire('run');
		}
	});
	
	var foo = new Foo();
	
	foo.events.add( 'run', function () {
		console.log( this.property ); // 42
	});
	
	foo.run();