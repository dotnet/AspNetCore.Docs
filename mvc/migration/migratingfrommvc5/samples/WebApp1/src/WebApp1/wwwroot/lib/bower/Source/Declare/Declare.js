/*
---

name: "Declare"

description: "Contains the Class Function for easily creating, extending, and implementing reusable Classes."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- accessors

provides: declare

...
*/

var declare = (function(atom){

var
	declare, methods,
	accessors   = atom.accessors.inherit,
	factory     = false,
	prototyping = false,
	mutators    = [];

declare = function (declareName, Parent, params) {
	if (prototyping) return this;

	params = methods.prepareParams(declareName, Parent, params);

	// line break for more user-friendly debug string
	var Constructor = function ()
	{ return methods.construct.call(this, Constructor, arguments) };

	// <debug> - should be removed on production
	if (params.name) {
		Constructor = new Function('con', 'return {"' + params.name + '": ' +
			function(){ return con.apply(this, arguments) }
		 + '}["' + params.name + '"];')(Constructor);
	}
	// </debug>

	for (var i = 0, l = mutators.length; i < l; i++) {
		mutators[i].fn( Constructor, params[mutators[i].name] );
	}

	Constructor.prototype.constructor = Constructor;

	if (params.declareName) methods.define( params.declareName, Constructor );

	return Constructor;
};

declare.prototype.bindMethods = function (methods) {
	var i;

	if (typeof methods == 'string') {
		if (typeof this[methods] == 'function') {
			this[methods] = this[methods].bind(this);
		}
		return this;
	}

	if (!methods) {
		for (i in this) this.bindMethods(i);
		return this;
	}

	for (i = methods.length; i--;) this.bindMethods( methods[i] );
	return this;
};

declare.prototype.toString = function () {
	return '[object ' + (this.constructor.NAME || 'Declare') + ']';
};

declare.NAME = 'atom.declare';

declare.invoke = function () {
	return this.factory( arguments );
};

declare.own = function (properties) {
	methods.addTo(this, properties, this.NAME + '.');
	return this;
};

declare.factory = function (args) {
	factory = true;
	return new this(args);
};

declare.castArguments = function (args) {
	if (args == null) return null;

	var constructor = this;

	return (args != null && args[0] && args[0] instanceof constructor) ?
		args[0] : args instanceof constructor ? args : new constructor( args );
};

methods = {
	define: function (path, value) {
		var key, part, target = atom.global;

		path = path.split('.');
		key  = path.pop();

		while (path.length) {
			part = path.shift();
			if (!target[part]) {
				target = target[part] = {};
			} else {
				target = target[part];
			}
		}

		target[key] = value;
	},
	mixin: function (target, items) {
		if (!Array.isArray(items)) items = [ items ];
		for (var i = 0, l = items.length; i < l; i++) {
			methods.addTo( target.prototype, methods.proto(items[i]) );
		}
		return this;
	},
	addTo: function (target, source, name) {
		var i, property;
		if (source) for (i in source) if (source.hasOwnProperty(i)) {
			if (!accessors(source, target, i) && source[i] != declare.config) {
				property = source[i];
				if (coreIsFunction(property)) {
					if (name) property.path = name + i;
					if (!property.previous && coreIsFunction(target[i])) {
						property.previous = target[i];
					}
				}
				target[i] = property;
			}
		}
		return target;
	},
	prepareParams: function (declareName, Parent, params) {
		if (typeof declareName != 'string') {
			params = Parent;
			Parent = declareName;
			declareName = null;
		}

		if (params == null && typeof Parent != 'function') {
			params = Parent;
			Parent = null;
		}

		if (!params                 ) params = {};
		if (!params.prototype       ) params = { prototype: params };
		if (!params.name            ) params.name = declareName;
		if (!params.declareName     ) params.declareName = declareName;
		if (!params.parent && Parent) params.parent = Parent;

		if (!params.prototype.initialize) {
			params.prototype.initialize = function () {
				if (!params.parent) return;
				return params.parent.prototype.initialize.apply(this, arguments);
			};
		}
		return params;
	},
	proto: function (Fn) {
		prototyping = true;
		var result = new Fn;
		prototyping = false;
		return result;
	},
	construct: function (Constructor, args) {
		if (factory) {
			args = args[0];
			factory = false;
		}

		if (prototyping) return this;

		if (this instanceof Constructor) {
			if (Constructor.NAME) this.Constructor = Constructor.NAME;
			return this.initialize.apply(this, args);
		} else {
			return Constructor.invoke.apply(Constructor, args);
		}
	}
};

declare.config = {
	methods: methods,
	mutator: atom.core.overloadSetter(function (name, fn) {
		mutators.push({ name: name, fn: fn });
		return this;
	})
};

declare.config
	.mutator( 'parent', function (Constructor, parent) {
		parent = parent || declare;
		methods.addTo( Constructor, parent );
		Constructor.prototype = methods.proto( parent );
		Constructor.Parent    = parent;
	})
	.mutator( 'mixin', function (Constructor, mixins) {
		if (mixins) methods.mixin( Constructor, mixins );
	})
	.mutator( 'name', function (Constructor, name) {
		if (!name) return;
		Constructor.NAME = name;
	})
	.mutator( 'own', function (Constructor, properties) {
		Constructor.own(properties);
	})
	.mutator( 'prototype', function (Constructor, properties) {
		methods.addTo(Constructor.prototype, properties, Constructor.NAME + '#');
	});

return atom.declare = declare;

})(atom);