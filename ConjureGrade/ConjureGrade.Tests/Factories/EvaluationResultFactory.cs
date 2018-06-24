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

        /// <summary>
        /// 150/300 points
        /// </summary>
        /// <returns></returns>
        public static List<EvaluationResult> CreateList_FailingCourse_NonWeight()
        {
            return new List<EvaluationResult>
            {
                CreateSimple_NonWeighted(50),
                CreateSimple_NonWeighted(50),
                CreateSimple_NonWeighted(50)
            };
        }

        /// <summary>
        /// 240/300 points
        /// </summary>
        /// <returns></returns>
        public static List<EvaluationResult> CreateList_BCourse_NonWeight()
        {
            return new List<EvaluationResult>
            {
                CreateSimple_NonWeighted(80),
                CreateSimple_NonWeighted(80),
                CreateSimple_NonWeighted(80)
            };
        }

        /// <summary>
        /// 32/19/23/.1
        /// </summary>
        /// <returns></returns>
        public static List<EvaluationResult> CreateList_WeightedCourse()
        {
            return new List<EvaluationResult>
            {
                CreateSimple_Weighted(40,80),
                CreateSimple_Weighted(25,75),
                CreateSimple_Weighted(25,90),
                CreateSimple_Weighted(10,100)
            };
        }

        public static EvaluationResult CreateSimple_NonWeighted(double percentAmount)
        {
            return new EvaluationResult
            {
                PointsEarned = percentAmount,
                PointsPossibleToDate = 100,
                PointsPossibleOverall = 100,
                Weighted = false
            };
        }
        

        public static EvaluationResult CreateSimple_Weighted(double percentGrade, double weightAmount)
        {
            return new EvaluationResult
            {
                PointsEarned = percentGrade,
                PointsPossibleToDate = 100,
                PointsPossibleOverall = 100,
                Weighted = true,
                WeightAmount = weightAmount
            };
        }

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
                PointValuePerScore = 10,
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
                PointValuePerScore = 10,
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
                PointValuePerScore = 10,
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
                PointValuePerScore = 10,
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
                PointValuePerScore = 10,
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
                PointValuePerScore = 10,
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
                PointValuePerScore = 10,
                TotalScoreCount = 4,
                Scores = scoreList,

            };
        }

        public static EvaluationResult Create_3OutOf4_DropLowest_100and67()
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
                PointValuePerScore = 10,
                TotalScoreCount = 4,
                Scores = scoreList,

            };
        }

        public static EvaluationResult Create_3OutOf4_DropLowest_90and60()
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
                PointValuePerScore = 10,
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
                PointValuePerScore = 10,
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
                DropLowestCount = 2,
                PointValuePerScore = 10,
                TotalScoreCount = 4,
                Scores = scoreList,

            };
        }
    }
}
