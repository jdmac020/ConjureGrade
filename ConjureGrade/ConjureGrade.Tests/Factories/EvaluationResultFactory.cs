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

        public static EvaluationResult Create_ThreeTests_NoDrop_93()
        {
            var scoreList = new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_EightyPercent(),
                Create_ScoreResult_OneHundredPercent()
            };

            return new EvaluationResult
            {
                PointValuePerScore = 100,
                TotalScoreCount = 3,
                Scores = scoreList
            };
        }

        public static EvaluationResult Create_ThreeTests_NoDrop_67()
        {
            var scoreList = new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_ZeroPercent()
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

        /// <summary>
        /// Overall = 50%, To-Date = 100
        /// </summary>
        /// <returns></returns>
        public static EvaluationResult Create_TwoOutOfFour_NoDrop_50and100()
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

        /// <summary>
        /// Overall = 45%, To-Date = 90
        /// </summary>
        /// <returns></returns>
        public static EvaluationResult Create_TwoOutOfFour_NoDrop_45and90()
        {
            var scoreList = new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_EightyPercent(),
            };

            return new EvaluationResult
            {
                PointValuePerScore = 100,
                TotalScoreCount = 4,
                Scores = scoreList,

            };
        }

        public static EvaluationResult Create_4Tests_DropLowest_100()
        {
            var scoreList = new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_EightyPercent(),
                Create_ScoreResult_OneHundredPercent(),
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

        public static EvaluationResult Create_3OutOf4_DropLowest_100and50()
        {
            var scoreList = new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_EightyPercent()
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

        public static EvaluationResult Create_3OutOf4_DropLowest_90and45()
        {
            var scoreList = new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_ZeroPercent(),
                Create_ScoreResult_EightyPercent()
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

        public static EvaluationResult Create_4Tests_DropLowest_90()
        {
            var scoreList = new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_EightyPercent(),
                Create_ScoreResult_ZeroPercent(),
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

        public static EvaluationResult Create_4Tests_DropLowestTwo_100()
        {
            var scoreList = new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_EightyPercent(),
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_ZeroPercent(),
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
    }
}
