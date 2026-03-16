# 03 – Planung und Controlling

## Planung vs. Ist

| Arbeitspaket                      |Geplant(h)|Ist(h)| Delta   | Bemerkung                                                               |
|-----------------------------------|---------:|-----:|--------:|-------------------------------------------------------------------------|
| Analyse der Aufgabenstellung      | 3        | 4    | +1      | Anforderungen und Abgrenzung mussten präzisiert werden                  |
| Design / Klassendiagramm          | 3        | 4    | +1      | Diagramm wurde nach Implementierungsdetails erweitert                   |
| Implementierung Domain + Services | 5        | 7    | +2      | Zusätzliche Regeln (eindeutiger Name, Löschfunktionen, Tag-Validierung) |
| Implementierung UI (WPF/MVVM)     | 5        | 8    | +3      | Mehr Aufwand für Bindings, Detailfenster und Bedienbarkeit              |
| Testplanung und Tests             | 2        | 3    | +1      | Testfälle detaillierter dokumentiert und wiederholt geprüft             |
| Dokumentation und Präsentation    | 2        | 4    | +2      | Umfangreiche Abschlussdokumentation und Präsentationsvorbereitung       |
| **Summe**                         | **20**   |**30**| **+10** | Delta ist für ein Lernprojekt nachvollziehbar                           |

## Delta-Analyse

### Positive Deltas (mehr Aufwand als geplant)
- Die UI-Umsetzung in WPF/MVVM war aufwendiger als erwartet (Bindings, Zustände, Interaktion).
- Im Verlauf wurden zusätzliche sinnvolle Funktionen umgesetzt:
  - Projekt-/Informationslöschung
  - Projektdetailblock
  - Info-Detailfenster mit Link-Öffnung
- Die Dokumentation wurde bewusst ausführlich erstellt, um die Bewertungskriterien vollständig abzudecken.

### Negative Deltas (weniger Aufwand als geplant)
- Keine wesentlichen negativen Deltas.
- Einzelne technische Grundlagen (z. B. InMemory-Repository) konnten schneller umgesetzt werden.

## Erkenntnisse für zukünftige Arbeiten
- Für UI-Arbeiten sollte frühzeitig ein realistisch größerer Zeitpuffer eingeplant werden.
- Testfälle sollten bereits in der Analysephase vorbereitet werden.
- Fachregeln müssen zentral in Domain/Services abgesichert werden, nicht nur in der Oberfläche.
- Eine laufende Dokumentation reduziert den Aufwand am Ende deutlich.

