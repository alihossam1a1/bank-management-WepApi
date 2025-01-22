using bank_management.dto;
using bank_management.repo.customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bank_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customercontroller : ControllerBase
    {
        private readonly Icustomer _repo;

        public customercontroller(Icustomer repo)
        {
            _repo = repo;
        }
        [HttpGet("Get All Data")]
        public IActionResult Get()
        {
            var res = _repo.Getall();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = _repo.Get(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [HttpPost("Add")]
        public IActionResult Add(getcustomerDto getcustomerDto)
        {
            _repo.addcustomer(getcustomerDto);
            if (getcustomerDto != null)
            {
                return Ok();
            }
            return BadRequest();

        }
    }
}
