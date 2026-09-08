namespace Virtuademy.SDK.Interface
{
    /// <summary>What kind of thing an experience runs.</summary>
    public enum ExperienceType
    {
        /// <summary>A world shipped by the platform.</summary>
        Core = 0,

        /// <summary>A world built with the Creator Kit.</summary>
        Authored = 1,

        /// <summary>An application outside the platform, launched by it. What an external app is.</summary>
        ExternalApp = 2,
    }
}
