/*
---

name: "Animatable"

description: "Provides Color class"

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- declare
	- frame
	- Transition
	- Events
	- Settings
	- Types.Object

provides: Animatable

...
*/

/** @class atom.Animatable */
declare( 'atom.Animatable', {
	
	element: null,

	initialize: function (callbacks, context) {
		this.bindMethods('animate');
		this.context = context || null;

		if (!callbacks) throw new TypeError( 'callbacks cant be null' );

		this.animations = [];
		if (this.isValidCallbacks(callbacks)) {
			this.callbacks = callbacks;
		} else {
			this.callbacks = this.getDefaultCallbacks(callbacks);
		}
	},

	get current () {
		return this.animations[0];
	},

	/**
	 * Binded to `Animatable`
	 * @returns {atom.Animatable.Animation}
	 */
	animate: atom.core.ensureObjectSetter(function (properties) {
		return this.next(new atom.Animatable.Animation(this, properties));
	}),

	stop: function (all) {
		var current = this.current;
		if (current) {
			if (all) this.animations.length = 0;
			current.destroy('stop');
		}
		return this;
	},

	/** @private */
	getDefaultCallbacks: function (element) {
		return {
			get: function (property) {
				return atom.object.path.get(element, property);
			},
			set: atom.core.overloadSetter(function (property, value) {
				return atom.object.path.set(element, property, value);
			})
		};
	},
	/** @private */
	isValidCallbacks: function (callbacks) {
		return typeof callbacks == 'object' &&
			Object.keys(callbacks).length == 2 &&
			coreIsFunction(callbacks.set) &&
			coreIsFunction(callbacks.get);
	},

	/** @private */
	animations: null,

	/** @private */
	next: function (animation) {
		var queue = this.animations;
		if (animation) {
			queue.push(animation);
			if (queue.length == 1) {
				this.launch(animation);
			}
		} else if (queue.length) {
			this.launch(this.current);
		}
		return animation;
	},
	/** @private */
	launch: function (animation) {
		var queue = this.animations, animatable = this;
		animation.events.add('destroy', function remove () {
			queue.splice(queue.indexOf(animation), 1);
			animation.events.remove('destroy', remove);
			animatable.next();
		});
		animation.start();
	},
	/** @private */
	get: function (name) {
		return this.callbacks.get.apply(this.context, arguments);
	},
	/** @private */
	set: function (name, value) {
		return this.callbacks.set.apply(this.context, arguments);
	}
});

/** @class atom.Animatable.Animation */
declare( 'atom.Animatable.Animation', {
	/** @property {atom.Animatable} */
	animatable: null,

	/**
	 * initial values of properties
	 * @property {Object}
	 */
	initial: null,

	/**
	 * target values of properties
	 * @property {Object}
	 */
	target: null,

	initialize: function (animatable, settings) {
		this.bindMethods([ 'tick', 'start' ]);

		if (!settings.props) settings = {props: settings};
		this.events   = new atom.Events(animatable);
		this.settings = new atom.Settings({
				fn  : 'linear',
				time: 500
			})
			.set(settings)
			.addEvents(this.events);
		this.animatable = animatable;
		this.transition = atom.Transition.get(this.settings.get('fn'));
		this.allTime = this.settings.get('time');
		this.target  = this.settings.get('props');
	},

	start: function () {
		this.initial  = this.fetchInitialValues();
		this.delta    = this.countValuesDelta();
		this.timeLeft = this.allTime;
		this.events.fire( 'start', [ this ]);
		atom.frame.add(this.tick);
		return this;
	},

	/** @private */
	countValuesDelta: function () {
		var initial = this.initial;
		return atom.object.map(this.target, function (value, key) {
			var start = initial[key];
			if (atom.Color && start instanceof atom.Color) {
				return start.diff( new atom.Color(value) );
			} else {
				return value - start;
			}
		});
	},

	/** @private */
	fetchInitialValues: function () {
		var animatable = this.animatable;
		return atom.object.map(this.target, function (value, key) {
			var v = animatable.get(key);
			if (atom.Color && atom.Color.isColorString(value) || value instanceof atom.Color) {
				if (!v) {
					v = new atom.Color(value);
					v.alpha = 0;
					return v;
				}
				return new atom.Color(v);
			} else if (isNaN(v)) {
				throw new Error('value is not animatable: ' + v);
			} else {
				return v;
			}
		});
	},

	/** @private */
	changeValues: function (progress) {
		var delta = this.delta, animatable = this.animatable, initial, target;
		for (var i in delta) if (delta.hasOwnProperty(i)) {
			if (progress == null) {
				target = this.target[i];
				animatable.set( i,
					atom.Color && target instanceof atom.Color
						? target.toString() : target
				);
			} else {
				initial = this.initial[i];
				animatable.set( i,
					atom.Color && initial instanceof atom.Color ?
						initial.clone().move(delta[i].clone().mul(progress)).toString() :
						initial + delta[i] * progress
				);
			}
		}
	},

	/** @private */
	tick: function (time) {
		var lastTick = time >= this.timeLeft;
		this.timeLeft = lastTick ? 0 : this.timeLeft - time;

		this.changeValues(this.transition(
			lastTick ? 1 : (this.allTime - this.timeLeft) / this.allTime
		));
		this.events.fire( 'tick', [ this ]);

		if (lastTick) this.destroy('complete');
	},

	destroy: function (type) {
		if (!type) type = 'error';
		this.events.fire( type, [ this ]);
		this.events.fire( 'destroy', [ this ]);
		atom.frame.remove(this.tick);
		return this;
	}
});

if (atom.dom) (function (animatable) {
	var accessors = {
		get: function (name) {
			var value = this.css(name);
			return atom.Color && atom.Color.isColorString(value) ? value : parseFloat(value);
		},
		set: function (name, value) {
			this.css(name, value);
		}
	};

	atom.dom.prototype.animate = atom.core.ensureObjectSetter(function (params) {
		this.each(function (elem) {
			if (!elem[animatable]) {
				elem[animatable] = new atom.Animatable(accessors, atom.dom(elem));
			}
			elem[animatable].animate(params);
		});
		return this
	});

	atom.dom.prototype.stopAnimation = function (force) {
		this.each(function (elem) {
			if (elem[animatable]) {
				elem[animatable].stop(force);
			}
		});
		return this;
	};
})('atom.animatable');