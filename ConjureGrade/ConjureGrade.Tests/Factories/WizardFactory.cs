using ConjureGrade.Wizards;

namespace ConjureGrade.Tests.Factories
{
    public static class WizardFactory
    {
        public static IScoreWizard Create_ScoreWizard()
        {
            return new ScoreWizard();
        }
    }
}