using System.Collections.Generic;

namespace ConjureGrade.Spells
{
    /// <summary>
    /// Represents a Course where point values represent the weight of the assignments.
    /// <para>For exapmple, Tests are worth 100 points each while Homeworks are only worth 10 points each</para>
    /// </summary>
    public class CourseResult : ICourseResult
    {
        /// <summary>
        /// Points possible based on assignments already graded
        /// </summary>
        public double PointsPossibleToDate { get; set; }

        /// <summary>
        /// Points possible based on all planned assignments
        /// </summary>
        public double PointsPossibleOverall { get; set; }

        /// <summary>
        /// Points earned on all graded assignments
        /// </summary>
        public double PointsEarned { get; set; }

        /// <summary>
        /// List of graded Evaluations in the Course
        /// </summary>
        public IEnumerable<IEvaluationResult> Evaluations { get; set; }

        /// <summary>
        /// The grade out of all completed assignments as a decimal rounded to 2 places
        /// </summary>
        public double GradeToDateRaw { get; set; }

        /// <summary>
        /// The grade of all completed assignments as a whole number
        /// </summary>
        public double GradeToDateFriendly { get; set; }

        /// <summary>
        /// The grade of all planned assignments as a decimal rounded to 2 places
        /// </summary>
        public double GradeOverallRaw { get; set; }

        /// <summary>
        /// The grade of all planned assignments as a whole number
        /// </summary>
        public double GradeOverallFriendly { get; set; }
    }
}
