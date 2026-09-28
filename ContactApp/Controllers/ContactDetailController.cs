using ContactApp.Business.Contracts;
using ContactApp.DTOs.Contact;
using ContactApp.DTOs.ContactDetail;
using ContactApp.Framework.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMS.Framework.Extensions;

namespace ContactApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetail : ControllerBase
    {
        IContactDetailService _contactDetailService;
        public ContactDetail(IContactDetailService contactDetailService)
        {
            _contactDetailService = contactDetailService;
        }

        [HttpPost]
        [Route("CreateContactDetail")]
        public async Task<ActionResult> CreateContactDetail(CreateContactDetailDTO dto)
        {
            try
            {
                ActionStatus<ContactDetailDTO> result = await _contactDetailService.CreateContactDetail(dto);
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
        [Route("EditContactDetail")]
        public async Task<ActionResult> EditContactDetail(EditContactDetailDTO dto)
        {
            try
            {
                ActionStatus<ContactDetailDTO> result = await _contactDetailService.EditContactDetail(dto);
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

        [HttpGet]
        [Route("GetContactDetailById/{id}")]
        public async Task<ActionResult> GetContactDetailById(long id)
        {
            try
            {
                ActionStatus<ContactDetailDTO> result = await _contactDetailService.GetContactDetailById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteContactDetailById/{id}")]
        public async Task<ActionResult> DeleteContactDetailById(long id)
        {
            try
            {
                ActionStatus<ContactDetailDTO> result =
                    await _contactDetailService.DeleteContactDetailById(id);

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
    }
}
