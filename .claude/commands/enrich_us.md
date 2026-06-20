Eres el asistente técnico del videojuego Elysia (Unity 6 + URP, RPG narrativo con personaje 2D en mundo 3D).

El usuario te ha dado una historia de usuario (User Story) en bruto:

---
$ARGUMENTS
---

Antes de analizar, lee obligatoriamente:
- `.claude/context/PURPOSE.md` — contexto del juego y el equipo
- `.claude/context/HIERARCHY.md` — qué depende de qué
- `.claude/context/VERSION_TRACKER.md` — estado actual del proyecto

Luego produce el siguiente documento estructurado:

---

## Historia de Usuario Enriquecida

### Historia original
(Copia textual de lo que escribió el usuario)

### Contexto técnico
- **Fase del proyecto:** (A / B / C / D / E según HIERARCHY.md)
- **Rama Git:** (feature/player / feature/world / etc.)
- **Responsable sugerido:** (miembro del equipo según PURPOSE.md)
- **Dependencias bloqueantes:** (qué debe existir primero en develop — si hay bloqueos, indicarlo claramente con ⚠️)

### Historia refinada
(Reescribe la historia con formato: "Como [rol], quiero [acción] para [beneficio]")

### Criterios de aceptación
Lista numerada de condiciones que deben ser verdaderas para considerar la historia completada. Deben ser verificables y específicos.

```
AC1. ...
AC2. ...
AC3. ...
```

### Casos límite y escenarios de fallo
Lista de situaciones no obvias que la implementación debe manejar:

```
CE1. ...
CE2. ...
```

### Detalle de implementación técnica
- Archivos a crear o modificar (con rutas completas desde Assets/)
- Componentes Unity involucrados
- Namespaces y clases a usar o crear
- Patrones de diseño aplicables
- Referencias a assets existentes que se reutilizarán

### Escenarios de testing
Describe cómo verificar manualmente en Unity Editor que cada criterio de aceptación se cumple. Incluye pasos concretos de Play Mode.

### Estimación de complejidad
- **Esfuerzo:** (Bajo / Medio / Alto)
- **Riesgo técnico:** (Bajo / Medio / Alto) con justificación
- **Sesiones estimadas:** (número aproximado)

---

Al terminar, sugiere ejecutar `/ff [nombre-corto-de-la-feature]` para generar los artefactos de planificación.
