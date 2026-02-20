using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace AsyncAwait.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetStudentInfo()
        {
            var studentTask = GetStudentAsync();
            var marsksTask = GetMarksAsync();

            await Task.WhenAll(studentTask, marsksTask);

            var result = new
            {
                Student = studentTask.Result,
                Marks = marsksTask.Result
            };
            return Ok(result);
        }

        private async Task<string> GetStudentAsync()
        {
            await Task.Delay(10000);
            return "John Doe";
        }
        private async Task<string> GetMarksAsync()
        {
            await Task.Delay(10000);
            return "85";
        }
    }
}