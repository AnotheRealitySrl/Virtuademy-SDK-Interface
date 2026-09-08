namespace Virtuademy.SDK.Interface
{
    /// <summary>
    /// One shard of a session: a capacity-bounded slice of participants who share a room.
    /// </summary>
    public sealed class SessionShard
    {
        public SessionShard(int number, int sessionId, int currentParticipants, int maxParticipants, bool isClosed)
        {
            Number = number;
            SessionId = sessionId;
            CurrentParticipants = currentParticipants;
            MaxParticipants = maxParticipants;
            IsClosed = isClosed;
        }

        public int Number { get; }

        public int SessionId { get; }

        public int CurrentParticipants { get; }

        public int MaxParticipants { get; }

        /// <summary>Whether the shard refuses further participants regardless of capacity.</summary>
        public bool IsClosed { get; }
    }
}
