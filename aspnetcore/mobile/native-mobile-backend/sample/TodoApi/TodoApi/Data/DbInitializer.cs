using TodoApi.Models;

namespace TodoApi.Data {
    public static class DbInitializer {
        public static void Initialize (TodoContext context) {
            var items = new TodoItem[] {
                new TodoItem {
                Id = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                Name = "Learn app development",
                Notes = "Attend Xamarin University",
                Done = true
                },
                new TodoItem {
                Id = "b94afb54-a1cb-4313-8af3-b7511551b33b",
                Name = "Develop apps",
                Notes = "Use Xamarin Studio/Visual Studio",
                Done = false
                },
                new TodoItem {
                Id = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
                Name = "Publish apps",
                Notes = "All app stores",
                Done = false
                }
            };

            foreach (var item in items) {
                context.TodoItems.Add (item);
            }

            context.SaveChanges ();
        }
    }
}