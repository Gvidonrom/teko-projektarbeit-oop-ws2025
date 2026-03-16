# 02 - Testfaelle

## Testplan

| ID | Anforderung | Testschritte | Erwartetes Resultat | Ist-Resultat | Status | Kommentar/Korrektur |
|---|---|---|---|---|---|---|
| T01 | Projekt erstellen | In Tab **Projekte** Name, Kunde, PM, Kernanforderungen eingeben -> **Projekt anlegen** | Projekt wird erstellt und in der Projektliste angezeigt | Projekt wurde erstellt und korrekt in der Liste dargestellt | Bestanden | - |
| T02 | Projektname eindeutig | Projekt mit bereits vorhandenem Namen erneut anlegen | Fehlermeldung, kein Duplikat | Es erscheint Fehlermeldung, zweites Projekt mit gleichem Namen wird nicht angelegt | Bestanden | Regel im `ProjectService` abgesichert |
| T03 | Text-Information anlegen | Projekt auswaehlen -> Tab **Information hinzufuegen** -> Art = Text -> Inhalt erfassen -> Speichern | Eintrag erscheint in Projektinfos | Textinformation wird in der Liste angezeigt | Bestanden | - |
| T04 | Bild-URL anlegen | Art = Bild(URL) waehlen -> URL eingeben -> Speichern | Eintrag erscheint, URL gespeichert | Eintrag ist sichtbar; URL wird in Info-Detail korrekt angezeigt | Bestanden | - |
| T05 | Dokument-URL anlegen | Art = Dokument(URL) waehlen -> URL eingeben -> Speichern | Eintrag erscheint, URL gespeichert | Eintrag ist sichtbar; URL kann ueber Detailfenster geoeffnet werden | Bestanden | - |
| T06 | Tags max 3 | Mehr als 3 Tags eingeben (z. B. 5 Werte) | Nur max. 3 eindeutige Tags gespeichert | Es werden nur 3 Tags uebernommen, Duplikate bereinigt | Bestanden | Begrenzung sowohl UI-nah als auch in Service-Logik |
| T07 | Keine Tags eingeben | Leeres Tag-Feld und Speichern versuchen | Validierungsfehler | Hinweisdialog erscheint; Speichern wird abgebrochen | Bestanden | Benutzerhinweis vorhanden |
| T08 | Kommentar hinzufuegen | Info auswaehlen -> Kommentar eingeben -> **Kommentar hinzufuegen** | Kommentar wird gespeichert und angezeigt | Kommentar erscheint im Bereich „Kommentare ...“ der ausgewaehlten Info | Bestanden | Auswahl bleibt erhalten |
| T09 | Revision Text | Text-Info auswaehlen -> Revision eingeben -> **Version hinzufuegen** | Revision wird gespeichert und vom Original unterscheidbar angezeigt | Revision erscheint in „Versionen“, Textinhalt wurde ergaenzt | Bestanden | Trennung ueber eigenes `Revision`-Objekt |
| T10 | Revision auf Bild/Dokument | Bild- oder Dokument-Info auswaehlen -> Revision speichern | Fehlermeldung | Operation wird abgelehnt mit Fehlermeldung | Bestanden | Fachregel korrekt durchgesetzt |
| T11 | Suche nach vorhandenem Tag | In Tab **Suche** bestehenden Tag eingeben -> **Suchen** | Trefferliste mit passenden Eintraegen | Passende Eintraege werden angezeigt | Bestanden | - |
| T12 | Suche nach nicht vorhandenem Tag | Nicht vorhandenen Tag suchen | Leere Trefferliste | Trefferliste bleibt leer | Bestanden | - |
| T13 | Information loeschen | Info auswaehlen -> **Ausgewaehlte Information loeschen** -> Bestaetigen | Information wird entfernt | Eintrag verschwindet aus Projektliste | Bestanden | Bestaetigungsdialog vorhanden |
| T14 | Projekt loeschen | Projekt in Liste per Rechtsklick -> **Projekt loeschen** -> Bestaetigen | Projekt inkl. zugehoeriger Infos entfernt | Projekt wird aus Liste entfernt, Inhalte nicht mehr verfuegbar | Bestanden | Kontextmenue funktioniert |
| T15 | Info-Detailfenster | In Spalte **Info** auf Eintrag klicken | Detailfenster oeffnet; Text/URL voll sichtbar | Fenster oeffnet korrekt; URL kann per Button im Browser geoeffnet werden | Bestanden | - |
| T16 | Anzeige/Startverhalten | Anwendung starten; Fenstergroesse pruefen | Fenster maximiert; bei kleineren Aufloesungen Scroll moeglich | Start ist maximiert, Inhalte sind durch Scroll erreichbar | Bestanden | Verbesserte Lesbarkeit in Praesentation |

## Zusammenfassung
- Geplante Testfaelle: 16
- Durchgefuehrte Testfaelle: 16
- Bestanden: 16
- Nicht bestanden: 0

## Offene Punkte
- Keine kritischen offenen Punkte fuer den geforderten Prototypen.
- Moegliche Erweiterungen fuer spaeter:
  - persistente Datenhaltung (z. B. Datenbank),
  - Rollen/Berechtigungen mit echter Authentifizierung,
  - Export/Import von Projektdaten.