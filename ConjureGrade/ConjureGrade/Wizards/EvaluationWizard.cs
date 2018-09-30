using System.Linq;
using ConjureGrade.Exceptions;
using ConjureGrade.Spells;
using static ConjureGrade.Apprentice.MathApprentice;

namespace ConjureGrade.Wizards
{
    /// <summary>
    /// Used to calculate the grade for an evaluation type
    /// </summary>
    public class EvaluationWizard : IEvaluationWizard
    {
        public double OverallGradeFriendly { get { return Evaluation.GradeOverallFriendly; } }

        public double OverallGradeRaw { get { return Evaluation.GradeOverallRaw; } }

        public double ToDateGradeFriendly { get { return Evaluation.GradeToDateFriendly; } }

        public double ToDateGradeRaw { get { return Evaluation.GradeToDateRaw; } }

        public IEvaluationResult Evaluation { get; set; }

        /// <summary>
        /// Updates both the grade based on assignments taken and assignments planned
        /// </summary>
        public void UpdateAllGrades()
        {
            if (Evaluation is null)
                throw new BadSpellException("There Is No Evaluation Property Set.");

            UpdateGradeOverAll();
            UpdateGradeToDate();
        }

        /// <summary>
        /// Updates the grade based on all planned assignments
        /// </summary>
        public void UpdateGradeOverAll()
        {
            if (Evaluation is null)
                throw new BadSpellException("There Is No Evaluation Property Set.");

            if (Evaluation.DropLowest == false)
            {
                Evaluation.PointsPossibleOverall = Evaluation.TotalScoreCount * Evaluation.PointValuePerScore;

                SetPointsEarnedAllScores();
            }
            else
            {
                Evaluation.PointsPossibleOverall = (Evaluation.TotalScoreCount - Evaluation.DropLowestCount) * Evaluation.PointValuePerScore;

                SetPointsEarnedAfterDroppingLowest();
            }

            SetGradeOverall();
        }

        /// <summary>
        /// Updates the grade based only on assignments graded
        /// </summary>
        public void UpdateGradeToDate()
        {
            if (Evaluation is null)
                throw new BadSpellException("There Is No Evaluation Property Set.");

            if (Evaluation.DropLowest == false)
            {
                Evaluation.PointsPossibleToDate = Evaluation.Scores.Count() * Evaluation.PointValuePerScore;

                SetPointsEarnedAllScores();
            }
            else
            {
                Evaluation.PointsPossibleToDate = (Evaluation.Scores.Count() - Evaluation.DropLowestCount) * Evaluation.PointValuePerScore;

                SetPointsEarnedAfterDroppingLowest();
            }

            SetGradeToDate();
        }

        protected void SetPointsEarnedAllScores()
        {
            Evaluation.PointsEarned = Evaluation.Scores.Sum(s => s.PointsEarned);
        }

        protected void SetGradeOverall()
        {
            Evaluation.GradeOverallRaw =
                CalculateRawPercentage(Evaluation.PointsEarned, Evaluation.PointsPossibleOverall);

            Evaluation.GradeOverallFriendly = GetFriendlyPercent(Evaluation.GradeOverallRaw);
        }

        protected void SetGradeToDate()
        {
            Evaluation.GradeToDateRaw =
                CalculateRawPercentage(Evaluation.PointsEarned, Evaluation.PointsPossibleToDate);

            Evaluation.GradeToDateFriendly = GetFriendlyPercent(Evaluation.GradeToDateRaw);
        }

        protected void SetPointsEarnedAfterDroppingLowest()
        {
            var adjustedScoreList = Evaluation.Scores.ToList();

            for (int i = 0; i < Evaluation.DropLowestCount; i++)
            {
                var lowestScore = adjustedScoreList.Min(s => s.PointsEarned);

                var scoreToRemove = Evaluation.Scores.Where(s => s.PointsEarned == lowestScore).FirstOrDefault();

                adjustedScoreList.Remove(scoreToRemove);
            }

            Evaluation.PointsEarned = adjustedScoreList.Sum(s => s.PointsEarned);
            
        }
        
    }
}
