using AutoMapper;
using Events.Data.Entities;
using Events.Services.Models;
using Modsen_test_task.ViewModels;

namespace Modsen_test_task
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressEntity, AddressModel>();
            CreateMap<AddressModel, AddressEntity>();
            CreateMap<AddressViewModel, AddressModel>();
            CreateMap<AddressModel, AddressViewModel>();
            CreateMap<EventEntity, EventModel>();
            CreateMap<EventModel, EventEntity>();
            CreateMap<EventViewModel, EventModel>();
            CreateMap<EventModel, EventViewModel>();
            CreateMap<OrganizerEntity, OrganizerModel>();
            CreateMap<OrganizerModel, OrganizerEntity>();
            CreateMap<OrganizerViewModel, OrganizerModel>();
            CreateMap<OrganizerModel, OrganizerViewModel>();
            CreateMap<PlanEntity, PlanModel>();
            CreateMap<PlanModel, PlanEntity>();
            CreateMap<PlanViewModel, PlanModel>();
            CreateMap<PlanModel, PlanViewModel>();
            CreateMap<SpeakerEntity, SpeakerModel>();
            CreateMap<SpeakerModel, SpeakerEntity>();
            CreateMap<SpeakerViewModel, SpeakerModel>();
            CreateMap<SpeakerModel, SpeakerViewModel>();
            CreateMap<SpeechEntity, SpeechModel>();
            CreateMap<SpeechModel, SpeechEntity>();
            CreateMap<SpeechViewModel, SpeechModel>();
            CreateMap<SpeechModel, SpeechViewModel>();
        }
    }
}