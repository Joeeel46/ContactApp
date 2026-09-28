using ContactApp.Business.Contracts;
using ContactApp.Data.Service.Contracts;
using ContactApp.DTOs.Contact;
using ContactApp.DTOs.ContactDetail;
using ContactApp.Framework.Extentions;
using ContactApp.Framework.Mappers;
using ContactMS.Data.Contract;
using ProductMS.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Business
{
    public class ContactService : IContactService
    {

        IContactDataService _contactDataService;

        private readonly IContactDetailDataService _contactDetailDataService;
        private readonly APIDataMapper<IContactDetail, ContactDetailDTO> _contactDetailMapper;

        private readonly APIDataMapper<IContact, ContactDTO> _contactMapper;
        private readonly APIDataMapper<IContact, CreateContactDTO> _createContactMapper;
        private readonly APIDataMapper<IContact, EditContactDTO> _editContactMapper;
        private readonly APIDataMapper<IContact, CreateContactRequestDTO> _createContactRequestMapper;
        private readonly APIDataMapper<IContactDetail, CreateContactDetailRequestDTO> _createContactDetailRequestMapper;
        public ContactService(IContactDataService contactDataService, IContactDetailDataService contactDetailDataService,
            APIDataMapper<IContact, ContactDTO> contactMapper,
            APIDataMapper<IContact, CreateContactDTO> createContactMapper,
            APIDataMapper<IContact, EditContactDTO> editContactMapper,
            APIDataMapper<IContact, CreateContactRequestDTO> createContactRequestMapper,
            APIDataMapper<IContactDetail, CreateContactDetailRequestDTO> createContactDetailRequestMapper,
            APIDataMapper<IContactDetail, ContactDetailDTO> contactDetailMapper
            )
        {
            _contactDataService = contactDataService;
            _contactDetailDataService = contactDetailDataService;
            _contactMapper = contactMapper;
            _createContactMapper = createContactMapper;
            _editContactMapper = editContactMapper;
            _createContactRequestMapper = createContactRequestMapper;
            _createContactDetailRequestMapper = createContactDetailRequestMapper;
            _contactDetailMapper = contactDetailMapper;
        }

        public async Task<ActionStatus<ContactDTO>> CreateContact(CreateContactDTO dto)
        {
            try
            {
                IContact result = _createContactMapper.ToEntity(dto);
                ActionStatus<IContact> data = await _contactDataService.CreateContact(result);
                if (data)
                {
                    ContactDTO response = _contactMapper.ToObject(data.Result);

                    return new ActionStatus<ContactDTO>(true, response);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactDTO>(new ResponseVM("BPCE001"));
                }
                return new ActionStatus<ContactDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDTO>("BPC-CreateContact", ex);
            }
        }

        public async Task<ActionStatus<ContactDTO>> EditContact(EditContactDTO dto)
        {
            try
            {
                IContact result = _editContactMapper.ToEntity(dto);
                ActionStatus<IContact> data = await _contactDataService.EditContact(result);
                if (data)
                {
                    ContactDTO response = _contactMapper.ToObject(data.Result);
                    return new ActionStatus<ContactDTO>(true, response);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactDTO>(new ResponseVM("BPCE002"));
                }
                return new ActionStatus<ContactDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDTO>("BPC-EditContact", ex);
            }
        }

        public async Task<ActionStatus<ContactDTO>> CreateContactWithDetails(CreateContactRequestDTO dto)
        {
            try
            {
                IContact result = _createContactRequestMapper.ToEntity(dto);

                ActionStatus<IContact> resultEntity = await _contactDataService.CreateContact(result);

                if (resultEntity)
                {
                    ContactDTO response = _contactMapper.ToObject(resultEntity.Result);

                    List<IContactDetail> detailmodel =_createContactDetailRequestMapper
                            .ToEntities(dto.ContactDetails)
                            .ToList();

                    detailmodel.ForEach(x =>
                    {
                        x.ContactId = resultEntity.Result.Id;
                        x.CreatedUserId = resultEntity.Result.CreatedUserId;
                    });

                    ActionStatus<List<IContactDetail>> detailResultEntity = await _contactDetailDataService.CreateContactDetails(detailmodel);

                    if (detailResultEntity)
                    {
                        List<ContactDetailDTO> detailresult =_contactDetailMapper
                                .ToObjects(detailResultEntity.Result)
                                .ToList();

                        response.ContactDetails = detailresult;
                    }

                    return new ActionStatus<ContactDTO>(true,response);
                }
                else if (resultEntity.HasException)
                {
                    return new ActionStatus<ContactDTO>(new ResponseVM("BCCE001"));
                }

                return new ActionStatus<ContactDTO>(resultEntity);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDTO>("BPC-CreateContactWithDetails", ex);
            }
        }

        public async Task<ActionStatus<ContactDTO>> GetContactById(long id)
        {
            try
            {
                ActionStatus<IContact> data = await _contactDataService.GetContactById(id);

                if (data)
                {
                    ContactDTO response = _contactMapper.ToObject(data.Result);

                    return new ActionStatus<ContactDTO>(true, response);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactDTO>(new ResponseVM("BPCE001"));
                }

                return new ActionStatus<ContactDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDTO>("BPC-GetContactById", ex);
            }
        }

        public async Task<ActionStatus<ContactDTO>> GetContactAndDetailsById(long id)
        {
            try
            {
                ActionStatus<IContact> contactResult = await _contactDataService.GetContactById(id);

                if (contactResult)
                {
                    ContactDTO response = _contactMapper.ToObject(contactResult.Result);

                    ActionStatus<List<IContactDetail>> detailResult = await _contactDetailDataService.GetContactDetailsByContactId(contactResult.Result.Id);
                     
                    if (detailResult)
                    {
                        List<ContactDetailDTO> details = _contactDetailMapper
                                .ToObjects(detailResult.Result)
                                .ToList();

                        response.ContactDetails = details;
                    }

                    return new ActionStatus<ContactDTO>(true, response);
                }

                if (contactResult.HasException)
                {
                    return new ActionStatus<ContactDTO>(new ResponseVM("BPGE001"));
                }

                return new ActionStatus<ContactDTO>(new ResponseVM("CONTACT_NOT_FOUND"));
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDTO>("BPC-GetContactById", ex);
            }
        }

        public async Task<ActionStatus<ContactDTO>> BlockContact(long id)
        {
            try
            {
                ActionStatus<IContact> data = await _contactDataService.BlockContact(id);

                if (data)
                {
                    ContactDTO response = _contactMapper.ToObject(data.Result);

                    return new ActionStatus<ContactDTO>(true, response);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactDTO>(new ResponseVM("BPC-BlockContact"));
                }

                return new ActionStatus<ContactDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDTO>("BPC-BlockContact", ex);
            }
        }

        public async Task<ActionStatus<ContactDTO>> UnblockContact(long id)
        {
            try
            {
                ActionStatus<IContact> data = await _contactDataService.UnblockContact(id);

                if (data)
                {
                    ContactDTO response = _contactMapper.ToObject(data.Result);

                    return new ActionStatus<ContactDTO>(true,response);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactDTO>(new ResponseVM("BPC-UnblockContact"));
                }

                return new ActionStatus<ContactDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDTO>("BPC-UnblockContact", ex);
            }
        }

        public async Task<ActionStatus<ContactDTO>> DeleteContact(long id)
        {
            try
            {
                ActionStatus<IContact> data = await _contactDataService.DeleteContact(id);

                if (data)
                {
                    ContactDTO response = _contactMapper.ToObject(data.Result);

                    return new ActionStatus<ContactDTO>(true,response);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactDTO>(new ResponseVM("BPC-DeleteContact"));
                }

                return new ActionStatus<ContactDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDTO>("BPC-DeleteContact", ex);
            }
        }
    }
}
