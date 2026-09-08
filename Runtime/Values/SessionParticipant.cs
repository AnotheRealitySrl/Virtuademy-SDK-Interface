namespace Virtuademy.SDK.Interface
{
    /// <summary>
    /// Someone present in this session, including the local user.
    /// </summary>
    /// <remarks>
    /// Read-only, and handed out inside a read-only list. Its predecessor returned the backing field
    /// itself, so a caller could add to — or clear — the platform's own roster.
    /// </remarks>
    public sealed class SessionParticipant
    {
        public SessionParticipant(PlatformUser user,
                                  string connectionId,
                                  int sessionId,
                                  int worldId,
                                  int shard,
                                  ParticipantPlatform platform)
        {
            User = user;
            ConnectionId = connectionId;
            SessionId = sessionId;
            WorldId = worldId;
            Shard = shard;
            Platform = platform;
        }

        public PlatformUser User { get; }

        /// <summary>
        /// Shorthand for <c>User.Id</c> — the key
        /// <see cref="IPlatformContext.TryGetParticipant"/> takes.
        /// </summary>
        public int UserId => User?.Id ?? 0;

        /// <summary>This participant's realtime connection id.</summary>
        public string ConnectionId { get; }

        public int SessionId { get; }

        public int WorldId { get; }

        /// <summary>Which shard of the session they are in.</summary>
        public int Shard { get; }

        public ParticipantPlatform Platform { get; }
    }
}
