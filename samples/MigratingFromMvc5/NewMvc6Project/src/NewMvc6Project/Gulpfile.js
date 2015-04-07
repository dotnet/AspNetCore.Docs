/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var clean = require('gulp-clean');
var concat = require('gulp-concat');

var paths = {
    bower: "./bower_components/",
    lib: "./wwwroot/lib/"
};

gulp.task('clean', function () {
    return gulp.src(paths.lib + '*')
        .pipe(clean());
});

gulp.task('default', ['clean'], function () {
    var bower = {
        "bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}",
        "jquery": "jquery/jquery*.{js,map}",
        "jquery-validation": "jquery-validation/jquery.validate.js",
        "jquery-validation-unobtrusive":
            "jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"
    };

    for (var destinationDir in bower) {
        gulp.src(paths.bower + bower[destinationDir])
			.pipe(gulp.dest(paths.lib + destinationDir));
    }
});

gulp.task('concat', function () {
    return gulp.src([paths.lib + 'bootstrap/js/bootstrap.min.js',
            paths.lib + 'jquery/jquery.min.js'])
        .pipe(concat("bundle.js"))
        .pipe(gulp.dest(paths.lib));
});
