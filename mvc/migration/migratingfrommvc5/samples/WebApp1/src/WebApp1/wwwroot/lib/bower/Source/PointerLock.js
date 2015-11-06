/*
---

name: "PointerLock"

description: "Provides cross-browser interface for locking pointer"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core

provides: PointerLock

...
*/
(function (document) {
	var prefix =
	      'pointerLockElement' in document ? '':
	   'mozPointerLockElement' in document ? 'moz':
	'webkitPointerLockElement' in document ? 'webkit': null;

    function PointerLock (supports) {
        this.supports = supports;
    }

    function p (string) {
        return prefix ? prefix + string :
        string[0].toLowerCase() + string.substr(1);
    }

    function isLocked (element) {
        return document[p('PointerLockElement')] === element;
    }

	if (prefix == null) {
		PointerLock.prototype = {
			locked  : function () { return false },
			request : function () {},
			exit    : function () {}
		};
	} else {

		document.addEventListener("mousemove", function onMove (e) {
			if (lockedElement && isLocked(lockedElement)) {
				e.movementX = e[p('MovementX')] || 0;
				e.movementY = e[p('MovementY')] || 0;

				callback && callback(e);
			}
		}, false);


		var lockedElement = false, callback = null;

		PointerLock.prototype = {
			locked: function (element) {
				return isLocked(element || lockedElement);
			},
			request: function (element, fn) {
				lockedElement = element;
				callback = fn;
				element[p('RequestPointerLock')]();
			},
			exit: function () {
				lockedElement = null;
				callback = null;
				document[p('ExitPointerLock')]();
			}
		};
	}

	atom.pointerLock = new PointerLock(prefix != null);

}(document));