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

            testClass.Course.GradeToDateRaw.ShouldBe(.83);
            testClass.Course.GradeToDateFriendly.ShouldBe(83);
        }

        [Fact]
        public void UpdateGradeOverAll_WeightedCourse_Result83()
        {
            var testClass = Create_CourseWizard();
            testClass.Course = Create_WeightedCourse();

            testClass.UpdateGradeOverall();

            testClass.Course.GradeOverallRaw.ShouldBe(.83);
            testClass.Course.GradeOverallFriendly.ShouldBe(83);
        }

        [Fact]
        public void UpdateGradeToDate_NonWeightedCourse_Result80()
        {
            var testClass = Create_CourseWizard();
            testClass.Course = Create_NonWeightedCourse();

            testClass.UpdateGradeToDate();

            testClass.Course.GradeToDateRaw.ShouldBe(.80);
            testClass.Course.GradeToDateFriendly.ShouldBe(80);

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

            testClass.Course.GradeOverallRaw.ShouldBe(.80);
            testClass.Course.GradeOverallFriendly.ShouldBe(80);

            var result = (CourseResult)testClass.Course;

            result.PointsEarned.ShouldBe(240);
            result.PointsPossibleOverall.ShouldBe(300);
        }

        [Fact]
        public void UpdateOverAllGrade()
        {
            var testClass = Create_CourseWizard();

            var final = new EvaluationResult {PointsPossibleOverall = 100, TotalScoreCount = 1, PointsEarned = 0, GradeToDateRaw = 1, GradeOverallRaw = 0, Weighted = true, WeightAmount = .4, PointsPossibleToDate = 0, PointValuePerScore = 100};
            var exams = new EvaluationResult { Weighted = true, WeightAmount = .3, TotalScoreCount = 3, PointValuePerScore = 100, PointsEarned = 175, PointsPossibleOverall = 300, PointsPossibleToDate = 200, GradeToDateRaw = .88, GradeOverallRaw = .58, };
            var quiz = new EvaluationResult { Weighted = true, WeightAmount = .2, TotalScoreCount = 4, PointValuePerScore = 100, PointsEarned = 342, PointsPossibleOverall = 400, PointsPossibleToDate = 400, GradeToDateRaw = .86, GradeOverallRaw = .86 };
            var hw = new EvaluationResult { Weighted = true, WeightAmount = .1, TotalScoreCount = 8, PointValuePerScore = 100, PointsEarned = 0, PointsPossibleOverall = 800, PointsPossibleToDate = 0, GradeToDateRaw = 1, GradeOverallRaw = 0};

            var courseResult = new WeightedCourseResult { Evaluations = new List<EvaluationResult>
            {
                final,
                exams,
                quiz,
                hw
            }};

            testClass.Course = courseResult;

            testClass.UpdateAllGrades();
        }

        [Fact]
        public void UpdateOverAllGrade_NoScoreEvals_Equal100()
        {
            var testClass = Create_CourseWizard();

            var final = new EvaluationResult { Weighted = true, WeightAmount = .4, PointValuePerScore = 100, PointsEarned = 0, PointsPossibleOverall = 100,  PointsPossibleToDate = 0,  };
            var exams = new EvaluationResult { Weighted = true, WeightAmount = .3, PointValuePerScore = 100, PointsEarned = 175, PointsPossibleOverall = 300, PointsPossibleToDate = 200 };
            var quiz = new EvaluationResult { Weighted = true, WeightAmount = .2, PointValuePerScore = 100, PointsEarned = 342, PointsPossibleOverall = 400, PointsPossibleToDate = 400 };
            var hw = new EvaluationResult { Weighted = true, WeightAmount = .1, PointValuePerScore = 100, PointsEarned = 0, PointsPossibleOverall = 800, PointsPossibleToDate = 0 };

            //var final = new EvaluationResult { PointsPossibleOverall = 100, TotalScoreCount = 1, PointsEarned = 0, GradeToDateRaw = 1, GradeOverallRaw = 0, Weighted = true, WeightAmount = .4, PointsPossibleToDate = 0, PointValuePerScore = 100 };
            //var exams = new EvaluationResult { Weighted = true, WeightAmount = .3, TotalScoreCount = 3, PointValuePerScore = 100, PointsEarned = 175, PointsPossibleOverall = 300, PointsPossibleToDate = 200, GradeToDateRaw = .88, GradeOverallRaw = .58, };
            //var quiz = new EvaluationResult { Weighted = true, WeightAmount = .2, TotalScoreCount = 4, PointValuePerScore = 100, PointsEarned = 342, PointsPossibleOverall = 400, PointsPossibleToDate = 400, GradeToDateRaw = .86, GradeOverallRaw = .86 };
            //var hw = new EvaluationResult { Weighted = true, WeightAmount = .1, TotalScoreCount = 8, PointValuePerScore = 100, PointsEarned = 0, PointsPossibleOverall = 800, PointsPossibleToDate = 0, GradeToDateRaw = 1, GradeOverallRaw = 0 };

            //var final = new EvaluationResult { PointsPossibleOverall = 100, PointsEarned = 0, Weighted = true, WeightAmount = .4 };
            //var exams = new EvaluationResult { Weighted = true, WeightAmount = .3, PointsEarned = 175, PointsPossibleOverall = 300, };
            //var quiz = new EvaluationResult { Weighted = true, WeightAmount = .2, PointsEarned = 342, PointsPossibleOverall = 400 };
            //var hw = new EvaluationResult { Weighted = true, WeightAmount = .1, PointsEarned = 0, PointsPossibleOverall = 800 };

            var courseResult = new WeightedCourseResult
            {
                Evaluations = new List<EvaluationResult>
            {
                final,
                exams,
                quiz,
                hw
            }
            };

            testClass.Course = courseResult;

            testClass.UpdateGradeOverall();

            testClass.Course.GradeOverallFriendly.ShouldBe(35);
        }
    }
}
