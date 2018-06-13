using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Spells;
using static ConjureGrade.Tests.Factories.ScoreResultFactory;

namespace ConjureGrade.Tests.Factories
{
    public static class EvaluationResultFactory
    {
        // 3 test scores, no drop, three fill
        public static EvaluationResult Create_ThreeTests_NoDrop_100()
        {
            var scoreList = new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_OneHundredPercent()
            };

            return new EvaluationResult
            {
                PointValuePerScore = 100,
                TotalScoreCount = 3,
                Scores = scoreList,

            };
        }

        public static EvaluationResult Create_FourTests_DropOne_100()
        {
            var scoreList = new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_OneHundredPercent(),
                new ScoreResult {PointsPossible = 100, PointsEarned = 90}
            };

            return new EvaluationResult
            {
                DropLowest = true,
                DropLowestCount = 1,
                PointValuePerScore = 100,
                TotalScoreCount = 4,
                Scores = scoreList,

            };
        }

        public static EvaluationResult Create_ThreeTests_NoDrop_Unfinished()
        {
            var scoreList = new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_OneHundredPercent(),
            };

            return new EvaluationResult
            {
                PointValuePerScore = 100,
                TotalScoreCount = 4,
                Scores = scoreList,

            };
        }
    }
}
