using CRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomControllerBase : ControllerBase
    {
        private protected readonly LoggerService _logger;

        public CustomControllerBase(LoggerService logger)
        {
            _logger = logger;
        }

    }
}