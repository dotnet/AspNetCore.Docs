module("messages");

test("predefined message not overwritten by addMethod(a, b, undefined)", function() {
	var message = "my custom message";
	$.validator.messages.custom = message;
	$.validator.addMethod("custom", function() {});
	deepEqual(message, $.validator.messages.custom);
	delete $.validator.messages.custom;
	delete $.validator.methods.custom;
});

test("group error messages", function() {
	$.validator.addClassRules({
		requiredDateRange: {required:true, date:true, dateRange:true}
	});
	$.validator.addMethod("dateRange", function() {
		return new Date($("#fromDate").val()) < new Date($("#toDate").val());
	}, "Please specify a correct date range.");
	var form = $("#dateRangeForm");
	form.validate({
		groups: {
			dateRange: "fromDate toDate"
		},
		errorPlacement: function(error) {
			form.find(".errorContainer").append(error);
		}
	});
	ok( !form.valid() );
	equal( 1, form.find(".errorContainer *").length );
	equal( "Please enter a valid date.", form.find(".errorContainer label.error").text() );

	$("#fromDate").val("12/03/2006");
	$("#toDate").val("12/01/2006");
	ok( !form.valid() );
	equal( "Please specify a correct date range.", form.find(".errorContainer label.error").text() );

	$("#toDate").val("12/04/2006");
	ok( form.valid() );
	ok( form.find(".errorContainer label.error").is(":hidden") );
});

test("read messages from metadata", function() {
	var form = $("#testForm9");
	form.validate();
	var e = $("#testEmail9");
	e.valid();
	equal( form.find("label").text(), "required" );
	e.val("bla").valid();
	equal( form.find("label").text(), "email" );
});


test("read messages from metadata, with meta option specified, but no metadata in there", function() {
	var form = $("#testForm1clean");
	form.validate({
		meta: "validate",
		rules: {
			firstname: "required"
		}
	});
	ok(!form.valid(), "not valid");
});
