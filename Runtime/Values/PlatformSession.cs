using System;

namespace Virtuademy.SDK.Interface
{
    /// <summary>
    /// The session this client is in.
    /// </summary>
    /// <remarks>
    /// Immutable. The field it projects from has a public setter and is assigned straight from a
    /// fetch, so anything holding a reference could see it change underneath — or change it.
    /// </remarks>
    public sealed class PlatformSession
    {
        public PlatformSession(int id,
                               string title,
                               SessionStatus status,
                               bool isLobby,
                               bool multiplayer,
                               int maxParticipants,
                               bool isPublic,
                               bool isOwner,
                               DateTime? startDateTime,
                               DateTime? endDateTime)
        {
            Id = id;
            Title = title;
            Status = status;
            IsLobby = isLobby;
            Multiplayer = multiplayer;
            MaxParticipants = maxParticipants;
            IsPublic = isPublic;
            IsOwner = isOwner;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        /// <summary>
        /// The session id. Historically called an <i>event</i>, which is why platform parameters
        /// still read <c>eventId</c>.
        /// </summary>
        public int Id { get; }

        public string Title { get; }

        public SessionStatus Status { get; }

        /// <summary>Whether this is the world's lobby rather than a session inside it.</summary>
        public bool IsLobby { get; }

        /// <summary>Whether other people can be here at all.</summary>
        public bool Multiplayer { get; }

        public int MaxParticipants { get; }

        public bool IsPublic { get; }

        /// <summary>Whether the local user owns this session.</summary>
        public bool IsOwner { get; }

        /// <summary>Set only when <see cref="Status"/> is <see cref="SessionStatus.Scheduled"/>.</summary>
        public DateTime? StartDateTime { get; }

        /// <summary>Set only when <see cref="Status"/> is <see cref="SessionStatus.Scheduled"/>.</summary>
        public DateTime? EndDateTime { get; }
    }
}
