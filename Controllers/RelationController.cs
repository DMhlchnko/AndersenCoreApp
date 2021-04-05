using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Interfaces.Helpers;
using AndersenCoreApp.Interfaces.Services;
using AndersenCoreApp.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AndersenCoreApp.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RelationController : ControllerBase
    {
        private IRelationService _relationService;
        private IRelationHelpers _relationHelper;

        public RelationController(IRelationService service, IRelationHelpers helper)
        {
            _relationService = service;
            _relationHelper = helper;
        }

        [HttpGet]
        public async Task<IEnumerable<RelationDTO>> GetRelationsList(string filterByCategoryName,
            string sortByProperty,
            OrderBy orderBy)
        {
            var filter = _relationHelper.CreateRelationFilter(filterByCategoryName, sortByProperty, orderBy);
            var relations = await _relationService.GetRelationsAsync(filter);

            return relations;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RelationDTO>> GetRelation(Guid id)
        {
            var relation = await _relationService.GetOneAsync(id);
            if (relation == null)
            {
                return NotFound();
            }

            return Ok(relation);
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateRelation([FromBody]RelationDTO relation)
        {
            if (ModelState.IsValid)
            {
                var createdRelation = await _relationService.CreateAsync(relation);
                return Ok(createdRelation);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(RelationDTO relation)
        {
            if (ModelState.IsValid)
            {
                var updatedRelation = await _relationService.UpdateAsync(relation);
                return Ok(updatedRelation);
            }
            return BadRequest(relation);
        }

        [HttpPut("Delete")]
        public async Task<ActionResult> DeleteAsync([FromBody]params Guid[] identificators)
        {
            var deletedRelations = await _relationService.DeleteAsync(identificators);
            return Ok(deletedRelations);
        }
    }
}
