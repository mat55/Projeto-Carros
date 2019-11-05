using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto_Carros.Models;
using Projeto_Carros.Services;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Carros.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class HomeController : Controller
    {
        private ICarrosServices _carrosServices;
        private IRevisoesServices _revisoesServices;

        public HomeController(ICarrosServices carrosServices, IRevisoesServices revisoesServices)
        {
            _carrosServices = carrosServices;
            _revisoesServices = revisoesServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_carrosServices.Lista());
        }

        // GET: api/Home/5
        [HttpGet("{Codigo}", Name = "Get")]
        public IActionResult Get(int Codigo)
        {
            var carros = _carrosServices.FindById(Codigo);
            if (carros == null)
            {
                return NotFound();
            }

            return Ok(carros);
        }

        // POST: api/Home
        [HttpPost]
        [Route("PostCarros")]
        public IActionResult Post([FromBody] Carros carros)
        {
            if (carros == null)
            {
                return NotFound();
            }

            return Ok(_carrosServices.Create(carros));
        }

        [HttpPost]
        [Route("PostRevisoes")]
        public IActionResult Post([FromBody] Revisoes revisoes)
        {
            if (revisoes == null)
            {
                return NotFound();
            }

            return Ok(_revisoesServices.Create(revisoes));
        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Carros carros)
        {
            if (carros == null)
            {
                return BadRequest();
            }

            return Ok(_carrosServices.Update(carros));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _carrosServices.Delete(id);
            return NoContent();
        }
    }
}
