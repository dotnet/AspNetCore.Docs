/*!
** An extension to the jQuery Validation Plugin which makes it use Globalize.js for number and date parsing
** Copyright (c) 2013 John Reilly
*/

(function ($, Globalize) {

    // Clone original methods we want to call into
    var originalMethods = {
        min: $.validator.methods.min,
        max: $.validator.methods.max,
        range: $.validator.methods.range
    };

    // Globalize options - initially just the date format used for parsing
    // Users can customise this to suit them
    $.validator.methods.dateGlobalizeOptions = { dateParseFormat: { skeleton: "yMd" } };

    // Tell the validator that we want numbers parsed using Globalize
    $.validator.methods.number = function (value, element) {
        var val = Globalize.parseNumber(value);
        return this.optional(element) || ($.isNumeric(val));
    };

    // Tell the validator that we want dates parsed using Globalize
    $.validator.methods.date = function (value, element) {
        var val = Globalize.parseDate(value, $.validator.methods.dateGlobalizeOptions.dateParseFormat);
        return this.optional(element) || (val instanceof Date);
    };

    // Tell the validator that we want numbers parsed using Globalize,
    // then call into original implementation with parsed value

    $.validator.methods.min = function (value, element, param) {
        var val = Globalize.parseNumber(value);
        return originalMethods.min.call(this, val, element, param);
    };

    $.validator.methods.max = function (value, element, param) {
        var val = Globalize.parseNumber(value);
        return originalMethods.max.call(this, val, element, param);
    };

    $.validator.methods.range = function (value, element, param) {
        var val = Globalize.parseNumber(value);
        return originalMethods.range.call(this, val, element, param);
    };

}(jQuery, Globalize));
