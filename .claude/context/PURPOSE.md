# Propósito del Proyecto — Elysia

## ¿Qué es Elysia?

Elysia es un videojuego RPG narrativo en desarrollo por un equipo de 4 personas.
El jugador controla un personaje 2D (estilo Paper Mario) dentro de un mundo 3D construido en Unity 6 con URP.

## Objetivo del primer prototipo jugable

Demostrar que todas las mecánicas principales funcionan usando únicamente geometría placeholder (cubos, cápsulas, cilindros). El flujo completo de la demo debe ser recorrible de principio a fin:

```
Menú Principal
  → Cinemática de introducción
  → Iglesia Interior (movimiento + diálogo con NPC)
  → Iglesia Exterior (encuentro con monstruo)
  → Combate (barras de vida, ataque, daño)
  → Victoria o Derrota
```

## Equipo

| Miembro | Rol | Área de responsabilidad |
|---|---|---|
| Juan José | Programación Core / Player | Movimiento, cámara, atributos, barra de vida, GameManager, SceneLoader |
| Nicolás | Programación UI / Narrativa | Menú, diálogos, cinemáticas, sistema de escenas |
| Nero | Arte / Escenarios | Iglesia interior, iglesia exterior, colisiones, NavMesh |
| Persona adicional | Programación Enemigo | IA del monstruo, detección de combate, sistema de ataque |

## Herramientas

| Herramienta | Uso |
|---|---|
| Unity 6000.5.0f1 + URP 17.5 | Engine principal |
| Blender 4.x | Modelado y animación |
| Git + GitHub | Control de versiones |
| Trello | Gestión de tareas del equipo |
| Claude Code | Asistente de desarrollo con contexto persistente |

## Repositorio

https://github.com/anavitateg/elysiagame

## Ramas activas

| Rama | Propósito |
|---|---|
| `main` | Versión estable, solo recibe merges al cerrar fases |
| `develop` | Integración continua del equipo |
| `feature/menu` | Nicolás — menú y navegación |
| `feature/player` | Juan José — jugador y cámara |
| `feature/combat` | Persona adicional — combate |
| `feature/dialogues` | Nicolás — diálogos y NPC |
| `feature/world` | Nero — escenarios |
| `feature/cinematics` | Nicolás — cinemáticas |

## Restricción de prototipo

Durante la fase de prototipo **no se usan texturas ni modelos definitivos**. Todo se representa con materiales de color sólido. El arte real entra en la Fase F (reemplazo de placeholders).
