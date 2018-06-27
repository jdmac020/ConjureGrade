namespace ConjureGrade.Spells
{
    public class ScoreResult
    {
        /// <summary>
        /// Points earned on the assignment
        /// </summary>
        public double PointsEarned { get; set; }

        /// <summary>
        /// Points value for the assignment
        /// </summary>
        public double PointsPossible { get; set; }

        /// <summary>
        /// Grade value as a decimal rounded to two places
        /// </summary>
        public double GradeRaw { get; set; }

        /// <summary>
        /// Grade value as a whole number
        /// </summary>
        public double GradeFriendly { get; set; }

        /// <summary>
        /// Not currently in use
        /// </summary>
        public bool IsPlaceholder { get; set; }
    }
}