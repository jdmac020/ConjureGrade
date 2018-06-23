namespace ConjureGrade.Spells
{
    public class ScoreResult
    {
        public double PointsEarned { get; set; }
        public double PointsPossible { get; set; }
        public double RawGradeResult { get; set; }
        public double FriendlyGradeResult { get; set; }
        public bool IsPlaceholder { get; set; }
    }
}