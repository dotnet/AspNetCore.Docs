/*
---

name: "ImagePreloader"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- declare
	- Events
	- Settings

provides: ImagePreloader

...
*/

atom.declare( 'atom.ImagePreloader', {
	processed : 0,
	number    : 0,

	initialize: function (settings) {
		this.events   = new Events(this);
		this.settings = new Settings(settings).addEvents(this.events);

		this.count = {
			error: 0,
			abort: 0,
			load : 0
		};

		this.suffix    = this.settings.get('suffix') || '';
		this.usrImages = this.prefixImages(this.settings.get('images'));
		this.imageUrls = this.fetchUrls();
		this.domImages = {};
		//this.domImages = this.createDomImages();
		this.images    = {};
		this.createNext();
	},
	get isReady () {
		return this.number == this.processed;
	},
	get info () {
		var stat = atom.string.substitute(
			"Images loaded: {load}; Errors: {error}; Aborts: {abort}",
			this.count
		);
		if (this.isReady) stat = "Image preloading has completed;\n" + stat;
		return stat;
	},
	get progress () {
		return this.isReady ? 1 : atom.number.round(this.processed / this.number, 4);
	},
	append: function (preloader) {
		for (var i in preloader.images) {
			this.images[i] = preloader.images[i];
		}
		return this;
	},
	exists: function (name) {
		return !!this.images[name];
	},
	get: function (name) {
		var image = this.images[name];
		if (image) {
			return image;
		} else {
			throw new Error('No image «' + name + '»');
		}
	},

	/** @private */
	cropImage: function (img, c) {
		if (!c) return img;

		var canvas = document.createElement('canvas');
		canvas.width  = c[2];
		canvas.height = c[3];
		canvas.getContext('2d').drawImage( img,
			c[0], c[1], c[2], c[3], 0, 0, c[2], c[3]
		);
		return canvas;
	},
	/** @private */
	withoutPrefix: function (src) {
		return src.indexOf('http://') === 0 || src.indexOf('https://') === 0;
	},
	/** @private */
	prefixImages: function (images) {
		var prefix = this.settings.get('prefix');
		if (!prefix) return images;

		return atom.object.map(images, function (src) {
			return this.withoutPrefix(src) ? src : prefix + src;
		}.bind(this));
	},
	/** @private */
	cutImages: function () {
		var i, parts, img;
		for (i in this.usrImages) if (this.usrImages.hasOwnProperty(i)) {
			parts = this.splitUrl( this.usrImages[i] );
			img   = this.domImages[ parts.url ];
			this.images[i] = this.cropImage(img, parts.coords);
		}
		return this;
	},
	/** @private */
	splitUrl: function (str) {
		var url = str, size, cell, match, coords = null;

				// searching for pattern 'url [x:y:w:y]'
		if (match = str.match(/ \[(\d+):(\d+):(\d+):(\d+)\]$/)) {
			coords = match.slice( 1 );
				// searching for pattern 'url [w:y]{x:y}'
		} else if (match = str.match(/ \[(\d+):(\d+)\]\{(\d+):(\d+)\}$/)) {
			coords = match.slice( 1 ).map( Number );
			size = coords.slice( 0, 2 );
			cell = coords.slice( 2, 4 );
			coords = [ cell[0] * size[0], cell[1] * size[1], size[0], size[1] ];
		}
		if (match) {
			url = str.substr(0, str.lastIndexOf(match[0]));
			coords = coords.map( Number );
		}
		if (this.suffix) {
			if (typeof this.suffix == 'function') {
				url = this.suffix( url );
			} else {
				url += this.suffix;
			}
		}

		return { url: url, coords: coords };
	},
	/** @private */
	fetchUrls: function () {
		var i, result = [], hash = {}, url, images = this.usrImages;
		for (i in images) if (images.hasOwnProperty(i)) {
			url = this.splitUrl( images[i] ).url;
			if (!hash[url]) {
				result.push(url);
				hash[url] = true;
				this.number++;
			}
		}
		return result;
	},
	/** @private */
	createDomImage : function (src) {
		var img = new Image();
		img.src = src;
		if (window.opera && img.complete) {
			setTimeout(this.onProcessed.bind(this, 'load', img), 10);
		} else {
			['load', 'error', 'abort'].forEach(function (event) {
				img.addEventListener( event, this.onProcessed.bind(this, event, img), false );
			}.bind(this));
		}
		return img;
	},
	createNext: function () {
		if (this.imageUrls.length) {
			var url = this.imageUrls.shift();
			this.domImages[url] = this.createDomImage(url);
		}
	},
	resetImage: function (img) {
		// opera fullscreen bug workaround
		img.width  = img.width;
		img.height = img.height;
		img.naturalWidth  = img.naturalWidth;
		img.naturalHeight = img.naturalHeight;
	},
	/** @private */
	onProcessed : function (type, img) {
		if (type == 'load' && window.opera) {
			this.resetImage(img);
		}
		this.count[type]++;
		this.processed++;
		this.events.fire('progress', [this, img]);

		if (this.isReady) {
			this.cutImages();
			this.events.ensureReady('ready', [this]);
		} else {
			this.createNext();
		}
		return this;
	}
}).own({
	run: function (images, callback, context) {
		var preloader = new this({ images: images });

		preloader.events.add( 'ready', context ? callback.bind(context) : callback );

		return preloader;
	}
});