using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Diploma
    {
        public int Id { get; set; }
        public int CreditsToGraduate { get; set; }
        public Requirement[] Requirements { get; set; }
    }
}
