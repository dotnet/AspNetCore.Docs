/* jshint node: true */

function mountFolder (connect, dir) {
  return connect.static(require('path').resolve(dir));
}

module.exports = function(grunt) {
  "use strict";

  // Project configuration.
  grunt.initConfig({

    // Metadata.
    pkg: grunt.file.readJSON('package.json'),
    banner: '/*! \n' +
            ' * <%= pkg.name %> v<%= pkg.version %>\n' +
            ' * <%= pkg.repository.url %> \n' +
            ' * \n' +
            ' * Copyright (c) <%= grunt.template.today("yyyy") %> <%= pkg.author %>\n' +
            ' * Licensed under the <%= pkg.licenses[0].type %> license\n' +
            ' * \n' +
            ' * \n' +
            ' * Including Hammer.js@1.0.6dev, http://eightmedia.github.com/hammer.js \n' +
            ' */ \n',

    functionalScope: {
      header: '+function ($) {\n' +
              '  "use strict";\n' +
              '\n' +
              '  if (!("ontouchstart" in window || navigator.msMaxTouchPoints)) return false \n\n',
      footer: '}(window.jQuery);'
    },

    jshint: {
      options: {
        jshintrc: '.jshintrc'
      },
      gruntfile: {
        src: 'Gruntfile.js'
      },
      src: {
        src: ['src/js/*.js']
      },
      test: {
        src: ['src/js/tests/unit/*.js']
      }
    },

    concat: {
      options: {
        banner: '<%= functionalScope.header %>',
        footer: '<%= functionalScope.footer %>',
        stripBanners: false
      },
      js: {
        src: [
          'src/js/transition.js',
          'src/js/touch-carousel.js',
        ],
        dest: 'dist/js/<%= pkg.name %>.js'
      }
    },

    uglify: {
      options: {
        banner: '<%= banner %>',
        report: 'min'
      },
      js: {
        src: ['<%= concat.js.dest %>', 'vendor/hammerjs/dist/jquery.hammer.js',],
        dest: 'dist/js/<%= pkg.name %>.js'
      }
    },

    less: {
      dev: {
        options: {
          compile: true,
          dumpLineNumbers: 'comments'
        },
        src: ['src/less/*.less'],
        dest: 'dist/css/<%= pkg.name %>.css'
      },
      prod: {
        options: {
          compile: true,
          banner: '<%= banner %>',
          compress: false
        },
        src: ['src/less/*.less'],
        dest: 'dist/css/<%= pkg.name %>.css'
      }
    },

    cssmin: {
      prod: {
        options: {
          banner: '/* <%= pkg.name %> v<%= pkg.version %>, (c) <%= grunt.template.today("yyyy") %> <%= pkg.author %> */',
          report: 'min'
        },
        files: {
          'dist/css/<%= pkg.name %>.css': '<%= less.prod.dest %>'
        }
      }
    },

    qunit: {
      //options: {
      //  inject: 'src/js/tests/unit/phantom.js'
      //},
      options: {
        //'phantomPath': 'node_modules/phantomjs/lib/phantom/phantomjs.exe',
        '--local-to-remote-url-access': 'no',
        '--proxy': '127.0.01',
        timeout: 5000,
        console: true
      },
      test: {
        options: {
            urls: ['http://127.0.0.1:<%= connect.test.options.port %>/index.html']
        }
      }
      //files: ['src/js/tests/index.html']
    },
    connect: {
      test: {
        options: {
          port: 9002,
          hostname: '127.0.0.1',
          middleware: function (connect) {
            return [
              mountFolder(connect, 'dist'),
              mountFolder(connect, 'src/js/tests'),
            ];
          }
        }
      }
    },

    watch: {
      less: {
        files: 'src/less/*.less',
        tasks: ['less:dev']
      },
      js: {
        files: 'src/js/*.js',
        tasks: ['jshint', 'concat', 'uglify']
      }
    },
    bump: {
      options: {
        commitFiles: ['-a'],
        pushTo: 'git@github.com:ixisio/bootstrap-touch-carousel.git'
      }
    }
  });


  // These plugins provide necessary tasks.
  grunt.loadNpmTasks('grunt-contrib-concat');
  grunt.loadNpmTasks('grunt-contrib-jshint');
  grunt.loadNpmTasks('grunt-contrib-qunit');
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-watch');
  grunt.loadNpmTasks('grunt-contrib-less');
  grunt.loadNpmTasks('grunt-contrib-connect');
  grunt.loadNpmTasks('grunt-contrib-cssmin');
  grunt.loadNpmTasks('grunt-bump');

  grunt.registerTask('default', ['watch']);
  grunt.registerTask('test', ['jshint', 'connect:test', 'qunit:test']);
  grunt.registerTask('build', ['jshint', 'test', 'concat', 'uglify', 'less:prod', 'cssmin']);
};
