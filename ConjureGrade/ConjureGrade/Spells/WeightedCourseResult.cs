using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConjureGrade.Spells
{
    public class WeightedCourseResult : ICourseResult
    {
        public List<EvaluationResult> Evaluations { get; set; }
        public double RawToDateGrade { get; set; }
        public double FriendlyToDateGrade { get; set; }
        public double RawOverallGrade { get; set; }
        public double FriendlyOverallGrade { get; set; }
    }
}
