using ConjureGrade.Spells;

namespace ConjureGrade.Wizards
{
    /// <summary>
    /// Used to calculate the grade for a course
    /// </summary>
    public interface ICourseWizard
    {
        ICourseResult Course { get; set; }

        /// <summary>
        /// Updates both the grade based on assignments taken and assignments planned
        /// </summary>
        void UpdateAllGrades();

        /// <summary>
        /// Updates the grade based only on assignments graded
        /// </summary>
        void UpdateGradeToDate();

        /// <summary>
        /// Updates the grade based on all planned assignments
        /// </summary>
        void UpdateGradeOverall();
    }
}
