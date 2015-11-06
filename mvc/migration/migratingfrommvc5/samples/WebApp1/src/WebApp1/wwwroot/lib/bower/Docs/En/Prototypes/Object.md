Object extending
================

Generally build-in type extending use `atom.%type%.*` methods, so here you will only see links to manual and examples

### See: [atom.object](https://github.com/theshock/atomjs/blob/master/Docs/En/Types/Object.md)

### Own properties

All properties of `atom.object` mixed to `Object`:

* invert
* collect
* values
* map
* max
* min
* isEmpty
* path

##### example

	Object.invert( myObject );
	// equals to:
	atom.object.invert( myObject );

	// and
	
	Object.map( myObject, callback );
	// equals to:
	atom.object.map( myObject, callback );