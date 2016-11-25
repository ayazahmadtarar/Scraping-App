using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Channel_app
{

    public class Channel
    {
        public string channelName { get; set; }
        public string channelImage { get; set; }
        public string channellink { get; set; }
    }

    public class RootObject
    {
        public List<Channel> channels { get; set; }
    }
}
