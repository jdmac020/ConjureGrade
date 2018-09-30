using System.Collections.Generic;

namespace ConjureGrade.Spells
{
    public class WeightedCourseResult : ICourseResult
    {
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
