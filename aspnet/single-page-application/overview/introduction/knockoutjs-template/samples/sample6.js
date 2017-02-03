saveChanges = function () {
    return datacontext.saveChangedTodoItem(self);
};

// Auto-save when these properties change
self.isDone.subscribe(saveChanges);
self.title.subscribe(saveChanges);