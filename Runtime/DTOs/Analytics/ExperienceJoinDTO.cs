using System;

namespace Virtuademy.SDK.ApiData
{
    [Serializable]
    public class ExperienceJoinDTO : ExperienceAnalyticDTO
    {
        [SettableField(isRequired = true)]
        public string context;

    }
}
