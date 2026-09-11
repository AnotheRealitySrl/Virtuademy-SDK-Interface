using System;

namespace Virtuademy.SDK.ApiData
{
    [Serializable]
    public class ExperienceStartDTO : ExperienceAnalyticDTO
    {
        [SettableField(isRequired = true)]
        public string context;
    }
}
