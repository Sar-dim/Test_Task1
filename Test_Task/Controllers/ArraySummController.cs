using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Test_Task.Controllers
{
    [ApiController]
    [Route("array_summ")]
    public class ArraySummController : Controller
    {
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<int> Summ(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Array is null or empty");
            }

            var counter = 0;
            var summ = 0;

            foreach (var item in array)
            {
                if (item % 2 != 0)
                {
                    counter++;
                    if (counter == 2)
                    {
                        counter = 0;
                        summ += Math.Abs(item);
                    }
                }
            }

            return summ;
        }
    }
}
