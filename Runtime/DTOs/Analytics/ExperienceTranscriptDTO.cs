using System;

namespace Virtuademy.SDK.ApiData
{
    [Serializable]
    public class ExperienceTranscriptDTO : ExperienceStepDTO
    {
        [SettableField(isRequired = true)]
        public string description;
    }
}
