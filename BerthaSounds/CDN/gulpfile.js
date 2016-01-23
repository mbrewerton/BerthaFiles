/// <binding ProjectOpened='Watch:Js, Watch:Sass' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    watch = require("gulp-watch"),
    rimraf = require("rimraf"),
    sass = require("gulp-sass"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    plumber = require("gulp-plumber"),
    project = require("./project.json");

var paths = {
    webroot: "./" + project.webroot
};
paths.cdnMinJsLoc = paths.webroot + "/js/min/";

paths.cdn = {
    // Js CDN Locations
    areasJs: paths.webroot + "/js/areas/**/*.js",
    directivesJs: paths.webroot + "/js/directives/**/*.js",
    servicesJs: paths.webroot + "/js/services/**/*.js",
    resourcesJs: paths.webroot + "/js/resources/**/*.js",
    libsJs: paths.webroot + "/js/libs/**/*.js",
    commonJs: paths.webroot + "/js/common/**/*.js",

    commonJsConcatDest: paths.cdnMinJsLoc + "common.js",
    areasJsConcatDest: paths.cdnMinJsLoc + "areas.js",
    directivesJsConcatDest: paths.cdnMinJsLoc + "directives.js",
    servicesJsConcatDest: paths.cdnMinJsLoc + "services.js",
    resourcesJsConcatDest: paths.cdnMinJsLoc + "resources.js",
    libsJsConcatDest: paths.cdnMinJsLoc + "libs.js",

    minJsDest: paths.cdnMinJsLoc + "js.min.js",

    // HTML CDN Locations
    areasHtml: paths.webroot + "/html/Areas/**/*.html",

    // CSS CDN Locations
    sassLoc: paths.webroot + "/css/**/*.scss",
    sassDest: paths.webroot + "/css/min",

    // Images CDN Locations
    imagesLoc: paths.webroot + "/images/**/*.*"
};

paths.cdn.allJs = [paths.cdn.commonJs, paths.cdn.areasJs, paths.cdn.directivesJs, paths.cdn.servicesJs, paths.cdn.resourcesJs, paths.cdn.libsJs];

paths.bertha = {

}

gulp.task("Compile:Js", function () {
    gulp.src([paths.cdn.areasJs], { base: "." })
    .pipe(concat(paths.cdn.areasJsConcatDest))
    .pipe(gulp.dest("."));

    gulp.src([paths.cdn.directivesJs], { base: "." })
    .pipe(concat(paths.cdn.directivesJsConcatDest))
    .pipe(gulp.dest("."));

    gulp.src([paths.cdn.servicesJs], { base: "." })
    .pipe(concat(paths.cdn.servicesJsConcatDest))
    .pipe(gulp.dest("."));

    gulp.src([paths.cdn.resourcesJs], { base: "." })
    .pipe(concat(paths.cdn.resourcesJsConcatDest))
    .pipe(gulp.dest("."));

    gulp.src([paths.cdn.libsJs], { base: "." })
    .pipe(concat(paths.cdn.libsJsConcatDest))
    .pipe(gulp.dest("."));
});

gulp.task("Min:Js", function () {
    gulp.src(paths.cdn.allJs, { base: "." })
    .pipe(plumber({
        handleError: function (err) {
            console.log(err);
            this.emit('end');
        }
    }))
    .pipe(concat(paths.cdn.minJsDest))
    .pipe(uglify())
    .pipe(gulp.dest("."));
});

gulp.task('Compile:Sass', function () {
    gulp.src(paths.cdn.imagesLoc).pipe(gulp.dest(paths.webroot + 'css/min/images'));
    gulp.src(paths.cdn.sassLoc)
        .pipe(plumber({
            handleError: function (err) {
                console.log(err);
                this.emit('end');
            }
        }))
      .pipe(sass().on('error', sass.logError))
      .pipe(gulp.dest(paths.cdn.sassDest));
});

gulp.task("Min:css", function () {
    gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("Watch:HTML", function () {
    watch(paths.cdn.allHtml, { verbose: true }, function () { gulp.start("") });
});

gulp.task('Watch:Sass', function () {
    watch(paths.cdn.sassLoc, function () { gulp.start('Compile:Sass') });
});

gulp.task("Watch:Js", function () {
    watch(paths.cdn.allJs, { verbose: true }, function () { gulp.start("Compile:Js"); gulp.start("Min:Js"); });
    //watch([paths.cdn.areasJs, paths.cdn.directivesJs, paths.cdn.servicesJs, paths.cdn.resourcesJs, paths.cdn.libsJs], { verbose: true }, function () { gulp.start("Compile:Js"); gulp.start("Min:Js"); });
    //watch(paths.cdn.directivesJs, { verbose: true }, function () { gulp.start("CompileJs") });
});