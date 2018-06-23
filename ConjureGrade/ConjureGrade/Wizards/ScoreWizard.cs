using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Exceptions;
using ConjureGrade.Spells;
using static  ConjureGrade.Apprentice.MathApprentice;

namespace ConjureGrade.Wizards
{
    public class ScoreWizard : IScoreWizard
    {
        public ScoreResult GetSingleScoreResult(double earnedPoints, double possiblePoints)
        {
            var rawResult = CalculateRawPercentage(earnedPoints, possiblePoints);
            var friendResult = GetFriendlyPercent(rawResult);
            
            return new ScoreResult
            {
                PointsPossible = possiblePoints,
                FriendlyGradeResult = friendResult,
                PointsEarned = earnedPoints,
                RawGradeResult = rawResult
            };
        }

        public List<ScoreResult> GetMultipleScoreResults(IEnumerable<ScoreResult> scoresToGrade)
        {
            var positiveScores = scoresToGrade.Where(stg => stg.PointsEarned >= 0 && stg.PointsPossible >= 0);

            return positiveScores.Select(stg => 
                new ScoreResult
                    {
                        PointsEarned = stg.PointsEarned,
                        PointsPossible = stg.PointsPossible,
                        RawGradeResult = CalculateRawPercentage(stg.PointsEarned, stg.PointsPossible),
                        FriendlyGradeResult = GetFriendlyPercent(stg.PointsEarned, stg.PointsPossible)
                    })
                .ToList();
            
        }
    }
}
