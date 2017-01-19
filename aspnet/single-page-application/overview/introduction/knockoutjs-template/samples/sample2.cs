TodoItemContext db = new TodoItemContext();
IEnumerable<TodoList> lists = 
    from td in db.TodoLists where td.UserId == "Alice" select td;