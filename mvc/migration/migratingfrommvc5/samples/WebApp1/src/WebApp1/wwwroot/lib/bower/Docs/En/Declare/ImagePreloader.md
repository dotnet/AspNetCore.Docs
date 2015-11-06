atom.ImagePreloader
===================

Class, which provides the easy way to preload images.

## Properties

* `events` - `atom.Events` object

* `settings` - `atom.Settings` object

* `count` - object, state of images preloading, subproperties:

* * `load`  - number of images, loaded successful
* * `abort` - number of images, which loading was aborted
* * `error` - number of images, loaded with errors 

* `isReady` - `bool`, true, if all images are loaded

* `info` - returns debug info about images loading state

* `progress` - float value between 0 and 1 - percent of images, loaded already

## Methods

### initialize

	void initialize( Settings settings )

##### Settings:

* `images` - hash of images should be preloaded
* `prefix` - string, all images should be prefixed by. Can be used, if all images begins with similar path
* `suffix` - string, all images should be suffixed by. Can be used to avoid images caching

##### Events:

* `ready` - fires when all images are successfully loaded

##### Example:

	new atom.ImagePrealoader({
		prefix: 'http://static.example.com/images/',
		suffix: '?_avoid_cache=' + Date.now(),
		images: {
			'unit-tractor'  : 'units/tractor.png',
			'unit-tank'     : 'units/tank.png',
			'unit-fighter'  : 'units/fighter.png',
			'unit-destroyer': 'units/destroyer.png',
			
			'building-factory'  : 'building/factory.jpg',
			'building-oilrig'   : 'building/oilrig.jpg',
			'building-warehouse': 'building/warehouse.jpg'
		},
		onReady: function (imagePreloader) {
			new Game(imagePreloader);
		}
	});

### exists

	bool exists( string name )

Checks, if image with name `name` was loaded.

	imagePreloader.exists( 'unit-traktor' ); // true
	imagePreloader.exists( 'unit-diablo'  ); // false

### get 

	Image get( string name )

Returns image with name `name`, if exists, or throws `Error` otherwise

	imagePreloader.exists( 'unit-traktor' ); // returns image
	imagePreloader.exists( 'unit-diablo'  ); // throws Error

## atom.ImagePreloader.run

	imagePreloader ImagePreloader.run( Object images, Function onReady, mixed context = null )

Short way to create image preloader.

	ImagePrealoader.run({ unit: 'unit.png' }, function (preloader) {
		new Game(preloader);
	});
	
	// equals to: 
	
	new ImagePrealoader({
		images: { unit: 'unit.png' },
		onReady: function (preloader) {
			new Game(preloader);
		}
	});

## images syntax

Preloader can dynamically crop images (sprites). Just add `[x:y:w:h]` part in the end of image path:

	ImagePrealoader.run({
		'unit-tractor'  : 'units.png [0:0:50:50]',
		'unit-tank'     : 'units.png [50:0:50:50]',
		'unit-fighter'  : 'units.png [100:0:50:50]',
		'unit-destroyer': 'units.png [150:0:50:50]',
		
		'building-factory'  : 'building.jpg [0:0:200:100]',
		'building-oilrig'   : 'building.jpg [0:100:200:100]',
		'building-warehouse': 'building.jpg [0:200:200:100]'
	});

Another way is `tile cropping`. Syntax is `[w:h]{x:y}` where `w` is width of tile, `h` is height of tile, `x` is horisontal index of tile at image and `y` is vertical index of tile in image. Next code is indetial to previous:

	ImagePrealoader.run({
		'unit-tractor'  : 'units.png [50:50]{0:0}',
		'unit-tank'     : 'units.png [50:50]{1:0}',
		'unit-fighter'  : 'units.png [50:50]{2:0}',
		'unit-destroyer': 'units.png [50:50]{3:0}',
		
		'building-factory'  : 'building.jpg [200:100]{0:0}',
		'building-oilrig'   : 'building.jpg [200:100]{0:1}',
		'building-warehouse': 'building.jpg [200:100]{0:2}'
	});

You can begins image with `http://` or `https://` if you dont want to prefix them:

	new ImagePrealoader({
		prefix: 'http://s1.example.com/images',
		images: {
			unit1: 'unit1.png',
			unit2: 'unit2.png',
			unit3: 'https://s2.example.com/images/secret-unit.png',
		},
	});


