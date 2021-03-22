﻿using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipiosController : ControllerBase
    {
        public IMunicipioService _service { get; set; }

        public MunicipiosController(IMunicipioService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("Complete/{id}")]
        public async Task<ActionResult> GetCompleteById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetCompleteById(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Authorize("Bearer")]
        [HttpGet]
        [Route("CompleteIbge/{ibge}")]
        public async Task<ActionResult> GetCompleteByIbge(int ibge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetCompleteByIBGE(ibge));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MunicipioDtoCreate dtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(dtoCreate);
                if (result != null)
                    return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
                else
                    return BadRequest();
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] MunicipioDtoUpdate dtoUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(dtoUpdate);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
