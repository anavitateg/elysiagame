# Version Tracker — Elysia

> Fuente de verdad del estado del proyecto. Actualizar con `/archive` al cerrar cada feature.
> Última actualización: 2026-06-20

---

## Estado actual por fase

| Fase | Nombre | Estado |
|---|---|---|
| 0 | Estructura del proyecto | ✅ COMPLETADO |
| A | Core: GameManager + SceneLoader | ⏳ PENDIENTE |
| B | Player + Escenarios base | 🔄 EN CURSO |
| C | UI Base + Escenarios completos | ⏳ PENDIENTE |
| D | Diálogos + Combate + Cinemáticas | ⏳ PENDIENTE |
| E | Integración final | ⏳ PENDIENTE |
| F | Arte definitivo | ⏳ PENDIENTE |
| G | Pulido | ⏳ PENDIENTE |

---

## Fase 0 — Estructura del proyecto ✅

**Cerrado:** 2026-06-20
**Rama:** `feature/world` mergeada a `develop`
**Commits:** `9a2a75e`, `498646c`, `6e4bce2`

### Completado
- [x] Proyecto Unity 6000.5.0f1 creado con URP 17.5
- [x] Repositorio GitHub configurado: `anavitateg/elysiagame`
- [x] Ramas creadas: main, develop, feature/menu, feature/player, feature/combat, feature/dialogues, feature/world, feature/cinematics
- [x] Estructura de carpetas `Assets/_Game/` con todas las subcarpetas
- [x] `CONTEXT.md` — documento de arquitectura y contexto general
- [x] `CLAUDE.md` — instrucciones del asistente
- [x] `.claude/context/` — archivos de contexto del proyecto
- [x] `.claude/commands/` — comandos personalizados del flujo de trabajo

---

## Fase A — Core ⏳

**Estado:** PENDIENTE
**Responsable:** Juan José
**Rama:** `feature/player`
**Bloquea a:** Nicolás (menú), 4to (combate), Nero (triggers de escena)

### Pendiente
- [ ] `GameManager.cs` (Singleton, enum GameState, DontDestroyOnLoad)
- [ ] `SceneLoader.cs` (Load, LoadAsync, wrapper único de SceneManager)
- [ ] PR y merge a `develop`

---

## Fase B — Player + Escenarios base 🔄

**Estado:** EN CURSO
**Responsables:** Juan José + Nero
**Ramas:** `feature/player` + `feature/world`

### Juan José — feature/player
- [x] `PlayerController.cs` — movimiento X/Z + salto Y con CharacterController
- [x] `BillboardController.cs` — Quad rota para mirar a la cámara siempre
- [x] `CameraFollow.cs` — cámara suave con offset y LookAt
- [ ] Ejecutar `WorldSetupTool` en Unity → genera `Mundo_Prototipo.unity`
- [ ] Crear `Player.prefab` en Unity Editor
  - GameObject raíz: CharacterController + PlayerController
  - Hijo Visual → Quad (escala 1,1.5,1) + BillboardController + Player_Mat
- [ ] Colocar `Player.prefab` en `Mundo_Prototipo.unity` pos(0,0.5,2)
- [ ] Reemplazar cámara estática por cámara con `CameraFollow` referenciando Player
- [ ] Probar: WASD mueve, Space salta, cámara sigue, Quad mira a cámara
- [ ] Commit y push `feature/player`
- [ ] PR `feature/player` → `develop`

### Nero — feature/world
- [x] `WorldSetupTool.cs` — genera materiales y escena automáticamente
- [ ] Ejecutar `WorldSetupTool` en Unity → revisar que la escena se ve correcta
- [ ] `Iglesia_Interior.unity` — geometría placeholder lista
- [ ] `Iglesia_Exterior.unity` — geometría placeholder lista
- [ ] Trigger de salida en Iglesia_Interior (hacia Exterior)
- [ ] Trigger de encuentro en Iglesia_Exterior (activa combate)
- [ ] NavMesh horneado en ambas escenas
- [ ] Commit y push `feature/world`
- [ ] PR `feature/world` → `develop`

---

## Fase C — UI Base + Escenarios completos ⏳

**Estado:** PENDIENTE — bloqueada hasta que Fase A y B estén en develop

### Nicolás — feature/menu
- [ ] `MainMenu.unity`
- [ ] `UIManager.cs`
- [ ] `HealthBar.cs` + `HealthBar.prefab`
- [ ] PR → develop

### Nero — feature/world (continuación)
- [ ] NPC placeholder en Iglesia_Interior + `NPCController.cs`
- [ ] PR → develop

---

## Fase D — Sistemas principales ⏳

**Estado:** PENDIENTE — bloqueada hasta que Fase C esté en develop

### Nicolás — feature/dialogues
- [ ] `DialogueManager.cs`
- [ ] `DialogueTrigger.cs`
- [ ] `DialogueData.cs` (ScriptableObject)
- [ ] `DialogueUI.cs`

### Nicolás — feature/cinematics
- [ ] `Cinematica_Intro.unity` con Timeline

### Juan José — feature/player (continuación)
- [ ] `PlayerStats.cs`
- [ ] `PlayerData.cs` (ScriptableObject)
- [ ] `PlayerCombat.cs`

### 4to miembro — feature/combat
- [ ] `EnemyAI.cs`
- [ ] `EnemyStats.cs`
- [ ] `EnemyData.cs` (ScriptableObject)
- [ ] `CombatManager.cs`
- [ ] `EnemySlime.prefab`

---

## Fase E — Integración ⏳

**Estado:** PENDIENTE

- [ ] `GameOver.unity`
- [ ] Flujo completo sin errores
- [ ] PR → main (primer hito)

---

## Fase F — Arte ⏳ | Fase G — Pulido ⏳

Sin fecha estimada hasta completar Fase E.

---

## Historial de features cerradas

| Feature | Rama | Fecha cierre | Responsable |
|---|---|---|---|
| Estructura del proyecto | feature/world | 2026-06-20 | Juan José |

---

## Notas técnicas importantes

- El `.inputactions` en `Assets/InputSystem_Actions.inputactions` ya tiene mapeados `Move` (WASD/stick) y `Jump` (Space/botón sur) — no modificar
- El `WorldSetupTool` genera una Plane con escala (0.85, 1, 1.2) = 8.5×12 unidades (la primitiva Plane de Unity es 10×10 a escala 1)
- Los Cylinders de pilares tienen escala (0.4, 1.5, 0.4) → 0.4u diámetro, 3u alto, centro en Y=1.5 → base en Y=0
- El shader URP Lit se referencia como `"Universal Render Pipeline/Lit"` en código
