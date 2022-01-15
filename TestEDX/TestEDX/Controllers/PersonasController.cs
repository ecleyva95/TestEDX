using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestEDX.Comunication;
using TestEDX.Models;

namespace TestEDX.Controllers
{
    public class PersonasController : Controller
    {
        
        private IPersona PersonaRepository { get; set; }
        private readonly ILoggerManager _logger;
        public PersonasController(IPersona personaRepository, ILoggerManager logger)
        {

            PersonaRepository = personaRepository;
            _logger = logger;
        }

      
        public IActionResult ListadoPersonas()
        {
            _logger.LogInformation("Listando Personas");
            return View(PersonaRepository.GetPersonas());
        }

        // GET
        [HttpGet]
        public IActionResult CrearPersona()
        { 
        return View();
        }

        //Post
        [HttpPost]
        public IActionResult CrearPersona(Personas persona)
        {
            _logger.LogInformation("<Post> Crear Persona");
            if (ModelState.IsValid)
            {
                PersonaRepository.CreatePersona(persona);
                _logger.LogInformation("Return Persona" + persona.ToString());
                return  RedirectToAction("ListadoPersonas", persona);
            }

            _logger.LogError("Error en Listar Personas");
            return new BadRequestObjectResult(HttpStatusCode.BadRequest);

        }
        // GET
        [HttpGet]
        public IActionResult ObtenerPorId(int? id)
        {
            _logger.LogInformation("<Get> Obtener Persona");
            if (id == null)
            {
                _logger.LogError("Error: Id es obligatorio");
                return new BadRequestObjectResult(HttpStatusCode.BadRequest);
            }
            int idPer = id.Value;
            Personas pers = PersonaRepository.GetById(idPer);
            if (pers == null)
            {
                _logger.LogError("Error: Persona inexistente");
                return new NotFoundResult();
            }
            _logger.LogInformation("Return Persona" + pers.ToString());
            return View(pers);


        }
        [HttpGet]
        public IActionResult EditarPersona(int id)
        {
            _logger.LogInformation("<Get> Editar Persona");
            Personas pers = PersonaRepository.GetById(id);
            return View(pers);
        }
        [HttpPost]
        public IActionResult EditarPersona(Personas persona, int? id)
        {
            _logger.LogInformation("<Post> Editar Persona");

            int idPer = id.Value;
            Personas pers = PersonaRepository.GetById(idPer);
            if (pers == null)
            {
                _logger.LogError("Error: Persona inexistente");
                return new NotFoundResult();
            }
            try
            {
                PersonaRepository.UpdatePersona(persona,pers);
                _logger.LogInformation("Persona editada satisfactoriamente");
                return RedirectToAction("ListadoPersonas", persona);
            }
            catch (Exception e)
            {
                _logger.LogError("Error:" + e.Message);
                return new BadRequestObjectResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public IActionResult EliminarPersona(int? id)
        {
            _logger.LogInformation("<Get> Eliminar Persona");

            int idPer = id.Value;
            Personas pers = PersonaRepository.GetById(idPer);
            if (pers == null)
            {
                _logger.LogError("Error: Persona inexistente");
                return new NotFoundResult();
            }
            return View(pers);
            
        }
        [HttpPost]
        public IActionResult EliminarPersona(int id)
        {
            _logger.LogInformation("<Post> Eliminar Persona");
            try
            {
                Personas pers = PersonaRepository.GetById(id);
                PersonaRepository.DeletePersona(pers);

                _logger.LogInformation("Persona elinibada satisfactoriamente");
                return RedirectToAction("ListadoPersonas");
            }
            catch (Exception e)
            {
                _logger.LogError("Error:" + e.Message);
                return new BadRequestObjectResult(HttpStatusCode.BadRequest);
            }
        }

    }
}
