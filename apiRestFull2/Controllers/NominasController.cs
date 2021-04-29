using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiRestFull2.Data;
using apiRestFull2.Models;

namespace apiRestFull2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominasController : ControllerBase
    {
        private readonly apiRestFull2Context _context;

        public NominasController(apiRestFull2Context context)
        {
            _context = context;
        }

        //GET: api/Nominas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nominas>>> GetNominas()
        {
            return await _context.Nominas.ToListAsync();

        }



        // GET: api/Nominas/5
        [HttpGet("{cargoId}/{departamento}")]
        public async Task<ActionResult<IEnumerable<NominaModel>>> GetNominas(int cargoId, string departamento)
        {
            var query = from a in _context.Nominas
                        join b in _context.Cargos on a.CargoId equals b.CargoId
                        select new NominaModel
                        {
                            Nombre = a.Nombre,
                            Ano =  a.Ano,
                            Cargo = b.Cargos,
                            Departamento = a.Departamento,
                            CargoId = a.CargoId,
                            Id = a.Id,
                            Mes = a.Mes,
                            Sueldo = a.Sueldo
                        };


            if (cargoId != -1)
                query = query.Where(w => w.CargoId == cargoId);

            if (departamento.ToLower() != "elija")
                query = query.Where(w => w.Departamento == departamento);

            return await query.Take(500).ToListAsync();

        }



         [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<NominaModel>>> GetNominasbyId()
        {
            var query = from a in _context.Nominas

                        select new NominaModel
                        {
                            Nombre = a.Nombre,
                            Ano = a.Ano,
                            Cargo = a.Nombre,
                            Departamento = a.Departamento,
                            CargoId = a.CargoId,
                            Id = a.Id,
                            Mes = a.Mes,
                            Sueldo = a.Sueldo
                        };




            return await query.Take(500).ToListAsync();

        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<string>>> GetNominasByDepartamento()
        {
            return await _context
                .Nominas
                .Select(s => s.Departamento)
                .Distinct()
                .OrderBy(o => o)
                .ToListAsync();


        }



        //[HttpGet("[action]/{id}")]
        //public async Task<ActionResult<IEnumerable<Nominas>>> GetNominasByCargoId(int id)
        //{
        //    var nominas = await _context.Nominas.Where(x => x.CargoId == id).ToListAsync();

        //    if (nominas == null)
        //    {
        //        return NotFound();
        //    }

        //    return nominas;
        //}


        //[HttpGet("[action]/{departamento}")]
        //public async Task<ActionResult<IEnumerable<Nominas>>> GetNominasByDept(string departamento)
        //{
        //    var nominas = await _context.Nominas.Where(x => x.Departamento == departamento).ToListAsync();

        //    if (nominas == null)
        //    {
        //        return NotFound();
        //    }

        //    return nominas;
        //}

 

        //[HttpPost("[action]")]
        //public async Task<ActionResult<IEnumerable<Nominas>>> GetNominasByCargo(List<Filtro> filtros)
        //{

        //    var query =  _context.Nominas.AsQueryable();
        //    if (filtros.Count() > 0)
        //    {
        //        var item = filtros.FirstOrDefault(f => f.PropertyName == "cargo");
        //        if (item != null)
        //            query = query.Where(w => w.CargoId == int.Parse(item.Value));

        //        item = filtros.FirstOrDefault(f => f.PropertyName == "departamento");
        //        if (item != null)
        //            query = query.Where(w => w.Departamento == item.Value);

        //    }


        //    return await query.ToListAsync();
        //}


        //// PUT: api/Nominas/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutNominas(int id, Nominas nominas)
        //{
        //    if (id != nominas.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(nominas).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!NominasExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Nominas
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Nominas>> PostNominas(Nominas nominas)
        //{
        //    _context.Nominas.Add(nominas);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetNominas", new { id = nominas.Id }, nominas);
        //}

        //// DELETE: api/Nominas/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteNominas(int id)
        //{
        //    var nominas = await _context.Nominas.FindAsync(id);
        //    if (nominas == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Nominas.Remove(nominas);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool NominasExists(int id)
        //{
        //    return _context.Nominas.Any(e => e.Id == id);
        //}
    }
}
