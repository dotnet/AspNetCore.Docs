document.addEventListener('DOMContentLoaded', function () {
    'use strict';

    var dateHiredElement = document.getElementById('Instructor_DateHired');

    document.querySelector('.btn-danger')
        .addEventListener('click', function () {
            dateHiredElement.type = 'text';
            dateHiredElement.value = '2019-13-32';
        });
});
