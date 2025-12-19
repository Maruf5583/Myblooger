using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    public class MathController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(float firstNumber, float secondNumber)
        {
            if (firstNumber > 0 && secondNumber > 0)
            {
                
                float result = sum(firstNumber,secondNumber);

                ViewBag.Result = result;
            }
            else
            {
                return BadRequest("number will be getter then 0");
            }

            return View();
        }

        private float sum(float firstNumber, float secondNumber)
       {
            return firstNumber + secondNumber;
        }


        public IActionResult Substraction()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Substraction(float firstNumber, float secondNumber)
        {
            if (firstNumber > 0 && secondNumber > 0)
            {

                float result = sub(firstNumber, secondNumber);

                ViewBag.Result = result;
            }
            else
            {
                return BadRequest("number will be getter then 0");
            }

            return View();
        }

        private float sub(float firstNumber, float secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }
}
