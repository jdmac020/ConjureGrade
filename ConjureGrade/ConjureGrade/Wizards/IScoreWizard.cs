using System.Collections.Generic;
using ConjureGrade.Spells;

namespace ConjureGrade.Wizards
{
    /// <summary>
    /// Used to determine ScoreResults from points earned and points possible
    /// </summary>
    public interface IScoreWizard
    {
        /// <summary>
        /// Calculate the results for a single score
        /// </summary>
        ScoreResult GetSingleScoreResult(double earnedPoints, double possiblePoints);

        /// <summary>
        /// Calculate the results for multiple scores
        /// </summary>
        List<ScoreResult> GetMultipleScoreResults(IEnumerable<ScoreResult> scoresToGrade);
    }
}