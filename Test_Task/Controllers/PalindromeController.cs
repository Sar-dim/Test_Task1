using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Test_Task.Controllers
{
    [ApiController]
    [Route("palindrome")]
    public class PalindromeController : Controller
    {
        [HttpPost]
        [ProducesResponseType(typeof(LinkedList<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> PalindromeCheck(string palindrome)
        {
            if (String.IsNullOrWhiteSpace(palindrome))
            {
                throw new ArgumentException("String shouldn't be null or empty");
            }

            var reverseString = String.Empty;

            for (int i = palindrome.Length - 1; i >= 0; i--)
            {
                reverseString += palindrome[i].ToString();
            }

            if (reverseString == palindrome)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
