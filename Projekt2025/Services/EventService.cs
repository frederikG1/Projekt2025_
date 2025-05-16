using Projekt2025.Interfaces;
using Projekt2025.Models;

namespace Projekt2025.Services
{
    public class EventService : IEvent
    {
        private readonly fgonline_dk_db_zooContext _dbContext;

        public EventService(fgonline_dk_db_zooContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IEnumerable<Event> GetEvents()
        {
            try
            {
                return _dbContext.Events.ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error", ex);
            }
        }
    }
}
