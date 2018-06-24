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
        EvaluationResult Evaluation { get; set; }

        void UpdateOverAllGrade();
        void UpdateToDateGrade();
        void UpdateAllGrades();
    }
}
