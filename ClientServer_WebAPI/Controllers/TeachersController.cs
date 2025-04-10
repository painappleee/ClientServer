using ClientServer_WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientServer_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : Controller
    {
        private ApplicationContext db;

        public TeachersController(ApplicationContext context)
        {
            db = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Json(db.Teachers.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Teacher teacher)
        {
            await db.Teachers.AddAsync(teacher);
            await db.SaveChangesAsync();
            return Json(teacher);

        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var TeacherToDelete = await db.Teachers.FindAsync(id);
            if ( TeacherToDelete!= null)
            {
                await Task.Run(() => db.Teachers.Remove(TeacherToDelete));
                await db.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }


    }
}
