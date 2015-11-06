Atom Cookie
===================


### atom.cookie.get(name)
Returns value of cookie `name` or `null` if not exists

	var testCookie = atom.cookie.get('test');

### atom.cookie.set(name, value, options)

Sets value of cookie, returns link to `atom.cookie`

* `name` (*string*) cookie title

* `value` (*string*) cookie value

* `options` (*mixed*) additional options for cookie:

	* `expires` (*number|date*) Cookie expires, can be time in seconds, left to expire, or Date object
	* `path` (*string*) cookie path
	* `domain` (*string*) cookie domain
	* `secure` (*boolean*) secure connection

#### example:

	atom.cookie
		.set('first' , 1)
		.set('second', 2);


### atom.cookie.del(name)
Delete cookie with name `name` and returns `atom.cookie`

	atom.cookie
		.del('first')
		.del('second');