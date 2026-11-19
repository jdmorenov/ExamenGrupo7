using Microsoft.AspNetCore.Mvc;
using DSWI_T1_Grupo7.Models;

namespace DSWI_T1_Grupo7.Controllers
{
    public class CalculadoraController : Controller
    {
        public IActionResult Motocicleta()
        {
            Motocicleta modelo = new Motocicleta();

            return View(modelo);
        }

        [HttpGet]
        public IActionResult ConsumoElectrico()
        {
            return View(new ConsumoElectrico());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConsumoElectrico(ConsumoElectrico modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            modelo.Calcular();

            return View(modelo);
        }
    }
}
