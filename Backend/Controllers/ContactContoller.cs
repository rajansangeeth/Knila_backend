using AutoMapper;
using Backend.Models;
using Backend.Models.DTO;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("contact")]
    public class ContactContoller : Controller
    {
        private IContactRepository _contactRepository;
        private IMapper _mapper;
        private IConfiguration _configuration;
       
        public ContactContoller(IContactRepository contactRepository, IMapper mapper, IConfiguration configuration)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var contacts = _contactRepository.GetAllContacts();
            var ContactsDtos = _mapper.Map<List<ContactDto>>(contacts);
            return Ok(ContactsDtos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetContactAsync([FromRoute] int id)
        {
            var contact = await _contactRepository.GetAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            var contactDto = _mapper.Map<ContactDto>(contact);
            return Ok(contactDto);
        }

        

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactDto contactDto)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            var result = await _contactRepository.CreateAsync(contact);
            if (result == null)
            {
                return NotFound("Email already exists");
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateContact([FromRoute]int id, [FromBody] UpdateContactDto contactDto)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            var result = _contactRepository.UpdateAsync(id, contact);
            if (result == null)
            {
                return NotFound("Contact details not found");
            }
            ContactDto contactResultDto = _mapper.Map<ContactDto>(result);
            return Ok(contactResultDto);

        }

    }
}
