using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConjureGrade.Spells
{
    public interface IEvaluationResult
    {
        /// <summary>
        /// If the Evaluation is weighted (ie, Labs make up 25% of the final grade) this should be true.
        /// </summary>
        bool Weighted { get; set; }

        /// <summary>
        /// The weight amount, as a decimal. (ie, if Labs are 25% of the final grade, this should be .25)
        /// </summary>
        double WeightAmount { get; set; }

        /// <summary>
        /// If the lowest score(s) are dropped and not counted towards the final grade (ie, 4 tests but only 3 are counted) this should be true
        /// </summary>
        bool DropLowest { get; set; }

        /// <summary>
        /// The number of scores that are dropped, if DropLowest is true
        /// </summary>
        int DropLowestCount { get; set; }

        /// <summary>
        /// The total number of assignments for this category (ie, if there are 12 labs in the semester this should be set to 12)
        /// </summary>
        int TotalScoreCount { get; set; }

        /// <summary>
        /// The planned value for each assignment (should be 100 if IsWeighted is true)
        /// </summary>
        double PointValuePerScore { get; set; }

        /// <summary>
        /// The list of graded Scores for this assignment
        /// </summary>
        IEnumerable<IScoreResult> Scores { get; set; }

        /// <summary>
        /// Points possible based on assignments already graded
        /// </summary>
        double PointsPossibleToDate { get; set; } // based on just the scores available

        /// <summary>
        /// Points earned on all graded assignments
        /// </summary>
        double PointsEarned { get; set; }

        /// <summary>
        /// The grade out of all completed assignments as a decimal rounded to 2 places
        /// </summary>
        double GradeToDateRaw { get; set; }

        /// <summary>
        /// The grade of all planned assignments as a decimal rounded to 2 places
        /// </summary>
        double GradeToDateFriendly { get; set; }

        /// <summary>
        /// Points possible based on all planned assignments
        /// </summary>
        double PointsPossibleOverall { get; set; } // based on (TotalScoreCount - DropLowestCount) * PointValuePerScore

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
