using System.Collections.Generic;
using ConjureGrade.Spells;

namespace ConjureGrade.Tests.Factories
{
    public static class ScoreResultFactory
    {
        
        
        public static List<ScoreResult> Create_ScoreResultList_MixedResults()
        {
            return new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_EightyPercent(),
                Create_ScoreResult_ZeroPercent(),
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_EightyPercent(),
                Create_ScoreResult_ZeroPercent()
            };
        }

        public static List<ScoreResult> Create_ScoreResultList_OneInvalid()
        {
            return new List<ScoreResult>
            {
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_EightyPercent(),
                Create_ScoreResult_Invalid(),
                Create_ScoreResult_OneHundredPercent(),
                Create_ScoreResult_EightyPercent(),
                Create_ScoreResult_ZeroPercent()
            };
        }

        public static ScoreResult Create_ScoreResult_OneHundredPercent()
        {
            return new ScoreResult {PointsEarned = 10, PointsPossible = 10};
        }

        public static ScoreResult Create_ScoreResult_EightyPercent()
        {
            return new ScoreResult { PointsEarned = 8, PointsPossible = 10 };
        }

        public static ScoreResult Create_ScoreResult_ZeroPercent()
        {
            return new ScoreResult { PointsEarned = 0, PointsPossible = 10 };
        }

        public static ScoreResult Create_ScoreResult_Invalid()
        {
            return new ScoreResult { PointsEarned = -5, PointsPossible = 10 };
        }

        public static ScoreResult Create_ScoreResult_DoubleZero()
        {
            return new ScoreResult { PointsEarned = 0, PointsPossible = 0 };
        }
    }
}