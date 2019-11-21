// <snippet_UnobtrusiveValidation>
$.validator.addMethod('classicmovie',
    function (value, element, params) {
        // Get element value. Classic genre has value '0'.
        var genre = $(params[0]).val(),
            year = params[1],
            date = new Date(value);
        if (genre && genre.length > 0 && genre[0] === '0') {
            // Since this is a classic movie, invalid if release date is after given year.
            return date.getUTCFullYear() <= year;
        }

        return true;
    });

$.validator.unobtrusive.adapters.add('classicmovie',
    ['year'],
    function (options) {
        var element = $(options.form).find('select#Genre')[0];
        options.rules['classicmovie'] = [element, parseInt(options.params['year'])];
        options.messages['classicmovie'] = options.message;
    });
// </snippet_UnobtrusiveValidation>
