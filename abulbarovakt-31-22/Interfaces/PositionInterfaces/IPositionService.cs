
using abulbarovakt_31_22.Models;
using abulbarovakt_31_22.Database;
using abulbarovakt_31_22.Database;


namespace abulbarovakt_31_22.Interfaces.PositionInterfaces
{

    public interface IPositionService
    {
        public Position GetPositionById(int id);
    }

    public class PositionService : IPositionService
    {
        private readonly TeacherDbContext _dbContext;

        public PositionService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Position GetPositionById(int positionId)
        {
            return _dbContext.Positions.Where(d => d.PositionId == positionId).FirstOrDefault();
        }
    }
}