/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.initConfig({
        bower: {
            install: {
                options: {
                    targetDir: "wwwroot/lib",
                    layout: "byComponent",
                    cleanTargetDir: false
                }
            }
        },
        concat: {
            all: {
                src: ['wwwroot/lib/jquery/jquery.min.js',
                    'wwwroot/lib/bootstrap/js/bootstrap.min.js'
                ],
                dest: 'wwwroot/lib/bundle.js'
            }
        }
    }); 

    grunt.registerTask("default", ["bower:install"]);

    grunt.loadNpmTasks("grunt-bower-task");
    grunt.loadNpmTasks('grunt-contrib-concat');
};