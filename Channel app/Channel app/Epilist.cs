using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Channel_app
{
    public class Epilist
    {
        public string episodeLink { get; set; }
        public string episodeName { get; set; }
        public string episodeImage { get; set; }
    }

    public class episodesRootObject
    {
        public List<Epilist> epilist { get; set; }
    }
}
