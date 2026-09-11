# Virtuademy-SDK-Core

The platform-context contracts. This is the one point where the creator graph and the external-app
graph meet: a creator installs `SPACS-*` + this + `Environments`, an external app developer installs
`SPACS-Utility` + this + `Library`, and the platform installs everything.

## What is here today

One assembly, `Virtuademy.SDK.Core` (the namespace inside it is still `Virtuademy.SDK.Interface`):

| Type | Role |
|---|---|
| `IPlatformContext` | Platform and session state as an app sees it — identity, session, experience, world, permissions, participants, shards, the caller's own save data |
| `IPlatformAuthentication` | Sign-in. A sibling rather than a member, because `Initialize` presupposes an authenticated user |
| `WorldChooser` | Delegate an app supplies to pick between publications, consulted only when there is more than one |
| `PlatformContextState` · `PlatformPermission` · `PlatformLaunchData` · `LoginChallenge` · `SessionShard` | The five types this contract still declares itself — see below |

`IPlatformContext` hands back the platform's **own wire types** — `UserDTO`, `SessionDTO`,
`WorldDTO`, `ExperienceDTO`, `OnlineUserDTO`, and the placements a chooser picks from. It does not
mirror them.

## Why it names the DTOs, and why it used to mirror them

An earlier version of this package declared a parallel set of value types — `PlatformUser`,
`PlatformSession` and six more — with a projection mapping each DTO onto its twin. The argument was
the perimeter: naming `SessionDTO` would make this assembly reference the one holding the platform
client, and a creator installing these contracts would get the client along with them.

That argument held only because the DTOs and the client shared an assembly, which was an accident of
layout rather than a necessity. **They no longer do.** The DTOs are `Virtuademy.SDK.ApiData.Wire`
— data and nothing else — while the transport, the credential and the sixty endpoints stay in
`Virtuademy.SDK.ApiData`, which nothing here names. The perimeter the plan calls invariant 4a,
*no transport and no credential in the contracts*, holds with no mirrored type at all.

The mirror's cost was paid before it came out: four members had to be dropped for having no wire
source, two types had to be renamed for colliding with the DTO family they duplicated, and every
field added to a DTO would have had to be added twice. What it bought that was worth keeping is
immutability — so the five DTOs this contract returns are **read-only**, and the single place in the
project that wrote to one was changed to stop.

**One property was given up with it.** The assembly used to declare no references and
`noEngineReferences: true`, which let the contracts be compiled outside Unity — a real check that
caught mistakes twice. The DTOs carry `[SerializeField]`, so that is gone. Mockability survives
(a mock still needs no network, no auth and no platform); the standalone compile is now done with a
small stub harness around the adapter instead.

## The five types this contract still declares

Each one is here because there is nothing to name, not because a twin was preferred:

- **`PlatformPermission`** — the wire form is a bare **string**. There is no DTO, and a caller
  cannot be handed raw text and expected to compare it correctly. **Its member names are the wire
  contract**: they are parsed case-sensitively, so renaming one silently stops granting that
  permission. That is not hypothetical — the leaderboard member was singular where the platform's
  identifier is plural, and that permission had never resolved in any client until it was measured.
- **`SessionShard`** — its wire form lives in the realtime package beside the WebSocket client, so
  naming it would pull transport into these contracts.
- **`PlatformContextState`**, **`PlatformLaunchData`**, **`LoginChallenge`** — concepts of this
  contract with no wire counterpart at all.

## Vocabulary

Three unrelated things were called "session" in the interface these contracts replace, in the same
file. Here they are named apart on the interface members, which is where the naming lives:

| Concept | Type | Here |
|---|---|---|
| The session | `int` | `Session.Id` |
| The realtime connection | `string` | `IPlatformContext.ConnectionId` |
| The authentication session | `string` | `PlatformLaunchData.AuthSessionHash` |

## What is deliberately absent

- **World/game concerns** — avatars, hands, grab, ownership, teleport, camera, sync vars, RPC,
  network spawn, nodes, tasks. They belong to other systems and get their own contracts beside this
  one. `IPlatformContext` must not become the container for everything.
- **The users directory and other sessions' presence.** An app holding those can enumerate the
  tenant.
- **The catalog**, and every CRUD region. The only writes here are the save-data members, and they
  write the caller's own data.
- **`ESessionStatus.Expired` / `.Empty` reaching a caller.** They exist on the wire and are
  server-side bookkeeping. With the enum returned as-is there is no mapping step to filter them, so
  the adapter checks explicitly and **refuses** such a session rather than relabelling it — which is
  what the conversion it replaces did, reporting both as `Persistent`.

## Known issues / TODO

- **`PlatformContext` in `Virtuademy-SDK-RealtimeApi` implements these, and nothing calls it yet.**
  It is complete — `Initialize`, the state machine, permission joining, participant diffing, shards
  and save data — but the Worlds app keeps its own boot: `AppManager` is untouched. First real
  exercise will be an external app, or a deliberate migration of `AppManager` onto it.
- **`Initialize`'s standalone path needs `GET /external-app/worlds`**, which is implemented only on
  a feature branch of the Application API. Verified working against a locally-run one; deployed
  nowhere.
- **`SessionParticipant` carried no role and no longer exists as a type.** The design sketch had
  one; no role exists anywhere in the DTOs, so there was nothing to project and none was invented.
  A caller now gets `OnlineUserDTO`, which is what the platform actually sends.
