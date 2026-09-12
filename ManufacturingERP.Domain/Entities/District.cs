using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP.Domain.Entities
{
    public class District
    {
        public Guid Id { get; set; }
        public Guid ProvinceId { get; set; }

        public required string Name { get; set; }
        public required string NameInNepali { get; set; }
        public virtual Province Province { get; set; } = null!;
        public virtual ICollection<LocalGovernment> LocalGovernments { get; set; } = new List<LocalGovernment>();

    }
}
