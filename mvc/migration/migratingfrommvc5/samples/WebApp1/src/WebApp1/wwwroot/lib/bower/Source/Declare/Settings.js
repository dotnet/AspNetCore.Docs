/*
---

name: "Settings"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- declare

provides: Settings

...
*/

/** @class atom.Settings */
declare( 'atom.Settings', {
	/** @private */
	recursive: false,

	/** @private */
	values: {},

	/**
	 * @constructs
	 * @param {Object} [initialValues]
	 */
	initialize: function (initialValues) {
		this.values    = {};

		if (initialValues) this.set(initialValues);
	},

	/**
	 * @param {atom.Events} events
	 * @return atom.Options
	 */
	addEvents: function (events) {
		this.events = events;
		return this.invokeEvents();
	},

	/**
	 * @param {string|Array} name
	 */
	get: function (name, defaultValue) {
		if (Array.isArray(name)) return this.subset(name, defaultValue);

		return name in this.values ? this.values[name] : defaultValue;
	},

	/**
	 * @param {object} target
	 * @param {string[]} [names=undefined]
	 * @return {atom.Settings}
	 */
	properties: function (target, names) {
		var originalNames = this.propertiesNames;

		if (typeof names == 'string') {
			names = names.split(' ');
		}

		if (names == null || names === true) {
			this.propertiesNames = true;
		} else if (originalNames == null) {
			this.propertiesNames = names;
		} else if (originalNames !== true) {
			atom.array.append(originalNames, names);
		}

		this.propertiesTarget = target;

		for (var i in this.values) {
			this.exportProperty(i, this.values);
		}

		return this;
	},

	subset: function (names, defaultValue) {
		var i, values = {};

		for (i = names.length; i--;) {
			values[names[i]] = this.get( names[i], defaultValue );
		}

		return values;
	},

	/** @private */
	propertiesNames : null,
	/** @private */
	propertiesTarget: null,

	/**
	 * @param {Object} options
	 * @return atom.Options
	 */
	set: function (options, value) {
		var i, values = this.values;

		options = this.prepareOptions(options, value);

		for (i in options) {
			value = options[i];
			if (values[i] != value) {
				values[i] = value;
				this.exportProperty(i, values);
			}
		}

		this.invokeEvents();

		return this;
	},

	/** @private */
	exportProperty: function (i, values) {
		var
			target = this.propertiesTarget,
			names  = this.propertiesNames;

		if (target && (names === true || names.indexOf(i) >= 0)) {
			target[i] = values[i];
		}
	},

	/** @private */
	prepareOptions: function (options, value) {
		if (typeof options == 'string') {
			var i = options;
			options = {};
			options[i] = value;
		} else if (options instanceof this.constructor) {
			options = options.values;
		}
		return options;
	},

	/**
	 * @param {String} name
	 * @return atom.Options
	 */
	unset: function (name) {
		delete this.values[name];
		return this;
	},

	/** @private */
	invokeEvents: function () {
		if (!this.events) return this;

		var values = this.values, name, option;
		for (name in values) if (values.hasOwnProperty(name)) {
			option = values[name];
			if (this.isInvokable(name, option)) {
				this.events.add(name, option);
				this.unset(name);
			}
		}
		return this;
	},

	/** @private */
	isInvokable: function (name, option) {
		return name &&
			option &&
			coreIsFunction(option) &&
			(/^on[A-Z]/).test(name);
	}
});

var Settings = atom.Settings;