using AndersenCoreApp.Interfaces.Services;
using AndersenCoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public ActionResult<List<RelationViewModel>> GetRelationsList([FromQuery] string orderProperty = "", [FromQuery] string categoryName = "")
        {
            var relations = relationService.GetAll();
            if (relations == null)
            {
                return NotFound();
            }
            var sortedRelations = relationService.GetSortedAndFilteredRelations(relations, categoryName, orderProperty);

            return Ok(sortedRelations);
        }

        [HttpGet("{id}")]
        public ActionResult<RelationViewModel> GetRelation(Guid id)
        {
            var relation = relationService.GetOne(id);
            if (relation == null)
                return NotFound();
            return Ok(relation);
        }

        [HttpPost]
        public ActionResult CreateRelation(RelationViewModel relation)
        {
            if (ModelState.IsValid)
            {
                relationService.Create(relation);
                return Ok(relation);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public ActionResult Update(RelationViewModel relation)
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
    }
}
