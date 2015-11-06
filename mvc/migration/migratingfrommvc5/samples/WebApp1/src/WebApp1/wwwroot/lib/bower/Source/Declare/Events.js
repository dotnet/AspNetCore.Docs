/*
---

name: "Events"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- declare

inspiration:
  - "[MooTools](http://mootools.net)"

provides: Events

...
*/

/** @class atom.Events */
declare( 'atom.Events', {

	/** @constructs */
	initialize: function (context) {
		this.context   = context || this;
		this.locked    = [];
		this.events    = {};
		this.actions   = {};
		this.readyList = {};
	},

	/**
	 * @param {String} name
	 * @return Boolean
	 */
	exists: function (name) {
		var array = this.events[this.removeOn( name )];
		return !!(array && array.length);
	},

	/**
	 * @param {String} name
	 * @param {Function} callback
	 * @return Boolean
	 */
	add: function (name, callback) {
		this.run( 'addOne', name, callback );
		return this;
	},

	/**
	 * @param {String} name
	 * @param {Function} [callback]
	 * @return Boolean
	 */
	remove: function (name, callback) {
		if (typeof name == 'string' && !callback) {
			this.removeAll( name );
		} else {
			this.run( 'removeOne', name, callback );
		}
		return this;
	},

	/**
	 * @param {String} name
	 * @param {Array} args
	 * @return atom.Events
	 */
	fire: function (name, args) {
		args = args ? slice.call( args ) : [];
		name = this.removeOn( name );

		this.locked.push(name);
		var i = 0, l, events = this.events[name];
		if (events) for (l = events.length; i < l; i++) {
			events[i].apply( this.context, args );
		}
		this.unlock( name );
		return this;
	},

	/**
	 * @param {String} name
	 * @param {Array} [args=null]
	 * @return atom.Events
	 */
	ready: function (name, args) {
		name = this.removeOn( name );
		this.locked.push(name);
		if (name in this.readyList) {
			throw new Error( 'Event «'+name+'» is ready' );
		}
		this.readyList[name] = args;
		this.fire(name, args);
		this.removeAll(name);
		this.unlock( name );
		return this;
	},

	/**
	 * @param {String} name
	 * @param {Array} [args=null]
	 * @return atom.Events
	 */
	ensureReady: function (name, args) {
		if (!(name in this.readyList)) {
			this.ready(name, args);
		}
		return this;
	},


	// only private are below

	/** @private */
	context: null,
	/** @private */
	events: {},
	/** @private */
	readyList: {},
	/** @private */
	locked: [],
	/** @private */
	actions: {},

	/** @private */
	removeOn: function (name) {
		return (name || '').replace(/^on([A-Z])/, function(full, first){
			return first.toLowerCase();
		});
	},
	/** @private */
	removeAll: function (name) {
		var events = this.events[name];
		if (events) for (var i = events.length; i--;) {
			this.removeOne( name, events[i] );
		}
	},
	/** @private */
	unlock: function (name) {
		var action,
			all    = this.actions[name],
			index  = this.locked.indexOf( name );

		this.locked.splice(index, 1);

		if (all) for (index = 0; index < all.length; index++) {
			action = all[index];

			this[action.method]( name, action.callback );
		}
	},
	/** @private */
	run: function (method, name, callback) {
		var i = 0, l = 0;

		if (Array.isArray(name)) {
			for (i = 0, l = name.length; i < l; i++) {
				this[method](name[i], callback);
			}
		} else if (typeof name == 'object') {
			for (i in name) {
				this[method](i, name[i]);
			}
		} else if (typeof name == 'string') {
			this[method](name, callback);
		} else {
			throw new TypeError( 'Wrong arguments in Events.' + method );
		}
	},
	/** @private */
	register: function (name, method, callback) {
		var actions = this.actions;
		if (!actions[name]) {
			actions[name] = [];
		}
		actions[name].push({ method: method, callback: callback })
	},
	/** @private */
	addOne: function (name, callback) {
		var events, ready, context;

		name = this.removeOn( name );

		if (this.locked.indexOf(name) == -1) {
			ready = this.readyList[name];
			if (ready) {
				context = this.context;
				setTimeout(function () {
					callback.apply(context, ready);
				}, 0);
				return this;
			} else {
				events = this.events;
				if (!events[name]) {
					events[name] = [callback];
				} else {
					events[name].push(callback);
				}
			}
		} else {
			this.register(name, 'addOne', callback);
		}
	},
	/** @private */
	removeOne: function (name, callback) {
		name = this.removeOn( name );

		if (this.locked.indexOf(name) == -1) {
			var events = this.events[name], i = events.length;
			while (i--) if (events[i] == callback) {
				events.splice(i, 1);
			}
		} else {
			this.register(name, 'removeOne', callback);
		}
	}
});

// local alias
var Events = atom.Events;