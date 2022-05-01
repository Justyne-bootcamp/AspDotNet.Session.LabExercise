using Session.Data.Data;
using Session.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session.Data.Repositories
{
    public interface IToyRepository : IBaseRepository<Toy>
    {
    }

    public class ToyRepository : GenericRepository<Toy>, IToyRepository
    {
        public ToyRepository(ToyUniverseContext context) : base(context)
        {
        }
    }
}
