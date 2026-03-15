# Praesentationsleitfaden (5–7 Minuten)

## Folie 1 – Ausgangslage (ca. 45s)
- Problem: Projektwissen war verteilt, schwer auffindbar, wenig strukturiert.
- Ziel: einfacher, vorzeigbarer Prototyp fuer Wissensmanagement in Projekten.

## Folie 2 – Was wurde verstanden? (ca. 45s)
- Projektanlage mit Kernangaben.
- Informationstypen: Text, Bild-URL, Dokument-URL.
- Tags (max. 3), Kommentare, Ergaenzungen/Revisionen, Suche nach Tags.

## Folie 3 – Ziele (messbar) (ca. 45s)
- Alle Muss-Use-Cases in der Anwendung vorhanden.
- Testfaelle geplant und durchgefuehrt.
- Bedienbarer UI-Prototyp mit klarer Struktur.

## Folie 4 – Loesungsansatz / Architektur (ca. 60s)
- Domain + Services + InMemory-Repository + WPF(MVVM).
- Warum: einfache Trennung von Fachlogik, Speicherung und UI.
- Kurzer Blick aufs Klassendiagramm.

## Folie 5 – Live-Demo (ca. 90s)
- Projekt anlegen.
- Information erfassen.
- Kommentar / Revision erfassen.
- Suche nach Tag.
- Info-Detailfenster und Loeschfunktion zeigen.

## Folie 6 – Testresultate (ca. 60s)
- Tabelle mit geplanten/durchgefuehrten Tests.
- Kurz erwaehnen, welche Fehler korrigiert wurden (z. B. Kind-Mapping, Anzeige/UX).

## Folie 7 – Planung & Erfahrungen (ca. 45s)
- Geplant vs. Ist (Delta kurz begruenden).
- Wichtigste Learnings:
  - Fachregeln zentral absichern.
  - UI/Biding frueh testen.
  - Doku parallel zur Implementierung fuehren.

---

## Fragen, die typischerweise kommen (Kurzantworten)

- **Warum kein EF/Core?**  
  Prototyp fuer kleine Datenmenge; InMemory reicht und reduziert Komplexitaet.

- **Wie wird max. 3 Tags sichergestellt?**  
  In der Service-Logik (Validierung/Begrenzung), nicht nur in der UI.

- **Wie ist Original vs. Ergaenzung trennbar?**  
  Ueber eigenes `Revision`-Objekt bei `TextInformation`.

