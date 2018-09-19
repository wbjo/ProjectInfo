using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInfo.Api.Features.Projects.Entities
{
    public class Project
    {
        public string Name { get; set; }
        public string Frontend { get; set; }
        public string Backend { get; set; }
        public string Hosting { get; set; }
        //public string[] ThirdParties { get; set; }
    }
}
