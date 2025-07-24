var todoClient = new TodoClient(new HttpClient());

// Gets all to-dos from the API
var allTodos = await todoClient.GetAsync();

// Create a new TodoItem, and save it via the API.
await todoClient.CreateAsync(new TodoItem());

// Get a single to-do by ID
var foundTodo = await todoClient.GetByIdAsync(1);
