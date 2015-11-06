/*
---

name: "Frame"

description: "Provides cross-browser interface for requestAnimationFrame"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core

provides: frame

...
*/
(function () {

	var previous,
		started   = false,
		callbacks = [],
		remove    = [],
		frameTime = 16, // 62 fps
		// we'll switch to real `requestAnimationFrame` here
		// when all browsers will be ready
		requestAnimationFrame = function (callback) {
			window.setTimeout(callback, frameTime);
		};

	function startAnimation () {
		if (!started) {
			previous  = Date.now();
			requestAnimationFrame(frame);
			started = true;
		}
	}

	function invokeFrame () {
		var fn, i, l,
			now = Date.now(),
			// 1 sec is max time for frame to avoid some bugs with too large time
			delta = Math.min(now - previous, 1000);

		for (i = 0, l = remove.length; i < l; i++) {
			coreEraseOne(callbacks, remove[i]);
		}
		remove.length = 0;

		for (i = 0, l = callbacks.length; i < l; i++) {
			fn = callbacks[i];
			// one of previous calls can remove our fn
			if (remove.indexOf(fn) == -1) {
				fn.call(null, delta);
			}
		}

		previous = now;
	}

	function frame() {
		requestAnimationFrame(frame);

		if (callbacks.length == 0) {
			remove.length = 0;
			previous = Date.now();
		} else invokeFrame();
	}

	atom.frame = {
		add: function (fn) {
			startAnimation();
			includeUnique(callbacks, fn);
		},
		// we dont want to fragmentate callbacks, so remove only before frame started
		remove: function (fn) {
			if (started) includeUnique(remove, fn);
		}
	};

}());