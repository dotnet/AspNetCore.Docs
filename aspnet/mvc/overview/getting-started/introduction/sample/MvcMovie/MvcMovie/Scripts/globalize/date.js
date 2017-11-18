/**
 * Globalize v1.0.0
 *
 * http://github.com/jquery/globalize
 *
 * Copyright jQuery Foundation and other contributors
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

var createError = Globalize._createError,
	createErrorUnsupportedFeature = Globalize._createErrorUnsupportedFeature,
	formatMessage = Globalize._formatMessage,
	numberSymbol = Globalize._numberSymbol,
	regexpEscape = Globalize._regexpEscape,
	stringPad = Globalize._stringPad,
	validateCldr = Globalize._validateCldr,
	validateDefaultLocale = Globalize._validateDefaultLocale,
	validateParameterPresence = Globalize._validateParameterPresence,
	validateParameterType = Globalize._validateParameterType,
	validateParameterTypePlainObject = Globalize._validateParameterTypePlainObject,
	validateParameterTypeString = Globalize._validateParameterTypeString;


var validateParameterTypeDate = function( value, name ) {
	validateParameterType( value, name, value === undefined || value instanceof Date, "Date" );
};




var createErrorInvalidParameterValue = function( name, value ) {
	return createError( "E_INVALID_PAR_VALUE", "Invalid `{name}` value ({value}).", {
		name: name,
		value: value
	});
};




/**
 * expandPattern( options, cldr )
 *
 * @options [Object] if String, it's considered a skeleton. Object accepts:
 * - skeleton: [String] lookup availableFormat;
 * - date: [String] ( "full" | "long" | "medium" | "short" );
 * - time: [String] ( "full" | "long" | "medium" | "short" );
 * - datetime: [String] ( "full" | "long" | "medium" | "short" );
 * - raw: [String] For more info see datetime/format.js.
 *
 * @cldr [Cldr instance].
 *
 * Return the corresponding pattern.
 * Eg for "en":
 * - "GyMMMd" returns "MMM d, y G";
 * - { skeleton: "GyMMMd" } returns "MMM d, y G";
 * - { date: "full" } returns "EEEE, MMMM d, y";
 * - { time: "full" } returns "h:mm:ss a zzzz";
 * - { datetime: "full" } returns "EEEE, MMMM d, y 'at' h:mm:ss a zzzz";
 * - { raw: "dd/mm" } returns "dd/mm";
 */

var dateExpandPattern = function( options, cldr ) {
	var dateSkeleton, result, skeleton, timeSkeleton, type;

	function combineDateTime( type, datePattern, timePattern ) {
		return formatMessage(
			cldr.main([
				"dates/calendars/gregorian/dateTimeFormats",
				type
			]),
			[ timePattern, datePattern ]
		);
	}

	switch ( true ) {
		case "skeleton" in options:
			skeleton = options.skeleton;
			result = cldr.main([
				"dates/calendars/gregorian/dateTimeFormats/availableFormats",
				skeleton
			]);
			if ( !result ) {
				timeSkeleton = skeleton.split( /[^hHKkmsSAzZOvVXx]/ ).slice( -1 )[ 0 ];
				dateSkeleton = skeleton.split( /[^GyYuUrQqMLlwWdDFgEec]/ )[ 0 ];
				if ( /(MMMM|LLLL).*[Ec]/.test( dateSkeleton ) ) {
					type = "full";
				} else if ( /MMMM/g.test( dateSkeleton ) ) {
					type = "long";
				} else if ( /MMM/g.test( dateSkeleton ) || /LLL/g.test( dateSkeleton ) ) {
					type = "medium";
				} else {
					type = "short";
				}
				result = combineDateTime( type,
					cldr.main([
						"dates/calendars/gregorian/dateTimeFormats/availableFormats",
						dateSkeleton
					]),
					cldr.main([
						"dates/calendars/gregorian/dateTimeFormats/availableFormats",
						timeSkeleton
					])
				);
			}
			break;

		case "date" in options:
		case "time" in options:
			result = cldr.main([
				"dates/calendars/gregorian",
				"date" in options ? "dateFormats" : "timeFormats",
				( options.date || options.time )
			]);
			break;

		case "datetime" in options:
			result = combineDateTime( options.datetime,
				cldr.main([ "dates/calendars/gregorian/dateFormats", options.datetime ]),
				cldr.main([ "dates/calendars/gregorian/timeFormats", options.datetime ])
			);
			break;

		case "raw" in options:
			result = options.raw;
			break;

		default:
			throw createErrorInvalidParameterValue({
				name: "options",
				value: options
			});
	}

	return result;
};




/**
 * dayOfWeek( date, firstDay )
 *
 * @date
 *
 * @firstDay the result of `dateFirstDayOfWeek( cldr )`
 *
 * Return the day of the week normalized by the territory's firstDay [0-6].
 * Eg for "mon":
 * - return 0 if territory is GB, or BR, or DE, or FR (week starts on "mon");
 * - return 1 if territory is US (week starts on "sun");
 * - return 2 if territory is EG (week starts on "sat");
 */
var dateDayOfWeek = function( date, firstDay ) {
	return ( date.getDay() - firstDay + 7 ) % 7;
};




/**
 * distanceInDays( from, to )
 *
 * Return the distance in days between from and to Dates.
 */
var dateDistanceInDays = function( from, to ) {
	var inDays = 864e5;
	return ( to.getTime() - from.getTime() ) / inDays;
};




/**
 * startOf changes the input to the beginning of the given unit.
 *
 * For example, starting at the start of a day, resets hours, minutes
 * seconds and milliseconds to 0. Starting at the month does the same, but
 * also sets the date to 1.
 *
 * Returns the modified date
 */
var dateStartOf = function( date, unit ) {
	date = new Date( date.getTime() );
	switch ( unit ) {
		case "year":
			date.setMonth( 0 );
		/* falls through */
		case "month":
			date.setDate( 1 );
		/* falls through */
		case "day":
			date.setHours( 0 );
		/* falls through */
		case "hour":
			date.setMinutes( 0 );
		/* falls through */
		case "minute":
			date.setSeconds( 0 );
		/* falls through */
		case "second":
			date.setMilliseconds( 0 );
	}
	return date;
};




/**
 * dayOfYear
 *
 * Return the distance in days of the date to the begin of the year [0-d].
 */
var dateDayOfYear = function( date ) {
	return Math.floor( dateDistanceInDays( dateStartOf( date, "year" ), date ) );
};




var dateWeekDays = [ "sun", "mon", "tue", "wed", "thu", "fri", "sat" ];




/**
 * firstDayOfWeek
 */
var dateFirstDayOfWeek = function( cldr ) {
	return dateWeekDays.indexOf( cldr.supplemental.weekData.firstDay() );
};




/**
 * millisecondsInDay
 */
var dateMillisecondsInDay = function( date ) {
	// TODO Handle daylight savings discontinuities
	return date - dateStartOf( date, "day" );
};




var datePatternRe = (/([a-z])\1*|'([^']|'')+'|''|./ig);




/**
 * hourFormat( date, format, timeSeparator, formatNumber )
 *
 * Return date's timezone offset according to the format passed.
 * Eg for format when timezone offset is 180:
 * - "+H;-H": -3
 * - "+HHmm;-HHmm": -0300
 * - "+HH:mm;-HH:mm": -03:00
 */
var dateTimezoneHourFormat = function( date, format, timeSeparator, formatNumber ) {
	var absOffset,
		offset = date.getTimezoneOffset();

	absOffset = Math.abs( offset );
	formatNumber = formatNumber || {
		1: function( value ) {
			return stringPad( value, 1 );
		},
		2: function( value ) {
			return stringPad( value, 2 );
		}
	};

	return format

		// Pick the correct sign side (+ or -).
		.split( ";" )[ offset > 0 ? 1 : 0 ]

		// Localize time separator
		.replace( ":", timeSeparator )

		// Update hours offset.
		.replace( /HH?/, function( match ) {
			return formatNumber[ match.length ]( Math.floor( absOffset / 60 ) );
		})

		// Update minutes offset and return.
		.replace( /mm/, function() {
			return formatNumber[ 2 ]( absOffset % 60 );
		});
};




/**
 * format( date, properties )
 *
 * @date [Date instance].
 *
 * @properties
 *
 * TODO Support other calendar types.
 *
 * Disclosure: this function borrows excerpts of dojo/date/locale.
 */
var dateFormat = function( date, numberFormatters, properties ) {
	var timeSeparator = properties.timeSeparator;

	return properties.pattern.replace( datePatternRe, function( current ) {
		var ret,
			chr = current.charAt( 0 ),
			length = current.length;

		if ( chr === "j" ) {
			// Locale preferred hHKk.
			// http://www.unicode.org/reports/tr35/tr35-dates.html#Time_Data
			chr = properties.preferredTime;
		}

		if ( chr === "Z" ) {
			// Z..ZZZ: same as "xxxx".
			if ( length < 4 ) {
				chr = "x";
				length = 4;

			// ZZZZ: same as "OOOO".
			} else if ( length < 5 ) {
				chr = "O";
				length = 4;

			// ZZZZZ: same as "XXXXX"
			} else {
				chr = "X";
				length = 5;
			}
		}

		switch ( chr ) {

			// Era
			case "G":
				ret = properties.eras[ date.getFullYear() < 0 ? 0 : 1 ];
				break;

			// Year
			case "y":
				// Plain year.
				// The length specifies the padding, but for two letters it also specifies the
				// maximum length.
				ret = date.getFullYear();
				if ( length === 2 ) {
					ret = String( ret );
					ret = +ret.substr( ret.length - 2 );
				}
				break;

			case "Y":
				// Year in "Week of Year"
				// The length specifies the padding, but for two letters it also specifies the
				// maximum length.
				// yearInWeekofYear = date + DaysInAWeek - (dayOfWeek - firstDay) - minDays
				ret = new Date( date.getTime() );
				ret.setDate(
					ret.getDate() + 7 -
					dateDayOfWeek( date, properties.firstDay ) -
					properties.firstDay -
					properties.minDays
				);
				ret = ret.getFullYear();
				if ( length === 2 ) {
					ret = String( ret );
					ret = +ret.substr( ret.length - 2 );
				}
				break;

			// Quarter
			case "Q":
			case "q":
				ret = Math.ceil( ( date.getMonth() + 1 ) / 3 );
				if ( length > 2 ) {
					ret = properties.quarters[ chr ][ length ][ ret ];
				}
				break;

			// Month
			case "M":
			case "L":
				ret = date.getMonth() + 1;
				if ( length > 2 ) {
					ret = properties.months[ chr ][ length ][ ret ];
				}
				break;

			// Week
			case "w":
				// Week of Year.
				// woy = ceil( ( doy + dow of 1/1 ) / 7 ) - minDaysStuff ? 1 : 0.
				// TODO should pad on ww? Not documented, but I guess so.
				ret = dateDayOfWeek( dateStartOf( date, "year" ), properties.firstDay );
				ret = Math.ceil( ( dateDayOfYear( date ) + ret ) / 7 ) -
					( 7 - ret >= properties.minDays ? 0 : 1 );
				break;

			case "W":
				// Week of Month.
				// wom = ceil( ( dom + dow of `1/month` ) / 7 ) - minDaysStuff ? 1 : 0.
				ret = dateDayOfWeek( dateStartOf( date, "month" ), properties.firstDay );
				ret = Math.ceil( ( date.getDate() + ret ) / 7 ) -
					( 7 - ret >= properties.minDays ? 0 : 1 );
				break;

			// Day
			case "d":
				ret = date.getDate();
				break;

			case "D":
				ret = dateDayOfYear( date ) + 1;
				break;

			case "F":
				// Day of Week in month. eg. 2nd Wed in July.
				ret = Math.floor( date.getDate() / 7 ) + 1;
				break;

			// Week day
			case "e":
			case "c":
				if ( length <= 2 ) {
					// Range is [1-7] (deduced by example provided on documentation)
					// TODO Should pad with zeros (not specified in the docs)?
					ret = dateDayOfWeek( date, properties.firstDay ) + 1;
					break;
				}

			/* falls through */
			case "E":
				ret = dateWeekDays[ date.getDay() ];
				ret = properties.days[ chr ][ length ][ ret ];
				break;

			// Period (AM or PM)
			case "a":
				ret = properties.dayPeriods[ date.getHours() < 12 ? "am" : "pm" ];
				break;

			// Hour
			case "h": // 1-12
				ret = ( date.getHours() % 12 ) || 12;
				break;

			case "H": // 0-23
				ret = date.getHours();
				break;

			case "K": // 0-11
				ret = date.getHours() % 12;
				break;

			case "k": // 1-24
				ret = date.getHours() || 24;
				break;

			// Minute
			case "m":
				ret = date.getMinutes();
				break;

			// Second
			case "s":
				ret = date.getSeconds();
				break;

			case "S":
				ret = Math.round( date.getMilliseconds() * Math.pow( 10, length - 3 ) );
				break;

			case "A":
				ret = Math.round( dateMillisecondsInDay( date ) * Math.pow( 10, length - 3 ) );
				break;

			// Zone
			case "z":
			case "O":
				// O: "{gmtFormat}+H;{gmtFormat}-H" or "{gmtZeroFormat}", eg. "GMT-8" or "GMT".
				// OOOO: "{gmtFormat}{hourFormat}" or "{gmtZeroFormat}", eg. "GMT-08:00" or "GMT".
				if ( date.getTimezoneOffset() === 0 ) {
					ret = properties.gmtZeroFormat;
				} else {
					ret = dateTimezoneHourFormat(
						date,
						length < 4 ? "+H;-H" : properties.tzLongHourFormat,
						timeSeparator,
						numberFormatters
					);
					ret = properties.gmtFormat.replace( /\{0\}/, ret );
				}
				break;

			case "X":
				// Same as x*, except it uses "Z" for zero offset.
				if ( date.getTimezoneOffset() === 0 ) {
					ret = "Z";
					break;
				}

			/* falls through */
			case "x":
				// x: hourFormat("+HH;-HH")
				// xx or xxxx: hourFormat("+HHmm;-HHmm")
				// xxx or xxxxx: hourFormat("+HH:mm;-HH:mm")
				ret = length === 1 ? "+HH;-HH" : ( length % 2 ? "+HH:mm;-HH:mm" : "+HHmm;-HHmm" );
				ret = dateTimezoneHourFormat( date, ret, ":" );
				break;

			// timeSeparator
			case ":":
				ret = timeSeparator;
				break;

			// ' literals.
			case "'":
				current = current.replace( /''/, "'" );
				if ( length > 2 ) {
					current = current.slice( 1, -1 );
				}
				ret = current;
				break;

			// Anything else is considered a literal, including [ ,:/.@#], chinese, japonese, and
			// arabic characters.
			default:
				ret = current;
		}
		if ( typeof ret === "number" ) {
			ret = numberFormatters[ length ]( ret );
		}
		return ret;
	});
};




/**
 * properties( pattern, cldr )
 *
 * @pattern [String] raw pattern.
 * ref: http://www.unicode.org/reports/tr35/tr35-dates.html#Date_Format_Patterns
 *
 * @cldr [Cldr instance].
 *
 * Return the properties given the pattern and cldr.
 *
 * TODO Support other calendar types.
 */
var dateFormatProperties = function( pattern, cldr ) {
	var properties = {
			pattern: pattern,
			timeSeparator: numberSymbol( "timeSeparator", cldr )
		},
		widths = [ "abbreviated", "wide", "narrow" ];

	function setNumberFormatterPattern( pad ) {
		if ( !properties.numberFormatters ) {
			properties.numberFormatters = {};
		}
		properties.numberFormatters[ pad ] = stringPad( "", pad );
	}

	pattern.replace( datePatternRe, function( current ) {
		var formatNumber,
			chr = current.charAt( 0 ),
			length = current.length;

		if ( chr === "j" ) {
			// Locale preferred hHKk.
			// http://www.unicode.org/reports/tr35/tr35-dates.html#Time_Data
			properties.preferredTime = chr = cldr.supplemental.timeData.preferred();
		}

		// ZZZZ: same as "OOOO".
		if ( chr === "Z" && length === 4 ) {
			chr = "O";
			length = 4;
		}

		switch ( chr ) {

			// Era
			case "G":
				properties.eras = cldr.main([
					"dates/calendars/gregorian/eras",
					length <= 3 ? "eraAbbr" : ( length === 4 ? "eraNames" : "eraNarrow" )
				]);
				break;

			// Year
			case "y":
				// Plain year.
				formatNumber = true;
				break;

			case "Y":
				// Year in "Week of Year"
				properties.firstDay = dateFirstDayOfWeek( cldr );
				properties.minDays = cldr.supplemental.weekData.minDays();
				formatNumber = true;
				break;

			case "u": // Extended year. Need to be implemented.
			case "U": // Cyclic year name. Need to be implemented.
				throw createErrorUnsupportedFeature({
					feature: "year pattern `" + chr + "`"
				});

			// Quarter
			case "Q":
			case "q":
				if ( length > 2 ) {
					if ( !properties.quarters ) {
						properties.quarters = {};
					}
					if ( !properties.quarters[ chr ] ) {
						properties.quarters[ chr ] = {};
					}
					properties.quarters[ chr ][ length ] = cldr.main([
						"dates/calendars/gregorian/quarters",
						chr === "Q" ? "format" : "stand-alone",
						widths[ length - 3 ]
					]);
				} else {
					formatNumber = true;
				}
				break;

			// Month
			case "M":
			case "L":
				if ( length > 2 ) {
					if ( !properties.months ) {
						properties.months = {};
					}
					if ( !properties.months[ chr ] ) {
						properties.months[ chr ] = {};
					}
					properties.months[ chr ][ length ] = cldr.main([
						"dates/calendars/gregorian/months",
						chr === "M" ? "format" : "stand-alone",
						widths[ length - 3 ]
					]);
				} else {
					formatNumber = true;
				}
				break;

			// Week - Week of Year (w) or Week of Month (W).
			case "w":
			case "W":
				properties.firstDay = dateFirstDayOfWeek( cldr );
				properties.minDays = cldr.supplemental.weekData.minDays();
				formatNumber = true;
				break;

			// Day
			case "d":
			case "D":
			case "F":
				formatNumber = true;
				break;

			case "g":
				// Modified Julian day. Need to be implemented.
				throw createErrorUnsupportedFeature({
					feature: "Julian day pattern `g`"
				});

			// Week day
			case "e":
			case "c":
				if ( length <= 2 ) {
					properties.firstDay = dateFirstDayOfWeek( cldr );
					formatNumber = true;
					break;
				}

			/* falls through */
			case "E":
				if ( !properties.days ) {
					properties.days = {};
				}
				if ( !properties.days[ chr ] ) {
					properties.days[ chr ] = {};
				}
				if ( length === 6 ) {

					// If short day names are not explicitly specified, abbreviated day names are
					// used instead.
					// http://www.unicode.org/reports/tr35/tr35-dates.html#months_days_quarters_eras
					// http://unicode.org/cldr/trac/ticket/6790
					properties.days[ chr ][ length ] = cldr.main([
							"dates/calendars/gregorian/days",
							chr === "c" ? "stand-alone" : "format",
							"short"
						]) || cldr.main([
							"dates/calendars/gregorian/days",
							chr === "c" ? "stand-alone" : "format",
							"abbreviated"
						]);
				} else {
					properties.days[ chr ][ length ] = cldr.main([
						"dates/calendars/gregorian/days",
						chr === "c" ? "stand-alone" : "format",
						widths[ length < 3 ? 0 : length - 3 ]
					]);
				}
				break;

			// Period (AM or PM)
			case "a":
				properties.dayPeriods = cldr.main(
					"dates/calendars/gregorian/dayPeriods/format/wide"
				);
				break;

			// Hour
			case "h": // 1-12
			case "H": // 0-23
			case "K": // 0-11
			case "k": // 1-24

			// Minute
			case "m":

			// Second
			case "s":
			case "S":
			case "A":
				formatNumber = true;
				break;

			// Zone
			case "z":
			case "O":
				// O: "{gmtFormat}+H;{gmtFormat}-H" or "{gmtZeroFormat}", eg. "GMT-8" or "GMT".
				// OOOO: "{gmtFormat}{hourFormat}" or "{gmtZeroFormat}", eg. "GMT-08:00" or "GMT".
				properties.gmtFormat = cldr.main( "dates/timeZoneNames/gmtFormat" );
				properties.gmtZeroFormat = cldr.main( "dates/timeZoneNames/gmtZeroFormat" );
				properties.tzLongHourFormat = cldr.main( "dates/timeZoneNames/hourFormat" );

			/* falls through */
			case "Z":
			case "X":
			case "x":
				setNumberFormatterPattern( 1 );
				setNumberFormatterPattern( 2 );
				break;

			case "v":
			case "V":
				throw createErrorUnsupportedFeature({
					feature: "timezone pattern `" + chr + "`"
				});
		}

		if ( formatNumber ) {
			setNumberFormatterPattern( length );
		}
	});

	return properties;
};




/**
 * isLeapYear( year )
 *
 * @year [Number]
 *
 * Returns an indication whether the specified year is a leap year.
 */
var dateIsLeapYear = function( year ) {
	return new Date(year, 1, 29).getMonth() === 1;
};




/**
 * lastDayOfMonth( date )
 *
 * @date [Date]
 *
 * Return the last day of the given date's month
 */
var dateLastDayOfMonth = function( date ) {
	return new Date( date.getFullYear(), date.getMonth() + 1, 0).getDate();
};




/**
 * Differently from native date.setDate(), this function returns a date whose
 * day remains inside the month boundaries. For example:
 *
 * setDate( FebDate, 31 ): a "Feb 28" date.
 * setDate( SepDate, 31 ): a "Sep 30" date.
 */
var dateSetDate = function( date, day ) {
	var lastDay = new Date( date.getFullYear(), date.getMonth() + 1, 0 ).getDate();

	date.setDate( day < 1 ? 1 : day < lastDay ? day : lastDay );
};




/**
 * Differently from native date.setMonth(), this function adjusts date if
 * needed, so final month is always the one set.
 *
 * setMonth( Jan31Date, 1 ): a "Feb 28" date.
 * setDate( Jan31Date, 8 ): a "Sep 30" date.
 */
var dateSetMonth = function( date, month ) {
	var originalDate = date.getDate();

	date.setDate( 1 );
	date.setMonth( month );
	dateSetDate( date, originalDate );
};




var outOfRange = function( value, low, high ) {
	return value < low || value > high;
};




/**
 * parse( value, tokens, properties )
 *
 * @value [String] string date.
 *
 * @tokens [Object] tokens returned by date/tokenizer.
 *
 * @properties [Object] output returned by date/tokenizer-properties.
 *
 * ref: http://www.unicode.org/reports/tr35/tr35-dates.html#Date_Format_Patterns
 */
var dateParse = function( value, tokens, properties ) {
	var amPm, day, daysOfYear, era, hour, hour12, timezoneOffset, valid,
		YEAR = 0,
		MONTH = 1,
		DAY = 2,
		HOUR = 3,
		MINUTE = 4,
		SECOND = 5,
		MILLISECONDS = 6,
		date = new Date(),
		truncateAt = [],
		units = [ "year", "month", "day", "hour", "minute", "second", "milliseconds" ];

	if ( !tokens.length ) {
		return null;
	}

	valid = tokens.every(function( token ) {
		var century, chr, value, length;

		if ( token.type === "literal" ) {
			// continue
			return true;
		}

		chr = token.type.charAt( 0 );
		length = token.type.length;

		if ( chr === "j" ) {
			// Locale preferred hHKk.
			// http://www.unicode.org/reports/tr35/tr35-dates.html#Time_Data
			chr = properties.preferredTimeData;
		}

		switch ( chr ) {

			// Era
			case "G":
				truncateAt.push( YEAR );
				era = +token.value;
				break;

			// Year
			case "y":
				value = token.value;
				if ( length === 2 ) {
					if ( outOfRange( value, 0, 99 ) ) {
						return false;
					}
					// mimic dojo/date/locale: choose century to apply, according to a sliding
					// window of 80 years before and 20 years after present year.
					century = Math.floor( date.getFullYear() / 100 ) * 100;
					value += century;
					if ( value > date.getFullYear() + 20 ) {
						value -= 100;
					}
				}
				date.setFullYear( value );
				truncateAt.push( YEAR );
				break;

			case "Y": // Year in "Week of Year"
				throw createErrorUnsupportedFeature({
					feature: "year pattern `" + chr + "`"
				});

			// Quarter (skip)
			case "Q":
			case "q":
				break;

			// Month
			case "M":
			case "L":
				if ( length <= 2 ) {
					value = token.value;
				} else {
					value = +token.value;
				}
				if ( outOfRange( value, 1, 12 ) ) {
					return false;
				}
				dateSetMonth( date, value - 1 );
				truncateAt.push( MONTH );
				break;

			// Week (skip)
			case "w": // Week of Year.
			case "W": // Week of Month.
				break;

			// Day
			case "d":
				day = token.value;
				truncateAt.push( DAY );
				break;

			case "D":
				daysOfYear = token.value;
				truncateAt.push( DAY );
				break;

			case "F":
				// Day of Week in month. eg. 2nd Wed in July.
				// Skip
				break;

			// Week day
			case "e":
			case "c":
			case "E":
				// Skip.
				// value = arrayIndexOf( dateWeekDays, token.value );
				break;

			// Period (AM or PM)
			case "a":
				amPm = token.value;
				break;

			// Hour
			case "h": // 1-12
				value = token.value;
				if ( outOfRange( value, 1, 12 ) ) {
					return false;
				}
				hour = hour12 = true;
				date.setHours( value === 12 ? 0 : value );
				truncateAt.push( HOUR );
				break;

			case "K": // 0-11
				value = token.value;
				if ( outOfRange( value, 0, 11 ) ) {
					return false;
				}
				hour = hour12 = true;
				date.setHours( value );
				truncateAt.push( HOUR );
				break;

			case "k": // 1-24
				value = token.value;
				if ( outOfRange( value, 1, 24 ) ) {
					return false;
				}
				hour = true;
				date.setHours( value === 24 ? 0 : value );
				truncateAt.push( HOUR );
				break;

			case "H": // 0-23
				value = token.value;
				if ( outOfRange( value, 0, 23 ) ) {
					return false;
				}
				hour = true;
				date.setHours( value );
				truncateAt.push( HOUR );
				break;

			// Minute
			case "m":
				value = token.value;
				if ( outOfRange( value, 0, 59 ) ) {
					return false;
				}
				date.setMinutes( value );
				truncateAt.push( MINUTE );
				break;

			// Second
			case "s":
				value = token.value;
				if ( outOfRange( value, 0, 59 ) ) {
					return false;
				}
				date.setSeconds( value );
				truncateAt.push( SECOND );
				break;

			case "A":
				date.setHours( 0 );
				date.setMinutes( 0 );
				date.setSeconds( 0 );

			/* falls through */
			case "S":
				value = Math.round( token.value * Math.pow( 10, 3 - length ) );
				date.setMilliseconds( value );
				truncateAt.push( MILLISECONDS );
				break;

			// Zone
			case "Z":
			case "z":
			case "O":
			case "X":
			case "x":
				timezoneOffset = token.value - date.getTimezoneOffset();
				break;
		}

		return true;
	});

	if ( !valid ) {
		return null;
	}

	// 12-hour format needs AM or PM, 24-hour format doesn't, ie. return null
	// if amPm && !hour12 || !amPm && hour12.
	if ( hour && !( !amPm ^ hour12 ) ) {
		return null;
	}

	if ( era === 0 ) {
		// 1 BC = year 0
		date.setFullYear( date.getFullYear() * -1 + 1 );
	}

	if ( day !== undefined ) {
		if ( outOfRange( day, 1, dateLastDayOfMonth( date ) ) ) {
			return null;
		}
		date.setDate( day );
	} else if ( daysOfYear !== undefined ) {
		if ( outOfRange( daysOfYear, 1, dateIsLeapYear( date.getFullYear() ) ? 366 : 365 ) ) {
			return null;
		}
		date.setMonth(0);
		date.setDate( daysOfYear );
	}

	if ( hour12 && amPm === "pm" ) {
		date.setHours( date.getHours() + 12 );
	}

	if ( timezoneOffset ) {
		date.setMinutes( date.getMinutes() + timezoneOffset );
	}

	// Truncate date at the most precise unit defined. Eg.
	// If value is "12/31", and pattern is "MM/dd":
	// => new Date( <current Year>, 12, 31, 0, 0, 0, 0 );
	truncateAt = Math.max.apply( null, truncateAt );
	date = dateStartOf( date, units[ truncateAt ] );

	return date;
};




/**
 * parseProperties( cldr )
 *
 * @cldr [Cldr instance].
 *
 * Return parser properties.
 */
var dateParseProperties = function( cldr ) {
	return {
		preferredTimeData: cldr.supplemental.timeData.preferred()
	};
};




/**
 * Generated by:
 *
 * regenerate().add( require( "unicode-7.0.0/categories/N/symbols" ) ).toString();
 *
 * https://github.com/mathiasbynens/regenerate
 * https://github.com/mathiasbynens/unicode-7.0.0
 */
var regexpN = /[0-9\xB2\xB3\xB9\xBC-\xBE\u0660-\u0669\u06F0-\u06F9\u07C0-\u07C9\u0966-\u096F\u09E6-\u09EF\u09F4-\u09F9\u0A66-\u0A6F\u0AE6-\u0AEF\u0B66-\u0B6F\u0B72-\u0B77\u0BE6-\u0BF2\u0C66-\u0C6F\u0C78-\u0C7E\u0CE6-\u0CEF\u0D66-\u0D75\u0DE6-\u0DEF\u0E50-\u0E59\u0ED0-\u0ED9\u0F20-\u0F33\u1040-\u1049\u1090-\u1099\u1369-\u137C\u16EE-\u16F0\u17E0-\u17E9\u17F0-\u17F9\u1810-\u1819\u1946-\u194F\u19D0-\u19DA\u1A80-\u1A89\u1A90-\u1A99\u1B50-\u1B59\u1BB0-\u1BB9\u1C40-\u1C49\u1C50-\u1C59\u2070\u2074-\u2079\u2080-\u2089\u2150-\u2182\u2185-\u2189\u2460-\u249B\u24EA-\u24FF\u2776-\u2793\u2CFD\u3007\u3021-\u3029\u3038-\u303A\u3192-\u3195\u3220-\u3229\u3248-\u324F\u3251-\u325F\u3280-\u3289\u32B1-\u32BF\uA620-\uA629\uA6E6-\uA6EF\uA830-\uA835\uA8D0-\uA8D9\uA900-\uA909\uA9D0-\uA9D9\uA9F0-\uA9F9\uAA50-\uAA59\uABF0-\uABF9\uFF10-\uFF19]|\uD800[\uDD07-\uDD33\uDD40-\uDD78\uDD8A\uDD8B\uDEE1-\uDEFB\uDF20-\uDF23\uDF41\uDF4A\uDFD1-\uDFD5]|\uD801[\uDCA0-\uDCA9]|\uD802[\uDC58-\uDC5F\uDC79-\uDC7F\uDCA7-\uDCAF\uDD16-\uDD1B\uDE40-\uDE47\uDE7D\uDE7E\uDE9D-\uDE9F\uDEEB-\uDEEF\uDF58-\uDF5F\uDF78-\uDF7F\uDFA9-\uDFAF]|\uD803[\uDE60-\uDE7E]|\uD804[\uDC52-\uDC6F\uDCF0-\uDCF9\uDD36-\uDD3F\uDDD0-\uDDD9\uDDE1-\uDDF4\uDEF0-\uDEF9]|\uD805[\uDCD0-\uDCD9\uDE50-\uDE59\uDEC0-\uDEC9]|\uD806[\uDCE0-\uDCF2]|\uD809[\uDC00-\uDC6E]|\uD81A[\uDE60-\uDE69\uDF50-\uDF59\uDF5B-\uDF61]|\uD834[\uDF60-\uDF71]|\uD835[\uDFCE-\uDFFF]|\uD83A[\uDCC7-\uDCCF]|\uD83C[\uDD00-\uDD0C]/;




/**
 * tokenizer( value, pattern, properties )
 *
 * @value [String] string date.
 *
 * @properties [Object] output returned by date/tokenizer-properties.
 *
 * Returns an Array of tokens, eg. value "5 o'clock PM", pattern "h 'o''clock' a":
 * [{
 *   type: "h",
 *   lexeme: "5"
 * }, {
 *   type: "literal",
 *   lexeme: " "
 * }, {
 *   type: "literal",
 *   lexeme: "o'clock"
 * }, {
 *   type: "literal",
 *   lexeme: " "
 * }, {
 *   type: "a",
 *   lexeme: "PM",
 *   value: "pm"
 * }]
 *
 * OBS: lexeme's are always String and may return invalid ranges depending of the token type.
 * Eg. "99" for month number.
 *
 * Return an empty Array when not successfully parsed.
 */
var dateTokenizer = function( value, numberParser, properties ) {
	var valid,
		timeSeparator = properties.timeSeparator,
		tokens = [],
		widths = [ "abbreviated", "wide", "narrow" ];

	valid = properties.pattern.match( datePatternRe ).every(function( current ) {
		var chr, length, numeric, tokenRe,
			token = {};

		function hourFormatParse( tokenRe, numberParser ) {
			var aux = value.match( tokenRe );
			numberParser = numberParser || function( value ) {
				return +value;
			};

			if ( !aux ) {
				return false;
			}

			// hourFormat containing H only, e.g., `+H;-H`
			if ( aux.length < 8 ) {
				token.value =
					( aux[ 1 ] ? -numberParser( aux[ 1 ] ) : numberParser( aux[ 4 ] ) ) * 60;

			// hourFormat containing H and m, e.g., `+HHmm;-HHmm`
			} else {
				token.value =
					( aux[ 1 ] ? -numberParser( aux[ 1 ] ) : numberParser( aux[ 7 ] ) ) * 60 +
					( aux[ 1 ] ? -numberParser( aux[ 4 ] ) : numberParser( aux[ 10 ] ) );
			}

			return true;
		}

		// Transform:
		// - "+H;-H" -> /\+(\d\d?)|-(\d\d?)/
		// - "+HH;-HH" -> /\+(\d\d)|-(\d\d)/
		// - "+HHmm;-HHmm" -> /\+(\d\d)(\d\d)|-(\d\d)(\d\d)/
		// - "+HH:mm;-HH:mm" -> /\+(\d\d):(\d\d)|-(\d\d):(\d\d)/
		//
		// If gmtFormat is GMT{0}, the regexp must fill {0} in each side, e.g.:
		// - "+H;-H" -> /GMT\+(\d\d?)|GMT-(\d\d?)/
		function hourFormatRe( hourFormat, gmtFormat, timeSeparator ) {
			var re;

			if ( !gmtFormat ) {
				gmtFormat = "{0}";
			}

			re = hourFormat
				.replace( "+", "\\+" )

				// Unicode equivalent to (\\d\\d)
				.replace( /HH|mm/g, "((" + regexpN.source + ")(" + regexpN.source + "))" )

				// Unicode equivalent to (\\d\\d?)
				.replace( /H|m/g, "((" + regexpN.source + ")(" + regexpN.source + ")?)" );

			if ( timeSeparator ) {
				re = re.replace( /:/g, timeSeparator );
			}

			re = re.split( ";" ).map(function( part ) {
				return gmtFormat.replace( "{0}", part );
			}).join( "|" );

			return new RegExp( re );
		}

		function oneDigitIfLengthOne() {
			if ( length === 1 ) {

				// Unicode equivalent to /\d/
				numeric = true;
				return tokenRe = regexpN;
			}
		}

		function oneOrTwoDigitsIfLengthOne() {
			if ( length === 1 ) {

				// Unicode equivalent to /\d\d?/
				numeric = true;
				return tokenRe = new RegExp( "(" + regexpN.source + ")(" + regexpN.source + ")?" );
			}
		}

		function twoDigitsIfLengthTwo() {
			if ( length === 2 ) {

				// Unicode equivalent to /\d\d/
				numeric = true;
				return tokenRe = new RegExp( "(" + regexpN.source + ")(" + regexpN.source + ")" );
			}
		}

		// Brute-force test every locale entry in an attempt to match the given value.
		// Return the first found one (and set token accordingly), or null.
		function lookup( path ) {
			var i, re,
				data = properties[ path.join( "/" ) ];

			for ( i in data ) {
				re = new RegExp( "^" + data[ i ] );
				if ( re.test( value ) ) {
					token.value = i;
					return tokenRe = new RegExp( data[ i ] );
				}
			}
			return null;
		}

		token.type = current;
		chr = current.charAt( 0 ),
		length = current.length;

		if ( chr === "Z" ) {
			// Z..ZZZ: same as "xxxx".
			if ( length < 4 ) {
				chr = "x";
				length = 4;

			// ZZZZ: same as "OOOO".
			} else if ( length < 5 ) {
				chr = "O";
				length = 4;

			// ZZZZZ: same as "XXXXX"
			} else {
				chr = "X";
				length = 5;
			}
		}

		switch ( chr ) {

			// Era
			case "G":
				lookup([
					"gregorian/eras",
					length <= 3 ? "eraAbbr" : ( length === 4 ? "eraNames" : "eraNarrow" )
				]);
				break;

			// Year
			case "y":
			case "Y":
				numeric = true;

				// number l=1:+, l=2:{2}, l=3:{3,}, l=4:{4,}, ...
				if ( length === 1 ) {

					// Unicode equivalent to /\d+/.
					tokenRe = new RegExp( "(" + regexpN.source + ")+" );
				} else if ( length === 2 ) {

					// Unicode equivalent to /\d\d/
					tokenRe = new RegExp( "(" + regexpN.source + ")(" + regexpN.source + ")" );
				} else {

					// Unicode equivalent to /\d{length,}/
					tokenRe = new RegExp( "(" + regexpN.source + "){" + length + ",}" );
				}
				break;

			// Quarter
			case "Q":
			case "q":
				// number l=1:{1}, l=2:{2}.
				// lookup l=3...
				oneDigitIfLengthOne() || twoDigitsIfLengthTwo() || lookup([
					"gregorian/quarters",
					chr === "Q" ? "format" : "stand-alone",
					widths[ length - 3 ]
				]);
				break;

			// Month
			case "M":
			case "L":
				// number l=1:{1,2}, l=2:{2}.
				// lookup l=3...
				oneOrTwoDigitsIfLengthOne() || twoDigitsIfLengthTwo() || lookup([
					"gregorian/months",
					chr === "M" ? "format" : "stand-alone",
					widths[ length - 3 ]
				]);
				break;

			// Day
			case "D":
				// number {l,3}.
				if ( length <= 3 ) {

					// Unicode equivalent to /\d{length,3}/
					numeric = true;
					tokenRe = new RegExp( "(" + regexpN.source + "){" + length + ",3}" );
				}
				break;

			case "W":
			case "F":
				// number l=1:{1}.
				oneDigitIfLengthOne();
				break;

			// Week day
			case "e":
			case "c":
				// number l=1:{1}, l=2:{2}.
				// lookup for length >=3.
				if ( length <= 2 ) {
					oneDigitIfLengthOne() || twoDigitsIfLengthTwo();
					break;
				}

			/* falls through */
			case "E":
				if ( length === 6 ) {
					// Note: if short day names are not explicitly specified, abbreviated day
					// names are used instead http://www.unicode.org/reports/tr35/tr35-dates.html#months_days_quarters_eras
					lookup([
						"gregorian/days",
						[ chr === "c" ? "stand-alone" : "format" ],
						"short"
					]) || lookup([
						"gregorian/days",
						[ chr === "c" ? "stand-alone" : "format" ],
						"abbreviated"
					]);
				} else {
					lookup([
						"gregorian/days",
						[ chr === "c" ? "stand-alone" : "format" ],
						widths[ length < 3 ? 0 : length - 3 ]
					]);
				}
				break;

			// Period (AM or PM)
			case "a":
				lookup([
					"gregorian/dayPeriods/format/wide"
				]);
				break;

			// Week, Day, Hour, Minute, or Second
			case "w":
			case "d":
			case "h":
			case "H":
			case "K":
			case "k":
			case "j":
			case "m":
			case "s":
				// number l1:{1,2}, l2:{2}.
				oneOrTwoDigitsIfLengthOne() || twoDigitsIfLengthTwo();
				break;

			case "S":
				// number {l}.

				// Unicode equivalent to /\d{length}/
				numeric = true;
				tokenRe = new RegExp( "(" + regexpN.source + "){" + length + "}" );
				break;

			case "A":
				// number {l+5}.

				// Unicode equivalent to /\d{length+5}/
				numeric = true;
				tokenRe = new RegExp( "(" + regexpN.source + "){" + ( length + 5 ) + "}" );
				break;

			// Zone
			case "z":
			case "O":
				// O: "{gmtFormat}+H;{gmtFormat}-H" or "{gmtZeroFormat}", eg. "GMT-8" or "GMT".
				// OOOO: "{gmtFormat}{hourFormat}" or "{gmtZeroFormat}", eg. "GMT-08:00" or "GMT".
				if ( value === properties[ "timeZoneNames/gmtZeroFormat" ] ) {
					token.value = 0;
					tokenRe = new RegExp( properties[ "timeZoneNames/gmtZeroFormat" ] );
				} else {
					tokenRe = hourFormatRe(
						length < 4 ? "+H;-H" : properties[ "timeZoneNames/hourFormat" ],
						properties[ "timeZoneNames/gmtFormat" ],
						timeSeparator
					);
					if ( !hourFormatParse( tokenRe, numberParser ) ) {
						return null;
					}
				}
				break;

			case "X":
				// Same as x*, except it uses "Z" for zero offset.
				if ( value === "Z" ) {
					token.value = 0;
					tokenRe = /Z/;
					break;
				}

			/* falls through */
			case "x":
				// x: hourFormat("+HH;-HH")
				// xx or xxxx: hourFormat("+HHmm;-HHmm")
				// xxx or xxxxx: hourFormat("+HH:mm;-HH:mm")
				tokenRe = hourFormatRe(
					length === 1 ? "+HH;-HH" : ( length % 2 ? "+HH:mm;-HH:mm" : "+HHmm;-HHmm" )
				);
				if ( !hourFormatParse( tokenRe ) ) {
					return null;
				}
				break;

			case "'":
				token.type = "literal";
				current = current.replace( /''/, "'" );
				if ( length > 2 ) {
					current = current.slice( 1, -1 );
				}
				tokenRe = new RegExp( regexpEscape( current ) );
				break;

			default:
				token.type = "literal";
				tokenRe = /./;
		}

		if ( !tokenRe ) {
			return false;
		}

		// Get lexeme and consume it.
		value = value.replace( new RegExp( "^" + tokenRe.source ), function( lexeme ) {
			token.lexeme = lexeme;
			if ( numeric ) {
				token.value = numberParser( lexeme );
			}
			return "";
		});

		if ( !token.lexeme ) {
			return false;
		}

		tokens.push( token );
		return true;
	});

	return valid ? tokens : [];
};




/**
 * tokenizerProperties( pattern, cldr )
 *
 * @pattern [String] raw pattern.
 *
 * @cldr [Cldr instance].
 *
 * Return Object with data that will be used by tokenizer.
 */
var dateTokenizerProperties = function( pattern, cldr ) {
	var properties = {
			pattern: pattern,
			timeSeparator: numberSymbol( "timeSeparator", cldr )
		},
		widths = [ "abbreviated", "wide", "narrow" ];

	function populateProperties( path, value ) {

		// The `dates` and `calendars` trim's purpose is to reduce properties' key size only.
		properties[ path.replace( /^.*\/dates\//, "" ).replace( /calendars\//, "" ) ] = value;
	}

	cldr.on( "get", populateProperties );

	pattern.match( datePatternRe ).forEach(function( current ) {
		var chr, length;

		chr = current.charAt( 0 ),
		length = current.length;

		if ( chr === "Z" && length < 5 ) {
				chr = "O";
				length = 4;
		}

		switch ( chr ) {

			// Era
			case "G":
				cldr.main([
					"dates/calendars/gregorian/eras",
					length <= 3 ? "eraAbbr" : ( length === 4 ? "eraNames" : "eraNarrow" )
				]);
				break;

			// Year
			case "u": // Extended year. Need to be implemented.
			case "U": // Cyclic year name. Need to be implemented.
				throw createErrorUnsupportedFeature({
					feature: "year pattern `" + chr + "`"
				});

			// Quarter
			case "Q":
			case "q":
				if ( length > 2 ) {
					cldr.main([
						"dates/calendars/gregorian/quarters",
						chr === "Q" ? "format" : "stand-alone",
						widths[ length - 3 ]
					]);
				}
				break;

			// Month
			case "M":
			case "L":
				// number l=1:{1,2}, l=2:{2}.
				// lookup l=3...
				if ( length > 2 ) {
					cldr.main([
						"dates/calendars/gregorian/months",
						chr === "M" ? "format" : "stand-alone",
						widths[ length - 3 ]
					]);
				}
				break;

			// Day
			case "g":
				// Modified Julian day. Need to be implemented.
				throw createErrorUnsupportedFeature({
					feature: "Julian day pattern `g`"
				});

			// Week day
			case "e":
			case "c":
				// lookup for length >=3.
				if ( length <= 2 ) {
					break;
				}

			/* falls through */
			case "E":
				if ( length === 6 ) {
					// Note: if short day names are not explicitly specified, abbreviated day
					// names are used instead http://www.unicode.org/reports/tr35/tr35-dates.html#months_days_quarters_eras
					cldr.main([
						"dates/calendars/gregorian/days",
						[ chr === "c" ? "stand-alone" : "format" ],
						"short"
					]) || cldr.main([
						"dates/calendars/gregorian/days",
						[ chr === "c" ? "stand-alone" : "format" ],
						"abbreviated"
					]);
				} else {
					cldr.main([
						"dates/calendars/gregorian/days",
						[ chr === "c" ? "stand-alone" : "format" ],
						widths[ length < 3 ? 0 : length - 3 ]
					]);
				}
				break;

			// Period (AM or PM)
			case "a":
				cldr.main([
					"dates/calendars/gregorian/dayPeriods/format/wide"
				]);
				break;

			// Zone
			case "z":
			case "O":
				cldr.main( "dates/timeZoneNames/gmtFormat" );
				cldr.main( "dates/timeZoneNames/gmtZeroFormat" );
				cldr.main( "dates/timeZoneNames/hourFormat" );
				break;

			case "v":
			case "V":
				throw createErrorUnsupportedFeature({
					feature: "timezone pattern `" + chr + "`"
				});
		}
	});

	cldr.off( "get", populateProperties );

	return properties;
};




function validateRequiredCldr( path, value ) {
	validateCldr( path, value, {
		skip: [
			/dates\/calendars\/gregorian\/dateTimeFormats\/availableFormats/,
			/dates\/calendars\/gregorian\/days\/.*\/short/,
			/supplemental\/timeData\/(?!001)/,
			/supplemental\/weekData\/(?!001)/
		]
	});
}

/**
 * .dateFormatter( options )
 *
 * @options [Object] see date/expand_pattern for more info.
 *
 * Return a date formatter function (of the form below) according to the given options and the
 * default/instance locale.
 *
 * fn( value )
 *
 * @value [Date]
 *
 * Return a function that formats a date according to the given `format` and the default/instance
 * locale.
 */
Globalize.dateFormatter =
Globalize.prototype.dateFormatter = function( options ) {
	var cldr, numberFormatters, pad, pattern, properties;

	validateParameterTypePlainObject( options, "options" );

	cldr = this.cldr;
	options = options || { skeleton: "yMd" };

	validateDefaultLocale( cldr );

	cldr.on( "get", validateRequiredCldr );
	pattern = dateExpandPattern( options, cldr );
	properties = dateFormatProperties( pattern, cldr );
	cldr.off( "get", validateRequiredCldr );

	// Create needed number formatters.
	numberFormatters = properties.numberFormatters;
	delete properties.numberFormatters;
	for ( pad in numberFormatters ) {
		numberFormatters[ pad ] = this.numberFormatter({
			raw: numberFormatters[ pad ]
		});
	}

	return function( value ) {
		validateParameterPresence( value, "value" );
		validateParameterTypeDate( value, "value" );
		return dateFormat( value, numberFormatters, properties );
	};
};

/**
 * .dateParser( options )
 *
 * @options [Object] see date/expand_pattern for more info.
 *
 * Return a function that parses a string date according to the given `formats` and the
 * default/instance locale.
 */
Globalize.dateParser =
Globalize.prototype.dateParser = function( options ) {
	var cldr, numberParser, parseProperties, pattern, tokenizerProperties;

	validateParameterTypePlainObject( options, "options" );

	cldr = this.cldr;
	options = options || { skeleton: "yMd" };

	validateDefaultLocale( cldr );

	cldr.on( "get", validateRequiredCldr );
	pattern = dateExpandPattern( options, cldr );
	tokenizerProperties = dateTokenizerProperties( pattern, cldr );
	parseProperties = dateParseProperties( cldr );
	cldr.off( "get", validateRequiredCldr );

	numberParser = this.numberParser({ raw: "0" });

	return function( value ) {
		var tokens;

		validateParameterPresence( value, "value" );
		validateParameterTypeString( value, "value" );

		tokens = dateTokenizer( value, numberParser, tokenizerProperties );
		return dateParse( value, tokens, parseProperties ) || null;
	};
};

/**
 * .formatDate( value, options )
 *
 * @value [Date]
 *
 * @options [Object] see date/expand_pattern for more info.
 *
 * Formats a date or number according to the given options string and the default/instance locale.
 */
Globalize.formatDate =
Globalize.prototype.formatDate = function( value, options ) {
	validateParameterPresence( value, "value" );
	validateParameterTypeDate( value, "value" );

	return this.dateFormatter( options )( value );
};

/**
 * .parseDate( value, options )
 *
 * @value [String]
 *
 * @options [Object] see date/expand_pattern for more info.
 *
 * Return a Date instance or null.
 */
Globalize.parseDate =
Globalize.prototype.parseDate = function( value, options ) {
	validateParameterPresence( value, "value" );
	validateParameterTypeString( value, "value" );

	return this.dateParser( options )( value );
};

return Globalize;




}));
