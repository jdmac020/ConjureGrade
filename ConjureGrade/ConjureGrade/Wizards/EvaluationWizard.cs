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

        public void UpdateOverAllGrade()
        {
            if (Evaluation is null)
                throw new BadSpellException("There Is No Evaluation Property Set.");

            if (Evaluation.DropLowest == false)
            {
                Evaluation.PointsPossibleOverall = Evaluation.TotalScoreCount * Evaluation.PointValuePerScore;

                Evaluation.PointsEarnedOverall = Evaluation.Scores.Sum(s => s.PointsEarned);

                Evaluation.GradeOverallRaw =
                    CalculateRawPercentage(Evaluation.PointsEarnedOverall, Evaluation.PointsPossibleOverall);

                Evaluation.GradeOverallFriendly = GetFriendlyPercent(Evaluation.GradeOverallRaw);
            }
            else
            {

            }
        }

        public void UpdateToDateGrade()
        {
            if (Evaluation is null)
                throw new BadSpellException("There Is No Evaluation Property Set.");

            if (Evaluation.DropLowest == false)
            {
                Evaluation.PointsPossibleToDate = Evaluation.Scores.Count * Evaluation.PointValuePerScore;

                Evaluation.PointsEarnedToDate = Evaluation.Scores.Sum(s => s.PointsEarned);

                Evaluation.GradeToDateRaw =
                    CalculateRawPercentage(Evaluation.PointsEarnedToDate, Evaluation.PointsPossibleToDate);

                Evaluation.GradeToDateFriendly = GetFriendlyPercent(Evaluation.GradeToDateRaw);
            }
            else
            {

            }
        }

        public void UpdateAllGrades()
        {
            throw new NotImplementedException();
        }
    }
}
