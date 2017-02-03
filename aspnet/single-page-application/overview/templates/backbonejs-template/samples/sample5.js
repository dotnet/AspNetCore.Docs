export class Session extends Backbone.Model {
    urlRoot() {
        return serverUrlPrefix + '/sessions'
    }

    defaults(): ISessionAttributes {
        return {
          email: null,
          password: null,
          rememberMe: false
        }
    }

    validate(attributes: ISessionAttributes): IValidationResult {
        var errors = {};

        if (!attributes.email) {
            Validation.addError(errors, 'email', 'Email is required.');
        }

        if (!attributes.password) {
            Validation.addError(errors, 'password', 'Password is required.');
        }

        if (!_.isEmpty(errors)) {
            return { errors: errors };
        }
    }
}