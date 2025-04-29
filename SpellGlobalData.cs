using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamCambpellJon
{
    /// <summary>
    /// C# class object to hold data for current spell record 
    /// and API links for the next and previous spell records
    /// </summary>
    class SpellGlobalData
    {
        public static string Name { get; set; }
        public static string Image { get; set; }
        public static string Creator { get; set; }
        public static string Effect { get; set; }
        public static string Hand { get; set; }
        public static string Incantation { get; set; }
        public static string Light { get; set; }

        // Store link URLs for the previous and next spell
        public static string Last { get; set; }
        public static string Next { get; set; }

    }
}
