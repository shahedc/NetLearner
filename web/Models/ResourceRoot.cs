using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetLearnerWeb.Models
{
    public class ResourceRoot: InternetResource
    {
        public RssFeed RssFeed { get; set; }
        public List<LearningResource> LearningResources { get; set; }
    }
}
