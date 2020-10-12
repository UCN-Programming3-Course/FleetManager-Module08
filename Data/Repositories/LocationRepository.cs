using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LocationRepository : IRepository<Location>
    {
        public Location Create(Location obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Location obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAll()
        {
            return new List<Location> {
            new Location{Id=1, Name="Aalborg"},
            new Location{Id=2, Name="Randers"}
            };
        }

        public Location GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Location Update(Location obj)
        {
            throw new NotImplementedException();
        }
    }
}
