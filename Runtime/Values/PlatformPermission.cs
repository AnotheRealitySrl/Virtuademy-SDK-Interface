namespace Virtuademy.SDK.Interface
{
    /// <summary>
    /// Something the local user may or may not do. Ask through
    /// <see cref="IPlatformContext.IsGranted"/>.
    /// </summary>
    /// <remarks>
    /// <b>The numeric values are the platform's identifiers and are part of the wire contract.</b>
    /// They are assigned explicitly and they are not contiguous — 4, 5, 6, 8, 9, 10, 11 and 13 do
    /// not exist, having been retired server-side. Never renumber, never fill a gap, never reorder:
    /// an adapter maps these by value.
    /// <para>
    /// Lifted here from a type nested inside a client model in the Worlds package. A permission is
    /// one of the few things an app genuinely has to reason about, and it cannot depend on that
    /// package in order to name one.
    /// </para>
    /// </remarks>
    public enum PlatformPermission
    {
        Unknown = 0,
        MuteOthers = 1,
        KickOthers = 2,
        UseTools = 3,
        SpawnFiles = 7,
        SendGlobalAndShardMessages = 12,
        SendAnnouncementMessages = 14,
        ManageMyExperiencesAndSessions = 15,
        EnableSpeaker = 16,
        UseAuthoringTool = 17,
        InteractWithAllObjects = 18,
        UseVoiceChat = 19,
        ManageMyEvents = 20,
        ManageMySessions = 21,
        ManageMyAuthoredExperiences = 22,
        ShowCatalogTab = 23,
        ShowLeaderboard = 24,
        UseEmotes = 25,
        ShowLogo = 26,
        ShowTutorialButton = 27,
        EnableDoubleUserConnection = 28,
        ShowCompleteName = 29,
        UploadAssetsFolders = 30,
        ReadSharedAssetsFolders = 31,
        ManageSharedAssetsFolders = 32,
        GenerateAI3DAssets = 33,
    }
}
