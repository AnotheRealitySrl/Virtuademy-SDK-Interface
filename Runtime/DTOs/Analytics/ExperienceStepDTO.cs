namespace Virtuademy.SDK.ApiData
{
    public abstract class ExperienceStepDTO : ExperienceAnalyticDTO
    {
        [SettableField(isRequired = true)]
        public string stepId;
    }
}
