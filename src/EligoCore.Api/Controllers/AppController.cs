using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers.v1
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1.0/[controller]")]
    public class AppController : Controller
    {
       
    }
}