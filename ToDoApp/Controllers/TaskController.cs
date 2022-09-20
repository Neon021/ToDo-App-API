using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _ctx;

        public TaskController(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            IEnumerable<TaskModel> tasks = _ctx.taskModels;
             
            return View(tasks);
        }

        //GET
        public IActionResult Create()
        {
            return View(new TaskModel());
        }

        //POST
        [HttpPost]
        public async Task<IResult> Create(TaskModel model)
        {
            try
            {

                if (ModelState.IsValid && _ctx.taskModels != null)
                {
                    var result = await _ctx.taskModels.AddAsync(model);
                    _ctx.SaveChanges();
                    return Results.Created("", result);
                }
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

            return Results.RedirectToRoute("/Index");
        }


        public async Task<IResult> GetTask(int id)
        {
            var model = await _ctx.taskModels.FindAsync(id);

            return Results.Ok(model);
        }

        public async Task<IResult> GetAllTask()
        {
            var models = await _ctx.taskModels.ToListAsync();
            return Results.Ok(models);
        }

        //GET
        public async Task<IResult> Edit(int id)
        {
            if(id == 0)
            {
                return Results.BadRequest();
            }

            var model = await _ctx.taskModels.FindAsync(id);
            return model == null ? Results.Ok(model) : Results.NoContent(); 
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Edit(TaskModel model)
        {
            if(ModelState.IsValid && _ctx.taskModels != null)
            {
                _ctx.taskModels.Update(model);
                await _ctx.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IResult> Delete(int? id)
        {
            if(id != null || id != 0)
            {
                var result = _ctx.taskModels.Remove(await _ctx.taskModels.FindAsync(id));
                return result != null ? Results.Ok(result) : Results.NoContent();
            }
            return Results.BadRequest();
        }
    }
}
