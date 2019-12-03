using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStoreSample
{
    public interface IEnvironmentService
    {
        string EnvironmentName { get; set; }
    }
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentService()
        {
            EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? "Production";
        }

        public string EnvironmentName { get; set; }
    }
}
