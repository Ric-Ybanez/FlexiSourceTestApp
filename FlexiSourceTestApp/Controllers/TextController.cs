using FlexiSourceTestApp.Common.Request;
using FlexiSourceTestApp.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FlexiSourceTestApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Text")]
    public class TextController : ControllerBase
    {
        private readonly ITextService _service;
        public TextController(ITextService service) => _service = service;

        [HttpPost]
        public IActionResult Post([FromBody] StringMatchRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var response = _service.StringSearch(request);
                return Ok(response);
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
        }
    }
}
