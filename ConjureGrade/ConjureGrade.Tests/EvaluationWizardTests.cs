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

            testClass.UpdateGradeOverAll();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(1);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(100);
        }

        [Fact]
        public void UpdateOverallGrade_300Possible280EarnedNoDropAllIn_ResultIs93()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_ThreeTests_NoDrop_93();

            testClass.UpdateGradeOverAll();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.93);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(93);
        }

        [Fact]
        public void UpdateOverallGrade_300Possible200EarnedNoDropAllIn_ResultIs67()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_ThreeTests_NoDrop_67();

            testClass.UpdateGradeOverAll();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.67);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(67);
        }

        [Fact]
        public void UpdateToDateGrade_300Possible300EarnedNoDropAllIn_ResultIs100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_ThreeTests_NoDrop_100();

            testClass.UpdateGradeToDate();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(1);
            testClass.Evaluation.GradeToDateFriendly.ShouldBe(100);
        }

        [Fact]
        public void UpdateToDateGrade_400Possible200EarnedNoDrop2OutOf4_Results100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_TwoOutOfFour_NoDrop_50and100();

            testClass.UpdateGradeToDate();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(1);
            testClass.Evaluation.GradeToDateFriendly.ShouldBe(100);
        }

        [Fact]
        public void UpdateOverallGrade_400Possible200EarnedNoDrop2OutOf4_Results50()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_TwoOutOfFour_NoDrop_50and100();

            testClass.UpdateGradeOverAll();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.5);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(50);
        }

        [Fact]
        public void UpdateToDateGrade_400Possible180EarnedNoDrop2OutOf4_Results90()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_TwoOutOfFour_NoDrop_45and90();

            testClass.UpdateGradeToDate();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(.9);
            testClass.Evaluation.GradeToDateFriendly.ShouldBe(90);
        }

        [Fact]
        public void UpdateOverallGrade_400Possible180EarnedNoDrop2OutOf4_Results45()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_TwoOutOfFour_NoDrop_45and90();

            testClass.UpdateGradeOverAll();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.45);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(45);
        }

        [Fact]
        public void UpdateOverallGrade_300Possible280EarnedDropOne_Results67()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_3OutOf4_DropLowest_100and67();

            testClass.UpdateGradeOverAll();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.67);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(67);
        }

        [Fact]
        public void UpdateGradeToDate_300Possible280EarnedDropOne_Results100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_3OutOf4_DropLowest_100and67();

            testClass.UpdateGradeToDate();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(1);
            testClass.Evaluation.GradeToDateFriendly.ShouldBe(100);
        }

        [Fact]
        public void UpdateOverAllGrade_400Possible380EarnedDropOne_Results100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_4Tests_DropLowest_100();

            testClass.UpdateGradeOverAll();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(1);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(100);
        }

        [Fact]
        public void UpdateToDateGrade_400Possible380EarnedDropOne_Results100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_4Tests_DropLowest_100();

            testClass.UpdateGradeToDate();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(1);
            testClass.Evaluation.GradeToDateFriendly.ShouldBe(100);
        }

        [Fact]
        public void UpdateOverAllGrade_3OutOf4DropOne_Results60()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_3OutOf4_DropLowest_90and60();

            testClass.UpdateGradeOverAll();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.6);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(60);
        }

        [Fact]
        public void UpdateToDateGrade_3OutOf4DropOne_Results90()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_3OutOf4_DropLowest_90and60();

            testClass.UpdateGradeToDate();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(.9);
            testClass.Evaluation.GradeToDateFriendly.ShouldBe(90);
        }

        [Fact]
        public void UpdateOverAllGrade_3OutOf4DropOne_Results67()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_3OutOf4_DropLowest_100and67();

            testClass.UpdateGradeOverAll();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.67);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(67);
        }

        [Fact]
        public void UpdateToDateGrade_3OutOf4DropOne_Results100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_3OutOf4_DropLowest_100and67();

            testClass.UpdateGradeToDate();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(1);
            testClass.Evaluation.GradeToDateFriendly.ShouldBe(100);
        }

        [Fact]
        public void UpdateOverAllGrade_400Possible280EarnedDropOne_Results90()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_4Tests_DropLowest_90();

            testClass.UpdateGradeOverAll();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(.93);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(93);
        }

        [Fact]
        public void UpdateToDateGrade_400Possible280EarnedDropOne_Results90()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_4Tests_DropLowest_90();

            testClass.UpdateGradeToDate();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(.93);
            testClass.Evaluation.GradeToDateFriendly.ShouldBe(93);
        }

        [Fact]
        public void UpdateOverAllGrade_400Possible280EarnedDropTwo_Results100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_4Tests_DropLowestTwo_100();

            testClass.UpdateGradeOverAll();

            testClass.Evaluation.GradeOverallRaw.ShouldBe(1);
            testClass.Evaluation.GradeOverallFriendly.ShouldBe(100);
        }

        [Fact]
        public void UpdateToDateGrade_400Possible280EarnedDropTwo_Results100()
        {
            var testClass = Create_EvaluationWizard();
            testClass.Evaluation = Create_4Tests_DropLowestTwo_100();

            testClass.UpdateGradeToDate();

            testClass.Evaluation.GradeToDateRaw.ShouldBe(1);
            testClass.Evaluation.GradeToDateFriendly.ShouldBe(100);
        }
    }
}
