using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LDI.BusinessLogic.Abstract;
using LDI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LDI.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {

        public IUnitOfWork service;
        public ILogger logger;

        public ApiController(IUnitOfWork _service, ILogger<ApiController> _logger)
        {
            service = _service;
            logger = _logger;

        }

        [HttpPost("AddCategory")]
        public bool AddCategory([FromBody] Category category)
        {
            logger.LogDebug("Kategory eklendi");
            return service.Category.Add(category);
        }


        [HttpPost("AddContent")]
        public bool AddContent([FromBody] Content content)
        {
            return service.Content.Add(content);
        }

        [HttpPost("AddMedia")]
        public bool AddMedia([FromBody] Media media)
        {
            return service.Media.Add(media);
        }

    }
}