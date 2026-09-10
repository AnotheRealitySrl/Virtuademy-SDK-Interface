# Release notes

## v0.2.0

### Changed
- **The wire DTOs live here now.** `Virtuademy.SDK.PlatformApi.Wire` — 65 files, zero references —
  moved from the `virtuademy-sdk-platformapi` package into this one, unchanged: same assembly name,
  same GUIDs, same bytes. The eight assemblies that reference it are untouched.

  The reason is that this package **names six of those DTOs** in `IPlatformContext`, so anyone who
  installs the contracts needs them by construction. They were in a package that also carries the
  platform's HTTP client — 923 lines, 64 endpoints — which needs `Virtuademy.SDK.Core`. So the two
  audiences the contracts exist for could not install them: an external app got 70 compile errors,
  and a creator got the platform client shipped into their project to be able to name a `UserDTO`.
  Measured by `Virtuademy-ExternalApp-Test`.

  The assembly keeps the name `Virtuademy.SDK.PlatformApi.Wire` even though it no longer sits in
  that package. An assembly name is a wire symbol — a built bundle records components by it — so
  renaming it would invalidate every published world for a tidier label. Left as a naming debt.
- `com.unity.nuget.newtonsoft-json` is now declared: 32 of the DTO files use it, and it travelled
  with them.

### Known
- The package now carries **two** assemblies. `Virtuademy.SDK.Interface` still declares no
  transport and no credentials; `noEngineReferences` stays `false`, because the DTOs carry
  `[SerializeField]` and that is what makes the contracts' closure engine-bound.

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
