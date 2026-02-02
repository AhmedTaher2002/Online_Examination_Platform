using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.Repositories
{
    public class RoleFeatureRepository
    {
        private readonly Context _context;

        public RoleFeatureRepository()
        {
            _context = new Context();
        }

        public async Task AddAsync(Role role, Feature feature)
        {
            if (IsExists(role, feature))
                return;
            var roleFeature = new RoleFeature
            {
                Role = role,
                Feature = feature
            };
            _context.RoleFeature.Add(roleFeature);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(Role role, Feature feature)
        {
            if (!IsExists(role, feature))
                return;
            var roleFeature = _context.RoleFeature.FirstOrDefault(rf => rf.Role == role && rf.Feature == feature);
            if (roleFeature != null)
            {
                _context.RoleFeature.Remove(roleFeature);
                await _context.SaveChangesAsync();
            }
        }

        public bool IsExists(Role role, Feature feature)
        {
            var isExists = _context.RoleFeature.Any(rf => rf.Role == role && rf.Feature == feature && !rf.IsDeleted);
            return isExists;
        }

    }
}
