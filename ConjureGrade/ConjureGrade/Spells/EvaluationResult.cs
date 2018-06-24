using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConjureGrade.Spells
{
    public class EvaluationResult
    {
        
        public bool DropLowest { get; set; }
        public int DropLowestCount { get; set; }
        public int TotalScoreCount { get; set; }
        public double PointValuePerScore { get; set; }
        public List<ScoreResult> Scores { get; set; }
        public double PointsPossibleToDate { get; set; } // based on just the scores available
        public double PointsEarnedToDate { get; set; } 
        public double GradeToDateRaw { get; set; }
        public double GradeToDateFriendly { get; set; }
        public double PointsPossibleOverall { get; set; } // based on (TotalScoreCount - DropLowestCount) * PointValuePerScore
        public double PointsEarnedOverall { get; set; }
        public double GradeOverallRaw { get; set; }
        public double GradeOverallFriendly { get; set; }
    }
}
