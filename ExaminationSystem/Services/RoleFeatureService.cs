using ExaminationSystem.Data;
using ExaminationSystem.Models.Enums;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels.Response;

namespace ExaminationSystem.Services
{
    public class RoleFeatureService
    {
        public RoleFeatureRepository _roleFeatureRepository;
        public Context _context;
        public RoleFeatureService()
        {
            _roleFeatureRepository = new RoleFeatureRepository();
            _context = new Context();
        }
        public async Task<ResponseViewModel<bool>> AssignFeatureToRole(Role role, Feature feature)
        {

            // Check if the role-feature assignment already exists
            if (_roleFeatureRepository.IsExists(role,feature))
            {
                return new FailResponseViewModel<bool>("Feature is AlreadyExist",ErrorCode.RoleAlreadyHasFeature); // Assignment already exists, no need to add
            }
            await _roleFeatureRepository.AddAsync(role,feature);
            return new SuccessResponseViewModel<bool>(true);
            
        }
        public async Task<ResponseViewModel<bool>> RemoveFeatureFromRole(Role role, Feature feature)
        {
            if (_roleFeatureRepository.IsExists(role, feature))
            {
                return new FailResponseViewModel<bool>("Feature is AlreadyExist", ErrorCode.RoleAlreadyHasFeature); // Assignment already exists, no need to add
            }         
            await _roleFeatureRepository.SoftDeleteAsync(role,feature);
            return new SuccessResponseViewModel<bool>(true);
        }

    }
}
