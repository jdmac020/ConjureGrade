using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Spells;

namespace ConjureGrade.Wizards
{
    public class EvaluationWizard : IEvaluationWizard
    {
        public EvaluationResult Evaluation { get; set; }

        public void UpdateOverAllGrade()
        {
            throw new NotImplementedException();
        }

        public void UpdateToDateGrade()
        {
            throw new NotImplementedException();
        }

        public void UpdateAllGrades()
        {
            throw new NotImplementedException();
        }
    }
}
