"use strict";

const gulp = require("gulp"),
      concat = require("gulp-concat"),
      cssmin = require("gulp-cssmin"),
      uglify = require("gulp-uglify"),
      merge = require("merge-stream"),
      del = require("del"),
      bundleconfig = require("./bundleconfig.json");

const regex = {
    css: /\.css$/,
    html: /\.(html|htm)$/,
    js: /\.js$/
};

gulp.task("min:js", () => {
    const tasks = getBundles(regex.js).map(bundle => {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(uglify())
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("min:css", () => {
    const tasks = getBundles(regex.css).map(bundle => {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(cssmin())
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task('clean', () => {
    const files = bundleconfig.map(bundle => {
        return bundle.outputFileName;
    });
    return del(files);
});

const getBundles = (regexPattern) => {
    return bundleconfig.filter(bundle => {
        return regexPattern.test(bundle.outputFileName);
    });
};

gulp.task("min", gulp.series(["min:js", "min:css", "min:html"]));
gulp.task("default", gulp.series(["min"]));