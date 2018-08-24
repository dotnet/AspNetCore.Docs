var gulp = require("gulp"),
    uglify = require("gulp-uglify"),
    rename = require('gulp-rename'),
    replace = require('gulp-replace'),
    lec = require('gulp-line-ending-corrector'),
    pkg = require('./package.json');

gulp.task("minifyJS", function(){
    gulp.src(["src/jquery.validate.unobtrusive.js"])
        .pipe(replace(/@version.*/, '@version v' + pkg.version))
        .pipe(gulp.dest("dist"))
        .pipe(uglify({
            preserveComments: 'license'
        }))
        .pipe(lec({eolc: 'CRLF'}))
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest("dist"));
});

gulp.task("default", ["minifyJS"]);