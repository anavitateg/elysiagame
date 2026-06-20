Eres el asistente de verificación del videojuego Elysia. Tu tarea es validar que una feature implementada cumple con todos sus criterios de aceptación.

## Paso 1 — Identificar la feature a verificar

Lee `.claude/features/` para encontrar la feature activa (archivo CURRENT) o usa: $ARGUMENTS

## Paso 2 — Cargar los criterios

Lee estos archivos:
- `.claude/features/[feature]/b_requisitos.md` — criterios de aceptación y casos límite
- `.claude/features/[feature]/d_checklist.md` — todas las tareas deben estar `[x]`
- `.claude/features/[feature]/a_propuesta.md` — alcance definido originalmente

## Paso 3 — Verificación técnica

Para cada archivo de código creado o modificado por la feature:
1. **Lee el archivo** y verifica que implementa lo descrito en el diseño técnico
2. **Comprueba convenciones:** namespace correcto (`Elysia.X`), PascalCase, sin comentarios obvios
3. **Detecta riesgos:** null references sin guardar, dependencias no inicializadas, magic numbers

## Paso 4 — Verificación del checklist

Revisa `d_checklist.md`:
- ¿Todas las tareas de código están `[x]`?
- ¿Las tareas manuales de Unity Editor están confirmadas por el usuario?
- ¿Se hizo push de todos los archivos?

## Paso 5 — Reporte de verificación

Genera un reporte con este formato:

```markdown
## Reporte de Verificación — [Feature]
Fecha: [fecha actual]

### Criterios de aceptación
| # | Criterio | Estado | Observación |
|---|---|---|---|
| AC1 | ... | ✅ / ❌ / ⚠️ | ... |
| AC2 | ... | ✅ / ❌ / ⚠️ | ... |

### Casos límite
| # | Caso | Estado | Observación |
|---|---|---|---|
| CE1 | ... | ✅ / ❌ / ⚠️ | ... |

### Checklist
- Tareas completadas: X / Y
- Tareas pendientes: [lista o "ninguna"]

### Código
- Convenciones: ✅ / ❌ [detalle]
- Riesgos detectados: [lista o "ninguno"]

### Veredicto
✅ APROBADO — listo para /archive y /commit
⚠️ APROBADO CON OBSERVACIONES — puede continuar pero atender: [lista]
❌ RECHAZADO — debe corregirse antes de continuar: [lista de bloqueantes]
```

Si el veredicto es ✅ o ⚠️, indica: "Ejecuta `/archive` para cerrar la feature y luego `/commit` para hacer el commit final."
Si es ❌, lista exactamente qué debe corregirse y sugiere volver a `/apply` para las tareas pendientes.
