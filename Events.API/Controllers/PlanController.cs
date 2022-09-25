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
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;
        private readonly IMapper _mapper;

        public PlanController(IPlanService planService, IMapper mapper)
        {
            _mapper = mapper;
            _planService = planService;
        }

        [HttpGet]
        [Route("getPlans")]
        
        public async Task<IEnumerable<PlanViewModel>> GetAllPlans()
        {
            var planModels = await _planService.GetAllPlans();
            var planViewModels = _mapper.Map<IEnumerable<PlanViewModel>>(planModels);
            return planViewModels;
        }

        [HttpGet]
        [Route("getPlan")]
        public async Task<PlanViewModel> GetPlan(Guid id)
        {
            var planModel = await _planService.GetPlan(id);
            var planViewModel = _mapper.Map<PlanModel, PlanViewModel>(planModel);
            return planViewModel;
        }

        [HttpPost]
        [Authorize]
        [Route("addPlan")]
        public async Task AddPlan(CreatePlanViewModel plan)
        {
            var planModel = _mapper.Map<CreatePlanViewModel, PlanModel>(plan);
            await _planService.AddPlan(planModel);
        }

        [HttpPut]
        [Authorize]
        [Route("editPlan")]
        public async Task EditPlan(EditPlanViewModel plan)
        {
            var planModel = _mapper.Map<EditPlanViewModel, PlanModel>(plan);
            await _planService.EditPlan(planModel);
        }

        [HttpDelete]
        [Authorize]
        [Route("deletePlan")]
        public async Task DeletePlan(Guid id)
        {
            await _planService.DeletePlan(id);
        }
    }
}