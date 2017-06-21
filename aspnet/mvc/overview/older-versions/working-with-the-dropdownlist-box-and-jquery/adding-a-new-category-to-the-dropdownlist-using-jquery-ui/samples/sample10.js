$('#genreAddLink').click(function () {

    var createFormUrl = $(this).attr('href');  

    $('#genreDialog').html('')

    .load(createFormUrl, function () {  

        // The createGenreForm is loaded on the fly using jQuery load. 

        // In order to have client validation working it is necessary to tell the 

        // jQuery.validator to parse the newly added content

        jQuery.validator.unobtrusive.parse('#createGenreForm');

        $('#genreDialog').dialog('open');

    });

    return false;

});