using System.Collections.Generic;
using ConjureGrade.Spells;

namespace ConjureGrade.Wizards
{
    public interface IScoreWizard
    {
        ScoreResult GetSingleScoreResult(double earnedPoints, double possiblePoints);

        List<ScoreResult> GetMultipleScoreResults(IEnumerable<ScoreResult> scoresToGrade);
    }
}