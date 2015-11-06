String extending
================

Generally build-in type extending use `atom.%type%.*` methods, so here you will only see links to manual and examples

### See: [atom.string](https://github.com/theshock/atomjs/blob/master/Docs/En/Types/String.md)

### prototype extending

Next properties mixed in to prototype, where first property is `this` array:

* safeHtml
* repeat
* substitute
* replaceAll
* contains
* begins
* ends
* ucfirst
* lcfirst

##### example

	var myString = 'test {string} is here';

	myString.begins( 'test' );
	// equals to:
	atom.string.begins( myString, 'test' );
	
	// and
	
	myString.substitute({ 'string': 'substring' });
	// equals to:
	atom.string.substitute( myString, { 'string': 'substring' });
