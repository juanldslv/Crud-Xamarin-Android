using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace CRUD2
{
    
        public interface IConfig
        {
            string DirecotrioDB { get; }
            ISQLitePlatform Plataforma { get; }
        }
    
}
