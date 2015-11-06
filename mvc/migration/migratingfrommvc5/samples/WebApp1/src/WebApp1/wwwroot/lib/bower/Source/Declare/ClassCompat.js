/*
---

name: "ClassCompat"

description: "Contains the Class Function for easily creating, extending, and implementing reusable Classes."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- CoreExtended
	- declare

provides: ClassCompat
...
*/

declare( 'atom.Settings.Mixin',
/** @deprecated */
{
	/**
	 * @private
	 * @property atom.Settings
	 */
	settings: null,
	options : {},

	setOptions: function (options) {
		if (!this.settings) {
			this.settings = new atom.Settings(
				atom.clone(this.options || {})
			);
			this.options = this.settings.values;
		}

		for (var i = 0; i < arguments.length; i++) {
			this.settings.set(arguments[i]);
		}

		return this;
	}
});

declare( 'atom.Events.Mixin', new function () {
	var init = function () {
		var events = this.__events;
		if (!events) events = this.__events = new atom.Events(this);
		if (this._events) {
			for (var name in this._events) if (name != '$ready') {
				this._events[name].forEach(function (fn) {
					events.add(name, fn);
				});
			}
		}
		return events;
	};

	var method = function (method, useReturn) {
		return function () {
			var result, events = init.call(this);

			result = events[method].apply( events, arguments );
			return useReturn ? result : this;
		}
	};

	return {
		get events ( ) { return init.call(this); },
		set events (e) { this.__events = e;       },
		isEventAdded: method( 'exists', true ),
		addEvent    : method( 'add'   , false ),
		removeEvent : method( 'remove', false ),
		fireEvent   : method( 'fire'  , false ),
		readyEvent  : method( 'ready' , false )
	};
});