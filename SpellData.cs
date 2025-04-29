using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamCambpellJon
{
    /// <summary>
    /// Convert gathered JSON objects to C# objects
    /// JSON Format is as follows
    /// JSON {
    ///     data
    ///         [0](record index for current search)
    ///             id
    ///             type
    ///             attributes
    ///                 slug
    ///                 category
    ///                 creator
    ///                 effect
    ///                 hand
    ///                 image
    ///                 incantation
    ///                 name
    ///                 wiki
    ///             links
    ///                 self
    ///     meta
    ///         copyright
    ///         generated_at
    ///         pagenation
    ///             current
    ///             next
    ///             last
    ///             records (total count)
    ///     links (URL pagenation)
    ///         self
    ///         current
    ///         next
    ///         last
    /// } 
    /// </summary>
    public class SpellJson

    {
        public Datum[] data { get; set; }
        public Meta meta { get; set; }
        public Links links { get; set; }
    }

    public class Meta
    {
        public Pagination pagination { get; set; }
        public string? copyright { get; set; }
        public DateTime generated_at { get; set; }
    }

    public class Pagination
    {
        public int? current { get; set; }
        public int? next { get; set; }
        public int? last { get; set; }
        public int? records { get; set; }
    }

    public class Links
    {
        public string? self { get; set; }
        public string? current { get; set; }
        public string? next { get; set; }
        public string? last { get; set; }
    }

    public class Datum
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public Attributes attributes { get; set; }
        public Links1 links { get; set; }
    }

    public class Attributes
    {
        public string? slug { get; set; }
        public string? category { get; set; }
        public string? creator { get; set; }
        public string? effect { get; set; }
        public string? hand { get; set; }
        public string? image { get; set; }
        public string? incantation { get; set; }
        public string? light { get; set; }
        public string? name { get; set; }
        public string? wiki { get; set; }
    }

    public class Links1
    {
        public string? self { get; set; }
    }

}
