using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories
{
    public partial interface ISoundRepository : IRepository<Sound> { }
    public partial class SoundRepository : GenericRepository<Sound>
    {
        public SoundRepository(IObjectContext objectContext) : base(objectContext) { }
    }
}
