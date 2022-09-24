using System;
using System.Threading.Tasks;
using AutoMapper;
using Events.Services.Models;
using Events.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Modsen_test_task.Jwt;
using Modsen_test_task.ViewModels;

namespace Modsen_test_task.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IJwtGenerator _jwtGenerator;

        public AccountController(IAccountService accountService, IMapper mapper, IJwtGenerator jwtGenerator)
        {
            _mapper = mapper;
            _accountService = accountService;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost]
        [Route("Register")]
        public async Task Register(CreateOrganizerViewModel organizer)
        {
            //organizer.Role = Role.User;
            OrganizerModel organizerModel = _mapper.Map<CreateOrganizerViewModel, OrganizerModel>(organizer);
            await _accountService.CreateAccount(organizerModel);
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel loginModel)
        {
            OrganizerModel organizerModel = _mapper.Map<LoginViewModel, OrganizerModel>(loginModel);

            try
            {
                organizerModel = _accountService.Authorize(organizerModel);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            OrganizerViewModel organizerViewModel = _mapper.Map<OrganizerModel, OrganizerViewModel>(organizerModel);

            if (organizerViewModel != null)
            {
                var token = _jwtGenerator.GenerateJwtToken(organizerViewModel);

                return Ok(new
                {
                    access_token = token,
                    role = organizerViewModel.Role,
                    id = organizerViewModel.Id,
                    user_name = organizerViewModel.Name,
                    
                });
            }

            return BadRequest();
        }
    }
}