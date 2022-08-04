using System.Transactions;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoxBack.Domain.Models;
using BoxBack.WebApi.EndPoints;
using BoxBack.WebApi.Controllers;

namespace BoxBack.WebApi.EndPoints
{
    [Route("api/roles")]
    public class RolesEndpoint : ApiController
    {
        private readonly RoleManager<ApplicationRole> _manager;

        public RolesEndpoint(RoleManager<ApplicationRole> manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ApplicationRole>>> Get()
        {
            var roles = await _manager.Roles.AsNoTracking().ToListAsync();

            return Ok(new { data = roles, recordsTotal = roles.Count, recordsFiltered = roles.Count });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApplicationRole>> Get([FromRoute]string id) => Ok(await _manager.FindByIdAsync(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromForm]ApplicationRole model)
        {
            model.Id = Guid.NewGuid().ToString();
            model.ConcurrencyStamp = Guid.NewGuid().ToString();

            var result = await _manager.CreateAsync(model);

            if (result.Succeeded)
            {
                return CreatedAtAction("Get", new { id = model.Id }, model);
            }

            return BadRequest(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromForm]ApplicationRole model)
        {
            var result = await _manager.UpdateAsync(model);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromForm]ApplicationRole model)
        {
            // HACK: The code below is just for demonstration purposes!
            // Please use a different method of preventing the default role from being removed
            

            var result = await _manager.DeleteAsync(model);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(result);
        }
    }
}
