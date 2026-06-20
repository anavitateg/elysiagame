# Historia — Elysia: Descent (Demo)

> **Fuente de verdad narrativa del proyecto.**
> Cuando la historia cambie, actualizar ESTE archivo primero.
> Los cambios en diálogos se propagan a los ScriptableObjects de `Assets/_Game/ScriptableObjects/Dialogues/`.
> Los cambios en el flujo de escenas se propagan a `SceneLoader` y los Timelines.
>
> **Changelog al final de este archivo.**

---

## Título y lore

- **Título del juego:** Elysia: Descent
- **Mundo:** Un mundo de fantasía oscura invadido por criaturas corruptas llamadas **Droglots**
- **Lore relevante para la demo:**
  - Las tierras donde ocurre la demo están siendo invadidas por Droglots
  - Hay una "corriente indómita de energía corrupta" en la zona
  - **Abbysum:** tierras lejanas donde "empezó todo" — origen de Elysia
  - Los exorcistas son quienes combaten a los Droglots usando poderes mágicos

---

## Personajes

### Elysia (Protagonista jugable)
- Exorcista proveniente de Abbysum
- Aparece herida y con vendajes al inicio — no recuerda qué le pasó
- Personalidad: reservada, directa, segura de sus capacidades
- Frase que la define: *"Los exorcizaremos, no hay duda de eso."*

### Lucerna (NPC / Compañera)
- Exorcista local de las tierras donde ocurre la demo
- Encontró a Elysia herida en un bosque y la llevó a la iglesia
- Usa magia — puede mostrar un poder con su mano
- Personalidad: calmada, apaciguadora, conocedora del peligro local
- Frase que la define: *"No es bueno estar mucho tiempo afuera..."*

### Droglots (Enemigos)
- Criaturas corruptas de energía oscura
- Para esta demo: **lobos** (un único diseño de monstruo, todos iguales)
- Futuros actos tendrán variantes más poderosas

---

## Flujo completo de la demo

```
[CINEMÁTICA 1 — Intro]
    Elysia despierta en la iglesia abandonada
    Lucerna entra y se presenta
    → Diálogo: Lucerna/Elysia (ver sección Diálogos)

[GAMEPLAY 1 — Iglesia Interior]
    Elysia puede moverse libremente por la iglesia
    Hay una puerta con la que puede interactuar (tecla E / botón Interactuar)
    Al interactuar con la puerta → trigger → CINEMÁTICA 2

[CINEMÁTICA 2 — La puerta]
    Lucerna y Elysia abren las puertas de la iglesia
    Ven un camino de cadáveres de Droglots
    Lobos aparecen al fondo listos para pelear
    → Diálogo: Lucerna/Elysia (ver sección Diálogos)

[GAMEPLAY 2 — Bosque Oscuro (Exterior)]
    Elysia puede golpear a los lobos
    [FIN DE LA DEMO]
```

---

## Diálogos

> Los diálogos se implementan como ScriptableObjects en `Assets/_Game/ScriptableObjects/Dialogues/`.
> Cambiar el texto aquí y en los assets, no en el código.

### Cinemática 1 — Iglesia Interior (Intro)

| # | Hablante | Línea |
|---|---|---|
| 1 | Lucerna | ¿Veo que ya has despertado, como te sientes? |
| 2 | *Acción* | *Elysia se queda en silencio y la observa* |
| 3 | Lucerna | Te he traído algo para que comas, esas heridas no sanarán si no te alimentas bien. |
| 4 | Elysia | ¿Quién eres tú?... ¿y como terminé aquí? |
| 5 | Lucerna | Yo me hago la misma pregunta, te encontré en un bosque cerca de aquí, estabas muy herida y te traje hasta acá, no es bueno estar mucho tiempo afuera... |
| 6 | Lucerna | Los Droglots han invadido la zona y cada vez son más fuertes, hay una corriente indómita de energía corrupta por la zona, y cada vez entendemos menos de lo que sucede. |
| 7 | Lucerna | Come tranquila, no te hare daño. |
| 8 | *Acción* | *Elysia agarra la comida y asiente con la cabeza en señal de gracias y empieza a comer* |
| 9 | Elysia | En realidad no recuerdo que sucedió, mi cabeza duele. |
| 10 | Lucerna | ¿Recuerdas cómo te llamas? |
| 11 | Elysia | Mi nombre es Elysia... soy una exorcista de Abbysum. |
| 12 | Lucerna | ¿Abbysum? ¿Aquellas tierras lejanas donde empezó todo? |
| 13 | Elysia | Así es, ha pasado un tiempo ya desde que sucedió... ya sabes... |
| 14 | Lucerna | Tienes razón... |
| 15 | Lucerna | Me presento, soy Lucerna, Soy una exorcista de estas tierras. |
| 16 | Lucerna | Y cómo puedes ver, puedo usar magia... de hecho, es lo que usé para sanar algo de tus heridas. |

### Cinemática 2 — La puerta (transición al exterior)

| # | Hablante | Línea |
|---|---|---|
| 1 | *Acción* | *Lucerna y Elysia abren las puertas de la iglesia* |
| 2 | *Acción* | *Ven un camino lleno de cadáveres de Droglots en un bosque oscuro* |
| 3 | *Acción* | *Al fondo se ven unos lobos llegando listos para la pelea* |
| 4 | Lucerna | Esos monstros son de los fáciles, pero a medida que vayamos avanzando habrá monstros más poderosos... |
| 5 | Elysia | Los exorcizaremos, no hay duda de eso. |

---

## Descripción visual de escenarios

### Iglesia Interior (Cinemática 1 + Gameplay 1)
- Iglesia **abandonada y en ruinas**
- Sillas/bancos de madera **desgastados**
- Paredes con **moho**
- **Luz roja oscura** filtrada por vidrios artísticos/emplomados
- Sensación de abandono prolongado
- Referencia visual: interior gótico con vidrieras de colores rojos/anaranjados

### Bosque Oscuro — Exterior (Cinemática 2 + Gameplay 2)
- **Bosque oscuro** — no es un exterior de iglesia convencional
- Camino con **cadáveres de Droglots** esparcidos
- Árboles de diseño oscuro/corrupto (referencia visual: árboles morados/negros con formas tentaculares)
- **Luna llena** visible al fondo
- Atmósfera: opresiva, peligrosa, de noche o crepúsculo oscuro
- Los lobos (Droglots) emergen desde el fondo del camino

---

## Triggers de gameplay

| Trigger | Condición | Resultado |
|---|---|---|
| `Trigger_Door` | Elysia interactúa con la puerta (tecla E) | Inicia Cinemática 2 → carga escena Bosque Oscuro |
| `Trigger_WolfEncounter` | Elysia entra a la zona de combate (Bosque) | Activa spawning de lobos enemigos |

---

## Lo que NO cambiará entre versiones de la historia

Estos elementos son **fijos** — el código depende de ellos:
- Existen exactamente 2 cinemáticas para la demo
- Hay exactamente 1 trigger de interacción de puerta en Iglesia Interior
- El combate ocurre en el escenario exterior (Bosque Oscuro)
- El tipo de enemigo de la demo son lobos (un solo prefab, múltiples instancias)

## Lo que SÍ puede cambiar

Estos elementos son **volátiles** — solo requieren actualizar datos:
- Texto de los diálogos
- Número de líneas de diálogo
- Descripciones narrativas de las cinemáticas
- Detalles del lore (nombres de lugares, historia de Abbysum)
- Añadir/quitar acciones narrativas intermedias

---

## Changelog de la historia

| Versión | Fecha | Cambio |
|---|---|---|
| v1.0 | 2026-06-20 | Historia inicial extraída de Historia_DEMO.pdf — Primer acto |
