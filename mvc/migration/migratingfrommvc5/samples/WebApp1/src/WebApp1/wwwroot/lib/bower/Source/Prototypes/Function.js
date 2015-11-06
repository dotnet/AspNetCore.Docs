/*
---

name: "Prototypes.Function"

description: "Contains Function Prototypes like after, periodical and delay."

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- Core
	- Types.Function
	- Prototypes.Abstract

provides: Prototypes.Function

...
*/

prototypize.add(function (globalObject) {

	var Function = globalObject.Function;

	Function.lambda = atom.fn.lambda;

	function timer (periodical) {
		var set = periodical ? setInterval : setTimeout;

		return function (time, bind, args) {
			var fn = this;
			return set(function () {
				fn.apply( bind, args || [] );
			}, time);
		};
	}
	
	coreAppend(Function.prototype, {
		after: prototypize.fn(atom.fn)('after'),
		delay     : timer(false),
		periodical: timer(true )
	});

});
