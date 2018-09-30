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
                if (Evaluation.PointsPossibleOverall == 0)
                {
                    Evaluation.PointsPossibleOverall = Evaluation.TotalScoreCount * Evaluation.PointValuePerScore;
                }
                
                SetPointsEarnedAllScores();
            }
            else
            {
                
                if (Evaluation.PointsPossibleOverall == 0)
                {
                    Evaluation.PointsPossibleOverall = (Evaluation.TotalScoreCount - Evaluation.DropLowestCount) * Evaluation.PointValuePerScore;
                }
                
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
                if (Evaluation.Scores != null)
                {
                    Evaluation.PointsPossibleToDate = Evaluation.Scores.Count() * Evaluation.PointValuePerScore;
                }
                else
                {
                    if (Evaluation.PointsPossibleToDate == 0 && Evaluation.PointsPossibleOverall != 0)
                    {
                        Evaluation.PointsPossibleToDate = Evaluation.PointsPossibleOverall;
                    }
                }
                
                SetPointsEarnedAllScores();
            }
            else
            {
                Evaluation.PointsPossibleToDate = (Evaluation.Scores.Count() - Evaluation.DropLowestCount) * Evaluation.PointValuePerScore;

                SetPointsEarnedAfterDroppingLowest();
            }

            SetGradeToDate();
        }

        // If there is no Scores object assigned, use PointsEarned as-is
        // If there is a Scores object assigned but it is empty, set PointsEarned to 0
        // If there is a Scores object with Scores attached, set PointsEarned to the sum of all scores PointsEarned property
        protected void SetPointsEarnedAllScores()
        {
            if (Evaluation.Scores != null)
            {
                if (Evaluation.Scores.Count() != 0)
                {
                    Evaluation.PointsEarned = Evaluation.Scores.Sum(s => s.PointsEarned);
                }
                else
                {
                    Evaluation.PointsEarned = 0;
                }
            }
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

            if (Evaluation.Scores != null)
            {
                if (Evaluation.Scores.Count() != 0)
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
                else
                {
                    Evaluation.PointsEarned = 0;
                }
            }
        }

    }
}
