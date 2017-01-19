export class Navigation extends Backbone.View {
    // Other implementation details
    handleCommand(e: JQueryEventObject) {
        var command = $(e.currentTarget).attr('data-command');
        if (command) {
            events.trigger(command);
        }
    }
}
Navigation.prototype.events = () => {
    return {
        'click [data-command]': 'handleCommand'
    };
};