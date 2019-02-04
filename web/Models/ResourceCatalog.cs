using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetLearnerWeb.Models
{
    public class ResourceCatalog
    {
        public int Id { get; set; }
        public List<ItemList> ItemLists { get; set; }
    }
}
