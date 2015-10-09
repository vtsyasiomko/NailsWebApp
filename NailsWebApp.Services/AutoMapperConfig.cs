using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsApp.Services
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            // see: https://github.com/AutoMapper/AutoMapper/wiki/Mapping-inheritance#inheritance-mapping-priorities
            MapProgrammList();
        }

        private static void MapProgrammList()
        {
            
        }
    }
}
