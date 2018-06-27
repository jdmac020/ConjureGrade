using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Spells;
using static ConjureGrade.Apprentice.MathApprentice;

namespace ConjureGrade.Wizards
{
    public class CourseWizard : ICourseWizard
    {
        public ICourseResult Course { get; set; }

        public void UpdateAllGrades()
        {
            throw new NotImplementedException();
        }

        public void UpdateGradeToDate()
        {
            if (Course.GetType() == typeof(WeightedCourseResult))
            {
                ProcessWeightedGrade(false);
            }
            else
            {
                ProcessNonWeightedGrade(false);
            }
        }

        public void UpdateGradeOverall()
        {
            if (Course.GetType() == typeof(WeightedCourseResult))
            {
                ProcessWeightedGrade(true);
            }
            else
            {
                ProcessNonWeightedGrade(true);
            }
        }

        protected void ProcessNonWeightedGrade(bool overallGrade)
        {
            var castedCourse = (CourseResult) Course;

            castedCourse.PointsEarned = castedCourse.PointsEarned = castedCourse.Evaluations.Sum(e => e.PointsEarned);

            if (overallGrade)
            {
                castedCourse.PointsPossibleOverall = castedCourse.Evaluations.Sum(e => e.PointsPossibleOverall);
                castedCourse.RawOverallGrade = CalculateRawPercentage(castedCourse.PointsEarned, castedCourse.PointsPossibleOverall);
                castedCourse.FriendlyOverallGrade = GetFriendlyPercent(castedCourse.RawOverallGrade);
            }
            else
            {
                castedCourse.PointsPossibleToDate = castedCourse.Evaluations.Sum(e => e.PointsPossibleToDate);
                castedCourse.RawToDateGrade = CalculateRawPercentage(castedCourse.PointsEarned, castedCourse.PointsPossibleToDate);
                castedCourse.FriendlyToDateGrade = GetFriendlyPercent(castedCourse.RawToDateGrade);
            }

            Course = castedCourse;
        }

        protected void ProcessWeightedGrade(bool overallGrade)
        {
            var totalGrade = GetTotalGrade(overallGrade);

            if (overallGrade)
            {
                Course.RawOverallGrade = totalGrade;
                Course.FriendlyOverallGrade = GetFriendlyPercent(totalGrade);
            }
            else
            {
                Course.RawToDateGrade = totalGrade;
                Course.FriendlyToDateGrade = GetFriendlyPercent(totalGrade);
            }
        }

        protected double GetTotalGrade(bool overallGrade)
        {
            double totalGrade = 0;

            foreach (var eval in Course.Evaluations)
            {
                if (overallGrade)
                {
                    var weightedGrade = eval.GradeOverallRaw * eval.WeightAmount;
                    totalGrade += weightedGrade;
                }
                else
                {
                    var weightedGrade = eval.GradeToDateRaw * eval.WeightAmount;
                    totalGrade += weightedGrade;
                }
            }

            return Math.Round(totalGrade,2);
        }
    }
}
