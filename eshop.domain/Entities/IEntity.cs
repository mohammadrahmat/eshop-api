using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.domain.Entities
{
    public interface IEntity<out TKey>
    {
        public TKey Id { get; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
