saveCheckbox: function () {
    if(this.get("isDirty")){
        if (this.get("todoItemId")) {
            App.store.commit();
        }
    }
}.observes('isDone'),