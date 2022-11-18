using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPIEscuela.Data;
using WebAPIEscuela.Models;

namespace WebAPIEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }
        public ProfesorController(DBEscuelaAPIContext context) {
            this.Context = context;

        
        }

        //TRAER TODOS
        [HttpGet]
        public List<Profesor> Get()
        {
            //EF
            List<Profesor> profesores = Context.Profesores.ToList();
            return profesores;
        }


        //TRAER UNO
        [HttpGet("{id}")]
        public Profesor Get(int id)
        {
            //EF
            Profesor profesor = Context.Profesores.Find(id);

            return profesor;
        }

        //INSERTAR 
        [HttpPost]
        public ActionResult Post(Profesor profesor)
        {
            //EF -- memoria
            Context.Profesores.Add(profesor);
            //EF - Guardar en la DB
            Context.SaveChanges();

            return Ok();
        }

//MODIFICAR
     [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest();
            }

            //EF para modificar en la DB
            Context.Entry(profesor).State = EntityState.Modified;
            Context.SaveChanges();

            return NoContent();
        }

//Eliminar

 [HttpDelete("{id}")]
        public ActionResult<Profesor> Delete(int id)
        {
            //EF
            var profesor = Context.Profesores.Find(id);

            if (profesor == null)
            {
                return NotFound();
            }

            //EF
            Context.Profesores.Remove(profesor);
            Context.SaveChanges();

            return profesor;

        }




    }
}
