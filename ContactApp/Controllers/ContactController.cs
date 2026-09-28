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

        [HttpPost]
        [Route("CreateContactWithDetails")]
        public async Task<ActionResult> CreateContactWithDetails(CreateContactRequestDTO dto)
        {
            try
            {
                ActionStatus<ContactDTO> result = await _contactService.CreateContactWithDetails(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetContactById/{id}")]
        public async Task<ActionResult> GetContactById(long id)
        {
            try
            {
                ActionStatus<ContactDTO> result =
                    await _contactService.GetContactById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetContactAndDetailsById/{id}")]
        public async Task<ActionResult> GetContactAndDetailsById(long id)
        {
            try
            {
                ActionStatus<ContactDTO> result = await _contactService.GetContactAndDetailsById(id);

                if (result)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("BlockContact/{id}")]
        public async Task<ActionResult> BlockContact(long id)
        {
            try
            {
                ActionStatus<ContactDTO> result = await _contactService.BlockContact(id);

                if (result)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UnblockContact/{id}")]
        public async Task<ActionResult> UnblockContact(long id)
        {
            try
            {
                ActionStatus<ContactDTO> result =
                    await _contactService.UnblockContact(id);

                if (result)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("DeleteContact/{id}")]
        public async Task<ActionResult> DeleteContact(long id)
        {
            try
            {
                ActionStatus<ContactDTO> result = await _contactService.DeleteContact(id);

                if (result)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
