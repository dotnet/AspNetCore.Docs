// Here $el is the form element
// Hide existing errors if there is any
this.$el.hideSummaryError().hideFieldErrors();

// Subscribe invalid event which
// is fired when validation fails
model.on('invalid', () =>
    this.$el.showFieldErrors{(
        errors: model.validationError.errors;
    )}
);

model.save(this.$el.serializeFields(), {
    success: () => { }, // lets do something good
    error: (m, jqxhr: JQueryXHR) => {
        if (jqxhr.status === 400) { // bad request
            // Handle server side field errors
            var response = <any>$.parseJSON(jqxhr.responseText);
            if (response && _.has(response, 'ModelState')) {
                return this.$el.showFieldErrors({
                    errors: response.ModelState
                });
            }
        }

        // All other server errors
        this.$el.showSummaryError({
            message: 'An unexpected error has occurred while performing ' +
                'operation.'
        });
    }
});