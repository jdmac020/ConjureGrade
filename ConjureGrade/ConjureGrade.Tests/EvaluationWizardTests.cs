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
using static ConjureGrade.Tests.Factories.EvaluationResultFactory;

namespace ConjureGrade.Tests
{
    public class EvaluationWizardTests
    {
        [Fact]
        public void UpdateOverallGrade_300Possible300EarnedNoDropAllIn_ResultIs100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_ThreeTests_NoDrop_100();

            testClass.UpdateOverAllGrade();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(1);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(100);
        }

        [Fact]
        public void UpdateOverallGrade_300Possible280EarnedNoDropAllIn_ResultIs93()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_ThreeTests_NoDrop_93();

            testClass.UpdateOverAllGrade();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.93);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(93);
        }

        [Fact]
        public void UpdateOverallGrade_300Possible200EarnedNoDropAllIn_ResultIs67()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_ThreeTests_NoDrop_67();

            testClass.UpdateOverAllGrade();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.67);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(67);
        }

        [Fact]
        public void UpdateToDateGrade_300Possible300EarnedNoDropAllIn_ResultIs100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_ThreeTests_NoDrop_100();

            testClass.UpdateToDateGrade();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(1);
            testClass.Evaluation.GradeToDateFriendly.ShouldBe(100);
        }

        [Fact]
        public void UpdateToDateGrade_400Possible200EarnedNoDrop2OutOf4_Results100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_TwoOutOfFour_NoDrop_50and100();

            testClass.UpdateToDateGrade();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(1);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(100);
        }

        [Fact]
        public void UpdateOverallGrade_400Possible200EarnedNoDrop2OutOf4_Results50()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_TwoOutOfFour_NoDrop_50and100();

            testClass.UpdateOverAllGrade();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.5);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(50);
        }

        [Fact]
        public void UpdateToDateGrade_400Possible180EarnedNoDrop2OutOf4_Results90()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_TwoOutOfFour_NoDrop_45and90();

            testClass.UpdateToDateGrade();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(.9);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(90);
        }

        [Fact]
        public void UpdateOverallGrade_400Possible180EarnedNoDrop2OutOf4_Results45()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_TwoOutOfFour_NoDrop_45and90();

            testClass.UpdateOverAllGrade();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.45);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(45);
        }

        // TO DO: Copy out the rest of the variations for the test below

        [Fact]
        public void UpdateOverallGrade_200Possible180EarnedDropOne_Results100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_3OutOf4_DropLowest_100();

            testClass.UpdateOverAllGrade();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(1);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(100);
        }
    }
}
