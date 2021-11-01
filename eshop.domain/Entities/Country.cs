using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.domain.Entities
{
    public class Country : BaseEntity<int>
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}