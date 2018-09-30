using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConjureGrade.Spells
{
    public interface IScoreResult
    {
        /// <summary>
        /// Points earned on the assignment
        /// </summary>
        double PointsEarned { get; set; }

        /// <summary>
        /// Points value for the assignment
        /// </summary>
        double PointsPossible { get; set; }

        /// <summary>
        /// Grade value as a decimal rounded to two places
        /// </summary>
        double GradeRaw { get; set; }

        /// <summary>
        /// Grade value as a whole number
        /// </summary>
        double GradeFriendly { get; set; }

        /// <summary>
        /// Not currently in use
        /// </summary>
        bool IsPlaceholder { get; set; }
    }
}
