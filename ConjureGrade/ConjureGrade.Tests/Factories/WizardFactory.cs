using ConjureGrade.Wizards;

namespace ConjureGrade.Tests.Factories
{
    public static class WizardFactory
    {
        public static IScoreWizard Create_ScoreWizard()
        {
            return new ScoreWizard();
        }

        public static IEvaluationWizard Create_EvaluationWizard()
        {
            return new EvaluationWizard();
        }
    }
}