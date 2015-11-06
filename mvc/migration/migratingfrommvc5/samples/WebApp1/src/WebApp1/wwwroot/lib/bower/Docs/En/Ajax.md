Atom AJAX
=========

	atom.ajax(config);

#### Config parameters:

* `interval`: 0. Repeat every `interval` seconds if it's greater than 0
* `type`: `'plain'`. One of `'plain'` or `'json'` (response automatically parsed as JSON)
* `method`: `'post'`. One of `'post'`, `'get'`, `'put'`, `'delete'`
* `data`: `{}`.
* `cache`: `false`. Disabling blowser cache: `cache:false`
* `url`: `location.href`. Request url
* `onLoad`: callback
* `onError`: callback

#### Example:

	atom.ajax({
		type   : 'json',
		method : 'get',
		url    : 'test.php',
		data   : { 'hello': 'world' },
		cache  : true,
		onLoad : function (json) {
			atom.log(json);
		},
		onError: function () {
			atom.log('error');
		}
	});

**Note:** if you're declare `onLoad()` function, then you function will be override  default `onLoad()`  and response text will not be added, like he did it default.

# Atom.Plugins.Ajax + Atom.Plugins.Dom

	atom.dom('#newMsgs').ajax({ // update html of #newMsgs
		interval : 15, // every 15 seconds
		url : 'newMsgs.php'
	});
