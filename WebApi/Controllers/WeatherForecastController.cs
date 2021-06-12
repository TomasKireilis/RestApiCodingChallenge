﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return null;
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Post()
        {
            return null;
        }

        [HttpPut]
        public IEnumerable<WeatherForecast> Put()
        {
            return null;
        }

        [HttpDelete]
        public IEnumerable<WeatherForecast> Delete()
        {
            return null;
        }
    }
}