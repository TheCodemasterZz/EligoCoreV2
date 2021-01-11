using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EligoCore.Service;
using EligoCore.Service.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers.v1
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    public class RefCountryController : Controller
    {
        private readonly IRefCountryService _refCountryService;

        public RefCountryController([FromServices] IRefCountryService refCountryService)
        {
            _refCountryService = refCountryService ?? throw new ArgumentNullException(nameof(refCountryService));
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<IActionResult> CreateRefCountryAsync([FromBody] RefCountryDto request, CancellationToken cancellationToken = default)
        {
            try
            {
                await _refCountryService.DispatchBehavior(request, cancellationToken);

                return Created("order/confirmation", null); // 201
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}