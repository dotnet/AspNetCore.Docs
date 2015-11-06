# atom.Class.Events

Let you add and fire event, linked with current object

#### method addEvent
	addEvent(string name, function fn)

Using this method you can add events to eventable object

#### method removeEvent
	removeEvent(string name, function fn)

Using this method you can remove events from eventable object

#### method fireEvent
	fireEvent(string name, array arguments)

Using this method you can fire events in eventable object

#### method readyEvent
	readyEvent(string name, array arguments)

Using this method you can fire event in eventable object and automaticaly fire it on during all next "addEvent" (as image.onload)

### Base examples

	MyClass = atom.Class({
		Implements: [ atom.Class.Events ]
	});

	var my = new MyClass;


	// We listen 2 events:
	my.addEvent('foo', function ( firstArg ) {
		alert(firstArg);
	});
	my.addEvent('bar', atom.log);

	// event `foo` fired
	my.fireEvent('foo');
	// event `bar` fired
	my.fireEvent('bar');

	// we don't listen `bar` event now
	me.removeEvent('bar', atom.log);

### readyEvent examples
readyEvent used for once runable events. E.g. it can be application initialize or image loaded

	Application = atom.Class({
		Implements: [ atom.Class.Events ],
		initialize: function (src) {
			this.image = new Image;
			this.image.onload = function () {
				this.readyEvent('ready');
			}.bind(this);
			this.image.src = src;
		}
	});

	var app = new Application('test');
	app.addEvent('ready', function () {
		alert('image loaded and application is ready');
	});

