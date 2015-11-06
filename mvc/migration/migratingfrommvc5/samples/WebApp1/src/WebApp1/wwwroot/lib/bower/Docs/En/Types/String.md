atom.string
===========

#### uniqueID
Returns unique for sessiong string id

	atom.string.uniqueID() // "h3biq3tz"
	atom.string.uniqueID() // "h3biq3u0"

#### safeHtml
Returns escaped string, safe to insert as html

	atom.string.safeHtml( '<b>Hello "World"</b>' );
	// "&lt;b&gt;Hello &quot;World&quot;&lt;/b&gt;"

#### repeat
Repeat string `times` times

	atom.string.repeat( 'bar*', 3 ); // bar*bar*bar*

#### substitute
Append values to string from object


	atom.string.substitute(
	  'Hello, {name}! How are you? Are you {type}? "{name}" is your real name?',
	  {
		name: 't800', type: 'destroyer'
	  });
	// "Hello, t800! How are you? Are you destroyer? "t800" is your real name?"

	
#### replaceAll
Replace all source substrings with target
	
	atom.string.replaceAll('Hi--my--dear--friend!', { '--': '+', '!': '?' })
	// "Hi+my+dear+friend?"

#### contains
Checks if string contains substring

	atom.string.contains( 'Hello, World!', 'World'  ); // true
	atom.string.contains( 'Hello, World!', 'Heaven' ); // false

#### begins
Checks if string begins with substring

	atom.string.begins( 'Hello, World!', 'Hello' ); // true
	atom.string.begins( 'Hello, World!', 'World' ); // false
	
#### begins
Checks if string begins with substring

	atom.string.begins( 'Hello, World!', 'Hello' ); // true
	atom.string.begins( 'Hello, World!', 'World' ); // false
	
#### ends
Checks if string ends with substring

	atom.string.ends( 'Hello, World!', 'Hello'  ); // false
	atom.string.ends( 'Hello, World!', 'World!' ); // true
	
#### ucfirst
Uppercase first character

	atom.string.ucfirst( 'hello, world!' ); // 'Hello, world!'
	
#### lcfirst
Lowercase first character

	atom.string.lcfirst( 'Hello, world!' ); // 'hello, world!'
