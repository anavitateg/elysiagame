Eres el asistente de control de versiones del videojuego Elysia. Tu tarea es crear un commit con el formato estándar del proyecto.

## Paso 1 — Revisar cambios

Ejecuta `git status` y `git diff --staged` para ver qué hay preparado para commit.
Si no hay nada en staging, ejecuta `git status` para ver los archivos modificados y pregunta al usuario qué archivos incluir.

## Paso 2 — Determinar el tipo de commit

Usa las convenciones del proyecto (definidas en CLAUDE.md):

| Tipo | Cuándo |
|---|---|
| `feat` | Nueva funcionalidad o sistema |
| `fix` | Corrección de un bug |
| `chore` | Configuración, estructura, herramientas |
| `docs` | Documentación (CLAUDE.md, CONTEXT.md, VERSION_TRACKER, etc.) |
| `art` | Assets visuales (modelos, texturas, materiales) |
| `anim` | Animaciones y Animator Controllers |
| `ui` | Cambios de interfaz de usuario |
| `refactor` | Refactorización sin cambio de funcionalidad |

## Paso 3 — Determinar el scope

El scope es el área del proyecto afectada:
`player`, `world`, `combat`, `dialogue`, `ui`, `core`, `cinematics`, `menu`, `setup`, `context`

## Paso 4 — Construir el mensaje

Formato obligatorio:
```
tipo(scope): descripción en inglés, imperativo, minúsculas, sin punto final

- detalle 1 (si hay más de un cambio significativo)
- detalle 2

Co-Authored-By: Claude Sonnet 4.6 <noreply@anthropic.com>
```

Ejemplos correctos:
```
feat(player): add CharacterController movement with Input System
fix(world): correct pillar Y position so base sits on floor
chore(core): add GameManager singleton and SceneLoader wrapper
docs(context): update VERSION_TRACKER phase B progress
art(environment): add church interior placeholder materials
```

## Paso 5 — Ejecutar el commit

Si el argumento $ARGUMENTS contiene un mensaje personalizado, úsalo como base.
Si no, genera el mensaje basándote en los cambios detectados.

Añade solo los archivos relevantes (nunca `Library/`, `Temp/`, `UserSettings/`, ni archivos `.meta` de assets no commiteados).

Haz el commit con el mensaje formateado.

## Paso 6 — Confirmar

Muestra el hash del commit y el mensaje usado.
Recuerda al usuario: "Ejecuta `git push origin [rama-actual]` para subir los cambios al repositorio remoto."
