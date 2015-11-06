if ( window.sessionStorage ) {
	sessionStorage.clear();
}
jQuery.validator.defaults.debug = true;
$.mockjaxSettings.log = $.noop;

$.mockjax({
	url: "form.php?user=Peter&password=foobar",
	responseText: 'Hi Peter, welcome back.',
	responseStatus: 200,
	responseTime: 1
});
$.mockjax({
	url: "users.php",
	data: { username: /Peter2?|asdf/},
	responseText: 'false',
	responseStatus: 200,
	responseTime: 1
});
$.mockjax({
	url: "users2.php",
	data: { username: "asdf"},
	responseText: '"asdf is already taken, please try something else"',
	responseStatus: 200,
	responseTime: 1
});
$.mockjax({
	url: "echo.php",
	response: function(data) {
		this.responseText = JSON.stringify(data.data);
	},
	responseTime: 100
});

module("validator");

test("Constructor", function() {
	var v1 = $("#testForm1").validate();
	var v2 = $("#testForm1").validate();
	equal( v1, v2, "Calling validate() multiple times must return the same validator instance" );
	equal( v1.elements().length, 3, "validator elements" );
});

test("validate() without elements, with non-form elements", 0, function() {
	$("#doesntexist").validate();
});

test("valid() plugin method", function() {
	var form = $("#userForm");
	form.validate();
	ok ( !form.valid(), "Form isn't valid yet" );
	var input = $("#username");
	ok ( !input.valid(), "Input isn't valid either" );
	input.val("Hello world");
	ok ( form.valid(), "Form is now valid" );
	ok ( input.valid(), "Input is valid, too" );
});

test("valid() plugin method", function() {
	var form = $("#testForm1");
	form.validate();
	var inputs = form.find("input");
	ok( !inputs.valid(), "all invalid" );
	inputs.not(":first").val("ok");
	strictEqual( inputs.valid(), false, "just one invalid" );
	inputs.val("ok");
	strictEqual( inputs.valid(), true, "all valid" );
});

test("valid() plugin method, special handling for checkable groups", function() {
	// rule is defined on first checkbox, must apply to others, too
	var checkable = $("#checkable2");
	ok( !checkable.valid(), "must be invalid, not checked yet" );
	checkable.attr("checked", true);
	ok( checkable.valid(), "valid, is now checked" );
	checkable.attr("checked", false);
	ok( !checkable.valid(), "invalid again" );
	$("#checkable3").attr("checked", true);
	ok( checkable.valid(), "valid, third box is checked" );
});

test("addMethod", function() {
	expect( 3 );
	$.validator.addMethod("hi", function(value) {
		return value === "hi";
	}, "hi me too");
	var method = $.validator.methods.hi,
		e = $('#text1')[0];
	ok( !method(e.value, e), "Invalid" );
	e.value = "hi";
	ok( method(e.value, e), "Invalid" );
	ok( jQuery.validator.messages.hi === "hi me too", "Check custom message" );
});

test("addMethod2", function() {
	expect( 4 );
	$.validator.addMethod("complicatedPassword", function(value, element, param) {
		return this.optional(element) || /\D/.test(value) && /\d/.test(value);
	}, "Your password must contain at least one number and one letter");
	var v = jQuery("#form").validate({
		rules: {
			action: { complicatedPassword: true }
		}
	});
	var rule = $.validator.methods.complicatedPassword,
		e = $('#text1')[0];
	e.value = "";
	strictEqual( v.element(e), true, "Rule is optional, valid" );
	equal( 0, v.size() );
	e.value = "ko";
	ok( !v.element(e), "Invalid, doesn't contain one of the required characters" );
	e.value = "ko1";
	ok( v.element(e) );
});

test("form(): simple", function() {
	expect( 2 );
	var form = $('#testForm1')[0];
	var v = $(form).validate();
	ok( !v.form(), 'Invalid form' );
	$('#firstname').val("hi");
	$('#lastname').val("hi");
	ok( v.form(), 'Valid form' );
});

test("form(): checkboxes: min/required", function() {
	expect( 3 );
	var form = $('#testForm6')[0];
	var v = $(form).validate();
	ok( !v.form(), 'Invalid form' );
	$('#form6check1').attr("checked", true);
	ok( !v.form(), 'Invalid form' );
	$('#form6check2').attr("checked", true);
	ok( v.form(), 'Valid form' );
});

test("form(): radio buttons: required", function () {
	expect( 6 );
	var form = $('#testForm10')[0];

	var v = $(form).validate({ rules: { testForm10Radio: "required"} });
	ok(!v.form(), 'Invalid Form');
	equal($('#testForm10Radio1').attr('class'), 'error');
	equal($('#testForm10Radio2').attr('class'), 'error');

	$('#testForm10Radio2').attr("checked", true);
	ok(v.form(), 'Valid form');

	equal($('#testForm10Radio1').attr('class'), 'valid');
	equal($('#testForm10Radio2').attr('class'), 'valid');
});

test("form(): selects: min/required", function() {
	expect( 3 );
	var form = $('#testForm7')[0];
	var v = $(form).validate();
	ok( !v.form(), 'Invalid form' );
	$("#optionxa").attr("selected", true);
	ok( !v.form(), 'Invalid form' );
	$("#optionxb").attr("selected", true);
	ok( v.form(), 'Valid form' );
});

test("form(): with equalTo", function() {
	expect( 2 );
	var form = $('#testForm5')[0];
	var v = $(form).validate();
	ok( !v.form(), 'Invalid form' );
	$('#x1, #x2').val("hi");
	ok( v.form(), 'Valid form' );
});

test("form(): with equalTo and onfocusout=false", function() {
	expect( 4 );
	var form = $('#testForm5')[0];
	var v = $(form).validate({
		onfocusout: false,
		showErrors: function() {
			ok(true, 'showErrors should only be called twice');
			this.defaultShowErrors();
		}
	});
	$('#x1, #x2').val("hi");
	ok( v.form(), 'Valid form' );
	$('#x2').val('not equal').blur();
	ok( !v.form(), 'Invalid form' );
});


test("check(): simple", function() {
	expect( 3 );
	var element = $('#firstname')[0];
	var v = $('#testForm1').validate();
	ok( v.size() === 0, 'No errors yet' );
	v.check(element);
	ok( v.size() === 1, 'error exists' );
	v.errorList = [];
	$('#firstname').val("hi");
	v.check(element);
	ok( v.size() === 0, 'No more errors' );
});

test("hide(): input", function() {
	expect( 3 );
	var errorLabel = $('#errorFirstname');
	var element = $('#firstname')[0];
	element.value ="bla";
	var v = $('#testForm1').validate();
	errorLabel.show();
	ok( errorLabel.is(":visible"), "Error label visible before validation" );
	ok( v.element(element) );
	ok( errorLabel.is(":hidden"), "Error label not visible after validation" );
});

test("hide(): radio", function() {
	expect( 2 );
	var errorLabel = $('#agreeLabel');
	var element = $('#agb')[0];
	element.checked = true;
	var v = $('#testForm2').validate({ errorClass: "xerror" });
	errorLabel.show();
	ok( errorLabel.is(":visible"), "Error label visible after validation" );
	v.element(element);
	ok( errorLabel.is(":hidden"), "Error label not visible after hiding it" );
});

test("hide(): errorWrapper", function() {
	expect(2);
	var errorLabel = $('#errorWrapper');
	var element = $('#meal')[0];
	element.selectedIndex = 1;

	errorLabel.show();
	ok( errorLabel.is(":visible"), "Error label visible after validation" );
	var v = $('#testForm3').validate({ wrapper: "li", errorLabelContainer: $("#errorContainer") });
	v.element(element);
	ok( errorLabel.is(":hidden"), "Error label not visible after hiding it" );
});

test("hide(): container", function() {
	expect(4);
	var errorLabel = $('#errorContainer');
	var element = $('#testForm3')[0];
	var v = $('#testForm3').validate({ errorWrapper: "li", errorContainer: $("#errorContainer") });
	v.form();
	ok( errorLabel.is(":visible"), "Error label visible after validation" );
	$('#meal')[0].selectedIndex = 1;
	v.form();
	ok( errorLabel.is(":hidden"), "Error label not visible after hiding it" );
	$('#meal')[0].selectedIndex = -1;
	v.element("#meal");
	ok( errorLabel.is(":visible"), "Error label visible after validation" );
	$('#meal')[0].selectedIndex = 1;
	v.element("#meal");
	ok( errorLabel.is(":hidden"), "Error label not visible after hiding it" );
});

test("valid()", function() {
	expect(4);
	var errorList = [{name:"meal",message:"foo", element:$("#meal")[0]}];
	var v = $('#testForm3').validate();
	ok( v.valid(), "No errors, must be valid" );
	v.errorList = errorList;
	ok( !v.valid(), "One error, must be invalid" );
	QUnit.reset();
	v = $('#testForm3').validate({ submitHandler: function() {
		ok( false, "Submit handler was called" );
	}});
	ok( v.valid(), "No errors, must be valid and returning true, even with the submit handler" );
	v.errorList = errorList;
	ok( !v.valid(), "One error, must be invalid, no call to submit handler" );
});

test("submitHandler keeps submitting button", function() {
	$("#userForm").validate({
		debug: true,
		submitHandler: function(form) {
			// dunno how to test this better; this tests the implementation that uses a hidden input
			var hidden = $(form).find("input:hidden")[0];
			deepEqual(hidden.value, button.value);
			deepEqual(hidden.name, button.name);
		}
	});
	$("#username").val("bla");
	var button = $("#userForm :submit")[0];
  var event = $.Event("click");
  event.preventDefault();
  $.event.trigger(event, null, button);
	$("#userForm").submit();
});

test("showErrors()", function() {
	expect( 4 );
	var errorLabel = $('#errorFirstname').hide();
	var element = $('#firstname')[0];
	var v = $('#testForm1').validate();
	ok( errorLabel.is(":hidden") );
	equal( 0, $("label.error[for=lastname]").size() );
	v.showErrors({"firstname": "required", "lastname": "bla"});
	equal( true, errorLabel.is(":visible") );
	equal( true, $("label.error[for=lastname]").is(":visible") );
});

test("showErrors(), allow empty string and null as default message", function() {
	$("#userForm").validate({
		rules: {
			username: {
				required: true,
				minlength: 3
			}
		},
		messages: {
			username: {
				required: "",
				minlength: "too short"
			}
		}
	});
	ok( !$("#username").valid() );
	equal( "", $("label.error[for=username]").text() );

	$("#username").val("ab");
	ok( !$("#username").valid() );
	equal( "too short", $("label.error[for=username]").text() );

	$("#username").val("abc");
	ok( $("#username").valid() );
	ok( $("label.error[for=username]").is(":hidden") );
});

test("showErrors() - external messages", function() {
	expect( 4 );
	var methods = $.extend({}, $.validator.methods);
	var messages = $.extend({}, $.validator.messages);
	$.validator.addMethod("foo", function() { return false; });
	$.validator.addMethod("bar", function() { return false; });
	equal( 0, $("#testForm4 label.error[for=f1]").size() );
	equal( 0, $("#testForm4 label.error[for=f2]").size() );
	var form = $('#testForm4')[0];
	var v = $(form).validate({
		messages: {
			f1: "Please!",
			f2: "Wohoo!"
		}
	});
	v.form();
	equal( $("#testForm4 label.error[for=f1]").text(), "Please!" );
	equal( $("#testForm4 label.error[for=f2]").text(), "Wohoo!" );

	$.validator.methods = methods;
	$.validator.messages = messages;
});

test("showErrors() - custom handler", function() {
	expect(5);
	var v = $('#testForm1').validate({
		showErrors: function(errorMap, errorList) {
			equal( v, this );
			equal( v.errorList, errorList );
			equal( v.errorMap, errorMap );
			equal( "buga", errorMap.firstname );
			equal( "buga", errorMap.lastname );
		}
	});
	v.form();
});

test("option: (un)highlight, default", function() {
	$("#testForm1").validate();
	var e = $("#firstname");
	ok( !e.hasClass("error") );
	ok( !e.hasClass("valid") );
	e.valid();
	ok( e.hasClass("error") );
	ok( !e.hasClass("valid") );
	e.val("hithere").valid();
	ok( !e.hasClass("error") );
	ok( e.hasClass("valid") );
});

test("option: (un)highlight, nothing", function() {
	expect(3);
	$("#testForm1").validate({
		highlight: false,
		unhighlight: false
	});
	var e = $("#firstname");
	ok( !e.hasClass("error") );
	e.valid();
	ok( !e.hasClass("error") );
	e.valid();
	ok( !e.hasClass("error") );
});

test("option: (un)highlight, custom", function() {
	expect(5);
	$("#testForm1clean").validate({
		highlight: function(element, errorClass) {
			equal( "invalid", errorClass );
			$(element).hide();
		},
		unhighlight: function(element, errorClass) {
			equal( "invalid", errorClass );
			$(element).show();
		},
		errorClass: "invalid",
		rules: {
			firstname: "required"
		}
	});
	var e = $("#firstnamec");
	ok( e.is(":visible") );
	e.valid();
	ok( !e.is(":visible") );
	e.val("hithere").valid();
	ok( e.is(":visible") );
});

test("option: (un)highlight, custom2", function() {
	expect(6);
	$("#testForm1").validate({
		highlight: function(element, errorClass) {
			$(element).addClass(errorClass);
			$(element.form).find("label[for=" + element.id + "]").addClass(errorClass);
		},
		unhighlight: function(element, errorClass) {
			$(element).removeClass(errorClass);
			$(element.form).find("label[for=" + element.id + "]").removeClass(errorClass);
		},
		errorClass: "invalid"
	});
	var e = $("#firstname");
	var l = $("#errorFirstname");
	ok( !e.is(".invalid") );
	ok( !l.is(".invalid") );
	e.valid();
	ok( e.is(".invalid") );
	ok( l.is(".invalid") );
	e.val("hithere").valid();
	ok( !e.is(".invalid") );
	ok( !l.is(".invalid") );
});

test("option: focusCleanup default false", function() {
	var form = $("#userForm");
	form.validate();
	form.valid();
	ok( form.is(":has(label.error[for=username]:visible)"));
	$("#username").focus();
	ok( form.is(":has(label.error[for=username]:visible)"));
});

test("option: focusCleanup true", function() {
	var form = $("#userForm");
	form.validate({
		focusCleanup: true
	});
	form.valid();
	ok( form.is(":has(label.error[for=username]:visible)") );
	$("#username").focus().trigger("focusin");
	ok( !form.is(":has(label.error[for=username]:visible)") );
});

test("option: focusCleanup with wrapper", function() {
	var form = $("#userForm");
	form.validate({
		focusCleanup: true,
		wrapper: "span"
	});
	form.valid();
	ok( form.is(":has(span:visible:has(label.error[for=username]))") );
	$("#username").focus().trigger("focusin");
	ok( !form.is(":has(span:visible:has(label.error[for=username]))") );
});

test("option: errorClass with multiple classes", function() {
	var form = $("#userForm");
	form.validate({
		focusCleanup: true,
		wrapper: "span",
		errorClass: "error error1"
	});
	form.valid();
	ok( form.is(":has(span:visible:has(label.error[for=username]))") );
	ok( form.is(":has(span:visible:has(label.error1[for=username]))") );
	$("#username").focus().trigger("focusin");
	ok( !form.is(":has(span:visible:has(label.error[for=username]))") );
	ok( !form.is(":has(span:visible:has(label.error1[for=username]))") );
});

test("elements() order", function() {
	var container = $("#orderContainer");
	var v = $("#elementsOrder").validate({
		errorLabelContainer: container,
		wrap: "li"
	});
	deepEqual( v.elements().map(function() {
		return $(this).attr("id");
	}).get(), ["order1", "order2", "order3", "order4", "order5", "order6"], "elements must be in document order" );
	v.form();
	deepEqual( container.children().map(function() {
		return $(this).attr("for");
	}).get(), ["order1", "order2", "order3", "order4", "order5", "order6"], "labels in error container must be in document order" );
});

test("defaultMessage(), empty title is ignored", function() {
	var v = $("#userForm").validate();
	equal( "This field is required.", v.defaultMessage($("#username")[0], "required") );
});

test("formatAndAdd", function() {
	expect(4);
	var v = $("#form").validate();
	var fakeElement = { form: $("#form")[0], name: "bar" };
	v.formatAndAdd(fakeElement, {method: "maxlength", parameters: 2});
	equal( "Please enter no more than 2 characters.", v.errorList[0].message );
	equal( "bar", v.errorList[0].element.name );

	v.formatAndAdd(fakeElement, {method: "range", parameters:[2,4]});
	equal( "Please enter a value between 2 and 4.", v.errorList[1].message );

	v.formatAndAdd(fakeElement, {method: "range", parameters:[0,4]});
	equal( "Please enter a value between 0 and 4.", v.errorList[2].message );
});

test("formatAndAdd2", function() {
	expect(3);
	var v = $("#form").validate();
	var fakeElement = { form: $("#form")[0], name: "bar" };
	jQuery.validator.messages.test1 = function(param, element) {
		equal( v, this );
		equal( 0, param );
		return "element " + element.name + " is not valid";
	};
	v.formatAndAdd(fakeElement, {method: "test1", parameters: 0});
	equal( "element bar is not valid", v.errorList[0].message );
});

test("formatAndAdd, auto detect substitution string", function() {
	var v = $("#testForm1clean").validate({
		rules: {
			firstname: {
				required: true,
				rangelength: [5, 10]
			}
		},
		messages: {
			firstname: {
				rangelength: "at least ${0}, up to {1}"
			}
		}
	});
	$("#firstnamec").val("abc");
	v.form();
	equal( "at least 5, up to 10", v.errorList[0].message );
});

test("error containers, simple", function() {
	expect(14);
	var container = $("#simplecontainer");
	var v = $("#form").validate({
		errorLabelContainer: container,
		showErrors: function() {
			container.find("h3").html( jQuery.validator.format("There are {0} errors in your form.", this.size()) );
			this.defaultShowErrors();
		}
	});

	v.prepareForm();
	ok( v.valid(), "form is valid" );
	equal( 0, container.find("label").length, "There should be no error labels" );
	equal( "", container.find("h3").html() );

	v.prepareForm();
	v.errorList = [{message:"bar", element: {name:"foo"}}, {message: "necessary", element: {name:"required"}}];
	ok( !v.valid(), "form is not valid after adding errors manually" );
	v.showErrors();
	equal( container.find("label").length, 2, "There should be two error labels" );
	ok( container.is(":visible"), "Check that the container is visible" );
	container.find("label").each(function() {
		ok( $(this).is(":visible"), "Check that each label is visible" );
	});
	equal( "There are 2 errors in your form.", container.find("h3").html() );

	v.prepareForm();
	ok( v.valid(), "form is valid after a reset" );
	v.showErrors();
	equal( container.find("label").length, 2, "There should still be two error labels" );
	ok( container.is(":hidden"), "Check that the container is hidden" );
	container.find("label").each(function() {
		ok( $(this).is(":hidden"), "Check that each label is hidden" );
	});
});

test("error containers, with labelcontainer I", function() {
	expect(16);
	var container = $("#container"),
		labelcontainer = $("#labelcontainer");
	var v = $("#form").validate({
		errorContainer: container,
		errorLabelContainer: labelcontainer,
		wrapper: "li"
	});

	ok( v.valid(), "form is valid" );
	equal( 0, container.find("label").length, "There should be no error labels in the container" );
	equal( 0, labelcontainer.find("label").length, "There should be no error labels in the labelcontainer" );
	equal( 0, labelcontainer.find("li").length, "There should be no lis labels in the labelcontainer" );

	v.errorList = [{message:"bar", element: {name:"foo"}}, {name: "required", message: "necessary", element: {name:"required"}}];
	ok( !v.valid(), "form is not valid after adding errors manually" );
	v.showErrors();
	equal( 0, container.find("label").length, "There should be no error label in the container" );
	equal( 2, labelcontainer.find("label").length, "There should be two error labels in the labelcontainer" );
	equal( 2, labelcontainer.find("li").length, "There should be two error lis in the labelcontainer" );
	ok( container.is(":visible"), "Check that the container is visible" );
	ok( labelcontainer.is(":visible"), "Check that the labelcontainer is visible" );
	var labels = labelcontainer.find("label").each(function() {
		ok( $(this).is(":visible"), "Check that each label is visible1" );
		equal( "li", $(this).parent()[0].tagName.toLowerCase(), "Check that each label is wrapped in an li" );
		ok( $(this).parent("li").is(":visible"), "Check that each parent li is visible" );
	});
});

test("errorcontainer, show/hide only on submit", function() {
	expect(14);
	var container = $("#container");
	var labelContainer = $("#labelcontainer");
	var v = $("#testForm1").bind("invalid-form.validate", function() {
		ok( true, "invalid-form event triggered called" );
	}).validate({
		errorContainer: container,
		errorLabelContainer: labelContainer,
		showErrors: function() {
			container.html( jQuery.validator.format("There are {0} errors in your form.", this.numberOfInvalids()) );
			ok( true, "showErrors called" );
			this.defaultShowErrors();
		}
	});
	equal( "", container.html(), "must be empty" );
	equal( "", labelContainer.html(), "must be empty" );
	// validate whole form, both showErrors and invalidHandler must be called once
	// preferably invalidHandler first, showErrors second
	ok( !v.form(), "invalid form" );
	equal( 2, labelContainer.find("label").length );
	equal( "There are 2 errors in your form.", container.html() );
	ok( labelContainer.is(":visible"), "must be visible" );
	ok( container.is(":visible"), "must be visible" );

	$("#firstname").val("hix").keyup();
	$("#testForm1").triggerHandler("keyup", [jQuery.event.fix({ type: "keyup", target: $("#firstname")[0] })]);
	equal( 1, labelContainer.find("label:visible").length );
	equal( "There are 1 errors in your form.", container.html() );

	$("#lastname").val("abc");
	ok( v.form(), "Form now valid, trigger showErrors but not invalid-form" );
});

test("option invalidHandler", function() {
	expect(1);
	var v = $("#testForm1clean").validate({
		invalidHandler: function() {
			ok( true, "invalid-form event triggered called" );
			start();
		}
	});
	$("#usernamec").val("asdf").rules("add", { required: true, minlength: 5 });
	stop();
	$("#testForm1clean").submit();
});

test("findByName()", function() {
	deepEqual( new $.validator({}, document.getElementById("form")).findByName(document.getElementById("radio1").name).get(), $("#form").find("[name=radio1]").get() );
});

test("focusInvalid()", function() {
	// TODO when using custom focusin, this is triggered just once
	// TODO when using 1.4 focusin, triggered twice; fix once not testing against 1.3 anymore
	// expect(1);
	var inputs = $("#testForm1 input").focus(function() {
		equal( inputs[0], this, "focused first element" );
	});
	var v = $("#testForm1").validate();
	v.form();
	v.focusInvalid();
});

test("findLastActive()", function() {
	expect(3);
	var v = $("#testForm1").validate();
	ok( !v.findLastActive() );
	v.form();
	v.focusInvalid();
	equal( v.findLastActive(), $("#firstname")[0] );
	var lastActive = $("#lastname").trigger("focus").trigger("focusin")[0];
	equal( v.lastActive, lastActive );
});

test("validating multiple checkboxes with 'required'", function() {
	expect(3);
	var checkboxes = $("#form input[name=check3]").prop("checked", false);
	equal(checkboxes.size(), 5);
	var v = $("#form").validate({
		rules: {
			check3: "required"
		}
	});
	v.form();
	equal(v.size(), 1);
	checkboxes.filter(":last").prop("checked", true);
	v.form();
	equal(v.size(), 0);
});

test("dynamic form", function() {
	var counter = 0;
	function add() {
		$("<input data-rule-required='true' name='list" + counter++ + "' />").appendTo("#testForm2");
	}
	function errors(expected, message) {
		equal(expected, v.size(), message );
	}
	var v = $("#testForm2").validate();
	v.form();
	errors(1);
	add();
	v.form();
	errors(2);
	add();
	v.form();
	errors(3);
	$("#testForm2 input[name=list1]").remove();
	v.form();
	errors(2);
	add();
	v.form();
	errors(3);
	$("#testForm2 input[name^=list]").remove();
	v.form();
	errors(1);
	$("#agb").attr("disabled", true);
	v.form();
	errors(0);
	$("#agb").attr("disabled", false);
	v.form();
	errors(1);
});

test("idOrName()", function() {
	expect(4);
	var v = $("#testForm1").validate();
	equal( "form8input", v.idOrName( $("#form8input")[0] ) );
	equal( "check", v.idOrName( $("#form6check1")[0] ) );
	equal( "agree", v.idOrName( $("#agb")[0] ) );
	equal( "button", v.idOrName( $("#form :button")[0] ) );
});

test("resetForm()", function() {
	function errors(expected, message) {
		equal(expected, v.size(), message );
	}
	var v = $("#testForm1").validate();
	v.form();
	errors(2);
	$("#firstname").val("hiy");
	v.resetForm();
	errors(0);
	equal("", $("#firstname").val(), "form plugin is included, therefor resetForm must also reset inputs, not only errors");
});

test("message from title", function() {
	var v = $("#withTitle").validate();
    v.checkForm();
	equal(v.errorList[0].message, "fromtitle", "title not used");
});

test("ignoreTitle", function() {
	var v = $("#withTitle").validate({ignoreTitle:true});
    v.checkForm();
	equal(v.errorList[0].message, $.validator.messages["required"], "title used when it should have been ignored");
});

test("ajaxSubmit", function() {
	expect(1);
	stop();
	$("#user").val("Peter");
	$("#password").val("foobar");
	jQuery("#signupForm").validate({
		submitHandler: function(form) {
			jQuery(form).ajaxSubmit({
				success: function(response) {
					equal("Hi Peter, welcome back.", response);
					start();
				}
			});
		}
	});
	jQuery("#signupForm").triggerHandler("submit");
});

test("validating groups settings parameter", function() {
    var form = $("<form>");
    var validate = form.validate({
        groups: {
            arrayGroup: ["input one", "input-two", "input three"],
            stringGroup: "input-four input-five input-six"
        }
    });
    equal(validate.groups["input one"], "arrayGroup");
    equal(validate.groups["input-two"], "arrayGroup");
    equal(validate.groups["input three"], "arrayGroup");
    equal(validate.groups["input-four"], "stringGroup");
    equal(validate.groups["input-five"], "stringGroup");
    equal(validate.groups["input-six"], "stringGroup");
});

test('bypassing validation on form submission',function () {
	var form = $("#bypassValidation");
	var normalSubmission = $("form#bypassValidation :input[id=normalSubmit]");
	var bypassSubmitWithCancel = $("form#bypassValidation :input[id=bypassSubmitWithCancel]");
	var bypassSubmitWithNoValidate1 = $("form#bypassValidation :input[id=bypassSubmitWithNoValidate1]");
	var bypassSubmitWithNoValidate2 = $("form#bypassValidation :input[id=bypassSubmitWithNoValidate2]");

	var $v = form.validate({
		debug : true
	});

	bypassSubmitWithCancel.click();
	equal($v.numberOfInvalids(), 0, "Validation was bypassed using CSS 'cancel' class.");
	$v.resetForm();

	bypassSubmitWithNoValidate1.click();
	equal($v.numberOfInvalids(), 0, "Validation was bypassed using blank 'formnovalidate' attribute.");
	$v.resetForm();

	bypassSubmitWithNoValidate2.click();
	equal($v.numberOfInvalids(), 0, "Validation was bypassed using 'formnovalidate=\"formnovalidate\"' attribute.");
	$v.resetForm();

	normalSubmission.click();
	equal($v.numberOfInvalids(), 1, "Validation failed correctly");
});


module("misc");

test("success option", function() {
	expect(7);
	equal( "", $("#firstname").val() );
	var v = $("#testForm1").validate({
		success: "valid"
	});
	var label = $("#testForm1 label");
	ok( label.is(".error") );
	ok( !label.is(".valid") );
	v.form();
	ok( label.is(".error") );
	ok( !label.is(".valid") );
	$("#firstname").val("hi");
	v.form();
	ok( label.is(".error") );
	ok( label.is(".valid") );
});

test("success option2", function() {
	expect(5);
	equal( "", $("#firstname").val() );
	var v = $("#testForm1").validate({
		success: "valid"
	});
	var label = $("#testForm1 label");
	ok( label.is(".error") );
	ok( !label.is(".valid") );
	$("#firstname").val("hi");
	v.form();
	ok( label.is(".error") );
	ok( label.is(".valid") );
});

test("success option3", function() {
	expect(5);
	equal( "", $("#firstname").val() );
	$("#errorFirstname").remove();
	var v = $("#testForm1").validate({
		success: "valid"
	});
	equal( 0, $("#testForm1 label").size() );
	$("#firstname").val("hi");
	v.form();
	var labels = $("#testForm1 label");
	equal( 3, labels.size() );
	ok( labels.eq(0).is(".valid") );
	ok( !labels.eq(1).is(".valid") );
});

test("successlist", function() {
	var v = $("#form").validate({ success: "xyz" });
	v.form();
	equal(0, v.successList.length);
});

test("success isn't called for optional elements", function() {
	expect(4);
	equal( "", $("#firstname").removeAttr("data-rule-required").removeAttr("data-rule-minlength").val() );
	$("#something").remove();
	$("#lastname").remove();
	$("#errorFirstname").remove();
	var v = $("#testForm1").validate({
		success: function() {
			ok( false, "don't call success for optional elements!" );
		},
		rules: {
			firstname: "email"
		}
	});
	equal( 0, $("#testForm1 label").size() );
	v.form();
	equal( 0, $("#testForm1 label").size() );
	$("#firstname").valid();
	equal( 0, $("#testForm1 label").size() );
});

test("success callback with element", function() {
	expect(1);
	var v = $("#userForm").validate({
		success: function( label, element ) {
			equal( element, $('#username').get(0) );
		}
	});
	$("#username").val("hi");
	v.form();
});

test("all rules are evaluated even if one returns a dependency-mistmatch", function() {
	expect(6);
	equal( "", $("#firstname").removeAttr("data-rule-required").removeAttr("data-rule-minlength").val() );
	$("#lastname").remove();
	$("#errorFirstname").remove();
	$.validator.addMethod("custom1", function() {
		ok( true, "custom method must be evaluated" );
		return true;
	}, "");
	var v = $("#testForm1").validate({
		rules: {
			firstname: {email:true, custom1: true}
		}
	});
	equal( 0, $("#testForm1 label").size() );
	v.form();
	equal( 0, $("#testForm1 label").size() );
	$("#firstname").valid();
	equal( 0, $("#testForm1 label").size() );

	delete $.validator.methods.custom1;
	delete $.validator.messages.custom1;
});

test("messages", function() {
	var m = jQuery.validator.messages;
	equal( "Please enter no more than 0 characters.", m.maxlength(0) );
	equal( "Please enter at least 1 characters.", m.minlength(1) );
	equal( "Please enter a value between 1 and 2 characters long.", m.rangelength([1, 2]) );
	equal( "Please enter a value less than or equal to 1.", m.max(1) );
	equal( "Please enter a value greater than or equal to 0.", m.min(0) );
	equal( "Please enter a value between 1 and 2.", m.range([1, 2]) );
});

test("jQuery.validator.format", function() {
	equal( "Please enter a value between 0 and 1.", jQuery.validator.format("Please enter a value between {0} and {1}.", 0, 1) );
	equal( "0 is too fast! Enter a value smaller then 0 and at least -15", jQuery.validator.format("{0} is too fast! Enter a value smaller then {0} and at least {1}", 0, -15) );
	var template = jQuery.validator.format("{0} is too fast! Enter a value smaller then {0} and at least {1}");
	equal( "0 is too fast! Enter a value smaller then 0 and at least -15", template(0, -15) );
	template = jQuery.validator.format("Please enter a value between {0} and {1}.");
	equal( "Please enter a value between 1 and 2.", template([1, 2]) );
	equal( $.validator.format("{0}", "$0"), "$0" );
});

test("option: ignore", function() {
	var v = $("#testForm1").validate({
		ignore: "[name=lastname]"
	});
	v.form();
	equal( 1, v.size() );
});

test("option: subformRequired", function() {
	jQuery.validator.addMethod("billingRequired", function(value, element) {
		if ($("#bill_to_co").is(":checked")) {
			return $(element).parents("#subform").length;
		}
		return !this.optional(element);
	}, "");
	var v = $("#subformRequired").validate();
	v.form();
	equal( 1, v.size() );
	$("#bill_to_co").attr("checked", false);
	v.form();
	equal( 2, v.size() );

	delete $.validator.methods.billingRequired;
	delete $.validator.messages.billingRequired;
});

module("expressions");

test("expression: :blank", function() {
	var e = $("#lastname")[0];
	equal( 1, $(e).filter(":blank").length );
	e.value = " ";
	equal( 1, $(e).filter(":blank").length );
	e.value = "   ";
	equal( 1, $(e).filter(":blank").length );
	e.value= " a ";
	equal( 0, $(e).filter(":blank").length );
});

test("expression: :filled", function() {
	var e = $("#lastname")[0];
	equal( 0, $(e).filter(":filled").length );
	e.value = " ";
	equal( 0, $(e).filter(":filled").length );
	e.value = "   ";
	equal( 0, $(e).filter(":filled").length );
	e.value= " a ";
	equal( 1, $(e).filter(":filled").length );
});

test("expression: :unchecked", function() {
	var e = $("#check2")[0];
	equal( 1, $(e).filter(":unchecked").length );
	e.checked = true;
	equal( 0, $(e).filter(":unchecked").length );
	e.checked = false;
	equal( 1, $(e).filter(":unchecked").length );
});

module("events");

test("validate on blur", function() {
	function errors(expected, message) {
		equal(v.size(), expected, message );
	}
	function labels(expected) {
		equal(v.errors().filter(":visible").size(), expected);
	}
	function blur(target) {
		target.trigger("blur").trigger("focusout");
	}
	$("#errorFirstname").hide();
	var e = $("#firstname");
	var v = $("#testForm1").validate();
	$("#something").val("");
	blur(e);
	errors(0, "No value yet, required is skipped on blur");
	labels(0);
	e.val("h");
	blur(e);
	errors(1, "Required was ignored, but as something was entered, check other rules, minlength isn't met");
	labels(1);
	e.val("hh");
	blur(e);
	errors(0, "All is fine");
	labels(0);
	e.val("");
	v.form();
	errors(3, "Submit checks all rules, both fields invalid");
	labels(3);
	blur(e);
	errors(1, "Blurring the field results in emptying the error list first, then checking the invalid field: its still invalid, don't remove the error" );
	labels(3);
	e.val("h");
	blur(e);
	errors(1, "Entering a single character fulfills required, but not minlength: 2, still invalid");
	labels(3);
	e.val("hh");
	blur(e);
	errors(0, "Both required and minlength are met, no errors left");
	labels(2);
});

test("validate on keyup", function() {
	function errors(expected, message) {
		equal(expected, v.size(), message );
	}
	function keyup(target) {
		target.trigger("keyup");
	}
	var e = $("#firstname");
	var v = $("#testForm1").validate();
	keyup(e);
	errors(0, "No value, no errors");
	e.val("a");
	keyup(e);
	errors(0, "Value, but not invalid");
	e.val("");
	v.form();
	errors(2, "Both invalid");
	keyup(e);
	errors(1, "Only one field validated, still invalid");
	e.val("hh");
	keyup(e);
	errors(0, "Not invalid anymore");
	e.val("h");
	keyup(e);
	errors(1, "Field didn't loose focus, so validate again, invalid");
	e.val("hh");
	keyup(e);
	errors(0, "Valid");
});

test("validate on not keyup, only blur", function() {
	function errors(expected, message) {
		equal(expected, v.size(), message );
	}
	var e = $("#firstname");
	var v = $("#testForm1").validate({
		onkeyup: false
	});
	errors(0);
	e.val("a");
	e.trigger("keyup");
	e.keyup();
	errors(0);
	e.trigger("blur").trigger("focusout");
	errors(1);
});

test("validate on keyup and blur", function() {
	function errors(expected, message) {
		equal(expected, v.size(), message );
	}
	var e = $("#firstname");
	var v = $("#testForm1").validate();
	errors(0);
	e.val("a");
	e.trigger("keyup");
	errors(0);
	e.trigger("blur").trigger("focusout");
	errors(1);
});

test("validate email on keyup and blur", function() {
	function errors(expected, message) {
		equal(expected, v.size(), message );
	}
	var e = $("#firstname");
	var v = $("#testForm1").validate();
	v.form();
	errors(2);
	e.val("a");
	e.trigger("keyup");
	errors(1);
	e.val("aa");
	e.trigger("keyup");
	errors(0);
});

test("validate checkbox on click", function() {
	function errors(expected, message) {
		equal(expected, v.size(), message );
	}
	function trigger(element) {
		element.click();
		// triggered click event screws up checked-state in 1.4
		element.valid();
	}
	var e = $("#check2");
	var v = $("#form").validate({
		rules: {
			check2: "required"
		}
	});
	trigger(e);
	errors(0);
	trigger(e);
	equal( false, v.form() );
	errors(1);
	trigger(e);
	errors(0);
	trigger(e);
	errors(1);
});

test("validate multiple checkbox on click", function() {
	function errors(expected, message) {
		equal(expected, v.size(), message );
	}
	function trigger(element) {
		element.click();
		// triggered click event screws up checked-state in 1.4
		element.valid();
	}
	var e1 = $("#check1").attr("checked", false);
	var e2 = $("#check1b");
	var v = $("#form").validate({
		rules: {
			check: {
				required: true,
				minlength: 2
			}
		}
	});
	trigger(e1);
	trigger(e2);
	errors(0);
	trigger(e2);
	equal( false, v.form() );
	errors(1);
	trigger(e2);
	errors(0);
	trigger(e2);
	errors(1);
});

test("correct checkbox receives the error", function(){
	function trigger(element) {
		element.click();
		// triggered click event screws up checked-state in 1.4
		element.valid();
	}
	var e1 = $("#check1").attr("checked", false);
	var e2 = $("#check1b").attr("checked", false);
    var v = $("#form").find('[type=checkbox]').attr('checked', false).end().validate({
        rules:{
            check: {
                    required: true,
                    minlength: 2
            }
        }
    });
    equal(false, v.form());
    trigger(e1);
    equal(false, v.form());
    ok(v.errorList[0].element.id === v.currentElements[0].id, "the proper checkbox has the error AND is present in currentElements");
});

test("validate radio on click", function() {
	function errors(expected, message) {
		equal(expected, v.size(), message );
	}
	function trigger(element) {
		element.click();
		// triggered click event screws up checked-state in 1.4
		element.valid();
	}
	var e1 = $("#radio1");
	var e2 = $("#radio1a");
	var v = $("#form").validate({
		rules: {
			radio1: "required"
		}
	});
	errors(0);
	equal( false, v.form() );
	errors(1);
	trigger(e2);
	errors(0);
	trigger(e1);
	errors(0);
});

test("validate input with no type attribute, defaulting to text", function() {
	function errors(expected, message) {
		equal(expected, v.size(), message );
	}
	var v = $("#testForm12").validate();
	var e = $("#testForm12text");
	errors(0);
	e.valid();
	errors(1);
	e.val('test');
	e.trigger('keyup');
	errors(0);
});

test("ignore hidden elements", function(){
    var form = $('#userForm');
    var validate = form.validate({
        rules:{
            "username": "required"
        }
    });
    form.get(0).reset();
    ok(! validate.form(), "form should be initially invalid");
    $('#userForm [name=username]').hide();
    ok(validate.form(), "hidden elements should be ignored by default");
});

test("ignore hidden elements at start", function(){
    var form = $('#userForm');
    var validate = form.validate({
        rules:{
            "username": "required"
        }
    });
    form.get(0).reset();
    $('#userForm [name=username]').hide();
    ok(validate.form(), "hidden elements should be ignored by default");
    $('#userForm [name=username]').show();
    ok(! validate.form(), "form should be invalid when required element is visible");
});

test("Specify error messages through data attributes", function() {
	var form = $('#dataMessages');
	var name = $('#dataMessagesName');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#dataMessages label');
	equal( label.text(), "You must enter a value here", "Correct error label" );
});

test("Updates pre-existing label if has error class", function() {
	var form = $('#updateLabel'),
		input = $('#updateLabelInput'),
		label = $('#targetLabel'),
		v = form.validate(),
		labelsBefore = form.find('label').length,
		labelsAfter;

	input.val('');
	input.valid();
	labelsAfter = form.find('label').length;

	// label was updated
	equal( label.text(), input.attr('data-msg-required') );
	// new label wasn't created
	equal( labelsBefore, labelsAfter );
});

test("Min date set by attribute", function() {
	var form = $('#rangesMinDateInvalid');
	var name = $('#minDateInvalid');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#rangesMinDateInvalid label');
	equal( label.text(), "Please enter a value greater than or equal to 2012-12-21.", "Correct error label" );
});

test("Max date set by attribute", function() {
	var form = $('#ranges');
	var name = $('#maxDateInvalid');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "Please enter a value less than or equal to 2012-12-21.", "Correct error label" );
});

test("Min and Max date set by attributes greater", function() {
	var form = $('#ranges');
	var name = $('#rangeDateInvalidGreater');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "Please enter a value less than or equal to 2013-01-21.", "Correct error label" );
});

test("Min and Max date set by attributes less", function() {
	var form = $('#ranges');
	var name = $('#rangeDateInvalidLess');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "Please enter a value greater than or equal to 2012-11-21.", "Correct error label" );
});

test("Min date set by attribute valid", function() {
	var form = $('#rangeMinDateValid');
	var name = $('#minDateValid');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#rangeMinDateValid label');
	equal( label.text(), "", "Correct error label" );
});

test("Max date set by attribute valid", function() {
	var form = $('#ranges');
	var name = $('#maxDateValid');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "", "Correct error label" );
});

test("Min and Max date set by attributes valid", function() {
	var form = $('#ranges');
	var name = $('#rangeDateValid');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "", "Correct error label" );
});

test("Min and Max strings set by attributes greater", function() {
	var form = $('#ranges');
	var name = $('#rangeTextInvalidGreater');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "Please enter a value less than or equal to 200.", "Correct error label" );
});

test("Min and Max strings set by attributes less", function() {
	var form = $('#ranges');
	var name = $('#rangeTextInvalidLess');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "Please enter a value greater than or equal to 200.", "Correct error label" );
});

test("Min and Max strings set by attributes valid", function() {
	var form = $('#ranges');
	var name = $('#rangeTextValid');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "", "Correct error label" );
});



test("Min and Max type absent set by attributes greater", function() {
	var form = $('#ranges');
	var name = $('#rangeAbsentInvalidGreater');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "Please enter a value less than or equal to 200.", "Correct error label" );
});

test("Min and Max type absent set by attributes less", function() {
	var form = $('#ranges');
	var name = $('#rangeAbsentInvalidLess');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "Please enter a value greater than or equal to 200.", "Correct error label" );
});

test("Min and Max type absent set by attributes valid", function() {
	var form = $('#ranges');
	var name = $('#rangeAbsentValid');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "", "Correct error label" );
});



test("Min and Max range set by attributes valid", function() {
	//
	// cannot test for overflow: 
	// When the element is suffering from an underflow,
	// the user agent must set the element's value to a valid
	// floating-point number that represents the minimum.
	// http://www.w3.org/TR/html5/forms.html#range-state-%28type=range%29
	//
	var form = $('#ranges');
	var name = $('#rangeRangeValid');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "", "Correct error label" );
});


test("Min and Max number set by attributes valid", function() {
	var form = $('#ranges');
	var name = $('#rangeNumberValid');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "", "Correct error label" );
});


test("Min and Max number set by attributes greater", function() {
	var form = $('#ranges');
	var name = $('#rangeNumberInvalidGreater');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "Please enter a value less than or equal to 200.", "Correct error label" );
});


test("Min and Max number set by attributes less", function() {
	var form = $('#ranges');
	var name = $('#rangeNumberInvalidLess');
	var v = form.validate();

	form.get(0).reset();
	name.valid();

	var label = $('#ranges label');
	equal( label.text(), "Please enter a value greater than or equal to 50.", "Correct error label" );
});

