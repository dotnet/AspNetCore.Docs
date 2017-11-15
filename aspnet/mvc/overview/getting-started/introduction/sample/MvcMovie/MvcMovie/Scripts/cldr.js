/**
 * CLDR JavaScript Library v0.4.1
 * http://jquery.com/
 *
 * Copyright 2013 Rafael Xavier de Souza
 * Released under the MIT license
 * http://jquery.org/license
 *
 * Date: 2015-02-25T13:51Z
 */
/*!
 * CLDR JavaScript Library v0.4.1 2015-02-25T13:51Z MIT license © Rafael Xavier
 * http://git.io/h4lmVg
 */
(function( root, factory ) {

	if ( typeof define === "function" && define.amd ) {
		// AMD.
		define( factory );
	} else if ( typeof module === "object" && typeof module.exports === "object" ) {
		// Node. CommonJS.
		module.exports = factory();
	} else {
		// Global
		root.Cldr = factory();
	}

}( this, function() {


	var arrayIsArray = Array.isArray || function( obj ) {
		return Object.prototype.toString.call( obj ) === "[object Array]";
	};




	var pathNormalize = function( path, attributes ) {
		if ( arrayIsArray( path ) ) {
			path = path.join( "/" );
		}
		if ( typeof path !== "string" ) {
			throw new Error( "invalid path \"" + path + "\"" );
		}
		// 1: Ignore leading slash `/`
		// 2: Ignore leading `cldr/`
		path = path
			.replace( /^\// , "" ) /* 1 */
			.replace( /^cldr\// , "" ); /* 2 */

		// Replace {attribute}'s
		path = path.replace( /{[a-zA-Z]+}/g, function( name ) {
			name = name.replace( /^{([^}]*)}$/, "$1" );
			return attributes[ name ];
		});

		return path.split( "/" );
	};




	var arraySome = function( array, callback ) {
		var i, length;
		if ( array.some ) {
			return array.some( callback );
		}
		for ( i = 0, length = array.length; i < length; i++ ) {
			if ( callback( array[ i ], i, array ) ) {
				return true;
			}
		}
		return false;
	};




	/**
	 * Return the maximized language id as defined in
	 * http://www.unicode.org/reports/tr35/#Likely_Subtags
	 * 1. Canonicalize.
	 * 1.1 Make sure the input locale is in canonical form: uses the right
	 * separator, and has the right casing.
	 * TODO Right casing? What df? It seems languages are lowercase, scripts are
	 * Capitalized, territory is uppercase. I am leaving this as an exercise to
	 * the user.
	 *
	 * 1.2 Replace any deprecated subtags with their canonical values using the
	 * <alias> data in supplemental metadata. Use the first value in the
	 * replacement list, if it exists. Language tag replacements may have multiple
	 * parts, such as "sh" ➞ "sr_Latn" or mo" ➞ "ro_MD". In such a case, the
	 * original script and/or region are retained if there is one. Thus
	 * "sh_Arab_AQ" ➞ "sr_Arab_AQ", not "sr_Latn_AQ".
	 * TODO What <alias> data?
	 *
	 * 1.3 If the tag is grandfathered (see <variable id="$grandfathered"
	 * type="choice"> in the supplemental data), then return it.
	 * TODO grandfathered?
	 *
	 * 1.4 Remove the script code 'Zzzz' and the region code 'ZZ' if they occur.
	 * 1.5 Get the components of the cleaned-up source tag (languages, scripts,
	 * and regions), plus any variants and extensions.
	 * 2. Lookup. Lookup each of the following in order, and stop on the first
	 * match:
	 * 2.1 languages_scripts_regions
	 * 2.2 languages_regions
	 * 2.3 languages_scripts
	 * 2.4 languages
	 * 2.5 und_scripts
	 * 3. Return
	 * 3.1 If there is no match, either return an error value, or the match for
	 * "und" (in APIs where a valid language tag is required).
	 * 3.2 Otherwise there is a match = languagem_scriptm_regionm
	 * 3.3 Let xr = xs if xs is not empty, and xm otherwise.
	 * 3.4 Return the language tag composed of languager _ scriptr _ regionr +
	 * variants + extensions.
	 *
	 * @subtags [Array] normalized language id subtags tuple (see init.js).
	 */
	var coreLikelySubtags = function( Cldr, cldr, subtags, options ) {
		var match, matchFound,
			language = subtags[ 0 ],
			script = subtags[ 1 ],
			sep = Cldr.localeSep,
			territory = subtags[ 2 ];
		options = options || {};

		// Skip if (language, script, territory) is not empty [3.3]
		if ( language !== "und" && script !== "Zzzz" && territory !== "ZZ" ) {
			return [ language, script, territory ];
		}

		// Skip if no supplemental likelySubtags data is present
		if ( typeof cldr.get( "supplemental/likelySubtags" ) === "undefined" ) {
			return;
		}

		// [2]
		matchFound = arraySome([
			[ language, script, territory ],
			[ language, territory ],
			[ language, script ],
			[ language ],
			[ "und", script ]
		], function( test ) {
			return match = !(/\b(Zzzz|ZZ)\b/).test( test.join( sep ) ) /* [1.4] */ && cldr.get( [ "supplemental/likelySubtags", test.join( sep ) ] );
		});

		// [3]
		if ( matchFound ) {
			// [3.2 .. 3.4]
			match = match.split( sep );
			return [
				language !== "und" ? language : match[ 0 ],
				script !== "Zzzz" ? script : match[ 1 ],
				territory !== "ZZ" ? territory : match[ 2 ]
			];
		} else if ( options.force ) {
			// [3.1.2]
			return cldr.get( "supplemental/likelySubtags/und" ).split( sep );
		} else {
			// [3.1.1]
			return;
		}
	};



	/**
	 * Given a locale, remove any fields that Add Likely Subtags would add.
	 * http://www.unicode.org/reports/tr35/#Likely_Subtags
	 * 1. First get max = AddLikelySubtags(inputLocale). If an error is signaled,
	 * return it.
	 * 2. Remove the variants from max.
	 * 3. Then for trial in {language, language _ region, language _ script}. If
	 * AddLikelySubtags(trial) = max, then return trial + variants.
	 * 4. If you do not get a match, return max + variants.
	 * 
	 * @maxLanguageId [Array] maxLanguageId tuple (see init.js).
	 */
	var coreRemoveLikelySubtags = function( Cldr, cldr, maxLanguageId ) {
		var match, matchFound,
			language = maxLanguageId[ 0 ],
			script = maxLanguageId[ 1 ],
			territory = maxLanguageId[ 2 ];

		// [3]
		matchFound = arraySome([
			[ [ language, "Zzzz", "ZZ" ], [ language ] ],
			[ [ language, "Zzzz", territory ], [ language, territory ] ],
			[ [ language, script, "ZZ" ], [ language, script ] ]
		], function( test ) {
			var result = coreLikelySubtags( Cldr, cldr, test[ 0 ] );
			match = test[ 1 ];
			return result && result[ 0 ] === maxLanguageId[ 0 ] &&
				result[ 1 ] === maxLanguageId[ 1 ] &&
				result[ 2 ] === maxLanguageId[ 2 ];
		});

		// [4]
		return matchFound ?  match : maxLanguageId;
	};




	/**
	 * subtags( locale )
	 *
	 * @locale [String]
	 */
	var coreSubtags = function( locale ) {
		var aux, unicodeLanguageId,
			subtags = [];

		locale = locale.replace( /_/, "-" );

		// Unicode locale extensions.
		aux = locale.split( "-u-" );
		if ( aux[ 1 ] ) {
			aux[ 1 ] = aux[ 1 ].split( "-t-" );
			locale = aux[ 0 ] + ( aux[ 1 ][ 1 ] ? "-t-" + aux[ 1 ][ 1 ] : "");
			subtags[ 4 /* unicodeLocaleExtensions */ ] = aux[ 1 ][ 0 ];
		}

		// TODO normalize transformed extensions. Currently, skipped.
		// subtags[ x ] = locale.split( "-t-" )[ 1 ];
		unicodeLanguageId = locale.split( "-t-" )[ 0 ];

		// unicode_language_id = "root"
		//   | unicode_language_subtag         
		//     (sep unicode_script_subtag)? 
		//     (sep unicode_region_subtag)?
		//     (sep unicode_variant_subtag)* ;
		//
		// Although unicode_language_subtag = alpha{2,8}, I'm using alpha{2,3}. Because, there's no language on CLDR lengthier than 3.
		aux = unicodeLanguageId.match( /^(([a-z]{2,3})(-([A-Z][a-z]{3}))?(-([A-Z]{2}|[0-9]{3}))?)(-[a-zA-Z0-9]{5,8}|[0-9][a-zA-Z0-9]{3})*$|^(root)$/ );
		if ( aux === null ) {
			return [ "und", "Zzzz", "ZZ" ];
		}
		subtags[ 0 /* language */ ] = aux[ 9 ] /* root */ || aux[ 2 ] || "und";
		subtags[ 1 /* script */ ] = aux[ 4 ] || "Zzzz";
		subtags[ 2 /* territory */ ] = aux[ 6 ] || "ZZ";
		subtags[ 3 /* variant */ ] = aux[ 7 ];

		// 0: language
		// 1: script
		// 2: territory (aka region)
		// 3: variant
		// 4: unicodeLocaleExtensions
		return subtags;
	};




	var arrayForEach = function( array, callback ) {
		var i, length;
		if ( array.forEach ) {
			return array.forEach( callback );
		}
		for ( i = 0, length = array.length; i < length; i++ ) {
			callback( array[ i ], i, array );
		}
	};




	/**
	 * bundleLookup( minLanguageId )
	 *
	 * @Cldr [Cldr class]
	 *
	 * @cldr [Cldr instance]
	 *
	 * @minLanguageId [String] requested languageId after applied remove likely subtags.
	 */
	var bundleLookup = function( Cldr, cldr, minLanguageId ) {
		var availableBundleMap = Cldr._availableBundleMap,
			availableBundleMapQueue = Cldr._availableBundleMapQueue;

		if ( availableBundleMapQueue.length ) {
			arrayForEach( availableBundleMapQueue, function( bundle ) {
				var existing, maxBundle, minBundle, subtags;
				subtags = coreSubtags( bundle );
				maxBundle = coreLikelySubtags( Cldr, cldr, subtags, { force: true } ) || subtags;
				minBundle = coreRemoveLikelySubtags( Cldr, cldr, maxBundle );
				minBundle = minBundle.join( Cldr.localeSep );
				existing = availableBundleMapQueue[ minBundle ];
				if ( existing && existing.length < bundle.length ) {
					return;
				}
				availableBundleMap[ minBundle ] = bundle;
			});
			Cldr._availableBundleMapQueue = [];
		}

		return availableBundleMap[ minLanguageId ] || null;
	};




	var objectKeys = function( object ) {
		var i,
			result = [];

		if ( Object.keys ) {
			return Object.keys( object );
		}

		for ( i in object ) {
			result.push( i );
		}

		return result;
	};




	var createError = function( code, attributes ) {
		var error, message;

		message = code + ( attributes && JSON ? ": " + JSON.stringify( attributes ) : "" );
		error = new Error( message );
		error.code = code;

		// extend( error, attributes );
		arrayForEach( objectKeys( attributes ), function( attribute ) {
			error[ attribute ] = attributes[ attribute ];
		});

		return error;
	};




	var validate = function( code, check, attributes ) {
		if ( !check ) {
			throw createError( code, attributes );
		}
	};




	var validatePresence = function( value, name ) {
		validate( "E_MISSING_PARAMETER", typeof value !== "undefined", {
			name: name
		});
	};




	var validateType = function( value, name, check, expected ) {
		validate( "E_INVALID_PAR_TYPE", check, {
			expected: expected,
			name: name,
			value: value
		});
	};




	var validateTypePath = function( value, name ) {
		validateType( value, name, typeof value === "string" || arrayIsArray( value ), "String or Array" );
	};




	/**
	 * Function inspired by jQuery Core, but reduced to our use case.
	 */
	var isPlainObject = function( obj ) {
		return obj !== null && "" + obj === "[object Object]";
	};




	var validateTypePlainObject = function( value, name ) {
		validateType( value, name, typeof value === "undefined" || isPlainObject( value ), "Plain Object" );
	};




	var validateTypeString = function( value, name ) {
		validateType( value, name, typeof value === "string", "a string" );
	};




	// @path: normalized path
	var resourceGet = function( data, path ) {
		var i,
			node = data,
			length = path.length;

		for ( i = 0; i < length - 1; i++ ) {
			node = node[ path[ i ] ];
			if ( !node ) {
				return undefined;
			}
		}
		return node[ path[ i ] ];
	};




	/**
	 * setAvailableBundles( Cldr, json )
	 *
	 * @Cldr [Cldr class]
	 *
	 * @json resolved/unresolved cldr data.
	 *
	 * Set available bundles queue based on passed json CLDR data. Considers a bundle as any String at /main/{bundle}.
	 */
	var coreSetAvailableBundles = function( Cldr, json ) {
		var bundle,
			availableBundleMapQueue = Cldr._availableBundleMapQueue,
			main = resourceGet( json, [ "main" ] );

		if ( main ) {
			for ( bundle in main ) {
				if ( main.hasOwnProperty( bundle ) && bundle !== "root" ) {
					availableBundleMapQueue.push( bundle );
				}
			}
		}
	};



	var alwaysArray = function( somethingOrArray ) {
		return arrayIsArray( somethingOrArray ) ?  somethingOrArray : [ somethingOrArray ];
	};


	var jsonMerge = (function() {

	// Returns new deeply merged JSON.
	//
	// Eg.
	// merge( { a: { b: 1, c: 2 } }, { a: { b: 3, d: 4 } } )
	// -> { a: { b: 3, c: 2, d: 4 } }
	//
	// @arguments JSON's
	// 
	var merge = function() {
		var destination = {},
			sources = [].slice.call( arguments, 0 );
		arrayForEach( sources, function( source ) {
			var prop;
			for ( prop in source ) {
				if ( prop in destination && arrayIsArray( destination[ prop ] ) ) {

					// Concat Arrays
					destination[ prop ] = destination[ prop ].concat( source[ prop ] );

				} else if ( prop in destination && typeof destination[ prop ] === "object" ) {

					// Merge Objects
					destination[ prop ] = merge( destination[ prop ], source[ prop ] );

				} else {

					// Set new values
					destination[ prop ] = source[ prop ];

				}
			}
		});
		return destination;
	};

	return merge;

}());


	/**
	 * load( Cldr, source, jsons )
	 *
	 * @Cldr [Cldr class]
	 *
	 * @source [Object]
	 *
	 * @jsons [arguments]
	 */
	var coreLoad = function( Cldr, source, jsons ) {
		var i, j, json;

		validatePresence( jsons[ 0 ], "json" );

		// Support arbitrary parameters, e.g., `Cldr.load({...}, {...})`.
		for ( i = 0; i < jsons.length; i++ ) {

			// Support array parameters, e.g., `Cldr.load([{...}, {...}])`.
			json = alwaysArray( jsons[ i ] );

			for ( j = 0; j < json.length; j++ ) {
				validateTypePlainObject( json[ j ], "json" );
				source = jsonMerge( source, json[ j ] );
				coreSetAvailableBundles( Cldr, json[ j ] );
			}
		}

		return source;
	};



	var itemGetResolved = function( Cldr, path, attributes ) {
		// Resolve path
		var normalizedPath = pathNormalize( path, attributes );

		return resourceGet( Cldr._resolved, normalizedPath );
	};




	/**
	 * new Cldr()
	 */
	var Cldr = function( locale ) {
		this.init( locale );
	};

	// Build optimization hack to avoid duplicating functions across modules.
	Cldr._alwaysArray = alwaysArray;
	Cldr._coreLoad = coreLoad;
	Cldr._createError = createError;
	Cldr._itemGetResolved = itemGetResolved;
	Cldr._jsonMerge = jsonMerge;
	Cldr._pathNormalize = pathNormalize;
	Cldr._resourceGet = resourceGet;
	Cldr._validatePresence = validatePresence;
	Cldr._validateType = validateType;
	Cldr._validateTypePath = validateTypePath;
	Cldr._validateTypePlainObject = validateTypePlainObject;

	Cldr._availableBundleMap = {};
	Cldr._availableBundleMapQueue = [];
	Cldr._resolved = {};

	// Allow user to override locale separator "-" (default) | "_". According to http://www.unicode.org/reports/tr35/#Unicode_language_identifier, both "-" and "_" are valid locale separators (eg. "en_GB", "en-GB"). According to http://unicode.org/cldr/trac/ticket/6786 its usage must be consistent throughout the data set.
	Cldr.localeSep = "-";

	/**
	 * Cldr.load( json [, json, ...] )
	 *
	 * @json [JSON] CLDR data or [Array] Array of @json's.
	 *
	 * Load resolved cldr data.
	 */
	Cldr.load = function() {
		Cldr._resolved = coreLoad( Cldr, Cldr._resolved, arguments );
	};

	/**
	 * .init() automatically run on instantiation/construction.
	 */
	Cldr.prototype.init = function( locale ) {
		var attributes, language, maxLanguageId, minLanguageId, script, subtags, territory, unicodeLocaleExtensions, variant,
			sep = Cldr.localeSep;

		validatePresence( locale, "locale" );
		validateTypeString( locale, "locale" );

		subtags = coreSubtags( locale );

		unicodeLocaleExtensions = subtags[ 4 ];
		variant = subtags[ 3 ];

		// Normalize locale code.
		// Get (or deduce) the "triple subtags": language, territory (also aliased as region), and script subtags.
		// Get the variant subtags (calendar, collation, currency, etc).
		// refs:
		// - http://www.unicode.org/reports/tr35/#Field_Definitions
		// - http://www.unicode.org/reports/tr35/#Language_and_Locale_IDs
		// - http://www.unicode.org/reports/tr35/#Unicode_locale_identifier

		// When a locale id does not specify a language, or territory (region), or script, they are obtained by Likely Subtags.
		maxLanguageId = coreLikelySubtags( Cldr, this, subtags, { force: true } ) || subtags;
		language = maxLanguageId[ 0 ];
		script = maxLanguageId[ 1 ];
		territory = maxLanguageId[ 2 ];

		minLanguageId = coreRemoveLikelySubtags( Cldr, this, maxLanguageId ).join( sep );

		// Set attributes
		this.attributes = attributes = {
			bundle: bundleLookup( Cldr, this, minLanguageId ),

			// Unicode Language Id
			minlanguageId: minLanguageId,
			maxLanguageId: maxLanguageId.join( sep ),

			// Unicode Language Id Subtabs
			language: language,
			script: script,
			territory: territory,
			region: territory, /* alias */
			variant: variant
		};

		// Unicode locale extensions.
		unicodeLocaleExtensions && ( "-" + unicodeLocaleExtensions ).replace( /-[a-z]{3,8}|(-[a-z]{2})-([a-z]{3,8})/g, function( attribute, key, type ) {

			if ( key ) {

				// Extension is in the `keyword` form.
				attributes[ "u" + key ] = type;
			} else {

				// Extension is in the `attribute` form.
				attributes[ "u" + attribute ] = true;
			}
		});

		this.locale = locale;
	};

	/**
	 * .get()
	 */
	Cldr.prototype.get = function( path ) {

		validatePresence( path, "path" );
		validateTypePath( path, "path" );

		return itemGetResolved( Cldr, path, this.attributes );
	};

	/**
	 * .main()
	 */
	Cldr.prototype.main = function( path ) {
		validatePresence( path, "path" );
		validateTypePath( path, "path" );

		validate( "E_MISSING_BUNDLE", this.attributes.bundle !== null, {
			locale: this.locale
		});

		path = alwaysArray( path );
		return this.get( [ "main/{bundle}" ].concat( path ) );
	};

	return Cldr;




}));
