
'use strict';

// ** include dependencies ** //
const gulp = require('gulp');
const sass = require('gulp-sass');
const concat = require('gulp-concat');
const notify = require("gulp-notify");
const bower = require('gulp-bower');
const minify = require('gulp-minify');
const rename = require('gulp-rename');
const uglify = require('gulp-uglify');
const browserSync = require('browser-sync').create();

const scripts = require('./scripts');
const styles = require('./styles');

var config = {
  bowerDir: ''
}

var devMode = false;

// ** task runners ** //
// ==================//

gulp.task('bower', function() {
  return bower()
        .pipe(gulp.dest('./bower_components'))
});

gulp.task('icons', function() {
    return gulp.src('./bower_components/fontawesome/fonts/**.*')
        .pipe(gulp.dest('./public/fonts'));
});


// ** scss task ** //

gulp.task('sass', function() {
    return gulp.src(styles)
        .pipe(sass({
            style: 'compressed',
            loadPath: [
              './bower_components/bootstrap-sass/assets/stylesheets',
              './bower_components/font-awesome/scss'
            ]
        }).on("error", notify.onError(function (error) {
                return "Error: " + error.message;
            })))
        .pipe(gulp.dest('./dist/css'));
});


gulp.task('scripts', function() {
    return gulp.src(scripts)
        .pipe(concat('scripts.js'))
        .pipe(rename('scripts.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('./dist/js'));
});

// ** html task ** //
gulp.task('html', function(){
  gulp.src('./src/templates/**/*.html')
      .pipe(gulp.dest('./dist/'))
      .pipe(browserSync.reload({
        stream: true
      }));
});

// ** build task ** //
gulp.task('build', function() {
  gulp.start(['bower', 'icons', 'sass', 'scripts', 'html', ]);
});

// ** browser sync task ** //
gulp.task('browser-sync', function(){
    browserSync.init(null, {
      open: false,
      server: {
        baseDir: 'dist'
      }
    });
});

// ** start task ** //
gulp.task('serve', function() {
  devMode = true;
  gulp.start(['build', 'browser-sync']);

  // ** watch all tasks being run ** //
  gulp.watch(['./src/scss/**/*.scss'], ['sass']);
  gulp.watch(['./src/js/**/*.js'], ['scripts']);
  gulp.watch(['./src/templates/**/*.html'], ['html']);

})
