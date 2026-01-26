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

        [HttpGet("Laikep")]
        public IActionResult Tinhlaikep(double money, double n, double p)
        {
            var x = money * Math.Pow((1 + p / 100), n) - money;
            return Ok(x);
        }

        [HttpPost("solonT3")]
        public IActionResult XulyMang([FromBody] int[] array)
        {
            if(array == null || array.Length == 0)
            {
                return BadRequest("Mang rong hoac null");
            }

            var distinct  =  array.Distinct().OrderByDescending(x => x).ToList();

            if (distinct.Count >= 3) 
            {
                return Ok(distinct[2]);
            }
            else
            {
                return BadRequest("Mang co it hon 3 phan tu");
            }
        }
    }

    public class InArray()
    {
        public int[] numbers;
    }
}
