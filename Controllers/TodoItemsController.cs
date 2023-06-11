using Microsoft.AspNetCore.Mvc;

namespace TestHttp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private static List<TodoItem> _todoItems = new List<TodoItem>();
        private static int _nextId = 1;

        // GET: api/TodoItems
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _todoItems;
        }

        // GET: api/TodoItems/{id}
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todoItem = _todoItems.FirstOrDefault(item => item.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }

        // POST: api/TodoItems
        [HttpPost]
        public ActionResult<TodoItem> Post(TodoItem todoItem)
        {
            todoItem.Id = _nextId++;
            _todoItems.Add(todoItem);

            return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
        }

        // PUT: api/TodoItems/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, TodoItem updatedTodoItem)
        {
            var existingTodoItem = _todoItems.FirstOrDefault(item => item.Id == id);
            if (existingTodoItem == null)
            {
                return NotFound();
            }

            existingTodoItem.Title = updatedTodoItem.Title;
            existingTodoItem.IsCompleted = updatedTodoItem.IsCompleted;

            return NoContent();
        }

        // DELETE: api/TodoItems/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todoItem = _todoItems.FirstOrDefault(item => item.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _todoItems.Remove(todoItem);

            return NoContent();
        }
    }

}
