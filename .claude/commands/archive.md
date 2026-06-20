Eres el asistente de documentación del videojuego Elysia. Tu tarea es cerrar una feature completada y actualizar el historial del proyecto.

## Paso 1 — Identificar la feature

Lee la feature activa (archivo CURRENT en `.claude/features/`) o usa: $ARGUMENTS

## Paso 2 — Verificar que está lista para archivar

Lee el reporte de `/verify` más reciente. Si el veredicto no es ✅ o ⚠️, detente y avisa: "La feature no ha sido verificada. Ejecuta `/verify` primero."

## Paso 3 — Actualizar VERSION_TRACKER.md

En `.claude/context/VERSION_TRACKER.md`:

1. Encuentra la sección de la fase correspondiente a esta feature
2. Cambia todas las tareas `- [ ]` completadas a `- [x]`
3. Cambia el estado de la feature de `🔄 EN CURSO` a `✅ COMPLETADO`
4. Añade en la tabla "Historial de features cerradas":

```markdown
| [nombre-feature] | feature/[rama] | [fecha-actual] | [responsable] |
```

5. Si toda la fase está completa (todos los ítems en `[x]`), cambia el estado de la fase en la tabla superior también a `✅ COMPLETADO`

## Paso 4 — Crear resumen de la feature

En `.claude/features/[feature]/` crea un archivo `RESUMEN.md`:

```markdown
# Resumen: [Feature]

## Estado final: ✅ COMPLETADO
## Fecha de cierre: [fecha]
## Responsable: [nombre]
## Rama: feature/[rama]

## Qué se construyó
(Listado de archivos creados/modificados con su propósito)

## Decisiones tomadas
(Las más importantes del diseño técnico)

## Lo que esta feature desbloqueó
(Qué pueden hacer ahora los otros miembros del equipo)

## Notas para el equipo
(Cualquier información que el equipo deba saber al trabajar con esto)
```

## Paso 5 — Limpiar el estado activo

Elimina el archivo `.claude/features/[feature]/CURRENT` para indicar que ya no hay feature activa.

## Paso 6 — Confirmar

Muestra al usuario:

```
✅ Feature [nombre] archivada correctamente.

Archivos actualizados:
- .claude/context/VERSION_TRACKER.md
- .claude/features/[feature]/RESUMEN.md

Próximo paso: ejecuta `/commit` para hacer el commit con todos los cambios.

Siguiente feature recomendada según HIERARCHY.md: [nombre de la siguiente pendiente]
```
