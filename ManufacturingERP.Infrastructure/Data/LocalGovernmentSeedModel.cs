using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP.Infrastructure.Data
{
    public class LocalGovernmentSeedModel
    {
        public string? province { get; set; }

        public string? district { get; set; }

        public string? type { get; set; }

        public int wardCount { get; set; }

        public string? name { get; set; }

        public string? nameNp { get; set; }
    }
}
