using System;
using System.Linq;
using ConjureGrade.Spells;
using static ConjureGrade.Apprentice.MathApprentice;

namespace ConjureGrade.Wizards
{
    /// <summary>
    /// Used to calculate the grade for a course
    /// </summary>
    public class CourseWizard : ICourseWizard
    {
        public double OverallGradeFriendly { get { return Course.GradeOverallFriendly; } }

        public double OverallGradeRaw { get { return Course.GradeOverallRaw; } }

        public double ToDateGradeFriendly { get { return Course.GradeToDateFriendly; } }

        public double ToDateGradeRaw { get { return Course.GradeToDateRaw; } }

        public ICourseResult Course { get; set; }

        /// <summary>
        /// Updates both the grade based on assignments taken and assignments planned
        /// </summary>
        public void UpdateAllGrades()
        {
            UpdateGradeToDate();
            UpdateGradeOverall();
        }

        /// <summary>
        /// Updates the grade based only on assignments graded
        /// </summary>
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

        /// <summary>
        /// Updates the grade based on all planned assignments
        /// </summary>
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
            var castedCourse = (CourseResult)Course;

            castedCourse.PointsEarned = castedCourse.PointsEarned = castedCourse.Evaluations.Sum(e => e.PointsEarned);

            if (overallGrade)
            {
                castedCourse.PointsPossibleOverall = castedCourse.Evaluations.Sum(e => e.PointsPossibleOverall);
                castedCourse.GradeOverallRaw = CalculateRawPercentage(castedCourse.PointsEarned, castedCourse.PointsPossibleOverall);
                castedCourse.GradeOverallFriendly = GetFriendlyPercent(castedCourse.GradeOverallRaw);
            }
            else
            {
                castedCourse.PointsPossibleToDate = castedCourse.Evaluations.Sum(e => e.PointsPossibleToDate);
                castedCourse.GradeToDateRaw = CalculateRawPercentage(castedCourse.PointsEarned, castedCourse.PointsPossibleToDate);
                castedCourse.GradeToDateFriendly = GetFriendlyPercent(castedCourse.GradeToDateRaw);
            }

            Course = castedCourse;
        }

        protected void ProcessWeightedGrade(bool overallGrade)
        {
            var totalGrade = GetTotalGrade(overallGrade);

            if (overallGrade)
            {
                Course.GradeOverallRaw = totalGrade;
                Course.GradeOverallFriendly = GetFriendlyPercent(totalGrade);
            }
            else
            {
                Course.GradeToDateRaw = totalGrade;
                Course.GradeToDateFriendly = GetFriendlyPercent(totalGrade);
            }
        }

        protected double GetTotalGrade(bool overallGrade)
        {
            double totalGrade = 0;

            foreach (var eval in Course.Evaluations)
            {
                if (overallGrade)
                {
                    var weightedGrade = CalculateRawPercentage(eval.PointsEarned, eval.PointsPossibleOverall) * eval.WeightAmount;
                    // var weightedGrade = eval.GradeOverallRaw * eval.WeightAmount;
                    totalGrade += weightedGrade;
                }
                else
                {
                    var weightedGrade = CalculateRawPercentage(eval.PointsEarned, eval.PointsPossibleToDate) * eval.WeightAmount;
                    totalGrade += weightedGrade;
                }
            }

            return Math.Round(totalGrade, 2);
        }
    }
}
