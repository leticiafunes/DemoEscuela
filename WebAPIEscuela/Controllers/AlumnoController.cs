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
    public class AlumnoController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }
        public AlumnoController(DBEscuelaAPIContext context)
        {
            this.Context = context;

        }

        //TRAER TODOS
        [HttpGet]
        public List<Alumno> Get()
        {
            //EF
            List<Alumno> alumnos = Context.Alumnos.ToList();
            return alumnos;
        }


        //TRAER UNO
        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            //EF
            Alumno alumno = Context.Alumnos.Find(id);

            return alumno;
        }

        //INSERTAR 
        [HttpPost]
        public ActionResult Post(Alumno alumno)
        {
            //EF -- memoria
            Context.Alumnos.Add(alumno);
            //EF - Guardar en la DB
            Context.SaveChanges();

            return Ok();
        }

        //MODIFICAR
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }

            //EF para modificar en la DB
            Context.Entry(alumno).State = EntityState.Modified;
            Context.SaveChanges();

            return NoContent();
        }

        //Eliminar

        [HttpDelete("{id}")]
        public ActionResult<Alumno> Delete(int id)
        {
            //EF
            var alumno = Context.Alumnos.Find(id);

            if (alumno == null)
            {
                return NotFound();
            }

            //EF
            Context.Alumnos.Remove(alumno);
            Context.SaveChanges();

            return alumno;

        }



    }
}
