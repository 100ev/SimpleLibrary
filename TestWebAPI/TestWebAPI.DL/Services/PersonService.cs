using System.Net;
using AutoMapper;
using BookStore.BL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Repositories.MsSql;
using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace BookStore.BL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonService> _logger;
        public PersonService(IPersonRepository personRepository, IMapper mapper, ILogger<PersonService> logger)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public IEnumerable<AddAuthorResponse> GetAllUsers()
        {
            List<AddAuthorResponse> users = new List<AddAuthorResponse>();

            return users;
        }

        async Task<AddAuthorResponse> IPersonService.AddUsers(AddAuthorResponse user)
        {
            try
            {
                var person = _personRepository.GetById(user.Author.Id);
                if (person != null)
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };


                var personMapper = _mapper.Map<Person>(user);
                await _personRepository.AddUsers(personMapper);


                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                };
            }
            catch (Exception)
            {
                _logger.LogError("User can't be added");
            }

            return null;
        }

        async Task<AddAuthorResponse>? IPersonService.DeletUser(int userId)
        {
            try
            {
                var person = _personRepository.GetById(userId);
                if (userId <= 0)
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };


                var personMapper = _mapper.Map<Person>(userId);
                await _personRepository.AddUsers(personMapper);


                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                };
            }
            catch (Exception)
            {
                _logger.LogError("User can't be added");
            }

            return null;
        }

        async Task<AddAuthorResponse> IPersonService.GetById(int id)
        {
            try
            {               
                if (id <= 0)
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var mappedPerson = _mapper.Map<Person>(id);

                await _personRepository.GetById(id);

                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                };
            }
            catch (Exception)
            {
                _logger.LogError($"There is no person with the represented Id {id}");
            }
            return null;
        }

        async Task<AddAuthorResponse>? IPersonService.UpdateUser(AddAuthorRequest user)
        {
            try
            {
                if (user == null)
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var mapBook = _mapper.Map<Author>(user);
               await _personRepository.UpdateUser(user.Id);

                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception)
            {
                _logger.LogError("The person can't be updated");
            }
            return null;
        }
    }
}