/**
 * Globalize v1.0.0
 *
 * http://github.com/jquery/globalize
 *
 * Copyright 2010, 2014 jQuery Foundation, Inc. and other contributors
 * Released under the MIT license
 * http://jquery.org/license
 *
 * Date: 2015-04-23T12:02Z
 */
/*!
 * Globalize v1.0.0 2015-04-23T12:02Z Released under the MIT license
 * http://git.io/TrdQbw
 */
(function( root, factory ) {

	// UMD returnExports
	if ( typeof define === "function" && define.amd ) {

		// AMD
		define([
			"cldr",
			"../globalize",
			"./number",
			"./plural",
			"cldr/event",
			"cldr/supplemental"
		], factory );
	} else if ( typeof exports === "object" ) {

		// Node, CommonJS
		module.exports = factory( require( "cldrjs" ), require( "globalize" ) );
	} else {

		// Extend global
		factory( root.Cldr, root.Globalize );
	}
}(this, function( Cldr, Globalize ) {

var formatMessage = Globalize._formatMessage,
	validateCldr = Globalize._validateCldr,
	validateDefaultLocale = Globalize._validateDefaultLocale,
	validateParameterPresence = Globalize._validateParameterPresence,
	validateParameterTypeString = Globalize._validateParameterTypeString,
	validateParameterTypeNumber = Globalize._validateParameterTypeNumber;


/**
 * format( value, numberFormatter, pluralGenerator, properties )
 *
 * @value [Number] The number to format
 *
 * @numberFormatter [String] A numberFormatter from Globalize.numberFormatter
 *
 * @pluralGenerator [String] A pluralGenerator from Globalize.pluralGenerator
 *
 * @properties [Object] containing relative time plural message.
 *
 * Format relative time.
 */
var relativeTimeFormat = function( value, numberFormatter, pluralGenerator, properties ) {

	var relativeTime,
		message = properties[ "relative-type-" + value ];

	if ( message ) {
		return message;
	}

	relativeTime = value <= 0 ? properties[ "relativeTime-type-past" ]
		: properties[ "relativeTime-type-future" ];

	value = Math.abs( value );

	message = relativeTime[ "relativeTimePattern-count-" + pluralGenerator( value ) ];
	return formatMessage( message, [ numberFormatter( value ) ] );
};




/**
 * properties( unit, cldr, options )
 *
 * @unit [String] eg. "day", "week", "month", etc.
 *
 * @cldr [Cldr instance].
 *
 * @options [Object]
 * - form: [String] eg. "short" or "narrow". Or falsy for default long form.
 *
 * Return relative time properties.
 */
var relativeTimeProperties = function( unit, cldr, options ) {

	var form = options.form,
		raw, properties, key, match;

	if ( form ) {
		unit = unit + "-" + form;
	}

	raw = cldr.main( [ "dates", "fields", unit ] );
	properties = {
		"relativeTime-type-future": raw[ "relativeTime-type-future" ],
		"relativeTime-type-past": raw[ "relativeTime-type-past" ]
	};
	for ( key in raw ) {
		if ( raw.hasOwnProperty( key ) ) {
			match = /relative-type-(-?[0-9]+)/.exec( key );
			if ( match ) {
				properties[ key ] = raw[ key ];
			}
		}
	}

	return properties;
};




/**
 * .formatRelativeTime( value, unit [, options] )
 *
 * @value [Number] The number of unit to format.
 *
 * @unit [String] see .relativeTimeFormatter() for details.
 *
 * @options [Object] see .relativeTimeFormatter() for details.
 *
 * Formats a relative time according to the given unit, options, and the default/instance locale.
 */
Globalize.formatRelativeTime =
Globalize.prototype.formatRelativeTime = function( value, unit, options ) {

	validateParameterPresence( value, "value" );
	validateParameterTypeNumber( value, "value" );

	return this.relativeTimeFormatter( unit, options )( value );
};

/**
 * .relativeTimeFormatter( unit [, options ])
 *
 * @unit [String] String value indicating the unit to be formatted. eg. "day", "week", "month", etc.
 *
 * @options [Object]
 * - form: [String] eg. "short" or "narrow". Or falsy for default long form.
 *
 * Returns a function that formats a relative time according to the given unit, options, and the
 * default/instance locale.
 */
Globalize.relativeTimeFormatter =
Globalize.prototype.relativeTimeFormatter = function( unit, options ) {
	var cldr, numberFormatter, pluralGenerator, properties;

	validateParameterPresence( unit, "unit" );
	validateParameterTypeString( unit, "unit" );

	cldr = this.cldr;
	options = options || {};

	validateDefaultLocale( cldr );

	cldr.on( "get", validateCldr );
	properties = relativeTimeProperties( unit, cldr, options );
	cldr.off( "get", validateCldr );

	numberFormatter = this.numberFormatter( options );
	pluralGenerator = this.pluralGenerator();

	return function( value ) {
		validateParameterPresence( value, "value" );
		validateParameterTypeNumber( value, "value" );

		return relativeTimeFormat( value, numberFormatter, pluralGenerator, properties );
	};
};

return Globalize;




}));
