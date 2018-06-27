using System.Collections.Generic;
using System.Linq;
using ConjureGrade.Spells;
using static  ConjureGrade.Apprentice.MathApprentice;

namespace ConjureGrade.Wizards
{
    /// <summary>
    /// Used to determine ScoreResults from points earned and points possible
    /// </summary>
    public class ScoreWizard : IScoreWizard
    {
        /// <summary>
        /// Calculate the results for a single score
        /// </summary>
        public ScoreResult GetSingleScoreResult(double earnedPoints, double possiblePoints)
        {
            var rawResult = CalculateRawPercentage(earnedPoints, possiblePoints);
            var friendResult = GetFriendlyPercent(rawResult);
            
            return new ScoreResult
            {
                PointsPossible = possiblePoints,
                GradeFriendly = friendResult,
                PointsEarned = earnedPoints,
                GradeRaw = rawResult
            };
        }

        /// <summary>
        /// Calculate the results for multiple scores
        /// </summary>
        public List<ScoreResult> GetMultipleScoreResults(IEnumerable<ScoreResult> scoresToGrade)
        {
            var positiveScores = scoresToGrade.Where(stg => stg.PointsEarned >= 0 && stg.PointsPossible >= 0);

            return positiveScores.Select(stg => 
                new ScoreResult
                    {
                        PointsEarned = stg.PointsEarned,
                        PointsPossible = stg.PointsPossible,
                        GradeRaw = CalculateRawPercentage(stg.PointsEarned, stg.PointsPossible),
                        GradeFriendly = GetFriendlyPercent(stg.PointsEarned, stg.PointsPossible)
                    })
                .ToList();
            
        }
    }
}
