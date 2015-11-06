/*
---

name: "Keyboard"

description: ""

license:
	- "[GNU Lesser General Public License](http://opensource.org/licenses/lgpl-license.php)"
	- "[MIT License](http://opensource.org/licenses/mit-license.php)"

requires:
	- declare
	- Events

provides: Keyboard

...
*/

var Keyboard = function () {

var
	keyName,
	codeNames = {},
	keyCodes  = {
		// Alphabet
		a:65, b:66, c:67, d:68, e:69,
		f:70, g:71, h:72, i:73, j:74,
		k:75, l:76, m:77, n:78, o:79,
		p:80, q:81, r:82, s:83, t:84,
		u:85, v:86, w:87, x:88, y:89, z:90,
		// Numbers
		n0:48, n1:49, n2:50, n3:51, n4:52,
		n5:53, n6:54, n7:55, n8:56, n9:57,
		// Controls
		tab:  9, enter:13, shift:16, backspace:8,
		ctrl:17, alt  :18, esc  :27, space    :32,
		menu:93, pause:19, cmd  :91,
		insert  :45, home:36, pageup  :33,
		'delete':46, end :35, pagedown:34,
		// F*
		f1:112, f2:113, f3:114, f4 :115, f5 :116, f6 :117,
		f7:118, f8:119, f9:120, f10:121, f11:122, f12:123,
		// numpad
		np0: 96, np1: 97, np2: 98, np3: 99, np4:100,
		np5:101, np6:102, np7:103, np8:104, np9:105,
		npslash:11,npstar:106,nphyphen:109,npplus:107,npdot:110,
		// Lock
		capslock:20, numlock:144, scrolllock:145,

		// Symbols
		equals: 61, hyphen   :109, coma  :188, dot:190,
		gravis:192, backslash:220, sbopen:219, sbclose:221,
		slash :191, semicolon: 59, apostrophe: 222,

		// Arrows
		aleft:37, aup:38, aright:39, adown:40
	};

for (keyName in keyCodes) if (keyCodes.hasOwnProperty(keyName)) {
	codeNames[ keyCodes[keyName] ] = keyName;
}

/** @class atom.Keyboard */
return declare( 'atom.Keyboard', {
	initialize : function (element, preventDefault) {
		if (Array.isArray(element)) {
			preventDefault = element;
			element = null;
		}
		if (element == null) element = document;

		if (element == document) {
			if (this.constructor.instance) {
				return this.constructor.instance;
			}
			this.constructor.instance = this;
		}

		this.events = new Events(this);
		this.keyStates = {};
		this.preventDefault = preventDefault;

		atom.dom(element).bind({
			keyup:    this.keyEvent('up'),
			keydown:  this.keyEvent('down'),
			keypress: this.keyEvent('press')
		});
	},
	/** @private */
	keyEvent: function (event) {
		return this.onKeyEvent.bind(this, event);
	},
	/** @private */
	onKeyEvent: function (event, e) {
		var key = this.constructor.keyName(e),
			prevent = this.prevent(key);

		e.keyName = key;

		if (prevent) e.preventDefault();
		this.events.fire( event, [e] );

		if (event == 'down') {
			this.events.fire(key, [e]);
			this.keyStates[key] = true;
		} else if (event == 'up') {
			this.events.fire(key + ':up', [e]);
			delete this.keyStates[key];
		} else if (event == 'press') {
			this.events.fire(key + ':press', [e]);
		}

		return !prevent;
	},
	/** @private */
	prevent : function (key) {
		var pD = this.preventDefault;
		return pD && (pD === true || pD.indexOf(key) >= 0);
	},
	key: function (keyName) {
		return !!this.keyStates[ this.constructor.keyName(keyName) ];
	}
}).own({
	keyCodes : keyCodes,
	codeNames: codeNames,
	keyName: function (code) {
		if (code && code.keyCode != null) {
			code = code.keyCode;
		}

		var type = typeof code;

		if (type == 'number') {
			return this.codeNames[code];
		} else if (type == 'string' && code in this.keyCodes) {
			return code;
		}

		return null;
	}
});

}();
