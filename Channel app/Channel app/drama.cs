using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Channel_app
{
    public class Drama
    {
        public string daramaImage { get; set; }
        public string dramaLink { get; set; }
    }

    public class DramaRootObject
    {
        public List<Drama> dramas { get; set; }
    }
}
