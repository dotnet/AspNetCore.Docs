/*
---

name: "Transition"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- declare
	
inspiration:
  - "[MooTools](http://mootools.net)"

provides: Transition

...
*/

atom.Transition = function (method, noEase) {
	var easeIn = function (progress) {
		return method(progress);
	};

	if (noEase) {
		return coreAppend( easeIn, {
			easeIn   : easeIn,
			easeOut  : easeIn,
			easeInOut: easeIn
		});
	}

	return coreAppend( easeIn, {
		easeIn: easeIn,
		easeOut: function(progress){
			return 1 - method(1 - progress);
		},
		easeInOut: function(progress){
			if (progress > 0.5) {
				return ( 2 - method(2 * (1 - progress)) ) /2
			} else {
				return method(2 * progress)/2;
			}
		}
	});
};

atom.Transition.set = atom.core.overloadSetter(function (id, fn) {
	atom.Transition[id] = atom.Transition(fn);
});

atom.Transition.get = function (fn) {
	if (typeof fn != 'string') return fn;
	var method = fn.split('-')[0], ease = 'easeInOut', In, Out;
	if (method != fn) {
		In  = fn.indexOf('-in' ) > 0;
		Out = fn.indexOf('-out') > 0;
		if (In ^ Out) {
			if (In ) ease = 'easeIn';
			if (Out) ease = 'easeOut';
		}
	}
	method = method[0].toUpperCase() + method.substr(1);
	if (!atom.Transition[method]) {
		throw new Error('No Transition method: ' + method);
	}
	return atom.Transition[method][ease];
};

atom.Transition.Linear = atom.Transition(function(p) { return p }, true);

atom.Transition.set({
	Expo: function(p){
		return Math.pow(2, 8 * (p - 1));
	},

	Circ: function(p){
		return 1 - Math.sin(Math.acos(p));
	},

	Sine: function(p){
		return 1 - Math.cos(p * Math.PI / 2);
	},

	Back: function(p){
		var x = 1.618;
		return Math.pow(p, 2) * ((x + 1) * p - x);
	},

	Bounce: function(p){
		var value, a = 0, b = 1;
		for (;;){
			if (p >= (7 - 4 * a) / 11){
				value = b * b - Math.pow((11 - 6 * a - 11 * p) / 4, 2);
				break;
			}
			a += b, b /= 2
		}
		return value;
	},

	Elastic: function(p){
		return Math.pow(2, 10 * --p) * Math.cos(12 * p);
	}

});

['Quad', 'Cubic', 'Quart', 'Quint'].forEach(function(transition, i){
	atom.Transition.set(transition, function(p){
		return Math.pow(p, i + 2);
	});
});