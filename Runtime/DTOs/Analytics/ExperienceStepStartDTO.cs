using System;

namespace Virtuademy.SDK.ApiData
{
    [Serializable]
    public class ExperienceStepStartDTO : ExperienceStepDTO
    {
        [SettableField(isRequired = true)]
        public string description;
    }
}
