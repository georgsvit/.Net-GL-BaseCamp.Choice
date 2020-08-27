using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangsController : ControllerBase
    {
        private readonly List<Lang> _langs;

        public LangsController(List<Lang> langs)
        {
            _langs = langs;
        }

        // GET: api/<LangsController>
        [HttpGet]
        public IEnumerable<Lang> Get()
        {
            return _langs;
        }

        // GET api/<LangsController>/5
        [HttpGet("{id}")]
        public ActionResult<Lang> Get(string id)
        {
            Lang lang = _langs.SingleOrDefault(l => l.Id == id);

            if (lang == null) return NotFound();
            return lang;
        }

        // POST api/<LangsController>
        [HttpPost]
        public ActionResult Post([FromForm] Lang lang)
        {
            if (ModelState.IsValid)
            {
                _langs.Add(lang);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // PUT api/<LangsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromForm] Lang lang)
        {
            var old = _langs.SingleOrDefault(l => l.Id == id);
            if (old == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                old.Id = lang.Id;
                old.Year = lang.Year;
                return Ok();
            }

            return BadRequest(ModelState);
        }

        // DELETE api/<LangsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var lang = _langs.SingleOrDefault(l => l.Id == id);

            if (lang == null)
            {
                return NotFound();
            }

            _langs.Remove(lang);
            return Ok();
        }
    }
}
