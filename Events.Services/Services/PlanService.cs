using System;
using System.Collections.Generic;
using System.Text;
using Events.Data;
using AutoMapper;
using System.Threading.Tasks;
using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Events.Services;
using Events.Services.Models;
using Events.Services.ServiceInterfaces;

namespace Events.Services.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public PlanService(IPlanRepository planRepository, IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _planRepository = planRepository;
            _mapper = mapper;
        }

        public async Task DeletePlan(Guid id)
        {
            await _planRepository.Delete(id);
        }

        public async Task AddPlan(PlanModel plan)
        {
            if ( await _eventRepository.GetById(plan.EventId) != null)
            {
                var planEntity = _mapper.Map<PlanModel, PlanEntity>(plan);
                await _planRepository.Add(planEntity);
            }
            else
            {
                throw new NotFoundException("No Event found with entered id");
            }
        }

        public async Task<PlanModel> GetPlan(Guid id)
        {
            var planEntity = await _planRepository.GetById(id);
            var planModel = _mapper.Map<PlanEntity, PlanModel>(planEntity);
            return planModel;
        }

        public async Task EditPlan(PlanModel plan)
        {
            var planEntity = _mapper.Map<PlanModel, PlanEntity>(plan);
            await _planRepository.Edit(planEntity);
        }

        public async Task<IEnumerable<PlanModel>> GetAllPlans()
        {
            var planEntities = await _planRepository.GetAll();
            var planModels = _mapper.Map<IEnumerable<PlanModel>>(planEntities);
            return planModels;
        }
    }
}