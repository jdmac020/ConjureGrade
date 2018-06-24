using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConjureGrade.Spells;

namespace ConjureGrade.Wizards
{
    public interface ICourseWizard
    {
        ICourseResult Course { get; set; }

        void UpdateAllGrades();
        void UpdateGradeToDate();
        void UpdateGradeOverall();
    }
}
