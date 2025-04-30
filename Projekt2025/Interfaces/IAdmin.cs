using System.Collections.Generic;
using Projekt2025.Models;

namespace Projekt2025.Interfaces
{
    public interface IAdmin
    {
        public IEnumerable<Event> GetEvents();
    }
}
