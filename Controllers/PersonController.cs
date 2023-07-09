using Microsoft.AspNetCore.Mvc;

namespace calculadora_grasa_corporal_back_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        [HttpGet("calculateBodyFatPercentege")]
        public IActionResult Get(String sexo="hombre", double altura=170, double cuello=20.5, double cintura=75, double cadera =85)
        {
            double result = 0;
            if (sexo.Equals("hombre"))
            {

                double porciento = 86.010 * Math.Log10(cintura - cuello) - 70.041 * Math.Log10(altura) + 36.76;
                result = Math.Round(porciento, 2);
            }
            else
            {
                double porciento = 163.205 * Math.Log10(cintura + cadera - cuello) - 97.684 * Math.Log10(altura) - 78.387;
                result = Math.Round(porciento, 2);
            }

            result = Math.Clamp(result, 0, 100);


            return Ok(result);
        }
    }
}