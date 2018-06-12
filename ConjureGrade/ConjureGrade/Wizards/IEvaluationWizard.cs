using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Spells;

namespace ConjureGrade.Wizards
{
    public interface IEvaluationWizard
    {
        EvaluationResult UpdateOverAllGrade(EvaluationResult evaluation);
        EvaluationResult UpdateToDateResults(EvaluationResult evaluation);
        EvaluationResult UpdateAllResults(EvaluationResult evaluation);
    }
}
