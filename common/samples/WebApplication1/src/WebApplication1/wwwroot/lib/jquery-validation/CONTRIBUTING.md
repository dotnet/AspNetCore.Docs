# Contributing to jQuery Validation Plugin

Thanks for contributing! Here's a few guidelines to help your contribution get landed.

1. Make sure the problem you're addressing is reproducible. Use jsbin.com or jsfiddle.net to provide a test page.
2. Add or update unit tests along with your patch. Run the unit tests in at least one browser (see below).
3. Run `grunt` (see below) to check for linting and a few other issues.
4. Describe the change in your commit message and reference the ticket, like this: "Fixed delegate bug for dynamic-totals demo. Fixes #51". If you're adding a new localization file, use something like this: "Added croatian (HR) localization"

## Unit Tests

To run unit tests, you should have a local webserver installed and pointing at your workspace. Then open `http://localhost/jquery-validation/test` to run the unit tests. Start with one browser while developing the fix, then run against others before committing. Usually latest Chrome, Firefox, Safari and Opera and a few IEs.

## Linting

To run jshint and other tools, use `grunt`. To install, you need nodejs and npm, then run `npm install -g grunt`.