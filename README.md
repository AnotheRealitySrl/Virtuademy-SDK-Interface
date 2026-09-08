# Virtuademy-SDK-Interface

The platform-context contracts. This is the one point where the creator graph and the external-app
graph meet: a creator installs `SPACS-*` + this + `Environments`, an external app developer installs
`SPACS-Utility` + this + `Library`, and the platform installs everything.

## What is here today

One assembly, `Virtuademy.SDK.Interface`, holding interfaces and their own value types:

| Type | Role |
|---|---|
| `IPlatformContext` | Platform and session state as an app sees it — identity, session, experience, world, permissions, participants, shards, the caller's own save data |
| `IPlatformAuthentication` | Sign-in. A sibling rather than a member, because `Initialize` presupposes an authenticated user |
| `WorldChooser` | Delegate an app supplies to pick between worlds, consulted only when there is more than one |
| `PlatformUser` · `PlatformSession` · `ExperienceInfo` · `WorldInfo` · `SessionParticipant` · `SessionShard` · `PlatformLaunchData` · `LoginChallenge` | Immutable projections. Constructor-set, get-only |
| `PlatformContextState` · `SessionStatus` · `ExperienceType` · `ParticipantPlatform` · `PlatformPermission` | The enums those carry |

**The assembly definition declares no references and `noEngineReferences: true`.** That is not
tidiness, it is the invariant: a mock must be able to implement these contracts with no network, no
authentication and no platform — and with the asmdef empty, that property is enforced by the
compiler rather than by anyone remembering it. It is also why no member returns a `Texture2D`, a
`Color` or a `UnityEvent`: `WorldInfo` hands back a thumbnail *address*, and every notification is a
plain `event Action`.

## Vocabulary

Three unrelated things were called "session" in the interface these contracts replace, in the same
file. Here they are named apart, and the names are load-bearing:

| Concept | Type | Here |
|---|---|---|
| The session | `int` | `PlatformSession.Id` · `SessionParticipant.SessionId` |
| The realtime connection | `string` | `IPlatformContext.ConnectionId` |
| The authentication session | `string` | `PlatformLaunchData.AuthSessionHash` |

## What is deliberately absent

- **World/game concerns** — avatars, hands, grab, ownership, teleport, camera, sync vars, RPC,
  network spawn, nodes, tasks. They belong to other systems and get their own contracts beside this
  one. `IPlatformContext` must not become the container for everything.
- **The users directory and other sessions' presence.** An app holding those can enumerate the
  tenant.
- **The catalog**, and every CRUD region — sessions, worlds, experiences, assets, tags, leaderboard,
  keys, schedule. Those stay in the Worlds project. The only writes here are the save-data members,
  and they write the caller's own data.
- **`SessionStatus.Expired` / `.Empty`.** They exist server-side and must never reach a client. An
  adapter that meets one has found a leak and should report it, not widen the enum.

## Known issues / TODO

- **`Virtuademy.SDK.Interface.Client` does not exist yet.** The plan puts a second assembly in this
  package — the minimum a creator needs in order to *call* these contracts: transport, request
  building including HMAC, the credential model, the endpoint asset, the publish endpoints, plus an
  editor assembly with the tenant session and the config generator. That content currently lives and
  works as `Virtuademy.SDK.Library` inside `Virtuademy-SDK-Core`, which as of the step-5 refactor is
  already free of the system framework. Moving it here is a relocation and a rename, not new code,
  and it is bundled with the repo pass.
- **Nothing implements `IPlatformContext` yet.** The adapter — the field-level projection from
  `IClientModelSystem` onto these types — is the next step. Until it exists these contracts are
  compiled and unused, which is deliberate: agreeing the surface before writing the projection is
  the whole point of splitting them out.
- **`SessionParticipant` carries no role.** The design sketch said it would, but no role exists
  anywhere in the client models it projects from, so there was nothing to project. Either the
  platform grows one or the member stays out; it was not invented here.
- **`EnableShard(bool)` is unresolved.** A mutation, but on one's own participation — the same
  category as save data, which is in. Left out until decided.
