atom.Keyboard
=============

Provides the way to easy manipulate the keyboard

### own

* `keyCodes` - object, where key is key name & value is key code.
* `codeNames` - object, where key is key code & value is key name.

#### keyName

Returns name of key. First argument can be event or number

	window.onclick = function (e) {
		atom.trace( atom.Keyboard.keyName(e) );
	}

### prototype

#### initialize

	new atom.Keyboard( DOMElement element );

First argument can be null - that used `document` as default.

	var keyboard = new atom.Keyboard();

#### key 

	boolean key( string keyName )

Checks if current key is pressed now

	if (keyboard.key('aleft')) {
		turnLeft();
	} else if (keyboard.key('aright')) {
		turnRight();
	}

#### events

Contains `atom.Events` instance. You can bind keys here. `:up` & `:press` prefixes can be used to specialize events:

	keyboard.events.add( 'space', function () {
		unit.jump();
	});
	
	keyboard.events.add( 'tab:up', function () {
		console.log( 'tab up' );
	});
	

Key Codes
=========

### Latin symbols

  Name   | Code |   Name   | Code |   Name   | Code
-------- | ---- | -------- | ---- | -------- | ----
    a    |  65  |     b    |  66  |     c    |  67
    d    |  68  |     e    |  69  |     f    |  70
    g    |  71  |     h    |  72  |     i    |  73
    j    |  74  |     k    |  75  |     l    |  76
    m    |  77  |     n    |  78  |     o    |  79
    p    |  80  |     q    |  81  |     r    |  82
    s    |  83  |     t    |  84  |     u    |  85
    v    |  86  |     w    |  87  |     x    |  88
    y    |  89  |     z    |  90  |          |    


### Numbers & F*

  Name   | Code |   Name   | Code |   Name   | Code
-------- | ---- | -------- | ---- | -------- | ----
   n0    |  48  |     n1   |  49  |     n2   |  50
   n3    |  51  |     n4   |  52  |     n5   |  53
   n6    |  54  |     n7   |  55  |     n8   |  56
   n9    |  57  |          |      |          |    
   f1    | 112  |     f2   | 113  |     f3   | 114
   f4    | 115  |     f5   | 116  |     f6   | 117
   f7    | 118  |     f8   | 119  |     f9   | 120
   f10   | 121  |    f11   | 122  |    f12   | 123

### Controls

  Name   | Code |   Name   | Code |    Name    | Code
-------- | ---- | -------- | ---- | ---------- | ----
capslock |  20  |  numlock | 144  | scrolllock | 145
 enter   |  13  |   shift  |  16  |  backspace |   6
  tab    |   9  |    ctrl  |  17  |    alt     |  18
  menu   |  93  |   pause  |  19  |    esc     |  27
 insert  |  45  |    home  |  36  |   pageup   |  33
 delete  |  46  |    end   |  35  |  pagedown  |  34
         |      |    aup   |  38  |            |  
  aleft  |  37  |   adown  |  40  |   aright   |  39

### Symbols

  Name   | Code |   Name   | Code |    Name    | Code
-------- | ---- | -------- | ---- | ---------- | ----
 equals  |  61  |  hyphen  | 109  | semicolon  |  59
   dot   | 190  |  sbopen  | 219  |  sbclose   | 221
  slash  | 191  |  gravis  | 192  | backslash  | 220
         |      |   coma   | 188  | apostrophe | 222

### Numpad

  Name   | Code |   Name   | Code |    Name    | Code
-------- | ---- | -------- | ---- | ---------- | ----
   np0   |  96  |    np1   |  97  | npslash    |  11
   np2   |  98  |    np3   |  99  | npstar     | 106
   np4   | 100  |    np5   | 101  | nphyphen   | 109
   np6   | 102  |    np7   | 103  | npplus     | 107
   np8   | 104  |    np9   | 105  | npdot      | 110