# 02 – Testfälle

## Testplan

| ID  | Anforderung                | Testschritte                                  | Erwartetes Resultat                                  | Ist-Resultat                                                        | Status    | Kommentar / Korrektur |
|-----|----------------------------|-----------------------------------------------|------------------------------------------------------|---------------------------------------------------------------------|-----------|---------------------------------------|
| T01 | Projekt erstellen          | Projektdaten eingeben, speichern              | Projekt wird erstellt und angezeigt                  | Projekt wurde erstellt und korrekt in der Projektliste angezeigt    | Bestanden | -                                     |
| T02 | Projektname eindeutig      | Projekt mit gleichem Namen erneut anlegen     | Fehlermeldung, kein Duplikat                         | Fehlermeldung erscheint, kein zweites Projekt mit gleichem Namen    | Bestanden | Regel im `ProjectService` abgesichert |
| T03 | Text-Information anlegen   | Typ „Text“ auswählen, Inhalt speichern        | Eintrag erscheint in Projektinfos                    | Textinformation wird korrekt angezeigt                              | Bestanden | -                                     |
| T04 | Bild-URL anlegen           | Typ „Bild (URL)“ auswählen, URL speichern     | Eintrag erscheint, URL gespeichert                   | Eintrag sichtbar; URL wird korrekt übernommen                       | Bestanden | -                                     |
| T05 | Dokument-URL anlegen       | Typ „Dokument (URL)“ auswählen, URL speichern | Eintrag erscheint, URL gespeichert                   | Eintrag sichtbar; URL kann im Detailfenster geöffnet werden         | Bestanden | -                                     |
| T06 | Tags max. 3                | Mehr als 3 Tags eingeben                      | Nur maximal 3 Tags werden gespeichert                | Es werden nur 3 Tags übernommen, Duplikate bereinigt                | Bestanden | Begrenzung in UI und Service-Logik    |
| T07 | Kommentar hinzufügen       | Info auswählen, Kommentar speichern           | Kommentar erscheint in der Liste                     | Kommentar wird gespeichert und angezeigt                            | Bestanden | -                                     |
| T08 | Revision für Text          | Text-Info auswählen, Revision speichern       | Revision erscheint, Text wird ergänzt                | Revision wird separat angezeigt und Textinhalt erweitert            | Bestanden | Trennung über `Revision`-Objekt       |
| T09 | Revision auf Bild/Dokument | Nicht-Text-Info auswählen, Revision speichern | Fehlermeldung                                        | Operation wird mit Fehlermeldung abgelehnt                          | Bestanden | Fachregel korrekt umgesetzt           |
| T10 | Suche nach Tag             | Tag eingeben, suchen                          | Trefferliste zeigt passende Einträge                 | Passende Einträge werden korrekt angezeigt                          | Bestanden | -                                     |
| T11 | Information löschen        | Info auswählen, Löschung bestätigen           | Info wird entfernt                                   | Eintrag wird entfernt und nicht mehr angezeigt                      | Bestanden | Bestätigungsdialog vorhanden          |
| T12 | Projekt löschen            | Projekt über Kontextmenü löschen              | Projekt inkl. zugehöriger Infos entfernt             | Projekt und Inhalte werden entfernt                                 | Bestanden | Kontextmenü funktioniert              |
| T13 | Info-Detailfenster         | In Spalte „Info“ klicken                      | Detailfenster öffnet, URL/Text sichtbar              | Fenster öffnet; Text lesbar, URL im Browser öffnbar                 | Bestanden | -                                     |
| T14 | Projektdetails anzeigen    | Projekt in Liste auswählen                    | Name, Kunde, Kernanforderungen, PM werden angezeigt  | Detailblock wird korrekt aktualisiert                               | Bestanden | -                                     |
| T15 | Startverhalten UI          | Anwendung starten                             | Fenster startet maximiert                            | Anwendung startet maximiert mit Scroll-Unterstützung                | Bestanden | Verbesserte Präsentationsfähigkeit    | 

## Zusammenfassung
- Geplante Testfälle: 15
- Durchgeführte Testfälle: 15
- Bestanden: 15
- Nicht bestanden: 0

## Offene Punkte
- Keine kritischen offenen Punkte für den geforderten Prototyp.
- Mögliche Erweiterungen:
  - persistente Datenhaltung (Datenbank),
  - differenzierte Rollen/Berechtigungen,
  - erweiterte Suchfilter.

