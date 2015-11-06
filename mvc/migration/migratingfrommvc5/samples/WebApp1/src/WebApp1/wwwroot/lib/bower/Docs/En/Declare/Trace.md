atom.trace
==========

This class used in browsers for easy online debug without using browser console. Please, use `atom.css` from repo core.

It recurcively dumps (map depth is 5) object according inner rules & object 'dump' method & show result at screen.

### atom.trace.dumpPlain( object )

Returns plain dump (string) of object, that can be logged e.g. in console or another place.

#### example:

	atom.trace.dumpPlain({
		foo: 123,
		bar: null,
		arr: [ 1, 2, 3 ],
		sub: { test: 'string' },
		dumpable: {
			dump: function () { return '[My Dumpable Object]' }
		}
	});

#### result:

	{
		foo: 123
		bar: null
		arr: [
			0: 1
			1: 2
			2: 3
		]
		sub: {
			test: "string"
		}
		dumpable: [My Dumpable Object]
	}

### Instance

	var trace = new atom.Trace( value );

Shows result of dump on page. Can be dynamicaly changed. It can be used for showing current fps number, mouse coord or another debug info, which can be change so fast, that we can't just log it into console.

You can use `destroy` method to remove it from screen, or just click on it.

You can change current its content by setting value property:

	var trace = atom.trace();
	var value = 0;

	setInterval(function () {
		trace.value = value++;
	}, 100);

You can set as value any object, you can see.

	// Some class:
	atom.declare( 'Changer', {
		value: 0,
		max  : 0,
	
		initialize: function (initial, max) {
			this.value = initial;
			this.max   = max;
			this.events = new atom.Events(this);
			this.runNext();
		},
		
		change: function () {
			this.value += Number.random(-5, 10);
			
			if (this.value > this.max) {
				this.events.fire('stop');
			} else {
				this.events.fire('change');
				this.runNext();
			}
		},
		
		runNext: function () {
			this.change.delay(100, this);
		},
		
		dump: function () {
			return '[Changer ' + this.value + ']';
		}
	});
	
	// listen code:
	var myChanger = new Changer(1000, 1200);
	
	var changerTrace = atom.trace(myChanger);
	myChanger.events.add({
		change: function () {
			changerTrace.value = myChanger;
		},
		stop: function (){
			changerTrace.destroy();
		}
	});
	
	
	