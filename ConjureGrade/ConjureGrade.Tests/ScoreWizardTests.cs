using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Exceptions;
using ConjureGrade.Wizards;
using Xunit;
using Shouldly;
using static ConjureGrade.Tests.Factories.WizardFactory;
using static ConjureGrade.Tests.Factories.GradeResultFactory;

namespace ConjureGrade.Tests
{
    public class ScoreWizardTests
    {
        [Fact]
        public void GetSingleScoreResult_EarnedPointsEqualsPointsPossible_ResultsAre1And100()
        {
            var testClass = Create_ScoreWizard();
            var testScore = Create_ScoreResult_OneHundredPercent();

            var result = testClass.GetSingleScoreResult(testScore.PointsEarned, testScore.PointsPossible);

            result.RawGradeResult.ShouldBe(1);
            result.FriendlyGradeResult.ShouldBe(100);
        }

        [Fact]
        public void GetSingleScoreResult_ZeroEarnedPoints_ResultsAre0And0()
        {
            var testClass = Create_ScoreWizard();
            var testScore = Create_ScoreResult_ZeroPercent();

            var result = testClass.GetSingleScoreResult(testScore.PointsEarned, testScore.PointsPossible);

            result.RawGradeResult.ShouldBe(0);
            result.FriendlyGradeResult.ShouldBe(0);
        }

        [Fact]
        public void GetSingleScoreResult_NegativeEarnedPoints_ThrowsException()
        {
            var testClass = Create_ScoreWizard();
            var testScore = Create_ScoreResult_Invalid();

            Should.Throw<BadSpellException>( ()=> testClass.GetSingleScoreResult(testScore.PointsEarned, testScore.PointsPossible));
            
        }

        [Fact]
        public void GetMultipleScoreResults_MixedList_FirstResult100LastResult0()
        {
            var testClass = Create_ScoreWizard();
            var testScores = Create_ScoreResultList_MixedResults();

            var result = testClass.GetMultipleScoreResults(testScores);

            result.First().RawGradeResult.ShouldBe(1);
            result.First().FriendlyGradeResult.ShouldBe(100);
            result.Last().RawGradeResult.ShouldBe(0);
            result.Last().FriendlyGradeResult.ShouldBe(0);
        }

        [Fact]
        public void GetMultipleScoreResults_ListWithInvalidScore_Returns5Scores()
        {
            var testClass = Create_ScoreWizard();
            var testScores = Create_ScoreResultList_OneInvalid();

            var result = testClass.GetMultipleScoreResults(testScores);

            result.Count.ShouldBe(5);
            result.Any(r => r.PointsEarned < 0).ShouldBe(false);
        }
    }
}
