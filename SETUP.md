# SETUP — Cómo unirse al proyecto Elysia: Descent

> Esta guía lleva a cualquier miembro del equipo desde cero hasta tener el proyecto funcionando en su PC y trabajando en su área específica.

---

## Índice

1. [Software que necesitas instalar](#1-software-que-necesitas-instalar)
2. [Clonar el repositorio](#2-clonar-el-repositorio)
3. [Configurar Git en tu PC](#3-configurar-git-en-tu-pc)
4. [Inicializar el proyecto en Unity](#4-inicializar-el-proyecto-en-unity)
5. [Verificar que todo funciona](#5-verificar-que-todo-funciona)
6. [Guía específica por miembro del equipo](#6-guía-específica-por-miembro-del-equipo)

---

## 1. Software que necesitas instalar

### Todos los miembros

| Software | Versión | Descarga | Para qué |
|---|---|---|---|
| **Unity Hub** | Última | [unity.com/download](https://unity.com/download) | Gestor de versiones de Unity |
| **Unity Editor** | **6000.5.0f1** ← exacta | Desde Unity Hub | Engine del juego |
| **Git** | Última | [git-scm.com](https://git-scm.com) | Control de versiones |
| **Visual Studio Code** | Última | [code.visualstudio.com](https://code.visualstudio.com) | Editor de código |

> ⚠️ **La versión de Unity debe ser exactamente `6000.5.0f1`.** Si abres el proyecto con una versión diferente, Unity lo migrará automáticamente y generará conflictos para todo el equipo.

### Cómo instalar la versión correcta de Unity

1. Instala **Unity Hub** primero
2. Abre Unity Hub → pestaña **Installs** → botón `Install Editor`
3. Busca la versión `6000.5.0f1` (puede aparecer como **Unity 6.0.5**)
4. En los módulos adicionales, marca:
   - ✅ `Windows Build Support (IL2CPP)` — para hacer builds de PC
   - ✅ `Visual Studio Code Editor` — integración con VSCode

### Solo Nero (arte y escenarios)

| Software | Versión | Descarga |
|---|---|---|
| **Blender** | 4.x LTS | [blender.org](https://blender.org) |

---

## 2. Clonar el repositorio

El repositorio es **público**, así que cualquier persona puede clonarlo directamente sin necesitar cuenta de GitHub ni contraseña.

Abre una terminal (PowerShell, Git Bash o la terminal de tu sistema) y ejecuta:

```bash
git clone https://github.com/anavitateg/elysiagame.git
```

Si quieres elegir dónde se guarda la carpeta:

```bash
git clone https://github.com/anavitateg/elysiagame.git "C:\Users\TuNombre\Desktop\elysiagame"
```

Cuando termine tendrás la carpeta `elysiagame` con todo el proyecto listo.

> **¿Prefieres interfaz visual?** Puedes usar **GitHub Desktop** ([desktop.github.com](https://desktop.github.com)):
> `File → Clone repository → URL` → pega `https://github.com/anavitateg/elysiagame` → Clone

---

## 3. Configurar Git en tu PC

Aunque el repo es público para leer y clonar, para **subir tus cambios (push)** necesitas identificarte. Esto se hace una sola vez.

### 3.1 Configurar tu nombre y correo

Abre la terminal y ejecuta estas dos líneas con tus datos:

```bash
git config --global user.name "Tu Nombre"
git config --global user.email "tuemail@ejemplo.com"
```

Usa el mismo email que tienes registrado en tu cuenta de GitHub.

### 3.2 Que Juan José te agregue como colaborador

Para poder hacer push necesitas permiso de escritura. Juan José debe:

1. Entrar a `https://github.com/anavitateg/elysiagame`
2. Ir a **Settings → Collaborators → Add people**
3. Escribir tu nombre de usuario de GitHub
4. Tú recibirás un email de invitación → **debes aceptarla**

### 3.3 Configurar tu contraseña para el push

La primera vez que hagas `git push`, GitHub te pedirá autenticación. La forma más simple:

1. Ve a GitHub → tu foto de perfil → **Settings**
2. Baja hasta **Developer settings → Personal access tokens → Tokens (classic)**
3. **Generate new token (classic)**
4. Nombre: `elysia-push`, expiración: `90 days`, permiso: ✅ `repo`
5. Copia el token generado
6. Cuando Git te pida contraseña al hacer push, pega ese token

> Después de la primera vez, Git recuerda tus credenciales y no te vuelve a pedir.

---

## 4. Inicializar el proyecto en Unity

### 4.1 Abrir el proyecto con Unity Hub

1. Abre **Unity Hub**
2. Pestaña **Projects** → botón **Open → Add project from disk**
3. Navega hasta la carpeta `elysiagame` que clonaste
4. Selecciona la carpeta raíz (la que contiene `Assets/`, `ProjectSettings/`, `CONTEXT.md`, etc.)
5. Asegúrate de que Unity Hub muestra la versión **6000.5.0f1** al lado del proyecto

### 4.2 Primera apertura (5 a 10 minutos)

La primera vez Unity necesita regenerar la carpeta `Library/` (no está en Git porque pesa demasiado). Verás una barra de progreso en la esquina inferior derecha del Editor.

**No cierres Unity hasta que termine.** Es normal que tarde.

### 4.3 Revisar la consola de Unity

Una vez abierto, ve a `Window → General → Console`:

- ✅ Sin errores rojos → todo compiló bien
- ❌ Errores rojos → ve a `Window → Package Manager` y verifica que estos paquetes están instalados:
  - `Input System` 1.19.0
  - `AI Navigation` 2.0.13
  - `Universal Render Pipeline` 17.5.0
  - `Timeline` 1.8.12

### 4.4 Generar la escena de prueba

En el menú superior de Unity:

1. Haz clic en **Elysia → Setup → Create World Scene**
2. Aparece un diálogo de confirmación → **Crear**
3. Unity genera automáticamente materiales de colores y la escena `Mundo_Prototipo.unity`
4. La escena se abre mostrando un espacio con pilares, cajas y luz cálida

---

## 5. Verificar que todo funciona

Confirma estos puntos antes de empezar a trabajar:

- [ ] Unity abre sin errores rojos en la consola
- [ ] La carpeta `Assets/_Game/` aparece en el panel Project con todas sus subcarpetas
- [ ] El menú **Elysia** aparece en la barra superior de Unity
- [ ] Al ejecutar **Elysia → Setup → Create World Scene** no hay errores
- [ ] La escena `Mundo_Prototipo.unity` se abre y muestra geometría con colores

Si todo está marcado, estás listo.

---

## 6. Guía específica por miembro del equipo

### Flujo de trabajo diario (todos los miembros)

```bash
# Al empezar el día — traer los últimos cambios del equipo
git checkout develop
git pull origin develop

# Ir a tu rama de trabajo
git checkout feature/tu-rama

# Actualizar tu rama con lo que llegó a develop
git merge develop

# ... trabajas en Unity, escribes código, configuras escenas ...

# En Unity: Ctrl+S para guardar la escena antes de commitear

# Subir tu trabajo
git add Assets/_Game/Scripts/TuCarpeta/TuArchivo.cs
git add Assets/_Game/Scripts/TuCarpeta/TuArchivo.cs.meta
git commit -m "feat(area): descripcion corta de lo que hiciste"
git push origin feature/tu-rama
```

Después de hacer push, abre GitHub y crea un **Pull Request** de tu rama hacia `develop`. El equipo lo revisa y aprueba antes de mergear.

---

### Juan José — Core y Player

**Rama:** `feature/player`
**Prioridad máxima:** `GameManager.cs` y `SceneLoader.cs` — todo el equipo queda bloqueado hasta que esto esté en `develop`.

#### Empezar a trabajar

```bash
git checkout feature/player
```

#### Primer día — crear el Core

1. Crea `Assets/_Game/Scripts/Core/GameManager.cs`
2. Crea `Assets/_Game/Scripts/Core/SceneLoader.cs`
3. Guarda en Unity (`Ctrl+S`)
4. En la terminal:

```bash
git add Assets/_Game/Scripts/Core/GameManager.cs
git add Assets/_Game/Scripts/Core/GameManager.cs.meta
git add Assets/_Game/Scripts/Core/SceneLoader.cs
git add Assets/_Game/Scripts/Core/SceneLoader.cs.meta
git commit -m "feat(core): add GameManager singleton and SceneLoader"
git push origin feature/player
```

5. En GitHub, abre un Pull Request: `feature/player → develop`

#### Orden de tus tareas

```
1. GameManager.cs + SceneLoader.cs     ← primero, desbloquea a todos
2. Player.prefab en Unity Editor       ← Quad + CharacterController + scripts
3. PlayerStats.cs                      ← vida actual, referencia a PlayerData SO
4. PlayerCombat.cs                     ← ataque de Elysia contra los lobos
```

---

### Nicolás — UI, Diálogos y Cinemáticas

**Ramas:** `feature/menu`, `feature/dialogues`, `feature/cinematics`
**Espera:** El `SceneLoader` de Juan José en `develop` antes de conectar el menú.

#### Empezar a trabajar

```bash
# Cuando Juan José mergee el Core a develop:
git checkout develop
git pull origin develop
git checkout feature/menu
git merge develop
```

#### Primer día — crear el sistema de diálogos

Los diálogos de Elysia y Lucerna están en `.claude/context/STORY.md` — ya están escritos y listos para implementar. Tu trabajo es crear el sistema que los muestre.

1. Crea `Assets/_Game/Scripts/Dialogue/DialogueData.cs` — ScriptableObject con un array de líneas `{ speaker, text }`
2. Crea `Assets/_Game/Scripts/Dialogue/DialogueUI.cs` — muestra el nombre del hablante y el texto
3. Crea `Assets/_Game/Scripts/Dialogue/DialogueManager.cs` — avanza las líneas con input del jugador
4. En Unity, crea los assets de datos:
   - Clic derecho en `Assets/_Game/ScriptableObjects/Dialogues/`
   - `Create → Elysia → DialogueData`
   - Nómbralo `Dialogo_CinematicaIntro` y llena las 16 líneas de la Cinemática 1
   - Repite para `Dialogo_CinematicaPuerta` (5 líneas de la Cinemática 2)

```bash
git checkout feature/dialogues
git add Assets/_Game/Scripts/Dialogue/
git add Assets/_Game/ScriptableObjects/Dialogues/
git commit -m "feat(dialogue): add dialogue system and cinematic dialogue assets"
git push origin feature/dialogues
```

#### Orden de tus tareas

```
1. MainMenu.unity + botón Iniciar Partida    ← feature/menu
2. DialogueData.cs + DialogueUI.cs           ← feature/dialogues
3. Assets de diálogos SO (texto de STORY.md) ← feature/dialogues
4. Cinematica_Intro.unity con Timeline       ← feature/cinematics
5. Cinemática 2 activada por trigger puerta  ← feature/cinematics
```

---

### Nero — Escenarios y Arte

**Rama:** `feature/world`
**Puede empezar ahora** — los escenarios no dependen del Core de Juan José.

#### Empezar a trabajar

```bash
git checkout feature/world
```

#### Primer día — crear Iglesia_Interior.unity

La iglesia es una **ruina abandonada con luz roja** filtrada por vidrieras (ver descripción visual en `.claude/context/STORY.md`). Todo con primitivas de colores por ahora.

1. En Unity: `File → New Scene → Empty`
2. Guárdala: `Assets/_Game/Scenes/Iglesia_Interior.unity`
3. Construye la geometría:

| Elemento | Primitiva | Material | Notas |
|---|---|---|---|
| Piso | Plane | `Floor_Mat` | Escala (2, 1, 3) |
| Paredes | Cubes | `Wall_Mat` | 4 paredes, altura 3 |
| Bancos desgastados | Cubes alargados | `Crate_Mat` | En filas, como bancas de iglesia |
| Vidrieras | Planes verticales | Material rojo oscuro | En los huecos de las paredes |
| Lucerna NPC | Cylinder | `Pillar_Mat` | Posición fija cerca del altar |
| Trigger puerta | Empty + Box Collider | — | `Is Trigger: ✅`, al fondo de la iglesia |
| Luz principal | Directional Light | Color rojo oscuro #8B1A1A | Intensidad 0.6 |

4. Guarda: `Ctrl+S`

```bash
git add Assets/_Game/Scenes/Iglesia_Interior.unity
git add Assets/_Game/Scenes/Iglesia_Interior.unity.meta
git commit -m "feat(world): add Iglesia_Interior placeholder with red light and door trigger"
git push origin feature/world
```

#### Segundo día — crear Bosque_Oscuro.unity

El bosque oscuro es el escenario de combate. Debe sentirse opresivo y de noche.

| Elemento | Primitiva | Material | Notas |
|---|---|---|---|
| Camino | Plane estrecho | `Wall_BG_Mat` | Centro de la escena |
| Árboles | Cylinders altos | `Wall_BG_Mat` | Escala Y grande, a los lados del camino |
| Luna | Point Light azul-blanca | — | Arriba, intensidad baja |
| Zona de spawn lobos | Empty + Box Collider | — | `Is Trigger: ✅`, al fondo del camino |

```bash
git add Assets/_Game/Scenes/Bosque_Oscuro.unity
git add Assets/_Game/Scenes/Bosque_Oscuro.unity.meta
git commit -m "feat(world): add Bosque_Oscuro placeholder with wolf spawn zone"
git push origin feature/world
```

#### Orden de tus tareas

```
1. Iglesia_Interior.unity (ruinas, luz roja, Lucerna, Trigger_Door)
2. Bosque_Oscuro.unity (bosque oscuro, zona de spawn de lobos)
3. NavMesh en Bosque_Oscuro (Window → AI → Navigation → Bake)
4. Prefab de Lucerna como NPC estático
```

---

### Persona adicional — Enemigo y Combate

**Rama:** `feature/combat`
**Espera:** `Player.prefab` de Juan José y `Bosque_Oscuro.unity` de Nero en `develop`.

#### Empezar a trabajar

```bash
# Cuando los prerequisitos estén en develop:
git checkout develop
git pull origin develop
git checkout feature/combat
git merge develop
```

#### Primer día — crear el lobo Droglot

El enemigo de la demo es un **lobo Droglot**. Placeholder oscuro que persigue a Elysia y la ataca.

1. Crea `Assets/_Game/Scripts/Enemy/EnemyData.cs` — ScriptableObject con `maxHealth`, `damage`, `speed`, `attackRange`
2. Crea `Assets/_Game/Scripts/Enemy/EnemyStats.cs` — vida actual, toma daño, muere
3. Crea `Assets/_Game/Scripts/Enemy/EnemyAI.cs` — NavMeshAgent que detecta a Elysia, la persigue y ataca
4. En Unity crea el prefab:
   - Crea un Capsule en la escena
   - Asígnale material oscuro `Wall_BG_Mat`
   - Agrégale los componentes: `NavMeshAgent`, `EnemyAI`, `EnemyStats`
   - Arrastra a `Assets/_Game/Prefabs/Characters/Droglot_Lobo.prefab`
5. Crea el asset de datos: `Assets/_Game/ScriptableObjects/Characters/EnemyData_Lobo.asset`

```bash
git add Assets/_Game/Scripts/Enemy/
git add Assets/_Game/Prefabs/Characters/Droglot_Lobo.prefab
git add Assets/_Game/Prefabs/Characters/Droglot_Lobo.prefab.meta
git add Assets/_Game/ScriptableObjects/Characters/EnemyData_Lobo.asset
git add Assets/_Game/ScriptableObjects/Characters/EnemyData_Lobo.asset.meta
git commit -m "feat(combat): add Droglot wolf prefab with NavMesh AI and stats SO"
git push origin feature/combat
```

#### Orden de tus tareas

```
1. EnemyData.cs (ScriptableObject de stats configurables)
2. EnemyStats.cs (vida actual, recibir daño, morir)
3. EnemyAI.cs (NavMesh, perseguir a Elysia, atacar)
4. Droglot_Lobo.prefab
5. CombatManager.cs (inicia combate al cargar Bosque_Oscuro, detecta fin de demo)
```

---

## Diagrama de dependencias entre miembros

```
Juan José termina GameManager + SceneLoader → merge a develop
              ↓
    Nicolás puede conectar el menú al SceneLoader
    Todos pueden usar SceneLoader para cambiar escenas

Juan José termina Player.prefab → merge a develop
              ↓
    Nero puede colocar a Elysia en sus escenas de prueba
    Persona adicional puede probar la IA del lobo contra Elysia

Nero termina Bosque_Oscuro.unity con NavMesh → merge a develop
              ↓
    Persona adicional puede probar los lobos en el escenario real

Nicolás termina DialogueData + DialogueUI → merge a develop
              ↓
    Los diálogos de Elysia y Lucerna aparecen en pantalla
```

---

## Reglas que todos deben respetar

1. **Nunca** hacer push directamente a `main` o `develop` — siempre trabajar en `feature/tu-rama`
2. **Siempre** hacer `git pull origin develop` antes de empezar a trabajar cada día
3. **Guardar la escena en Unity** (`Ctrl+S`) antes de hacer `git add`
4. **Commitear los `.meta`** junto con cada archivo nuevo — sin ellos las referencias se rompen para el resto
5. **Crear un Pull Request** en GitHub cuando termines algo — necesita 1 aprobación del equipo antes de mergear
6. Probar tus cambios en una **escena personal** (`_Test_TuNombre.unity`) antes de tocar las escenas oficiales

---

## Recursos del proyecto

| Recurso | Dónde |
|---|---|
| Repositorio | https://github.com/anavitateg/elysiagame |
| Tablero Trello | https://trello.com/b/BK1q96lS/elysia-descent-desarrollo |
| Historia y diálogos | `.claude/context/STORY.md` |
| Estado del proyecto | `.claude/context/VERSION_TRACKER.md` |
| Arquitectura técnica | `CONTEXT.md` |
| Jerarquía de desarrollo | `.claude/context/HIERARCHY.md` |
