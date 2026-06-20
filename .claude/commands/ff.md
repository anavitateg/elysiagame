Eres el asistente técnico del videojuego Elysia. El usuario quiere crear los artefactos de planificación para una feature.

Nombre de la feature: **$ARGUMENTS**

Antes de proceder, lee:
- `.claude/context/HIERARCHY.md` — verifica que no hay bloqueos
- `.claude/context/VERSION_TRACKER.md` — estado actual
- Si existe `.claude/features/$ARGUMENTS/` — revisar si ya hay artefactos previos

---

## Tu tarea

Crea la carpeta `.claude/features/$ARGUMENTS/` y dentro los siguientes 4 archivos:

---

### Archivo a — `a_propuesta.md`

```markdown
# Propuesta: [Nombre legible de la feature]

## Resumen ejecutivo
(2-3 oraciones que explican qué se construye y por qué)

## Historia de usuario
(Historia enriquecida — cópiala del output de /enrich_us si está disponible)

## Alcance
### Incluido
- ...
### Excluido (explícitamente fuera de scope)
- ...

## Impacto en otros sistemas
(Qué otros sistemas se verán afectados o desbloqueados por esta feature)

## Rama Git
`feature/...`

## Responsable
...
```

---

### Archivo b — `b_requisitos.md`

```markdown
# Requisitos y Escenarios: [Feature]

## Requisitos funcionales
RF1. ...
RF2. ...

## Requisitos no funcionales
RNF1. (rendimiento, escalabilidad, convenciones de código)
RNF2. ...

## Criterios de aceptación
AC1. ...
AC2. ...

## Casos límite
CE1. ...
CE2. ...

## Escenarios de prueba manual
### Escenario 1: [nombre]
1. Precondición: ...
2. Acción: ...
3. Resultado esperado: ...

### Escenario 2: [nombre]
...
```

---

### Archivo c — `c_diseno_tecnico.md`

```markdown
# Diseño Técnico: [Feature]

## Arquitectura

### Archivos a crear
| Archivo | Namespace | Propósito |
|---|---|---|
| `Assets/_Game/Scripts/.../Foo.cs` | `Elysia.X` | ... |

### Archivos a modificar
| Archivo | Cambio |
|---|---|
| ... | ... |

### Dependencias
- Requiere en develop: ...
- Assets que se reutilizan: ...

## Diseño de clases

### [NombreClase]
- Hereda de: MonoBehaviour / ScriptableObject / etc.
- Campos serializados: ...
- Métodos principales: ...
- Eventos que emite / consume: ...

## Decisiones de arquitectura
| Decisión | Alternativa descartada | Razón |
|---|---|---|
| ... | ... | ... |

## Patrones utilizados
- ...

## Riesgos técnicos
- ...
```

---

### Archivo d — `d_checklist.md`

```markdown
# Checklist de tareas: [Feature]

> Ejecutar con /apply. Marcar cada tarea completada antes de pasar a la siguiente.
> Feature activa: $ARGUMENTS

## 0. Preparación Git
- [ ] `git checkout develop && git pull origin develop`
- [ ] `git checkout feature/[rama]`

## 1. Estructura de archivos
- [ ] Crear archivo: `Assets/_Game/Scripts/.../Foo.cs`
- [ ] ...

## 2. Implementación
- [ ] Implementar [clase/método específico]
- [ ] ...

## 3. Unity Editor
- [ ] Crear Prefab: `Assets/_Game/Prefabs/.../Foo.prefab`
- [ ] Configurar componente X con valor Y
- [ ] ...

## 4. Pruebas manuales
- [ ] Play Mode: verificar AC1 — [descripción]
- [ ] Play Mode: verificar AC2 — [descripción]
- [ ] No hay errores en la consola de Unity

## 5. Documentación
- [ ] Actualizar `VERSION_TRACKER.md` — marcar tareas completadas

## 6. Entrega
- [ ] `git add [archivos específicos]`
- [ ] `/commit`
- [ ] `git push origin feature/[rama]`
- [ ] Abrir PR: `feature/[rama]` → `develop`
```

---

Después de crear los 4 archivos, actualiza `.claude/context/VERSION_TRACKER.md`:
- Añade la feature como `🔄 EN CURSO` en la fase correspondiente
- Crea un archivo `.claude/features/$ARGUMENTS/CURRENT` con el texto `$ARGUMENTS` para que `/apply` sepa cuál es la feature activa

Finaliza indicando: "Artefactos creados en `.claude/features/$ARGUMENTS/`. Ejecuta `/apply` para comenzar la implementación."
