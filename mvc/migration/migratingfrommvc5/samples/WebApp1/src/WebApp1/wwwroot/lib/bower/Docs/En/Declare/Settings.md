atom.Settings
=============

`atom.Settings` is class, which provides easy settings changing

  var settings = new atom.Settings();

### set

`set` - sets values

	atom.Settings set( string name, mixed value );
	atom.Settings set( object values );

#### example:

	settings.set( 'test', 123 );
	settings.set({ a: 1, b: 2 });

#### returns `this`

### get

`get` - returns value of key, or all values

	mixed get( string key, mixed defaultValue = undefined );

#### example:

	settings.get( 'test' ); // 123
	settings.get( 'wrong', 'default' ); // 'default'

### properties

`properties` - such properties will be set automatically to target object.
If no names set - all properties will be set.

	atom.Settings properties( string target, string[] names = null );

#### example:

	var object = {};

	settings.properties( object, [ 'foo' ] );
	settings.set({ foo: 1, bar: 2 });

	console.log( object.foo ); // 1
	console.log( object.bar ); // undefined

### initial values

You can set initial values of Settings using first argument while constructing:

	var settings = new atom.Settings({ initial: 42 });
	settings.get('initial'); // 42

### addEvents

	atom.Settings addEvents( atom.Events events );

When events are added all settings, which begins with 'on' are recognized as events

	var events   = new atom.Events();
	var settings = new atom.Settings();
	settings.addEvents( events );
	
	settings.set({ onClick: onClickCallback });
	//equals to:
	events.add( 'click', onClickCallback );

This can be used for easy events+settings class construction:

	atom.declare( 'Button', {
		initialize: function (settings) {
			this.events = new atom.Events(this);
			this.settings = new atom.Settings(settings);
			
			this.settings.addEvents( this.events );
		}
	});
	
	new Button({
		title: 'My Test Button',
		onClick: function () {
			// button onClick event
		}
	});
	