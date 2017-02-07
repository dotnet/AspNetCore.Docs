[ForeignKey("TodoList")]
public int TodoListId { get; set; }
public virtual TodoList TodoList { get; set; }