using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Events.Services.Models;

namespace Events.Services.ServiceInterfaces
{
    public interface IPlanService
    {
        public Task DeletePlan(Guid id);
        
        public Task AddPlan(PlanModel plan);

        public Task<PlanModel> GetPlan(Guid id);

        public Task<IEnumerable<PlanModel>> GetAllPlans();

        public Task EditPlan(PlanModel plan);
    }
}