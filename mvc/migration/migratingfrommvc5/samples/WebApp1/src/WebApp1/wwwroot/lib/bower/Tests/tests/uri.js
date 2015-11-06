
new function () {

module('[Atom Plugins] Uri');

var testUri = function (uri, tests) {
	// based on http://stevenlevithan.com/demo/parseuri/js/

	var parse = atom.uri(uri);

	for (prop in tests) if (prop != 'queryKey') {
		equal(parse[prop], tests[prop], prop);
	}


	if ('queryKey' in tests) deepEqual(parse.queryKey, tests.queryKey, 'queryKey');
};

test('Full path', function(){
	var uri = 'http://usr:pwd@www.example.com:81/dir/dir.2/index.htm?q1=0&&test1&test2=value#top';
	testUri( uri, {
		anchor: 'top',
		query: 'q1=0&&test1&test2=value',
		file: 'index.htm',
		directory: '/dir/dir.2/',
		path: '/dir/dir.2/index.htm',
		relative: '/dir/dir.2/index.htm?q1=0&&test1&test2=value#top',
		port: '81',
		host: 'www.example.com',
		password: 'pwd',
		user: 'usr',
		userInfo: 'usr:pwd',
		authority: 'usr:pwd@www.example.com:81',
		protocol: 'http',
		source: uri,
		queryKey: {
			q1: '0',
			test1: '',
			test2: 'value'
		}
	});
});

test('Relative path', function(){
	var uri = '/dir/dir.2/index.htm?q1=0&&test1&test2=value#top';
	testUri( uri, {
		anchor: 'top',
		query: 'q1=0&&test1&test2=value',
		file: 'index.htm',
		directory: '/dir/dir.2/',
		path: '/dir/dir.2/index.htm',
		relative: '/dir/dir.2/index.htm?q1=0&&test1&test2=value#top',
		port: '',
		host: '',
		password: '',
		user: '',
		userInfo: '',
		authority: '',
		protocol: '',
		source: uri,
		queryKey: {
			q1: '0',
			test1: '',
			test2: 'value'
		}
	});
});

};