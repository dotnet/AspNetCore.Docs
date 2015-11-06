new function () {

var ID = 'qunit-fixture', $ID = '#' + ID,
	win = window, doc = win.document,
	wrapper = doc.getElementById(ID), slice=[].slice;

module('[Atom Plugins] Dom');

test('Get', function(){
	strictEqual(atom.dom().get(), doc, 'atom.dom() is document');
	strictEqual(atom.dom('body').first, doc.body, 'atom.dom("body") is body');
	strictEqual(atom.dom('unknownTag').length, 0, 'atom.dom("unknownTag") returns nothing');
	strictEqual(atom.dom($ID + ' p').length , wrapper.getElementsByTagName('p').length    , 'atom.dom("#cid p") right length');
	strictEqual(atom.dom('.foo', $ID).length, wrapper.getElementsByClassName('foo').length, 'atom.dom(".foo", "#cid") right length');
	strictEqual(atom.dom($ID).first, wrapper, 'atom.dom($ID).first');
	strictEqual(atom.dom(atom.dom($ID)).first, wrapper, 'atom.dom(atom.dom($ID)).first');
	deepEqual(atom.dom('#element_is_null').elems, [], 'if no element should be empty');
	// todo: [qtest] full of DOM plugin
});

test('atom.dom.create', function () {
	var $canvas = atom.dom.create('canvas', { width: 100 });

	ok($canvas instanceof atom.dom, 'atom.dom.create creates element, wrapped with atom.dom' );
	equal($canvas.length, 1, 'atom.dom.create creates one element');
	equal($canvas.first.tagName, 'CANVAS', 'atom.dom.create creates one element with correct name');
	equal($canvas.attr('width'), 100, 'attr sets correctly');

});

test('atom.dom().attr', function() {
	var $elem = atom.dom($ID + ' code');

	strictEqual($elem.attr('style'), wrapper.getElementsByTagName('code')[0].getAttribute('style'), 'atom.dom("#cid code").attr("style") right attribute content');
	$elem.attr('data-test-attr', 42);
	equal($elem.attr('data-test-attr'), 42, 'atom.dom("#cid code").attr("data-test-attr", "42") attribute must equal to 42');
});

test('atom.dom().css', function() {
	var $elem = atom.dom($ID + ' code');


	strictEqual($elem.css('color'), 'rgb(150, 150, 150)', 'inline style "color" of atom.dom("#cid code") must equal to "rgb(150, 150, 150)"');
	strictEqual(atom.dom($ID).css('position'), 'absolute', 'css style "position" of atom.dom("#cid") must equal to "absolute"');

	$elem.css('color', 'rgb(100, 100, 100)');
	strictEqual($elem.css('color'), 'rgb(100, 100, 100)', 'set the css style "color" of atom.dom("#cid code") should be equal to "rgb(100, 100, 100)"');

	$elem.css({
		color: 'rgb(80, 80, 80)',
		backgroundColor: 'rgb(30, 30, 30)'
	});
	strictEqual($elem.css('color'), 'rgb(80, 80, 80)', 'set the css style ("color") of atom.dom("#cid code") should be equal to "rgb(80, 80, 80)"');
	strictEqual($elem.css('background-color'), 'rgb(30, 30, 30)', 'set the css style ("backgroundColor") of atom.dom("#cid code") should be equal to "rgb(30, 30, 30)"');
});

test('atom.dom().addClass', function() {
	var $elem = atom.dom($ID + ' p');
	$elem.each(function(e){e.className = ''});

	$elem.addClass('cls1');
	deepEqual(slice.call(wrapper.getElementsByClassName('cls1'), 0), slice.call($elem.elems, 0), 'addClass("cls1") must make elements selectable with getElementsByClassName("cls1")');

	var $elem2 = atom.dom($elem.elems.slice(0,2));
	$elem2.addClass('cls2');
	deepEqual(slice.call(wrapper.getElementsByClassName('cls2'), 0), slice.call($elem2.elems, 0), 'addClass("cls2") must make elements selectable with getElementsByClassName("cls2")');
	deepEqual(slice.call(wrapper.getElementsByClassName('cls1'), 0), slice.call($elem.elems, 0), 'addClass("cls2") must not remove "cls1" from elements');

	var $elem3 = atom.dom($elem.first);
	$elem3.addClass(['cls1', 'cls2']);
	var classes = $elem3.first.className.split(' ');
	strictEqual(classes.length, 2, 'repeated adding classes must have no effect');

	// cleanup
	$elem.each(function(e){e.className = ''});
});

test('atom.dom().removeClass', function() {
	var $elem = atom.dom($ID + ' p');
	$elem.each(function(e){e.className = 'cls1'});
	var $elem2 = atom.dom($elem.elems.slice(0,2));
	$elem2.each(function(e){e.className = 'cls2 cls1'});

	var $elem3 = atom.dom($elem.get(0));
	$elem3.removeClass('cls1');
	strictEqual($elem3.get(0).className, 'cls2', 'removeClass("cls1") must remove class "cls1" but keep "cls2"');

	$elem.removeClass('cls2');
	strictEqual($elem3.get(0).className, '', 'removeClass("cls2") must remove class "cls2"');
	deepEqual(slice.call(wrapper.getElementsByClassName('cls2'), 0), [], 'removeClass("cls2") must remove class "cls2" from all elements');

	// cleanup
	$elem.each(function(e){e.className = ''});
});

test('atom.dom().hasClass', function() {
	var $elem = atom.dom($ID + ' p');
	$elem.each(function(e){e.className = 'cls1'});

	strictEqual($elem.hasClass('cls1'), true, 'hasClass("cls1") must return true if elements\' className is "cls1"');
	strictEqual($elem.hasClass('cls2'), false, 'hasClass("cls2") must return false if elements\' className is "cls1"');

	var $elem2 = atom.dom($elem.elems.slice(0,2));
	$elem2.each(function(e){e.className='cls2 cls3'});

	strictEqual($elem.hasClass('cls1'), true, 'hasClass(class) must return true if one of the elements has this class');
	strictEqual($elem.hasClass('cls2'), true, 'hasClass(class) must return true if one of the elements has this class');
	strictEqual($elem.hasClass(['cls2','cls3']), true, 'hasClass([classes]) must return true if one of the elements has all the classes');
	strictEqual($elem.hasClass(['cls1','cls3']), false, 'hasClass([classes]) must return false if none of the elements has all the classes');

	// cleanup
	$elem.each(function(e){e.className = ''});
});

test('atom.dom().toggleClass', function() {
	var $elem = atom.dom($ID + ' p');
	$elem.each(function(e){e.className = 'cls1'});
	var $elem2 = atom.dom($elem.elems.slice(0,2));
	$elem2.each(function(e){e.className='cls2 cls3'});

	$elem.toggleClass('cls1');
	deepEqual(slice.call(wrapper.getElementsByClassName('cls1'), 0), slice.call($elem2.elems, 0), 'after toggling "cls1" the only elements having "cls1" must be those which didn\'t have "cls1" before toggling');
	$elem.toggleClass(['cls1','cls2']);
	strictEqual($elem2.hasClass(['cls2','cls3']), false, 'there must not be any element in $elem2 having both "cls2" and "cls3"');
	strictEqual($elem.hasClass(['cls2','cls1']), true, 'there must be some elements in $elem having both "cls2" and "cls1"');

	// cleanup
	$elem.each(function(e){e.className = ''});
});
	
test('atom.dom().html', function() {
	var $elem = atom.dom($ID + ' h1');

	$elem.html('<span>42</span>');
	strictEqual($elem.html(), '<span>42</span>', 'html content atom.dom("#cid h1") should be equal to "<span>42</span>", because it was added as html content')
});

test('atom.dom().text', function() {
	var $elem = atom.dom($ID + ' h1');
		
	$elem.html('<span>42</span>');
	strictEqual($elem.text(), '42', 'text content atom.dom("#cid h1") should be equal to "42", but html content is "<span>42</span>"');

	$elem.find('span').text(24);
	strictEqual($elem.find('span').text(), '24', 'text content atom.dom("#cid h1") should be equal to "24", because it was changed from 42');
});

test('atom.dom().parent', function() {
	var $elem  = atom.dom.create('span').appendTo(atom.dom($ID + ' h1').html(''));

	$elem.html('<b>' + 24 + '</b>');
	strictEqual($elem.find('b').parent().html(), $elem.html(), 'html content should be equal to "<b>24</b>", because this content have parent element');
	strictEqual($elem.find('b').parent(2).html(), $elem.parent().html(), 'html content should be equal to "<span><b>24</b></span>", because this content have parent(2) element');
});

test('atom.dom().bind', function () {
	var $elem = atom.dom.create('div');
	var bind = false;
	
	$elem.bind("click", function () {
		bind = true;
	}).bind("click", false);
	
	var event = document.createEvent("MouseEvent");
	event.initMouseEvent("click", true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
	
	ok(!$elem.first.dispatchEvent(event), "bind('click', false) should prevent default action");
	ok(bind, "event listener should was called on click event");
});

test('atom.dom().unbind', function () {
	var $elem = atom.dom.create('div');
	var bind = 0;
	
	$elem.bind("click", function listener () {
		bind++;
		$elem.unbind("click", listener);
	});
	
	var event = document.createEvent("MouseEvent");
	event.initMouseEvent("click", true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
	
	$elem.first.dispatchEvent(event);
	$elem.first.dispatchEvent(event);
	
	equal(bind, 1, "unbind should detach event listener");
});

// Пусть всегда будет последним, чтобы не вешал остальные тесты!
asyncTest('atom.dom (ready)', 3, function () {
	atom.dom(function () {
		ok(true, 'onready runned');

		var async = false;
		atom.dom(function () {
			ok(true, 'onReady should wait for events even after ready');
			ok(async, 'onReady should runs async always');
		});
		async = true;
	});

	setTimeout(function () {
		// it has 1 sec for onDomReady
		start();
	}, 1000);
});

};
