var gulp = require('gulp');
var browserSync = require('browser-sync').create();

gulp.task('browser-sync', function () {
  browserSync.init({
   proxy: "http://localhost:5000"
  });
  gulp.watch('Areas/Tools/**/*.cshtml').on('change', browserSync.reload);
  
});

gulp.task('default', gulp.series(['browser-sync']))