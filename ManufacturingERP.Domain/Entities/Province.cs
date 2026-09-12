using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP.Domain.Entities
{
    public class Province
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string NameInNepali { get; set; }


        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<LocalGovernment> LocalGovernments { get; set; }
       
    }
}
