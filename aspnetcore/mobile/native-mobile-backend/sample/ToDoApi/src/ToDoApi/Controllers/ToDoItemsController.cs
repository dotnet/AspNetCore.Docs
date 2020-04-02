using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase {
        private readonly IToDoRepository _toDoRepository;

        public ToDoItemsController (IToDoRepository toDoRepository) {
            _toDoRepository = toDoRepository;
        }

        // GET: api/TodoItems
        [HttpGet]
        public ActionResult<List<ToDoItem>> GetTodoItems () =>
            _toDoRepository.Get ();

        [HttpGet ("{id}")]
        public ActionResult<ToDoItem> GetTodoItem (string id) {
            var todoItem = _toDoRepository.Get (id);

            if (todoItem == null) {
                return NotFound ();
            }

            return todoItem;
        }

        [HttpPost]
        public IActionResult CreateTodoItem (ToDoItem todoItem) {
            try {
                bool itemExists = _toDoRepository.DoesItemExist (todoItem.Id);
                if (itemExists) {
                    return StatusCode (StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString ());
                }
                _toDoRepository.Create (todoItem);
            } catch (Exception) {
                return BadRequest (ErrorCode.CouldNotCreateItem.ToString ());
            }

            return CreatedAtAction (
                nameof (GetTodoItem),
                new { id = todoItem.Id },
                todoItem);
        }

        [HttpPut]
        public IActionResult UpdateTodoItem (ToDoItem todoItem) {
            try {
                var existingItem = _toDoRepository.Get (todoItem.Id);
                if (existingItem == null) {
                    return NotFound (ErrorCode.RecordNotFound.ToString ());
                }
                _toDoRepository.Update (todoItem);
            } catch (Exception) {
                return BadRequest (ErrorCode.CouldNotUpdateItem.ToString ());
            }
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public IActionResult DeleteTodoItem (string id) {
            try {
                var item = _toDoRepository.Get (id);
                if (item == null) {
                    return NotFound (ErrorCode.RecordNotFound.ToString ());
                }
                _toDoRepository.Delete (id);
            } catch (Exception) {
                return BadRequest (ErrorCode.CouldNotDeleteItem.ToString ());
            }
            return NoContent ();
        }
    }

    public enum ErrorCode {
        TodoItemNameAndNotesRequired,
        TodoItemIDInUse,
        RecordNotFound,
        CouldNotCreateItem,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }

}