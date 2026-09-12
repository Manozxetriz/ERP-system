using ManufacturingERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP.Domain.Entities
{
    public class LocalGovernment
    {
         public Guid Id { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid DistrictId { get; set; }
        public LocalGovernmentType Type { get; set; }
        public string? Name { get; set; }

        public string? NameInNepali { get; set; }
        public int WardCount { get; set; }
        public Province Province { get; set; } = null!;

        public District District { get; set; } = null!;
    }
}
