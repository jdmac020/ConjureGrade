using System.Collections.Generic;

namespace ConjureGrade.Spells
{
    public interface ICourseResult
    {
        /// <summary>
        /// List of graded Evaluations in the Course
        /// </summary>
        IEnumerable<IEvaluationResult> Evaluations { get; set; }
        
        /// <summary>
        /// The grade out of all completed assignments as a decimal rounded to 2 places
        /// </summary>
        double GradeToDateRaw { get; set; }

        /// <summary>
        /// The grade of all completed assignments as a whole number
        /// </summary>
        double GradeToDateFriendly { get; set; }

        /// <summary>
        /// The grade of all planned assignments as a decimal rounded to 2 places
        /// </summary>
        double GradeOverallRaw { get; set; }

        /// <summary>
        /// The grade of all planned assignments as a whole number
        /// </summary>
        double GradeOverallFriendly { get; set; }
    }
}
