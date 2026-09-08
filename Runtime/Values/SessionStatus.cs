namespace Virtuademy.SDK.Interface
{
    /// <summary>
    /// What kind of session this is.
    /// </summary>
    /// <remarks>
    /// The platform's own session enum has two further values, <c>Expired</c> and <c>Empty</c>,
    /// which are server-side bookkeeping and <b>must never reach a client</b>. They are absent here
    /// by design rather than by omission: an adapter that meets one has found a server-side leak and
    /// should report it, not widen this enum to accommodate it.
    /// </remarks>
    public enum SessionStatus
    {
        /// <summary>Created on demand, for one visit. What a standalone app gets.</summary>
        OnTheFly = 0,

        /// <summary>Has a start and an end time.</summary>
        Scheduled = 1,

        /// <summary>Always available.</summary>
        Persistent = 2,
    }
}
