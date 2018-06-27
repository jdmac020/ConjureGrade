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
using static ConjureGrade.Tests.Factories.ScoreResultFactory;

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

            result.GradeRaw.ShouldBe(1);
            result.GradeFriendly.ShouldBe(100);
        }

        [Fact]
        public void GetSingleScoreResult_ZeroDividedByZero_ResultsAre0And0()
        {
            var testClass = Create_ScoreWizard();
            var testScore = Create_ScoreResult_DoubleZero();

            var result = testClass.GetSingleScoreResult(testScore.PointsEarned, testScore.PointsPossible);

            result.GradeRaw.ShouldBe(0);
            result.GradeFriendly.ShouldBe(0);
        }

        [Fact]
        public void GetSingleScoreResult_ZeroEarnedPoints_ResultsAre0And0()
        {
            var testClass = Create_ScoreWizard();
            var testScore = Create_ScoreResult_ZeroPercent();

            var result = testClass.GetSingleScoreResult(testScore.PointsEarned, testScore.PointsPossible);

            result.GradeRaw.ShouldBe(0);
            result.GradeFriendly.ShouldBe(0);
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

            result.First().GradeRaw.ShouldBe(1);
            result.First().GradeFriendly.ShouldBe(100);
            result.Last().GradeRaw.ShouldBe(0);
            result.Last().GradeFriendly.ShouldBe(0);
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
