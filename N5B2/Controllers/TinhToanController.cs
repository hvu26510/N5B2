using AppData.Models.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhToanController : ControllerBase
    {
        [HttpGet("tinhtong")]
        public  IActionResult TinhTong(int a, int b)
        {
            var x = a + b;
            return Ok(x);
        }
    }
}
