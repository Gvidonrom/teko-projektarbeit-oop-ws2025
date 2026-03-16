# 03 - Planung und Controlling

## Planung vs. Ist

| Arbeitspaket | Geplant (h) | Ist (h) | Delta | Bemerkung |
|---|---:|---:|---:|---|
| Analyse der Aufgabenstellung | 3 | 4 | +1 | Anforderungen und Abgrenzung mussten genauer ausgearbeitet werden |
| Design / Klassendiagramm | 3 | 4 | +1 | Diagramm wurde nach Implementierungsdetails erweitert |
| Implementierung Domain + Services | 5 | 7 | +2 | Zusaetzliche Regeln (Unique Name, Delete-Funktionen, Tag-Validierung) umgesetzt |
| Implementierung UI (WPF/MVVM) | 5 | 8 | +3 | Mehr Aufwand fuer Bindings, neue Ansichten (Detailfenster), Usability-Verbesserungen |
| Testplanung und Tests | 2 | 3 | +1 | Testfaelle wurden detaillierter dokumentiert und nachgebessert |
| Dokumentation und Praesentation | 2 | 4 | +2 | Umfangreiche Enddokumentation inkl. Checklisten und Praesentationsleitfaden |
| **Summe** | **20** | **30** | **+10** | Delta fuer Lernprojekt nachvollziehbar und fachlich begruendet |

## Delta-Analyse

### Positive Deltas (mehr Aufwand als geplant)
- Die UI-Umsetzung in WPF/MVVM war aufwaendiger als erwartet (Bindings, Command-Logik, Detailansichten).
- Durch iterative Verbesserungen kamen weitere sinnvolle Funktionen hinzu:
  - Projekt-/Informationsloeschung
  - Projektdetails in der Ansicht
  - Info-Spalte mit Klick und Detailfenster
- Die Dokumentation wurde bewusst ausfuehrlich erstellt, um den Bewertungsanforderungen (Analyse, Testnachweise, Lehren) voll zu entsprechen.

### Negative Deltas (weniger Aufwand als geplant)
- Keine nennenswerten negativen Deltas.
- Einzelne Teilaufgaben (z. B. InMemory-Repository) konnten dafuer schneller umgesetzt werden als komplexere Persistenz.

## Erkenntnisse fuer zukuenftige Arbeiten

- **Puffer fuer UI einplanen:** Oberflaechenentwicklung kostet meist mehr Zeit als anfangs angenommen.
- **Tests frueh mitdenken:** Frueh definierte Testfaelle helfen bei Struktur und Fehlervermeidung.
- **Regeln zentral absichern:** Fachregeln (z. B. max. Tags, eindeutige Projektnamen) nicht nur in der UI, sondern in Service/Domain absichern.
- **Dokumentation parallel fuehren:** Laufende Dokumentation spart Zeit am Schluss und verbessert die Nachvollziehbarkeit.
- **Iteratives Vorgehen funktioniert:** Kleine, pruefbare Verbesserungen reduzieren Risiko und verbessern Stabilitaet.