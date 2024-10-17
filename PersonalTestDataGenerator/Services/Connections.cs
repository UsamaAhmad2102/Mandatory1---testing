using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTestDataGenerator.Services
{
     public abstract class Connections
    {
        protected string ConnectionString;
        public IConfiguration Configuration { get; }

        public Connections(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration["ConnectionStrings:DefaultConnection"];
        }
    }
}
