using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Projekt2025.Interfaces;
using Projekt2025.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Projekt2025.Services
{
    public class AdminService : IAdmin
    {
        //injecter databasecontext i constructoren
        fgonline_dk_db_zooContext _dbContext;
        public AdminService(fgonline_dk_db_zooContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Event> GetEvents()
        {
            try
            {
                return _dbContext.Events;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error", ex);
            }
        }
    }
}
