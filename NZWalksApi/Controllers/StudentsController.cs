using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET: /api/students
        [HttpGet(Name = "GetStudents")]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = ["John", "okay"];

            return Ok(studentNames);
        }


    }
}
