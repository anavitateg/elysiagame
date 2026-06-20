# Elysia — Documento de Contexto General

> Referencia única del equipo. Toda decisión de arquitectura, nomenclatura y flujo de trabajo debe consultarse aquí antes de escribir código o crear assets.

---

## 1. Ficha del Proyecto

| Campo | Valor |
|---|---|
| Nombre | Elysia |
| Género | RPG de acción / narrativo |
| Plataforma objetivo | PC (Windows) |
| Engine | Unity 6000.5.0f1 (Unity 6 LTS) |
| Pipeline de render | Universal Render Pipeline (URP) 17.5.0 |
| Arte 3D | Blender |
| Control de versiones | Git + GitHub |
| Gestión de tareas | Trello |
| IDEs | Visual Studio Code / Rider |
| Repositorio | https://github.com/anavitateg/elysiagame |

---

## 2. Objetivo del Primer Prototipo

Construir una demo jugable completa que valide todas las mecánicas principales. Durante esta fase se utilizarán **modelos temporales** (cubos, cápsulas, cilindros, placeholders) hasta confirmar que cada sistema funciona correctamente.

### Flujo completo de la demo

```
[Menú Principal]
       ↓ Iniciar Partida
[Cinemática de Introducción]
       ↓
[Iglesia — Interior]
  • El jugador puede moverse
  • El jugador puede hablar con el NPC
       ↓ Salir de la iglesia
[Iglesia — Exterior]
  • El jugador encuentra un monstruo
  • Se activa el combate
       ↓
[Sistema de Combate]
  • Barras de vida visibles
  • El monstruo puede atacar
  • El jugador puede atacar
       ↓
  [Victoria] → Pantalla de resultado
  [Derrota]  → Game Over / Reintentar
```

### Requisitos mínimos del prototipo

- [ ] Menú principal funcional con botón de inicio
- [ ] Cinemática reproducible (Timeline)
- [ ] Movimiento de personaje en 3D con colisiones
- [ ] Cámara que sigue al jugador
- [ ] Sistema de diálogos con NPC
- [ ] Transición entre escenas (interior ↔ exterior)
- [ ] Detección de encuentro con monstruo
- [ ] Sistema de combate por turnos o en tiempo real (a definir en Etapa 2)
- [ ] Barras de vida para jugador y enemigo
- [ ] IA básica del enemigo (acercarse y atacar)
- [ ] Condición de victoria y derrota
- [ ] Todo lo anterior funcionando con primitivas geométricas

---

## 3. Stack Tecnológico

### Unity 6 LTS + URP 17.5

- Proyecto configurado con perfiles de calidad **Mobile** y **PC** (útil para ajustar rendimiento)
- Input System moderno (no el Input Manager legacy) ya configurado en `Assets/InputSystem_Actions.inputactions`
- AI Navigation (NavMesh) instalado — se usará para la IA del enemigo
- Timeline instalado — se usará para las cinemáticas

### Blender

- Versión recomendada: 4.x LTS
- Formato de exportación: `.fbx` para Unity, `.blend` como fuente
- Convención de escala: aplicar todas las transformaciones antes de exportar (`Ctrl+A → All Transforms`)
- Origen del objeto: centrado en la base del personaje/objeto

### Git + GitHub

- Repositorio: `https://github.com/anavitateg/elysiagame`
- `.gitattributes` ya configurado para manejar archivos binarios de Unity correctamente
- Ver sección 8 para el flujo de trabajo completo

---

## 4. Equipo y Responsabilidades

| Miembro | Área principal | Sistemas |
|---|---|---|
| **Nicolás** | Programación UI / Narrativa | Menú, carga de escenas, diálogos, cinemáticas, UI |
| **Juan José** | Programación Jugador / Core | Movimiento, cámara, atributos, barra de vida, flujo narrativo |
| **Nero** | Escenarios / World | Iglesia interior, iglesia exterior, colisiones, navegación |
| **Persona adicional** | Enemigo / Combate | Sistema base del monstruo, detección, IA básica |

---

## 5. Etapas de Desarrollo

### Etapa 1 — Organización del Proyecto
**Responsables:** Todos | **Estado:** En curso

| Tarea | Responsable | Estado |
|---|---|---|
| Crear proyecto Unity | Juan José | Hecho |
| Crear repositorio Git | Juan José | Hecho |
| Configurar ramas | Juan José | Hecho |
| Definir estructura de carpetas | Todos | Hecho |
| Definir flujo de Pull Requests | Todos | Hecho |
| Definir nomenclatura de scripts | Todos | Hecho |
| Crear tablero Trello | Todos | Pendiente |

**Resultado esperado:** Todos pueden trabajar simultáneamente sin conflictos.

---

### Etapa 2 — Prototipo Técnico
**Responsables:** Todos

Objetivo: el juego funciona de principio a fin aunque todo sea visualmente simple.

| Tarea | Responsable |
|---|---|
| Menú principal | Nicolás |
| Sistema de carga de escenas | Nicolás |
| Sistema de diálogos | Nicolás |
| Sistema de cinemáticas | Nicolás |
| UI inicial (barras, paneles) | Nicolás |
| Movimiento del personaje | Juan José |
| Cámara | Juan José |
| Sistema de atributos | Juan José |
| Barra de vida | Juan José |
| Flujo narrativo inicial | Juan José |
| Escenario Iglesia Interior (placeholder) | Nero |
| Escenario Iglesia Exterior (placeholder) | Nero |
| Colisiones y navegación | Nero |
| Sistema base del monstruo | Persona adicional |
| Detección de combate | Persona adicional |
| IA básica | Persona adicional |

**Resultado esperado:** Demo completa jugable usando únicamente figuras geométricas.

---

### Etapa 3 — Mecánicas Completas
**Responsables:** Todos

| Tarea |
|---|
| Combate funcional con daño y vida |
| Interacción NPC completa |
| Cambio entre escenarios fluido |
| Cinemática funcional con Timeline |
| Sistema de victoria y derrota |

**Resultado esperado:** Demo completamente jugable y balanceada.

---

### Etapa 4 — Reemplazo de Placeholders
**Responsables:** Todos

| Área | Tarea |
|---|---|
| Arte | Personaje principal, NPC, Monstruo, Iglesia interior y exterior |
| Animación | Movimiento, ataque, idle, interacción |
| UI | Menú definitivo, barras de vida definitivas |

**Resultado esperado:** La demo jugable ahora tiene apariencia visual propia.

---

### Etapa 5 — Pulido
**Responsables:** Todos

| Tarea |
|---|
| Corrección de errores |
| Optimización de rendimiento |
| Sonidos y música |
| Ajuste de combate |
| Ajuste de diálogos |
| Ajuste de cámaras |

**Resultado esperado:** Versión demostrable del proyecto.

---

## 6. Arquitectura del Proyecto

### 6.1 Estructura de Carpetas

Toda la lógica del juego vive dentro de `Assets/_Game/` para separarse del contenido del template de Unity.

```
Assets/
├── _Game/
│   ├── Animations/          # Clips .anim y Animator Controllers
│   │   ├── Player/
│   │   ├── Enemy/
│   │   └── NPC/
│   ├── Audio/               # AudioClips y AudioMixer
│   │   ├── Music/
│   │   └── SFX/
│   ├── Fonts/               # Fuentes tipográficas
│   ├── Materials/           # Materials URP
│   │   ├── Characters/
│   │   ├── Environment/
│   │   └── UI/
│   ├── Models/              # Meshes importados desde Blender (.fbx)
│   │   ├── Characters/
│   │   ├── Environment/
│   │   └── Props/
│   ├── Prefabs/             # GameObjects prefabricados
│   │   ├── Characters/
│   │   ├── Combat/
│   │   ├── Environment/
│   │   ├── UI/
│   │   └── VFX/
│   ├── Scenes/              # Archivos .unity
│   │   ├── MainMenu.unity
│   │   ├── Cinematica_Intro.unity
│   │   ├── Iglesia_Interior.unity
│   │   ├── Iglesia_Exterior.unity
│   │   └── GameOver.unity
│   ├── ScriptableObjects/   # Assets de datos (instancias de SO)
│   │   ├── Characters/
│   │   ├── Dialogues/
│   │   └── Items/
│   ├── Scripts/             # Todo el código C#
│   │   ├── Combat/
│   │   ├── Core/
│   │   ├── Dialogue/
│   │   ├── Enemy/
│   │   ├── Player/
│   │   ├── UI/
│   │   └── World/
│   ├── Shaders/             # Shaders y Shader Graphs URP
│   ├── Sprites/             # Texturas 2D para UI
│   └── VFX/                 # Visual Effect Graph / Particle Systems
├── Settings/                # Existente — configuración URP
└── TutorialInfo/            # Existente — se puede eliminar tras el setup inicial
```

### 6.2 Arquitectura de Escenas

| Escena | Responsable | Contenido |
|---|---|---|
| `MainMenu` | Nicolás | Canvas menú, botones, fondo |
| `Cinematica_Intro` | Nicolás | Timeline con cámara y subtítulos |
| `Iglesia_Interior` | Nero | Placeholder iglesia, NPC, trigger de salida |
| `Iglesia_Exterior` | Nero | Placeholder exterior, trigger de enemigo |
| `GameOver` | Juan José / Nicolás | Pantalla victoria/derrota, botón reintentar |

**Convención de nombres de escena:** `PascalCase` sin espacios.

**Carga de escenas:** Siempre a través de `SceneLoader` (ver 6.3). Nunca llamar `SceneManager.LoadScene()` directamente desde scripts de gameplay.

### 6.3 Sistemas Core

#### GameManager (Singleton persistente)
```
Elysia.Core.GameManager
```
- Persiste entre escenas (`DontDestroyOnLoad`)
- Responsable del estado global: `GameState` (MainMenu, Playing, Combat, Paused, GameOver)
- Referencia central para acceder a otros managers
- No contiene lógica de gameplay, solo orquesta

#### SceneLoader
```
Elysia.Core.SceneLoader
```
- Wrapper sobre `SceneManager` con soporte para pantalla de carga
- Métodos: `LoadScene(string name)`, `LoadSceneAsync(string name)`
- Emite eventos al iniciar y terminar la carga

#### EventManager
```
Elysia.Core.EventManager
```
- Bus de eventos global usando `System.Action` (delegates C#)
- Desacopla sistemas: el sistema de combate no necesita saber nada del UI
- Ejemplos de eventos: `OnPlayerDamaged`, `OnEnemyDead`, `OnDialogueStart`, `OnSceneLoaded`

#### ScriptableObjects de datos
Separar datos de lógica. Los stats NO van hardcodeados en los scripts.

```
Elysia.Core.Data
├── PlayerData.cs       → vida máx, velocidad, daño base
├── EnemyData.cs        → vida máx, velocidad, daño, agro range
└── DialogueData.cs     → array de líneas, nombre del hablante
```

### 6.4 Sistemas por Feature

#### Player (`Elysia.Player`)
```
PlayerController.cs     → movimiento con Input System (CharacterController)
PlayerStats.cs          → vida actual, referencia a PlayerData SO
PlayerCombat.cs         → ataque, recepción de daño, muerte
PlayerStateMachine.cs   → estados: Idle, Walk, Run, Combat, Dialogue, Dead
```

#### Enemy (`Elysia.Enemy`)
```
EnemyAI.cs              → NavMeshAgent, detección del jugador, persecución
EnemyStats.cs           → vida actual, referencia a EnemyData SO
EnemyCombat.cs          → ataque, recepción de daño, muerte
EnemyStateMachine.cs    → estados: Idle, Chase, Attack, Dead
```

#### Combat (`Elysia.Combat`)
```
CombatManager.cs        → inicia/termina combate, turno (si es por turnos), resultado
DamageSystem.cs         → cálculo de daño, aplicación a stats
HitDetection.cs         → colliders de ataque, triggers
```

#### Dialogue (`Elysia.Dialogue`)
```
DialogueManager.cs      → avance de líneas, control del flujo
DialogueTrigger.cs      → componente en el NPC, detecta input de interacción
DialogueData.cs         → ScriptableObject con líneas y nombre
```

#### UI (`Elysia.UI`)
```
UIManager.cs            → muestra/oculta paneles
HealthBar.cs            → barra de vida, se suscribe a OnPlayerDamaged / OnEnemyDead
DialogueUI.cs           → panel de texto de diálogo
MainMenuUI.cs           → botones del menú
GameOverUI.cs           → pantalla de victoria/derrota
```

#### World (`Elysia.World`)
```
SceneTrigger.cs         → trigger para cambio de escena (puerta, umbral)
NPCController.cs        → idle, orientarse al jugador al hablar
CameraController.cs     → seguimiento del jugador (Cinemachine recomendado)
```

### 6.5 Patrones de Diseño Utilizados

| Patrón | Dónde se aplica | Por qué |
|---|---|---|
| **Singleton** | GameManager, SceneLoader, EventManager | Acceso global único, persiste entre escenas |
| **Observer / Evento** | EventManager + todos los sistemas | Desacoplamiento; UI no depende de Combat |
| **State Machine** | Player, Enemy | Comportamiento claro y extensible |
| **ScriptableObject** | PlayerData, EnemyData, DialogueData | Separar datos de lógica; fácil de editar en Inspector |
| **Command** | Sistema de combate (futuro) | Facilita deshacer/rehacer acciones |

---

## 7. Namespaces

Todos los scripts deben declarar su namespace al inicio del archivo:

```csharp
namespace Elysia.Core { }       // GameManager, SceneLoader, EventManager
namespace Elysia.Player { }     // PlayerController, PlayerStats, PlayerCombat
namespace Elysia.Enemy { }      // EnemyAI, EnemyStats, EnemyCombat
namespace Elysia.Combat { }     // CombatManager, DamageSystem, HitDetection
namespace Elysia.Dialogue { }   // DialogueManager, DialogueTrigger, DialogueData
namespace Elysia.UI { }         // UIManager, HealthBar, DialogueUI
namespace Elysia.World { }      // SceneTrigger, NPCController, CameraController
```

---

## 8. Infraestructura Git

### Modelo de ramas

```
main
  └── develop
        ├── feature/menu
        ├── feature/player
        ├── feature/combat
        ├── feature/dialogues
        ├── feature/world
        └── feature/cinematics
```

### Reglas

1. **Nunca hacer push directo** a `main` ni a `develop`
2. Todo desarrollo ocurre en una rama `feature/*`
3. `feature/*` → PR a `develop` (requiere **1 aprobación** de otro miembro)
4. `develop` → PR a `main` solo al **finalizar una etapa completa**
5. Resolver conflictos en la rama `feature/*` antes de hacer PR, no en `develop`

### Flujo de trabajo diario

```bash
# Antes de empezar a trabajar
git checkout develop
git pull origin develop
git checkout feature/mi-rama
git rebase develop          # O merge, según prefieran

# Al terminar una sesión
git add <archivos específicos>
git commit -m "feat(player): add walk animation controller"
git push origin feature/mi-rama
```

### Convención de commits

Formato: `tipo(scope): descripción en inglés, imperativo, minúsculas`

| Tipo | Cuándo usarlo |
|---|---|
| `feat` | Nueva funcionalidad |
| `fix` | Corrección de bug |
| `chore` | Tareas de mantenimiento (configuración, estructura) |
| `docs` | Cambios en documentación |
| `refactor` | Refactorización sin cambio de funcionalidad |
| `art` | Adición o modificación de assets (modelos, texturas) |
| `anim` | Animaciones |
| `ui` | Cambios de interfaz de usuario |

**Ejemplos:**
```
feat(player): add movement controller with input system
fix(combat): correct damage not applying on first hit
chore(setup): configure _Game folder structure
art(environment): add church interior placeholder meshes
docs(context): update architecture section
```

### Archivos a nunca commitear

Ya están en `.gitignore`, pero recordar:
- `Library/` — se regenera automáticamente
- `Temp/` — temporal
- `UserSettings/` — configuración personal del editor
- `*.csproj`, `*.sln` — se regeneran

---

## 9. Nomenclatura

### Scripts C#

| Tipo | Convención | Ejemplo |
|---|---|---|
| Clase MonoBehaviour | `PascalCase` + sufijo descriptivo | `PlayerController.cs` |
| ScriptableObject | `PascalCase` + `Data` | `PlayerData.cs` |
| Manager | `PascalCase` + `Manager` | `CombatManager.cs` |
| UI Component | `PascalCase` + `UI` o `Panel` | `DialogueUI.cs` |
| State Machine | `PascalCase` + `StateMachine` | `EnemyStateMachine.cs` |
| Interface | `I` + `PascalCase` | `IDamageable.cs` |
| Enum | `PascalCase` | `GameState.cs` |

### Assets y Prefabs

| Tipo | Convención | Ejemplo |
|---|---|---|
| Prefab | `PascalCase` | `PlayerCharacter.prefab` |
| Material | `PascalCase` + `_Mat` | `Church_Wall_Mat.mat` |
| Texture | `PascalCase` + `_Tex` o sufijo de tipo | `Player_Diffuse_Tex.png` |
| Animation Clip | `PascalCase` + acción | `Player_Walk.anim` |
| Animator Controller | `PascalCase` + `AC` | `Player_AC.controller` |
| ScriptableObject asset | `PascalCase` + tipo | `PlayerData_Default.asset` |
| Escena | `PascalCase` | `Iglesia_Interior.unity` |

### GameObjects en escena

`PascalCase` con guion bajo como separador de contexto:
- `Player_Character`
- `Enemy_Slime_01`
- `NPC_Priest`
- `Trigger_ExitChurch`
- `UI_HealthBar`

---

## 10. Paquetes Unity Instalados

| Paquete | Versión | Uso en el proyecto |
|---|---|---|
| Universal Render Pipeline | 17.5.0 | Pipeline de render principal |
| Input System | 1.19.0 | Movimiento del jugador, interacciones |
| AI Navigation | 2.0.13 | NavMesh para IA del enemigo |
| Timeline | 1.8.12 | Cinemáticas |
| UI Toolkit (UGUI) | 2.5.0 | Menú, HUD, diálogos |
| Visual Scripting | 1.9.11 | Opcional para prototipar lógica rápida |
| Test Framework | 1.7.0 | Tests unitarios (sistemas de stats, daño) |
| Collab Proxy | 2.12.4 | Integración Unity Version Control (opcional) |

**Paquetes recomendados para añadir:**

| Paquete | Por qué |
|---|---|
| Cinemachine | Cámara de seguimiento profesional con poco código |
| TextMeshPro | Texto de alta calidad para UI de diálogos |

Para instalar: `Window → Package Manager → Unity Registry`

---

## 11. Verificación por Etapa

### Checklist Etapa 1
- [ ] Todos pueden clonar el repo y abrir el proyecto en Unity sin errores
- [ ] Todos pueden crear una rama `feature/*`, hacer un commit y abrir un PR
- [ ] La estructura de carpetas `Assets/_Game/` existe
- [ ] El tablero de Trello tiene las tareas de la Etapa 2 creadas

### Checklist Etapa 2
- [ ] Ejecutar la escena `MainMenu` → pulsar Play → inicia la cinemática
- [ ] La cinemática termina y carga `Iglesia_Interior`
- [ ] El jugador (cápsula) se mueve con WASD/joystick
- [ ] Al acercarse al NPC (cubo) y pulsar `E`, aparece el diálogo
- [ ] Al salir por la puerta, carga `Iglesia_Exterior`
- [ ] Al acercarse al enemigo (cubo rojo), se activa el combate
- [ ] Aparecen barras de vida en pantalla
- [ ] El enemigo se mueve hacia el jugador y ataca
- [ ] El jugador puede atacar y bajar la vida del enemigo
- [ ] Al llegar a 0 de vida uno de los dos, se muestra la pantalla de resultado

### Checklist Etapa 3
- [ ] El flujo completo no tiene errores de consola críticos
- [ ] Los valores de daño y vida están balanceados para una demo de ~3 minutos
- [ ] Todas las transiciones de escena funcionan en ambas direcciones

### Checklist Etapa 4
- [ ] Ningún placeholder geométrico visible en la build final
- [ ] Todas las animaciones están conectadas a los Animator Controllers

### Checklist Etapa 5
- [ ] La build de PC corre a 60fps estables
- [ ] No hay errores ni warnings críticos en consola
- [ ] Audio de fondo y efectos de sonido presentes en todas las escenas

---

## 12. Decisiones Pendientes

Estos puntos deben resolverse al inicio de la Etapa 2:

| Decisión | Opciones | Responsable |
|---|---|---|
| Tipo de combate | Tiempo real vs. por turnos | Todos |
| Tipo de cámara | Top-down, tercera persona, isométrica | Juan José |
| Sistema de diálogos | Manual (propio) vs. paquete externo (Dialogue System, Yarn Spinner) | Nicolás |
| ¿Usar Cinemachine? | Sí (recomendado) / No (CameraController manual) | Juan José |

---

*Última actualización: Etapa 1 — Organización del Proyecto*
*Este documento debe actualizarse al inicio de cada nueva etapa.*
