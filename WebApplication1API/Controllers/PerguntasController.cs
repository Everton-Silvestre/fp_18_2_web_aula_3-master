using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using fp_stack.core.Models;
using Microsoft.AspNetCore.Cors;

namespace WebApplication1API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{apiVersion}/[controller]")]
    [ApiController]
    //[EnableCors("Default")]
    public class PerguntasController : Controller
    {
        private Context _context;

        public PerguntasController(Context context)
        {
            _context = context;
        }

        //public List<Pergunta>Index()
        //{     
        //    return _context.Perguntas.ToList();
        //}


        //[HttpGet]
        ////[ProducesResponseType(200,Type = typeof(List<Pergunta>))]
        ////[ProducesResponseType(400)] 
        //public IActionResult Index()
        //{
        //    var perguntas = _context.Perguntas.ToList();
        //    if (perguntas.Count() == 3)
        //        return BadRequest();
        //    return Ok(perguntas);
        //}

        [HttpGet]
        //[Route("")]
        public ActionResult<List<Pergunta>> Get()
        {
            var perguntas = _context.Perguntas.ToList();
            //if (perguntas.Count() == 3)
            //    return BadRequest();
            return perguntas;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post(Pergunta pergunta)
        {
            //var perguntas = _context.Perguntas.ToList();
            //if (perguntas.Count() == 3)
            //    return BadRequest();


            if (ModelState.IsValid)
            {
                _context.Perguntas.Add(pergunta);
                _context.SaveChanges();
                return Created($"/api/perguntas{pergunta.Id}",pergunta);
            }
       
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int Id, [FromBody]Pergunta pergunta)
        {            
            if (ModelState.IsValid)
            {
                _context.Attach(pergunta);
                _context.Entry(pergunta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok(pergunta);
            }

            return BadRequest(ModelState);
        }
    }
}
