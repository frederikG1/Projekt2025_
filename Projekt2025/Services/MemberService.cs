using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Projekt2025.Interfaces;
using Projekt2025.Models;

namespace Projekt2025.Services
{
    public class MemberService : IMember
    {

        //injecter databasecontext i constructoren 
        fgonline_dk_db_zooContext _dbContext;
        public MemberService(fgonline_dk_db_zooContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Denne metode skal returnere en liste af medlemmer
        public IEnumerable<Member> GetMembers()
        {
            try
            {
                return _dbContext.Members;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error", ex);
            }
        }
        
    }
}
