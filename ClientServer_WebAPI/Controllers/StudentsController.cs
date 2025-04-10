using ClientServer_WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientServer_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private ApplicationContext db;

        public StudentsController(ApplicationContext context)
        {
            db = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Json(db.Students.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            await db.Students.AddAsync(student);
            await db.SaveChangesAsync();
            return Json(student);

        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var StudentToDelete = await db.Students.FindAsync(id);
            if ( StudentToDelete!= null)
            {
                await Task.Run(() => db.Students.Remove(StudentToDelete));
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
