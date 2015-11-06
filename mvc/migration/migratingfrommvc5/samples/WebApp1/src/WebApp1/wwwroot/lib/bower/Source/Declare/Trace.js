/*
---

name: "trace"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- declare
	- dom
	- CoreExtended

provides: trace

...
*/

atom.trace = declare( 'atom.trace', {
	initialize : function (object) {
		this.value = object;
		this.stopped = false;
	},
	set value (value) {
		if (!this.stopped) {
			var html = atom.string.replaceAll( this.constructor.dump(value), {
				'\t': '&nbsp;'.repeat(3),
				'\n': '<br />'
			});
			this.createNode().html(html);
		}
	},
	destroy : function (force) {
		var trace = this;
		if (force) this.stop();
		if (trace.node) {
			trace.node.addClass('atom-trace-node-destroy');
			trace.timeout = setTimeout(function () {
				if (trace.node) {
					trace.node.destroy();
					trace.node = null;
				}
			}, 500);
		}
		return trace;
	},
	/** @private */
	stop  : function () {
		this.stopped = true;
		return this;
	},
	/** @private */
	getContainer : function () {
		var cont = atom.dom('#atom-trace-container');
		return cont.length ? cont :
			atom.dom.create('div', { 'id' : 'atom-trace-container'})
				.appendTo('body');
	},
	/** @deprecated */
	trace : function (value) {
		this.value = value;
		return this;
	},
	/** @private */
	createNode : function () {
		var trace = this, node = trace.node;

		if (node) {
			if (trace.timeout) {
				clearTimeout(trace.timeout);
				node.removeClass('atom-trace-node-destroy');
			}
			return node;
		}

		return trace.node = atom.dom
			.create('div')
			.addClass('atom-trace-node')
			.appendTo(trace.getContainer())
			.bind({
				click    : function () { trace.destroy(0) },
				dblclick : function () { trace.destroy(1) }
			});
	}
}).own({
	dumpRec : function dumpRec (obj, level, plain) {
		var html = '', type, tabs;

		level  = parseInt(level) || 0;

		if (level > 5) return '*TOO_DEEP*';

		if (obj && typeof obj == 'object' && coreIsFunction(obj.dump)) return obj.dump();

		function escape (v) {
			return plain ? v : atom.string.safeHtml(v);
		}

		function subDump (elem, index) {
			return tabs + '\t' + index + ': ' + dumpRec(elem, level+1, plain) + '\n';
		}

		type = atom.typeOf(obj);
		tabs = '\t'.repeat(level);

		switch (type) {
			case 'object':
				for (var index in obj) if (obj.hasOwnProperty(index)) {
					html += subDump(obj[index], index);
				}
				return '{\n' + html + tabs + '}';

			case 'element':
				var prop = (obj.width && obj.height) ? '('+obj.width+'×'+obj.height+')' : '';
				return '[DOM ' + obj.tagName.toLowerCase() + prop + ']';

			case 'textnode':
			case 'whitespace':
				return '[DOM ' + type + ']';

			case 'array'  : return '[\n' + obj.map(subDump).join('') + tabs + ']';
			case 'null'   : return 'null';
			case 'boolean': return obj ? 'true' : 'false';
			case 'string' : return escape('"' + obj + '"');
			default       : return escape('' + obj);
		}
	},
	dumpPlain: function (object) {
		return (this.dumpRec(object, 0, true));
	},
	dump : function (object) {
		return (this.dumpRec(object, 0));
	}
});