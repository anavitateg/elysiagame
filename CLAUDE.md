# Elysia — Instrucciones para Claude

Eres el asistente de desarrollo del videojuego **Elysia**, un RPG narrativo en Unity 6 + URP.
Lee este archivo completo antes de responder cualquier consulta del equipo.

---

## Archivos de contexto obligatorios

Antes de ejecutar cualquier tarea, consulta estos archivos en este orden:

1. `.claude/context/PURPOSE.md` — qué es el juego, su objetivo y el equipo
2. `.claude/context/HIERARCHY.md` — qué se debe construir antes que qué
3. `.claude/context/VERSION_TRACKER.md` — estado actual del proyecto y checklists

Si el usuario pide trabajar en algo que depende de algo no completado aún según `HIERARCHY.md`, **advierte el bloqueo antes de proceder**.

---

## Flujo de trabajo obligatorio

Todo desarrollo sigue este flujo sin excepciones:

```
/enrich_us  →  /ff  →  /apply  →  /verify  →  /archive  →  /commit
```

| Comando | Qué hace |
|---|---|
| `/enrich_us` | Convierte una historia de usuario vaga en una especificación técnica exhaustiva |
| `/ff` | Crea los 4 artefactos de planificación para la feature en `.claude/features/` |
| `/apply` | Ejecuta el checklist de la feature activa tarea por tarea |
| `/verify` | Valida que todo está completo según criterios de aceptación |
| `/archive` | Actualiza VERSION_TRACKER.md y cierra la feature |
| `/commit` | Crea el commit con formato estándar del proyecto |

**Nunca saltar pasos.** Si alguien pide implementar algo sin haber pasado por `/enrich_us` y `/ff`, recuérdale el flujo y ejecuta esos pasos primero.

---

## Convenciones del proyecto

### Ramas Git
```
main ← develop ← feature/*
```
- Todo desarrollo en `feature/*`
- PR a `develop` requiere 1 aprobación
- `develop` → `main` solo al cerrar una fase completa

### Commits
```
feat(scope):   nueva funcionalidad
fix(scope):    corrección de bug
chore(scope):  configuración, estructura
docs(scope):   documentación
art(scope):    assets visuales
anim(scope):   animaciones
ui(scope):     interfaz de usuario
refactor(scope): refactorización
```

### Scripts C#
- Namespace: `Elysia.{Area}` (Core, Player, Enemy, Combat, Dialogue, UI, World)
- PascalCase para clases: `PlayerController.cs`
- Sin comentarios obvios, solo cuando el WHY no es claro

### Carpetas
Todo el código y assets del juego viven en `Assets/_Game/`. Nunca crear archivos fuera de esa carpeta sin justificación.

---

## Reglas generales

1. **Nunca commitear** archivos auto-generados por Unity (`Library/`, `Temp/`, `UserSettings/`)
2. **Nunca hacer push directo** a `main` o `develop`
3. **Siempre crear Prefabs** de GameObjects reutilizables antes de colocarlos en escenas
4. **Actualizar VERSION_TRACKER.md** después de cada feature completada
5. Si hay duda sobre dependencias, consultar `HIERARCHY.md` antes de proceder
6. Las escenas oficiales no se tocan directamente — se trabaja con Prefabs y escenas `_Test_` personales

---

## Stack técnico
- **Engine:** Unity 6000.5.0f1
- **Pipeline:** URP 17.5.0
- **Input:** Input System 1.19.0 (`Assets/InputSystem_Actions.inputactions`)
- **Navegación IA:** AI Navigation 2.0.13
- **Cinemáticas:** Timeline 1.8.12
- **Arte 3D:** Blender 4.x → exportar `.fbx` con transformaciones aplicadas
- **Repositorio:** https://github.com/anavitateg/elysiagame
