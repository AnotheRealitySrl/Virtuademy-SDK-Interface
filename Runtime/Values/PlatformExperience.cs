using System;

namespace Virtuademy.SDK.Interface
{
    /// <summary>
    /// The experience the app is running as.
    /// </summary>
    /// <remarks>
    /// First-class on <see cref="IPlatformContext"/> rather than reachable through the session,
    /// because this is the record that <i>is</i> the app on the platform.
    /// <para>
    /// What an operator configures on it — including the identity the app is matched on — stays
    /// server-side and is deliberately absent here. The app proves who it is by passing its own
    /// identity to <see cref="IPlatformContext.Initialize"/>; it does not read the answer back.
    /// </para>
    /// </remarks>
    public sealed class PlatformExperience
    {
        public PlatformExperience(int id,
                                  string title,
                                  string description,
                                  ExperienceType type,
                                  bool isPublic,
                                  bool isOwner,
                                  DateTime lastUpdate)
        {
            Id = id;
            Title = title;
            Description = description;
            Type = type;
            IsPublic = isPublic;
            IsOwner = isOwner;
            LastUpdate = lastUpdate;
        }

        public int Id { get; }

        public string Title { get; }

        public string Description { get; }

        public ExperienceType Type { get; }

        public bool IsPublic { get; }

        /// <summary>Whether the local user owns this experience.</summary>
        public bool IsOwner { get; }

        public DateTime LastUpdate { get; }
    }
}
