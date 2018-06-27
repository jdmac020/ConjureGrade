using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Exceptions;
using ConjureGrade.Spells;
using static ConjureGrade.Apprentice.MathApprentice;

namespace ConjureGrade.Wizards
{
    public class EvaluationWizard : IEvaluationWizard
    {
        public EvaluationResult Evaluation { get; set; }

        public void UpdateAllGrades()
        {
            if (Evaluation is null)
                throw new BadSpellException("There Is No Evaluation Property Set.");

            UpdateOverAllGrade();
            UpdateToDateGrade();
        }

        public void UpdateOverAllGrade()
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
        
        public void UpdateToDateGrade()
        {
            if (Evaluation is null)
                throw new BadSpellException("There Is No Evaluation Property Set.");

            if (Evaluation.DropLowest == false)
            {
                Evaluation.PointsPossibleToDate = Evaluation.Scores.Count * Evaluation.PointValuePerScore;

                SetPointsEarnedAllScores();
            }
            else
            {
                Evaluation.PointsPossibleToDate = (Evaluation.Scores.Count - Evaluation.DropLowestCount) * Evaluation.PointValuePerScore;

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
            var adjustedScoreList = Evaluation.Scores;

            for (int i = 0; i < Evaluation.DropLowestCount; i++)
            {
                var lowestScore = Evaluation.Scores.Min(s => s.PointsEarned);

                var scoreToRemove = Evaluation.Scores.Where(s => s.PointsEarned == lowestScore).FirstOrDefault();

                adjustedScoreList.Remove(scoreToRemove);
            }

            Evaluation.PointsEarned = adjustedScoreList.Sum(s => s.PointsEarned);
            
        }
        
    }
}
