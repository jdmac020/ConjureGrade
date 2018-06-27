using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Exceptions;
using ConjureGrade.Spells;
using ConjureGrade.Wizards;
using Xunit;
using Shouldly;
using static ConjureGrade.Tests.Factories.WizardFactory;
using static ConjureGrade.Tests.Factories.CourseResultFactory;

namespace ConjureGrade.Tests
{
    public class CourseWizardTests
    {
        [Fact]
        public void UpdateGradeToDate_WeightedCourse_Result83()
        {
            var testClass = Create_CourseWizard();
            testClass.Course = Create_WeightedCourse();

            testClass.UpdateGradeToDate();

            testClass.Course.RawToDateGrade.ShouldBe(.83);
            testClass.Course.FriendlyToDateGrade.ShouldBe(83);
        }

        [Fact]
        public void UpdateGradeOverAll_WeightedCourse_Result83()
        {
            var testClass = Create_CourseWizard();
            testClass.Course = Create_WeightedCourse();

            testClass.UpdateGradeOverall();

            testClass.Course.RawOverallGrade.ShouldBe(.83);
            testClass.Course.FriendlyOverallGrade.ShouldBe(83);
        }

        [Fact]
        public void UpdateGradeToDate_NonWeightedCourse_Result80()
        {
            var testClass = Create_CourseWizard();
            testClass.Course = Create_NonWeightedCourse();

            testClass.UpdateGradeToDate();

            testClass.Course.RawToDateGrade.ShouldBe(.80);
            testClass.Course.FriendlyToDateGrade.ShouldBe(80);

            var result = (CourseResult) testClass.Course;

            result.PointsEarned.ShouldBe(240);
            result.PointsPossibleToDate.ShouldBe(300);
        }

        [Fact]
        public void UpdateGradeOverAll_NonWeightedCourse_Result80()
        {
            var testClass = Create_CourseWizard();
            testClass.Course = Create_NonWeightedCourse();

            testClass.UpdateGradeOverall();

            testClass.Course.RawOverallGrade.ShouldBe(.80);
            testClass.Course.FriendlyOverallGrade.ShouldBe(80);

            var result = (CourseResult)testClass.Course;

            result.PointsEarned.ShouldBe(240);
            result.PointsPossibleOverall.ShouldBe(300);
        }
    }
}
