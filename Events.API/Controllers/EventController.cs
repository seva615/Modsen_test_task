using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Events.Services.Models;
using Events.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modsen_test_task.ViewModels;

namespace Modsen_test_task.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        [HttpGet]
        [Route("getEvents")]
        public async Task<IEnumerable<EventViewModel>> GetAllEvents()
        {
            var eventModels = await _eventService.GetAllEvents();
            var eventViewModels = _mapper.Map<IEnumerable<EventViewModel>>(eventModels);
            return eventViewModels;
        }

        [HttpGet]
        [Route("getEvent")]
        public async Task<EventViewModel> GetEvent(Guid id)
        {
            EventModel eventModel;
            try
            {
                 eventModel = await _eventService.GetEvent(id);
            }
            catch (Exception e)
            {
                throw new Exception("Event not found");
            }
            var eventViewModel = _mapper.Map<EventModel, EventViewModel>(eventModel);
            return eventViewModel;
        }

        [HttpPost]
        [Authorize]
        [Route("addEvent")]
        public async Task AddEvent(CreateEventViewModel eventViewModel)
        {
            var eventModel = _mapper.Map<CreateEventViewModel, EventModel>(eventViewModel);
            await _eventService.AddEvent(eventModel);
        }

        [HttpPut]
        [Authorize]
        [Route("editEvent")]
        public async Task EditEvent(EditEventViewModel eventViewModel)
        {
            var eventModel = _mapper.Map<EditEventViewModel, EventModel>(eventViewModel);
            await _eventService.EditEvent(eventModel);
        }

        [HttpDelete]
        [Authorize]
        [Route("deleteEvent")]
        public async Task DeleteEvent(Guid id)
        {try
            {
                await _eventService.DeleteEvent(id);
            }
            catch (Exception e)
            {
                throw new Exception("Event not found");
            }
        }
    }
}