using ContactApp.Business.Contracts;
using ContactApp.DTOs.Contact;
using ContactApp.Framework.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMS.Framework.Extensions;

namespace ContactApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        [Route("CreateContact")]
        public async Task<ActionResult> CreateContact(CreateContactDTO dto)
        {
            try
            {
                ActionStatus<ContactDTO> result = await _contactService.CreateContact(dto);
                if (result)
                {
                    result.Response = new ResponseVM("CPC0001");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("CPCE001")));
                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ActionStatus(new ResponseVM("CPCE001")));
            }
        }

        [HttpPost]
        [Route("EditContact")]
        public async Task<ActionResult> EditContact(EditContactDTO dto)
        {
            try
            {
                ActionStatus<ContactDTO> result = await _contactService.EditContact(dto);
                if (result)
                {
                    result.Response = new ResponseVM("CPE0001");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("CPCE002")));
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ActionStatus(new ResponseVM("CPCE002")));
            }
        }
    }
}
