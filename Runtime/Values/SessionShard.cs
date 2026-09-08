namespace Virtuademy.SDK.Interface
{
    /// <summary>
    /// One shard of a session: a capacity-bounded slice of participants who share a room.
    /// </summary>
    /// <remarks>
    /// No per-shard maximum: the wire carries the current occupancy and the closed flag, and the
    /// ceiling is a single global for every shard in the deployment. A per-shard
    /// <c>MaxParticipants</c> was in an earlier draft of this type, copied from a client model that
    /// reads that global through a static field — so it would have looked like shard data while
    /// being the same number everywhere. The session's own <see cref="PlatformSession.MaxParticipants"/>
    /// is the capacity a caller actually wants.
    /// </remarks>
    public sealed class SessionShard
    {
        public SessionShard(int number, int sessionId, int currentParticipants, bool isClosed)
        {
            Number = number;
            SessionId = sessionId;
            CurrentParticipants = currentParticipants;
            IsClosed = isClosed;
        }

        public int Number { get; }

        /// <summary>
        /// The session this shard belongs to. Supplied by the implementation: the wire does not
        /// repeat it on every shard, because a shard list is always the answer about one session.
        /// </summary>
        public int SessionId { get; }

        public int CurrentParticipants { get; }

        /// <summary>Whether the shard refuses further participants regardless of capacity.</summary>
        public bool IsClosed { get; }
    }
}
