using AndersenCoreApp.Abstractions;
using AndersenCoreApp.EF_Abstractions;
using AndersenCoreApp.Models;
using AndersenCoreApp.ViewDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public List<RelationDTO> Get(string orderProperty ="", string orderCategory = "")
        {
            var relations = relationService.GetAll();
            if (!string.IsNullOrEmpty(orderProperty))
            {
                relations = relationService.GetSortedListByProperties(relations, orderProperty);
            }
            if (!string.IsNullOrEmpty(orderCategory))
            {
                 relations = relationService.GetListByCategories(relations, orderCategory);
            }
            var mapper = relationService.ConfigureMapperForDto();
            var relationsDTO = mapper.Map<List<Relation>, List<RelationDTO>>(relations.ToList());
            return relationsDTO;


        }

        
        [HttpGet("{id}")]
        public RelationDTO Get(Guid id)
        {
             
            var relation = relationService.GetOne(id);
            var mapper = relationService.ConfigureMapperForDto();
            RelationDTO model = mapper.Map<Relation, RelationDTO>(relation);
            return model;
        }

        
        [HttpPost]
        public void Post(Relation relation)
        {
            if (ModelState.IsValid)
            {
                relationService.Create(relation);
            }
        }

        
        [HttpPut("{id}")]
        public void Put(Guid id, Relation relation)
        {
            if (ModelState.IsValid)
            {
                relationService.Update(relation);
            }
        }

       
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            relationService.Delete(id);
        }

        

    }
}
