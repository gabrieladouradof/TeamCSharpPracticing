using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers {

    [ApiController]
    public class HomeController : ControllerBase //essa heranca (controller) gera um controller generico, CONTROLLER BASE DA MAIS METODOS
    {
        [HttpGet("/")] //atributo pra mostrar
        public IActionResult Get([FromServices] AppDbContext context) 
            => Ok(context.Todos.ToList());

        [HttpGet("/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var todos = context.Todos.FirstOrDefault(x => x.id == id);
            if (todos == null)
                return NotFound();

            return Ok(todos);
        }

        [HttpPost("/")]
        public IActionResult Post(
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context)
        {
            context.Todos.Add(todo);
            context.SaveChanges();

            return Created($"/{todo.id}", todo);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] TodoModel todo, //vai vir do corpo da requisicao

            [FromServices] AppDbContext context) //instancia do servico - (injecao de dependencia)
        {
            var model = context.Todos.FirstOrDefault(x => x.id == id);
            if(model == null)
            return NotFound();

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();
            return Ok(model);

        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        
        {
            var model = context.Todos.FirstOrDefault(x => x.id == id);
            if (model == null)
                return NotFound();

            context.Todos.Remove(model);
            context.SaveChanges();

            return Ok(model);
        }
     }
    }
