using System;
using ConjureGrade.Exceptions;

namespace ConjureGrade.Apprentice
{
    public static class MathApprentice
    {
        /// <summary>
        /// Used across the library to get the percentage of two numbers, and return it as a double rounded to two decimal places.
        /// </summary>
        public static double CalculateRawPercentage(double earnedPoints, double possiblePoints, int precisionInDecimalPlaces = 2)
        {

            if (possiblePoints < 0 || earnedPoints < 0)
            {
                throw new BadSpellException("All Arguments Must Be At Least Zero!");
            }

            var rawResult = earnedPoints / possiblePoints;

            if (double.IsInfinity(rawResult) || double.IsNaN(rawResult))
            {
                return 0;
            }
            else
            {
                return Math.Round(rawResult, precisionInDecimalPlaces);
            }
        }

        /// <summary>
        /// Converts a percentage in decimal form to a whole number for easier reading.
        /// </summary>
        public static double GetFriendlyPercent(double rawPercent)
        {
            if (rawPercent < 0)
            {
                throw new BadSpellException("Value for Raw Percent Must Be At Least 0.");
            }

            if (rawPercent == 0)
            {
                return 0;
            }

            var percentResult = rawPercent * 100;

            return percentResult;
            
        }

        /// <summary>
        /// Accepts two numbers and returns the whole number percent value.
        /// </summary>
        public static double GetFriendlyPercent(double pointsEarned, double pointsPossible)
        {
            var rawPercent = CalculateRawPercentage(pointsEarned, pointsPossible);

            var friendlyPercent = GetFriendlyPercent(rawPercent);

            return friendlyPercent;
        }
    }
}