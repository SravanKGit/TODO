using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TODO.Models;

namespace TODO.Controllers
{
    public class TodoTasksV1Controller : ApiController
    {
        private TODOEntities db = new TODOEntities();
        [Route("todo/api/v1.0/tasks")]
        [HttpGet]
        public IQueryable<TodoTask> GetTodoTasks()
        {
            return db.TodoTasks;
        }

        [Route("todo/api/v1.0/tasks/{id}")]
        [HttpGet]
        [ResponseType(typeof(TodoTask))]
        // GET: api/TodoTasksV1/5
        public async Task<IHttpActionResult> GetTodoTask([FromUri] int id)
        {
            TodoTask todoTask = await db.TodoTasks.FindAsync(id);
            if (todoTask == null)
            {
                return NotFound();
            }

            return Ok(todoTask);
        }

        [Route("todo/api/v1.0/tasks/{id}")]
        [HttpPut]
        // PUT: api/TodoTasksV1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTodoTask([FromUri] int id, [FromBody] TodoTask todoTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoTask.id)
            {
                return BadRequest();
            }

            db.Entry(todoTask).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("todo/api/v1.0/tasks")]
        [HttpPost]
        // POST: api/TodoTasksV1
        [ResponseType(typeof(TodoTask))]
        public async Task<IHttpActionResult> PostTodoTask(TodoTask todoTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TodoTasks.Add(todoTask);
            await db.SaveChangesAsync();

            return Ok(todoTask);
        }

        [Route("todo/api/v1.0/tasks/{id}")]
        [HttpDelete]
        [ResponseType(typeof(TodoTask))]
        public async Task<IHttpActionResult> DeleteTodoTask(int id)
        {
            TodoTask todoTask = await db.TodoTasks.FindAsync(id);
            if (todoTask == null)
            {
                return NotFound();
            }

            db.TodoTasks.Remove(todoTask);
            await db.SaveChangesAsync();

            return Ok(todoTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoTaskExists(int id)
        {
            return db.TodoTasks.Count(e => e.id == id) > 0;
        }
    }
}