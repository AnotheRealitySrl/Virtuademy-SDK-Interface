namespace Virtuademy.SDK.Interface
{
    /// <summary>
    /// A world an app may enter.
    /// </summary>
    /// <remarks>
    /// This is also what <see cref="WorldChooser"/> is handed, so it carries what a chooser needs in
    /// order to render a picker — a label, a description, a thumbnail address — and nothing that
    /// belongs to the catalog, such as the live occupancy counter or the world's default experience.
    /// </remarks>
    public sealed class WorldInfo
    {
        public WorldInfo(int id,
                         string label,
                         string description,
                         string thumbnailUri,
                         bool multiplayer,
                         int? maxOnlineUsers)
        {
            Id = id;
            Label = label;
            Description = description;
            ThumbnailUri = thumbnailUri;
            Multiplayer = multiplayer;
            MaxOnlineUsers = maxOnlineUsers;
        }

        public int Id { get; }

        public string Label { get; }

        public string Description { get; }

        /// <summary>
        /// Address of the thumbnail, not the loaded image. Fetching and decoding belong to the host,
        /// and a contract with no engine dependency could not hand back a texture anyway.
        /// </summary>
        public string ThumbnailUri { get; }

        public bool Multiplayer { get; }

        /// <summary>Null when the world sets no ceiling.</summary>
        public int? MaxOnlineUsers { get; }
    }
}
