# Jerarquía de Desarrollo — Elysia

## Regla fundamental

**Nunca iniciar una fase sin que la fase anterior esté completa.**
Si un sistema depende de otro que no existe, el trabajo está bloqueado hasta que ese sistema exista en `develop`.

---

## Mapa de dependencias

```
                        [Fase G — Pulido]
                               ↑
                    [Fase F — Arte definitivo]
                               ↑
         [Fase E — Integración y ensamblaje final]
                               ↑
    [Fase D — Sistemas: Diálogos / Combate / Cinemáticas]
                               ↑
          [Fase C — UI Base + Escenarios completos]
                               ↑
              [Fase B — Player.prefab + Escenarios]   ← EN CURSO
                               ↑
               [Fase A — Core: GameManager + SceneLoader]   ← PENDIENTE
                               ↑
              [Fase 0 — Estructura del proyecto]   ← COMPLETADO
```

---

## Fase 0 — Estructura del proyecto
**Estado: COMPLETADO**
**Rama:** `feature/world` mergeada a `develop`

Todo lo que sigue depende de que esto exista.

- [x] Proyecto Unity creado
- [x] Repositorio Git configurado con todas las ramas
- [x] Estructura de carpetas `Assets/_Game/` creada
- [x] `CONTEXT.md` documentado
- [x] `CLAUDE.md` y sistema de comandos configurado

---

## Fase A — Core del juego
**Estado: PENDIENTE**
**Responsable:** Juan José
**Rama:** `feature/player` o nueva `feature/core`
**Bloquea a:** Todos los demás sistemas

Estos dos scripts son la base de todo. Sin ellos, cada persona inventará su propio sistema de carga de escenas y habrá que refactorizar después.

### Dependencias de entrada
- Fase 0 completada ✓

### Entregables
- [ ] `Assets/_Game/Scripts/Core/GameManager.cs`
  - Singleton persistente (`DontDestroyOnLoad`)
  - Enum `GameState` (MainMenu, Playing, Paused, Combat, Dialogue, GameOver)
  - Propiedad `CurrentState` con getter/setter
- [ ] `Assets/_Game/Scripts/Core/SceneLoader.cs`
  - Método estático `Load(string sceneName)`
  - Método `LoadAsync(string sceneName)` con callback opcional
  - Nunca llamar `SceneManager.LoadScene` directamente fuera de este script
- [ ] Ambos scripts mergeados a `develop`

### Qué desbloquea
Una vez en `develop`: Nicolás puede conectar el menú, el 4to miembro puede cambiar a la escena de combate, Nero puede colocar triggers de salida.

---

## Fase B — Player + Escenarios base
**Estado: EN CURSO**
**Responsables:** Juan José (Player) + Nero (World)
**Ramas:** `feature/player` + `feature/world`
**Pueden ir en paralelo entre sí**

### Dependencias de entrada
- Fase A completada (GameManager + SceneLoader en develop)

### Entregables Juan José
- [x] `PlayerController.cs` — movimiento X/Y/Z con Input System
- [x] `BillboardController.cs` — Quad siempre mira la cámara
- [x] `CameraFollow.cs` — cámara de seguimiento suave
- [ ] `Player.prefab` creado en Unity Editor y commiteado
  - Estructura: `Player (CharacterController) → Visual → Quad (BillboardController)`
  - Material `Player_Mat` asignado al Quad
- [ ] `Mundo_Prototipo.unity` con Player colocado y cámara CameraFollow activa

### Entregables Nero
- [ ] `WorldSetupTool` ejecutado en Unity → `Mundo_Prototipo.unity` generada
- [ ] Escena `Iglesia_Interior.unity` con geometría placeholder
  - Piso, paredes, pilares, cajas
  - Punto de spawn del jugador definido
  - Trigger de salida hacia Iglesia_Exterior
- [ ] `Iglesia_Exterior.unity` con geometría placeholder
  - Zona exterior de la iglesia
  - Área de encuentro con el monstruo (trigger)
- [ ] NavMesh horneado en ambas escenas para IA del enemigo

### Qué desbloquea
Player.prefab en develop: todos pueden colocar al jugador en sus escenas de prueba.
Escenas base en develop: Nicolás puede empezar el menú sabiendo a qué escenas navegar.

---

## Fase C — UI Base + Escenarios completos
**Estado: PENDIENTE**
**Responsables:** Nicolás (UI/Menu) + Nero (escenarios completos)
**Requiere:** Fase B completada

### Dependencias de entrada
- `Player.prefab` en develop
- Al menos `Iglesia_Interior.unity` funcional en develop

### Entregables Nicolás
- [ ] `MainMenu.unity` — pantalla de menú con botón "Nueva Partida"
  - Llama `SceneLoader.Load("Cinematica_Intro")` al pulsar
- [ ] `Assets/_Game/Scripts/UI/UIManager.cs` — muestra/oculta paneles
- [ ] `Assets/_Game/Scripts/UI/HealthBar.cs` — barra de vida UI
- [ ] `Assets/_Game/Prefabs/UI/HealthBar.prefab`

### Entregables Nero
- [ ] NPC placeholder (cilindro) colocado en `Iglesia_Interior`
- [ ] `NPCController.cs` — gira hacia el jugador al acercarse
- [ ] Trigger de combate en `Iglesia_Exterior`
- [ ] Colisiones verificadas en ambas escenas

### Qué desbloquea
Sistema de diálogos (necesita NPC y UI base) y combate (necesita trigger y HealthBar).

---

## Fase D — Sistemas principales
**Estado: PENDIENTE**
**Responsables:** Nicolás (Diálogos + Cinemáticas) + 4to (Combate) + Juan José (PlayerCombat)
**Requiere:** Fase C completada

### Entregables Nicolás
- [ ] `DialogueManager.cs` — avanza líneas, controla flujo
- [ ] `DialogueTrigger.cs` — detecta proximidad del jugador e input E
- [ ] `DialogueData.cs` — ScriptableObject con líneas y hablante
- [ ] `DialogueUI.cs` — panel de texto en pantalla
- [ ] `Cinematica_Intro.unity` con Timeline reproducible
- [ ] Al final del Timeline: `SceneLoader.Load("Iglesia_Interior")`

### Entregables 4to miembro
- [ ] `EnemyAI.cs` — NavMeshAgent, perseguir al jugador, atacar
- [ ] `EnemyStats.cs` — vida, daño (referencias a `EnemyData` ScriptableObject)
- [ ] `EnemyData.cs` — ScriptableObject con valores configurables
- [ ] `EnemySlime.prefab` — geometría placeholder + scripts
- [ ] `CombatManager.cs` — inicia/termina combate, evalúa victoria/derrota

### Entregables Juan José
- [ ] `PlayerStats.cs` — vida actual, referencia a `PlayerData` SO
- [ ] `PlayerData.cs` — ScriptableObject con vida máx, velocidad, daño
- [ ] `PlayerCombat.cs` — ataque, recibir daño, muerte

### Qué desbloquea
Integración final (Fase E): todas las piezas existen, solo hay que ensamblarlas.

---

## Fase E — Integración
**Estado: PENDIENTE**
**Responsable:** Juan José (coordinación) + todos
**Requiere:** Fase D completada

- [ ] `GameOver.unity` — pantalla victoria/derrota con botón reintentar
- [ ] Flujo completo: MainMenu → Cinematica → Interior → Exterior → Combate → GameOver
- [ ] Sin errores de consola críticos en el flujo completo
- [ ] Escena `Mundo_Prototipo.unity` reemplazada por escenas oficiales

---

## Fase F — Reemplazo de placeholders
**Estado: PENDIENTE**
**Requiere:** Fase E completada y aprobada

- [ ] Personaje principal (Blender → fbx → Unity)
- [ ] NPC sacerdote
- [ ] Monstruo
- [ ] Iglesia interior y exterior
- [ ] Animaciones: idle, walk, attack, interact
- [ ] Menú y UI definitivos

---

## Fase G — Pulido
**Estado: PENDIENTE**
**Requiere:** Fase F completada

- [ ] Sonidos y música
- [ ] Optimización (60fps estables en PC objetivo)
- [ ] Corrección de bugs finales
- [ ] Ajuste de valores de combate y diálogos
- [ ] Build final de PC

---

## Regla de bloqueo

Si al ejecutar `/enrich_us` o `/ff` se detecta que la feature requiere algo de una fase superior no completada, Claude debe:
1. Indicar exactamente qué está bloqueando
2. Señalar qué fase/entregable debe completarse primero
3. No proceder con la implementación hasta que el bloqueo se resuelva
