using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USZO_EB.Models;

namespace USZO_EB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VersenyzokController : ControllerBase
    {
        private readonly UszoebContext context;
        public VersenyzokController(UszoebContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult getVersenyzok()
        {
            try
            {
                return Ok(context.Versenyzoks.ToList());
                /*
                Ha kell a többi tábla: 
                return Ok(context.Versenyzoks.Include(v => v.Orszag).Include(v => v.Szamoks).ToList());
                */
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult getVersenyzo(int id)
        {
            try
            {
                var versenyzo = context.Versenyzoks.Include(v => v.Orszag).Include(v => v.Szamoks).FirstOrDefault(x => x.Id == id);
                /*
                Ha nem kell a többi tábla: 
                var versenyzo = context.Versenyzoks.FirstOrDefault(x => x.Id == id);
                */
                if (versenyzo == null)
                {
                    return NotFound("A versenyző nem található!");
                }
                return Ok(versenyzo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteVersenyzo(int id)
        {
            try
            {
                var versenyzo = context.Versenyzoks.FirstOrDefault(x => x.Id == id);
                if (versenyzo == null)
                {
                    return NotFound("A versenyző nem található!");
                }
                context.Remove(versenyzo);
                context.SaveChanges();
                return Ok("A versenyző sikeresen törölve!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult postVersenyzo(Versenyzok versenyzo)
        {
            try
            {
                context.Versenyzoks.Add(versenyzo);
                context.SaveChanges();
                return Ok("Versenyző sikeresen létrehozva!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult putVersenyzo(Versenyzok versenyzo)
        {
            try
            {
                context.Versenyzoks.Update(versenyzo);
                context.SaveChanges();
                return Ok("Versenyző sikeresen módosítva!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}