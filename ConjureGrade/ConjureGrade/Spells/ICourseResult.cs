using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConjureGrade.Spells
{
    public interface ICourseResult
    {
        List<EvaluationResult> Evaluations { get; set; }
        double RawToDateGrade { get; set; }
        double FriendlyToDateGrade { get; set; }
        double RawOverallGrade { get; set; }
        double FriendlyOverallGrade { get; set; }
    }
}
