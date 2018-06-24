using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Spells;

namespace ConjureGrade.Wizards
{
    public class CourseWizard : ICourseWizard
    {
        public ICourseResult Course { get; set; }

        public void UpdateAllGrades()
        {
            throw new NotImplementedException();
        }

        public void UpdateGradeToDate()
        {
            throw new NotImplementedException();
        }

        public void UpdateGradeOverall()
        {
            throw new NotImplementedException();
        }
    }
}
