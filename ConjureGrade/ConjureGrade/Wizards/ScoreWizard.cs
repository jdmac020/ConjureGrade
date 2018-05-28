using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Spells;

namespace ConjureGrade.Wizards
{
    public class ScoreWizard : IScoreWizard
    {
        public ScoreResult GetSingleScoreResult(double earnedPoints, double possiblePoints)
        {
            throw new NotImplementedException();
        }

        public List<ScoreResult> GetMultipleScoreResults(IEnumerable<ScoreResult> scoresToGrade)
        {
            throw new NotImplementedException();
        }
    }
}
