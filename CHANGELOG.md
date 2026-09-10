# Release notes

## v0.1.0

First release as a repository of its own. The package existed before this, embedded in
`Virtuademy-Unity` under `Packages/`, which meant the one package an external app developer needs
could not be installed by git URL — the whole point of it being public. The eight commits that
built it are preserved here with their original dates and messages.

### Added
- `IPlatformContext` — platform and session state as an application sees it: identity, session,
  experience, world, permissions, participants, shards, and the caller's own save data.
- `IPlatformAuthentication` — sign-in, as a sibling rather than a member, because `Initialize`
  presupposes an authenticated user.
- `WorldChooser`, and the five types this contract declares itself: `PlatformContextState`,
  `PlatformPermission`, `PlatformLaunchData`, `LoginChallenge`, `SessionShard`.
- `IApplicationManager` and `EApplicationState`, the two application-lifecycle types.

### Known
- **This assembly is not reference-free.** It references `Virtuademy.SDK.PlatformApi.Wire` for the
  six DTOs the contracts hand back, and `noEngineReferences` is `false` because those DTOs carry
  `[SerializeField]`. The README explains why naming them beats mirroring them; what the reference
  costs is the standalone, outside-Unity compile the package once had.
- **A mock cannot populate the contract.** Those DTOs expose private `[SerializeField]` fields and
  get-only properties with no public constructor, so `LocalUser`, `Session`, `Experience` and
  `World` are null in any test double. The types this contract owns are all constructible.
  `Virtuademy-ExternalApp-Test` exists to keep that measured.
