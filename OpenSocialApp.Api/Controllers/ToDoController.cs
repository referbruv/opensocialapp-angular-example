using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OpenSocialApp.Api.Models;
using OpenSocialApp.Api.Providers;

namespace OpenSocialApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoRepository _repository;

        public ToDoController()
        {
            _repository = new ToDoRepository();
        }

        [HttpGet, Route("all")]
        public IEnumerable<ToDo> Get()
        {
            return _repository.Get(x => x.CreatedOn > DateTime.MinValue);
        }

        [HttpGet, Route("{id}")]
        public ToDo GetSingle(Guid toDoItemId)
        {
            return _repository.GetSingle(toDoItemId);
        }

        [HttpPost]
        public ToDo CreateSingle(ToDo item)
        {
            return _repository.CreateSingle(item);
        }

        [HttpPatch, Route("{id}")]
        public ToDo UpdateSingle(Guid id, ToDo item)
        {
            return _repository.UpdateSingle(id, item);
        }

        [HttpDelete, Route("{id}")]
        public void DeleteSingle(Guid id)
        {
            _repository.DeleteSingle(id);
        }
    }
}