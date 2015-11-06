/*
---

name: "Ajax"

description: "todo"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- CoreExtended

provides: ajax

...
*/

(function () {
	var extend = atom.core.extend, emptyFn = function () {};

	var ajax = function (userConfig) {
		var data, config, method, req, url;
		config = {};
		extend(config, ajax.defaultProps);
		extend(config, userConfig);
		config.headers = {};
		extend(config.headers, ajax.defaultHeaders);
		extend(config.headers, userConfig.headers);

		data = ajax.stringify( config.data );
		req  = new XMLHttpRequest();
		url  = config.url;
		method = config.method.toUpperCase();
		if (method == 'GET' && data) {
			url += (url.indexOf( '?' ) == -1 ? '?' : '&') + data;
		}
		if (!config.cache) {
			url += (url.indexOf( '?' ) == -1 ? '?' : '&') + '_no_cache=' + Date.now();
		}
		req.onreadystatechange = ajax.onready(req, config);
		req.open(method, url, true);
		for (var i in config.headers) {
			req.setRequestHeader(i, config.headers[i]);
		}
		req.send( method == 'POST' && data ? data : null );
	};

	ajax.stringify = function (object) {
		if (!object) return '';
		if (typeof object == 'string' || typeof object == 'number') return String( object );

		var array = [], e = encodeURIComponent;
		for (var i in object) if (object.hasOwnProperty(i)) {
			array.push( e(i) + '=' + e(object[i]) );
		}
		return array.join('&');
	};

	ajax.defaultProps = {
		interval: 0,
		type    : 'plain',
		method  : 'post',
		data    : {},
		headers : {},
		cache   : false,
		url     : location.href,
		onLoad  : emptyFn,
		onError : emptyFn
	};

	ajax.defaultHeaders = {
		'X-Requested-With': 'XMLHttpRequest',
		'Accept': 'text/javascript, text/html, application/xml, text/xml, */*'
	};
	/** @type {function} */
	ajax.onready = function (req, config) {
		return function (e) {
			if (req.readyState == 4) {
				if (req.status != 200) return config.onError(e);

				var result = req.responseText;
				if (config.type.toLowerCase() == 'json') {
					result = JSON.parse(result);
				}
				if (config.interval > 0) setTimeout(function () {
					atom.ajax(config);
				}, config.interval * 1000);
				config.onLoad(result);
			}
		};
	};

	atom.ajax = ajax;
})();
