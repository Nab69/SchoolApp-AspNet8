const gulp = require('gulp'),
    cleanCss = require('gulp-clean-css'),
    sass = require('gulp-sass')(require('sass'));

gulp.task("sass", function () {
    return gulp.src('Styles/style.scss')
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task("minifycss", () => {
    return gulp.src('wwwroot/css/style.css')
        .pipe(cleanCss())
        .pipe(gulp.dest('wwwroot/css/min'))
});