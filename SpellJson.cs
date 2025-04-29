using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamCambpellJon
{

    public class SpellJson
    {
        public Datum[] data { get; set; }
        public Meta meta { get; set; }
        public Links links { get; set; }
    }

    public class Meta
    {
        public Pagination pagination { get; set; }
        public string copyright { get; set; }
        public DateTime generated_at { get; set; }
    }

    public class Pagination
    {
        public int current { get; set; }
        public int next { get; set; }
        public int last { get; set; }
        public int records { get; set; }
    }

    public class Links
    {
        public string self { get; set; }
        public string current { get; set; }
        public string next { get; set; }
        public string last { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributes attributes { get; set; }
        public Links1 links { get; set; }
    }

    public class Attributes
    {
        public string slug { get; set; }
        public string category { get; set; }
        public object creator { get; set; }
        public string effect { get; set; }
        public string hand { get; set; }
        public object image { get; set; }
        public object incantation { get; set; }
        public string light { get; set; }
        public string name { get; set; }
        public string wiki { get; set; }
    }

    public class Links1
    {
        public string self { get; set; }
    }

}
