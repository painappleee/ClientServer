using ClientServer_WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientServer_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : Controller
    {
        private ApplicationContext db;

        public CoursesController(ApplicationContext context)
        {
            db = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Json(db.Courses.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Course course)
        {
            await db.Courses.AddAsync(course);
            await db.SaveChangesAsync();
            return Json(course);

        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var courseToDelete = await db.Courses.FindAsync(id);
            if ( courseToDelete!= null)
            {
                await Task.Run(() => db.Courses.Remove(courseToDelete));
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
