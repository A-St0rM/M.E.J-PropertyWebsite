using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using M.E.J_PropertyWebsite.Server.Database;
using M.E.J_PropertyWebsite.Server.Models;
using M.E.J_PropertyWebsite.Server.DTO;

namespace M.E.J_PropertyWebsite.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WaitingListController : ControllerBase
    {
        private readonly AzureDBContext _context;

        public WaitingListController(AzureDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetWaitingList")]
        public IActionResult GetWaitingList()
        {
            var waitingList = _context.WaitlingList.ToList();
            return Ok(waitingList);
        }

        [HttpPost]
        [Route("AddToWaitingList")]
        public IActionResult AddToWaitingList([FromBody] WaitingList waitingList)
        {
            _context.WaitlingList.Add(waitingList);
            _context.SaveChanges();

            return Created("", waitingList);
        }

        [HttpDelete]
        [Route("RemoveFromWaitingList/{id}")]
        public IActionResult RemoveFromWaitingList(int id)
        {
            var waitingList = _context.WaitlingList.FirstOrDefault(w => w.Id == id);
            if (waitingList == null)
            {
                return NotFound();
            }

            _context.WaitlingList.Remove(waitingList);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
