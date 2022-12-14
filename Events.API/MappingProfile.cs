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
            CreateMap<CreateAddressViewModel, AddressModel>();
            CreateMap<CreateEventViewModel, EventModel>();
            CreateMap<CreateOrganizerViewModel, OrganizerModel>();
            CreateMap<CreatePlanViewModel, PlanModel>();
            CreateMap<CreateSpeakerViewModel, SpeakerModel>();
            CreateMap<CreateSpeechViewModel, SpeechModel>();
            CreateMap<LoginViewModel, OrganizerModel>();
            CreateMap<EditAddressViewModel, AddressModel>();
            CreateMap<AddressModel, EditAddressViewModel>();
            CreateMap<EditEventViewModel, EventModel>();
            CreateMap<EventModel, EditEventViewModel>();
            CreateMap<EditOrganizerRole, OrganizerModel>();
            CreateMap<OrganizerModel, EditOrganizerRole>();
            CreateMap<EditPlanViewModel, PlanModel>();
            CreateMap<PlanModel, EditPlanViewModel>();
            CreateMap<EditSpeakerViewModel, SpeakerModel>();
            CreateMap<SpeakerModel, EditSpeakerViewModel>();
            CreateMap<EditSpeechViewModel, SpeechModel>();
            CreateMap<SpeechModel, EditSpeechViewModel>();
            CreateMap<EditAddressEvent, AddressModel>();
            CreateMap<AddressModel, EditAddressEvent>();
        }
    }
}