using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Spells;
using static ConjureGrade.Tests.Factories.EvaluationResultFactory;

namespace ConjureGrade.Tests.Factories
{
    public static class CourseResultFactory
    {
        /// <summary>
        /// 240/300 or 80%
        /// </summary>
        /// <returns></returns>
        public static ICourseResult Create_NonWeightedCourse()
        {
            return new CourseResult
            {
                Evaluations = CreateList_BCourse_NonWeight()
            };
        }

        /// <summary>
        /// 84%
        /// </summary>
        /// <returns></returns>
        public static ICourseResult Create_WeightedCourse()
        {
            return new WeightedCourseResult
            {
                Evaluations = CreateList_WeightedCourse()
            };
        }
    }
}
