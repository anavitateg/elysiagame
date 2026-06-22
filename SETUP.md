# SETUP — Cómo unirse al proyecto Elysia: Descent

> Esta guía lleva a cualquier miembro del equipo desde cero hasta tener el proyecto funcionando en su PC y trabajando en su área específica.

---

## Índice

1. [Software que necesitas instalar](#1-software-que-necesitas-instalar)
2. [Acceso al repositorio privado de GitHub](#2-acceso-al-repositorio-privado-de-github)
3. [Clonar el repositorio](#3-clonar-el-repositorio)
4. [Inicializar el proyecto en Unity](#4-inicializar-el-proyecto-en-unity)
5. [Verificar que todo funciona](#5-verificar-que-todo-funciona)
6. [Guía específica por miembro del equipo](#6-guía-específica-por-miembro-del-equipo)

---

## 1. Software que necesitas instalar

### Todos los miembros

| Software | Versión | Descarga | Para qué |
|---|---|---|---|
| **Unity Hub** | Última | [unity.com/download](https://unity.com/download) | Gestor de versiones de Unity |
| **Unity Editor** | **6000.5.0f1** (obligatorio) | Desde Unity Hub | Engine del juego |
| **Git** | Última | [git-scm.com](https://git-scm.com) | Control de versiones |
| **Visual Studio Code** | Última | [code.visualstudio.com](https://code.visualstudio.com) | Editor de código |

> ⚠️ **La versión de Unity debe ser exactamente 6000.5.0f1.** Si abres el proyecto con otra versión Unity lo migrará y generará conflictos para el resto del equipo.

### Cómo instalar Unity 6000.5.0f1

1. Instala **Unity Hub** primero
2. Abre Unity Hub → pestaña **Installs** → `Install Editor`
3. En el buscador escribe `6000.5.0f1` o busca en el archivo de versiones
4. En los módulos a instalar, asegúrate de marcar:
   - `Windows Build Support (IL2CPP)` — para hacer builds de PC
   - `Microsoft Visual Studio Community` — o marca `Visual Studio Code` si prefieres VSCode

### Solo Nero (arte y escenarios)

| Software | Versión | Descarga |
|---|---|---|
| **Blender** | 4.x LTS | [blender.org](https://blender.org) |

---

## 2. Acceso al repositorio privado de GitHub

El repositorio es **privado**. Para acceder, necesitas dos cosas:

### Paso A — Que Juan José te agregue como colaborador

1. Juan José entra a: `https://github.com/anavitateg/elysiagame`
2. Va a **Settings → Collaborators → Add people**
3. Escribe el nombre de usuario de GitHub de cada miembro
4. El miembro recibe un email de invitación → debe aceptarla

### Paso B — Configurar tu acceso desde la terminal

Hay dos opciones. Elige **una**:

---

#### Opción 1: Token de acceso personal (más simple, recomendada)

1. En GitHub, ve a tu foto de perfil → **Settings**
2. En el menú izquierdo baja hasta **Developer settings**
3. **Personal access tokens → Tokens (classic) → Generate new token (classic)**
4. Dale un nombre: `elysia-dev`
5. En expiración: `No expiration` (o 90 días si prefieres)
6. Marca el permiso: ✅ `repo` (acceso completo a repositorios)
7. Haz clic en **Generate token**
8. **Copia el token ahora** — no lo podrás ver de nuevo

Cuando Git te pida contraseña al clonar o hacer push, usa este token como contraseña (tu usuario de GitHub es el usuario de login).

---

#### Opción 2: GitHub Desktop (sin terminal, más visual)

1. Descarga **GitHub Desktop** en [desktop.github.com](https://desktop.github.com)
2. Inicia sesión con tu cuenta de GitHub
3. File → `Clone repository` → pestaña `GitHub.com`
4. Busca `anavitateg/elysiagame` → selecciona dónde guardarlo → Clone

Si usas GitHub Desktop puedes saltarte la sección 3 y continuar desde la sección 4.

---

## 3. Clonar el repositorio

Abre una terminal (PowerShell en Windows o la terminal de Git) y ejecuta:

```bash
git clone https://github.com/anavitateg/elysiagame.git
```

Te pedirá usuario y contraseña:
- **Usuario:** tu nombre de usuario de GitHub
- **Contraseña:** el token que generaste en el Paso B

Cuando termine, tendrás una carpeta `elysiagame` con todo el proyecto.

> Si quieres clonarlo en una carpeta específica:
> ```bash
> git clone https://github.com/anavitateg/elysiagame.git "C:\Users\TuNombre\Desktop\elysiagame"
> ```

---

## 4. Inicializar el proyecto en Unity

### 4.1 Abrir el proyecto con Unity Hub

1. Abre **Unity Hub**
2. En la pestaña **Projects**, haz clic en **Open → Add project from disk**
3. Navega hasta la carpeta `elysiagame` que clonaste
4. Selecciona la carpeta raíz (donde está el archivo `elysiagame.slnx`)
5. Asegúrate de que Unity Hub detecta la versión **6000.5.0f1** — si no, descárgala

### 4.2 Primera apertura (puede tardar 5-10 minutos)

La primera vez que abres el proyecto, Unity necesita importar todos los assets y compilar los scripts. Verás una barra de progreso en la esquina inferior derecha. **No cierres Unity hasta que termine.**

Lo que hace Unity en este proceso:
- Genera la carpeta `Library/` (no está en Git, por eso tarda)
- Compila todos los scripts C#
- Importa los materiales y configuración URP

### 4.3 Verificar que compiló correctamente

Una vez abierto, mira la **consola de Unity** (`Window → General → Console`):
- ✅ Sin errores rojos = todo bien
- ❌ Si hay errores rojos: probablemente falta un paquete. Ve a `Window → Package Manager` y verifica que `Input System`, `AI Navigation` y `Universal Render Pipeline` están instalados

### 4.4 Generar la escena de prueba

En el menú superior de Unity:
1. Haz clic en **Elysia → Setup → Create World Scene**
2. Aparece un diálogo de confirmación → clic en **Crear**
3. Unity genera automáticamente:
   - La estructura de materiales de colores
   - La escena `Assets/_Game/Scenes/Mundo_Prototipo.unity`
4. La escena debería abrirse y mostrar un espacio interior con pilares y cajas

---

## 5. Verificar que todo funciona

Antes de empezar a trabajar, confirma estos puntos:

- [ ] Unity abre sin errores rojos en la consola
- [ ] Ves la carpeta `Assets/_Game/` en el panel Project con todas sus subcarpetas
- [ ] Puedes ejecutar `Elysia → Setup → Create World Scene` sin errores
- [ ] La escena `Mundo_Prototipo.unity` se abre y muestra geometría con colores

Si todo está marcado, estás listo para trabajar.

---

## 6. Guía específica por miembro del equipo

### Flujo de trabajo diario (todos los miembros)

```bash
# Al empezar el día — traer los últimos cambios del equipo
git checkout develop
git pull origin develop

# Pasarte a tu rama de trabajo
git checkout feature/tu-rama

# Traer a tu rama lo que otros mergearon a develop
git merge develop

# ... trabajas en Unity / escribes código ...

# Al terminar — guardar y subir tu trabajo
# 1. En Unity: Ctrl+S para guardar la escena
# 2. En la terminal:
git add Assets/_Game/Scripts/TuScript.cs
git add Assets/_Game/Scripts/TuScript.cs.meta
git commit -m "feat(player): descripcion de lo que hiciste"
git push origin feature/tu-rama
```

---

### Juan José — Core y Player

**Tu rama:** `feature/player`
**Lo que harás primero:** `GameManager.cs` y `SceneLoader.cs` (Fase A del proyecto — todo el equipo te espera para esto)

#### Setup inicial
```bash
git checkout feature/player
```

#### Ejemplo de tu primer día de trabajo

1. Crea el archivo `Assets/_Game/Scripts/Core/GameManager.cs`
2. Crea el archivo `Assets/_Game/Scripts/Core/SceneLoader.cs`
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

5. En GitHub, abre un **Pull Request**: `feature/player → develop`
6. El equipo lo revisa y aprueba

#### Orden de tus tareas

```
1. GameManager.cs + SceneLoader.cs  ← hazlo primero, desbloquea a todos
2. Player.prefab en Unity Editor     ← configuras el Quad + scripts
3. PlayerStats.cs                    ← vida, datos del jugador
4. PlayerCombat.cs                   ← ataque de Elysia
```

---

### Nicolás — UI, Diálogos y Cinemáticas

**Tus ramas:** `feature/menu`, `feature/dialogues`, `feature/cinematics`
**Lo que harás primero:** Esperar a que Juan José mergee el `SceneLoader` a `develop`, luego empezar el menú

#### Setup inicial
```bash
# Cuando Juan José termine el Core:
git checkout develop
git pull origin develop
git checkout feature/menu
git merge develop
```

#### Ejemplo: crear el sistema de diálogos

Los diálogos de Elysia y Lucerna están definidos en `.claude/context/STORY.md`. Tu trabajo es implementarlos como ScriptableObjects.

1. Crea `Assets/_Game/Scripts/Dialogue/DialogueData.cs`
2. En Unity, crea el asset de diálogos de la Cinemática 1:
   - Clic derecho en `Assets/_Game/ScriptableObjects/Dialogues/`
   - `Create → Elysia → DialogueData`
   - Nómbralo `Dialogo_CinematicaIntro`
   - Llena las 16 líneas de la tabla en `.claude/context/STORY.md`
3. Haz lo mismo para `Dialogo_CinematicaPuerta` (5 líneas)

```bash
git checkout feature/dialogues
git add Assets/_Game/Scripts/Dialogue/DialogueData.cs
git add Assets/_Game/ScriptableObjects/Dialogues/
git commit -m "feat(dialogue): add DialogueData SO with cinematic 1 and 2 lines"
git push origin feature/dialogues
```

#### Orden de tus tareas

```
1. MainMenu.unity + botón de inicio     ← feature/menu
2. DialogueData.cs + DialogueUI.cs     ← feature/dialogues
3. Los assets de diálogos SO (texto)   ← feature/dialogues
4. Cinematica_Intro.unity con Timeline ← feature/cinematics
5. Cinemática 2 (trigger de puerta)    ← feature/cinematics
```

---

### Nero — Escenarios y Arte

**Tu rama:** `feature/world`
**Lo que harás primero:** Crear `Iglesia_Interior.unity` y `Bosque_Oscuro.unity` con geometría placeholder

#### Setup inicial
```bash
git checkout feature/world
```

#### Ejemplo: crear Iglesia_Interior.unity

La iglesia debe ser una ruina con luz roja oscura (ver descripción visual en `.claude/context/STORY.md`). Para el placeholder:

1. En Unity: `File → New Scene → Empty`
2. Guárdala como `Assets/_Game/Scenes/Iglesia_Interior.unity`
3. Crea la geometría con primitivas:
   - **Floor:** `GameObject → 3D Object → Plane` → escala (2, 1, 3), material `Floor_Mat`
   - **Paredes:** Cubes oscuros, material `Wall_Mat`
   - **Bancos (desgastados):** Cubes marrones alargados, material `Crate_Mat`
   - **Luz roja:** `Directional Light` con color rojo oscuro (#8B1A1A) y baja intensidad
   - **Lucerna NPC:** Cylinder en posición fija (donde estará el personaje)
   - **Trigger_Door:** Empty GameObject con Box Collider (Is Trigger: ✅) en la puerta
4. Guarda la escena: `Ctrl+S`

```bash
git add Assets/_Game/Scenes/Iglesia_Interior.unity
git add Assets/_Game/Scenes/Iglesia_Interior.unity.meta
git commit -m "feat(world): add Iglesia_Interior placeholder with door trigger and Lucerna NPC"
git push origin feature/world
```

#### Para Bosque_Oscuro.unity

```
- Iluminación: Directional Light azul oscuro + intensidad baja (simula luna)
- Árboles: Cylinders negros/morados muy altos (escala Y grande)
- Camino: Plane estrecho central
- Zona de spawn de lobos: Empty GameObject con Box Collider (Is Trigger: ✅)
```

#### Orden de tus tareas

```
1. Iglesia_Interior.unity (ruinas, luz roja, bancos, Lucerna, Trigger_Door)
2. Bosque_Oscuro.unity (bosque oscuro, luna, zona de spawn de lobos)
3. NavMesh en Bosque_Oscuro (Window → AI → Navigation → Bake)
4. Prefab de Lucerna como NPC estático
```

---

### Persona adicional — Enemigo y Combate

**Tu rama:** `feature/combat`
**Lo que harás primero:** Esperar a que estén en develop: Player.prefab (Juan José) y Bosque_Oscuro.unity (Nero)

#### Setup inicial
```bash
# Cuando los prerequisitos estén en develop:
git checkout develop
git pull origin develop
git checkout feature/combat
git merge develop
```

#### Ejemplo: crear el lobo (Droglot)

El enemigo de la demo es un **lobo Droglot** — un placeholder oscuro que persigue a Elysia y la ataca.

1. Crea `Assets/_Game/Scripts/Enemy/EnemyData.cs` (ScriptableObject con vida, daño, velocidad, rango)
2. Crea `Assets/_Game/Scripts/Enemy/EnemyAI.cs` (NavMeshAgent que sigue a Elysia)
3. En Unity, crea el prefab:
   - Crea un Capsule en la escena
   - Asígnale material oscuro `Wall_BG_Mat`
   - Agrégale `NavMeshAgent`, `EnemyAI`, `EnemyStats`
   - Guárdalo como `Assets/_Game/Prefabs/Characters/Droglot_Lobo.prefab`

```bash
git add Assets/_Game/Scripts/Enemy/
git add Assets/_Game/Prefabs/Characters/Droglot_Lobo.prefab
git add Assets/_Game/Prefabs/Characters/Droglot_Lobo.prefab.meta
git commit -m "feat(combat): add Droglot wolf prefab with NavMesh AI"
git push origin feature/combat
```

#### Orden de tus tareas

```
1. EnemyData.cs (ScriptableObject de stats)
2. EnemyAI.cs (NavMesh, seguir a Elysia, atacar)
3. Droglot_Lobo.prefab
4. CombatManager.cs (inicia combate al cargar Bosque_Oscuro)
```

---

## Resumen de dependencias entre miembros

```
Juan José termina GameManager + SceneLoader
              ↓
    Todos pueden hacer pull y empezar sus sistemas

Juan José termina Player.prefab
              ↓
    Nero puede colocar a Elysia en sus escenas de prueba
    Persona adicional puede probar la IA del lobo contra Elysia

Nero termina Bosque_Oscuro.unity con NavMesh
              ↓
    Persona adicional puede probar los lobos en el escenario real

Nicolás termina DialogueData + DialogueUI
              ↓
    Los diálogos de la cinemática 1 y 2 pueden mostrarse en pantalla
```

---

## Reglas que todos deben respetar

1. **Nunca** hacer push directamente a `main` o `develop`
2. **Siempre** hacer `git pull origin develop` antes de empezar a trabajar
3. **Guardar la escena en Unity** (`Ctrl+S`) antes de hacer `git add`
4. **Commitear los `.meta`** junto con cada archivo nuevo — sin ellos las referencias se rompen
5. **Crear un PR** en GitHub cuando termines algo — el equipo lo aprueba antes de mergear
6. Trabajar en tu escena personal de prueba (`_Test_TuNombre.unity`) para no pisar la escena oficial

---

## Recursos del proyecto

| Recurso | URL |
|---|---|
| Repositorio | https://github.com/anavitateg/elysiagame |
| Tablero Trello | https://trello.com/b/BK1q96lS/elysia-descent-desarrollo |
| Historia y diálogos | `.claude/context/STORY.md` |
| Estado del proyecto | `.claude/context/VERSION_TRACKER.md` |
| Arquitectura técnica | `CONTEXT.md` |
| Jerarquía de desarrollo | `.claude/context/HIERARCHY.md` |
