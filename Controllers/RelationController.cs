using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Interfaces.Services;
using AndersenCoreApp.Models.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static AndersenCoreApp.Infrastructure.RelationFilter;

namespace AndersenCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationController : ControllerBase
    {
        private IRelationService relationService;

        public RelationController(IRelationService service)
        {
            relationService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<RelationDTO>> GetRelationsList(string filterByCategoryName,
            string sortByProperty,
            OrderBy orderBy)
        {
            var filter = CreateFilter(filterByCategoryName, sortByProperty, orderBy);
            var relations = await relationService.GetRelationsAsync(filter);

            return relations;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RelationDTO>> GetRelation(Guid id)
        {
            var relation = await relationService.GetOneAsync(id);
            if (relation == null)
            {
                return NotFound();
            }

            return Ok(relation);
        }

        [HttpPost]
        public ActionResult CreateRelation(RelationDTO relation)
        {
            if (ModelState.IsValid)
            {
                relationService.Create(relation);
                return Ok(relation);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public ActionResult Update(RelationDTO relation)
        {
            relationService.Update(relation);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            relationService.Delete(id);
            return NoContent();
        }

        //Move CreateRelationFilter to Helpers/RelationHelpers
        private static RelationFilter CreateFilter(string filterByCategoryName = "", string sortByProperty = "", OrderBy orderBy = OrderBy.Ascending)
        {
            return new RelationFilter(filterByCategoryName, sortByProperty, orderBy);
        }
    }
}
