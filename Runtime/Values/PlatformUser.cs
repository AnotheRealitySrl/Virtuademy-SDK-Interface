namespace Virtuademy.SDK.Interface
{
    /// <summary>
    /// The signed-in user, as much of them as an app has any use for.
    /// </summary>
    /// <remarks>
    /// Immutable, unlike the mutable model it is projected from. And deliberately thin: the source
    /// carries the user's tag list, their stored preferences and a display colour, which are
    /// respectively tenant taxonomy, someone else's CRUD surface, and an engine type that has no
    /// place in a contract.
    /// </remarks>
    public sealed class PlatformUser
    {
        public PlatformUser(int id, string nickname, string displayName, int code, string email)
        {
            Id = id;
            Nickname = nickname;
            DisplayName = displayName;
            Code = code;
            Email = email;
        }

        public int Id { get; }

        /// <summary>The name the user chose.</summary>
        public string Nickname { get; }

        /// <summary>What to render: the nickname, disambiguated when the tenant asks for full names.</summary>
        public string DisplayName { get; }

        /// <summary>The numeric discriminator that makes two identical nicknames distinguishable.</summary>
        public int Code { get; }

        public string Email { get; }
    }
}
