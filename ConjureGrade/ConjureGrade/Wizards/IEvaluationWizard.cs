﻿using ConjureGrade.Spells;

namespace ConjureGrade.Wizards
{
    /// <summary>
    /// Used to calculate the grade for an evaluation type
    /// </summary>
    public interface IEvaluationWizard
    {
        double OverallGradeFriendly { get; }

        double OverallGradeRaw { get; }

        double ToDateGradeFriendly { get; }

        double ToDateGradeRaw { get; }

        IEvaluationResult Evaluation { get; set; }

        /// <summary>
        /// Updates both the grade based on assignments taken and assignments planned
        /// </summary>
        void UpdateGradeOverAll();

        /// <summary>
        /// Updates the grade based only on assignments graded
        /// </summary>
        void UpdateGradeToDate();

        /// <summary>
        /// Updates both the grade based on assignments taken and assignments planned
        /// </summary>
        void UpdateAllGrades();
    }
}
