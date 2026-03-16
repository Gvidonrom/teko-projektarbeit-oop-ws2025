# 01 - Dokumentation

## 1. Analyse nach dem roten Faden

### 1.1 Ausgangslage

Die kleine IT-Firma Xarelto moechte die Zusammenarbeit in Projekten verbessern und ein einfaches Wissensmanagement einführen.  
Projektbezogene Informationen liegen oft verteilt vor und sind schwer wiederzufinden.  
Deshalb soll ein Prototyp entwickelt werden, mit dem Projektleiter und Projektmitarbeiter Informationen strukturiert in Projekten erfassen, mit Tags versehen, kommentieren, ergaenzen und nach Tags suchen koennen.

Im Rahmen der Aufgabenstellung werden folgende Informationen pro Projekt benoetigt:
- Name des Projekts
- Kunde
- Projektleiter
- Kernanforderungen
Zusätzlich muessen Informationen in den Typen Text, Bild-URL und Dokument-URL verwaltet werden.

### 1.2 Stakeholder

Die wichtigsten Stakeholder dieser Projektarbeit sind:
- **Projektleiter (PL)**  
  Legt neue Projekte an, verwaltet Kerninformationen und braucht eine uebersichtliche Sicht auf den Projektstand.
- **Projektmitarbeiter**  
  Erfassen neue Informationen (Text, Bild-URL, Dokument-URL), vergeben Tags und ergaenzen bestehende Inhalte mit Kommentaren/Revisionen.
- **Firma Xarelto (Auftraggeber)**  
  Erwartet einen funktionalen, nachvollziehbaren Prototypen fuer internes Wissensmanagement.
- **Dozent / Bewertungsperson**  
  Bewertet die Arbeit anhand Analyse, Loesungsansatz, Testnachweis, Dokumentation und Praesentation.

### 1.3 Zielsetzung (messbar)

Fuer die Projektarbeit wurden folgende messbare Ziele definiert:
1. Es ist moeglich, ein Projekt mit den Feldern **Name, Kunde, Projektleiter und Kernanforderungen** anzulegen.
2. Pro Projekt koennen neue Informationen in drei Typen erfasst werden:
   - Text
   - Bild (URL)
   - Dokument (URL)
3. Pro Information koennen maximal **3 Tags** gespeichert werden.
4. Informationen koennen kommentiert werden.
5. Textinformationen koennen durch Revisionen ergaenzt werden, wobei Ergaenzungen vom Original nachvollziehbar getrennt bleiben.
6. Informationen koennen projektintern nach Tags gesucht werden.
7. Die wesentlichen Funktionen sind durch geplante und durchgefuehrte Testfaelle nachgewiesen.
8. Der Prototyp bleibt fuer kleine Datenmengen ausgelegt (ca. bis 100 Eintraege gemaess Aufgabenstellung).

### 1.4 Loesungsansatz

Die Loesung wurde als WPF-Anwendung mit MVVM-Struktur umgesetzt und in logische Schichten getrennt:

- **Domain-Schicht**  
  Fachobjekte wie `Project`, `Information`, `TextInformation`, `ImageInformation`, `DocumentInformation`, `Tag`, `Comment` und `Revision`.
- **Application-Schicht**  
  Anwendungslogik in Services (`ProjectService`, `InformationService`) sowie Request-Modelle fuer Use-Cases.
- **Infrastructure-Schicht**  
  Speicherung ueber ein `InMemoryProjectRepository`.  
  Diese Variante ist fuer den geforderten Prototypen mit kleiner Datenmenge ausreichend.
- **Presentation-Schicht (WPF/MVVM)**  
  `MainViewModel` steuert Commands und Datenbindung, die Views bilden die Bedienoberflaeche.
Wichtige Fachregeln wurden zentral in der Logik abgesichert (z. B. eindeutiger Projektname, max. 3 Tags, Revision nur fuer Textinformation), damit sie nicht nur von der UI abhaengen.

### 1.5 Lehren / Erkenntnisse

Aus der Umsetzung wurden folgende Erkenntnisse gewonnen:

- Eine klare Trennung in Schichten (Domain, Application, Infrastructure, UI) macht den Code wartbarer.
- Geschaeftsregeln sollen in Services/Domain abgesichert werden, nicht nur in der Oberflaeche.
- Fruehe und konkrete Testfaelle helfen, Fehler schneller zu finden (z. B. bei Binding und Typzuordnung).
- Kleine iterative Verbesserungen fuehren schneller zu einem stabilen Prototyp als ein grosser Einmal-Wurf.
- Fuer UI-Themen (Layout, Lesbarkeit, Interaktion) sollte von Anfang an Zeitpuffer eingeplant werden.

---

## 2. Erlaeutertes Klassendiagramm

Das Klassendiagramm ist in PlantUML erstellt und als Bild exportiert.

- PlantUML-Datei: `docs/diagrams/klassendiagramm.puml`
- Exportierte Grafik: `docs/diagrams/klassendiagramm.png`

### Erlaeuterung zum Diagramm

- `Project` ist das zentrale Aggregat und enthaelt mehrere `Information`-Eintraege.
- `Information` ist abstrakt und besitzt die konkreten Typen:
  - `TextInformation`
  - `ImageInformation`
  - `DocumentInformation`
- Jede Information kann mit `Tag`-Objekten versehen und mit `Comment` kommentiert werden.
- Nur `TextInformation` unterstuetzt `Revision`-Eintraege zur nachvollziehbaren Ergaenzung.
- `ProjectService` und `InformationService` kapseln die Use-Case-Logik.
- Das `IProjectRepository` entkoppelt die Fachlogik vom Speicher; aktuell ist die Implementierung `InMemoryProjectRepository`.
---

## 3. Anforderungen und Testfaelle (geplant und durchgefuehrt)

Die detaillierte Testfallliste ist in `docs/02_Testfaelle.md` dokumentiert.

### Zusammenfassung

- Alle Kernanforderungen der Aufgabenstellung wurden in der Anwendung umgesetzt:
  - Projektanlage
  - Informationserfassung (Text/Bild-URL/Dokument-URL)
  - Tags (max. 3)
  - Kommentare und Revisionen
  - Suche nach Tags
- Die geplanten Testfaelle wurden durchgefuehrt und bewertet.
- Nicht bestandene bzw. fehlerhafte Faelle wurden durch Korrekturmassnahmen bereinigt (z. B. bei UI-Binding, Typ-Mapping und Anzeigeverhalten).
---

## 4. Besondere Realisationselemente

Die folgenden Elemente wurden zusaetzlich bzw. bewusst umgesetzt:

- **Eindeutiger Projektname**  
  Beim Erstellen wird geprueft, ob ein Projektname bereits existiert.
- **Automatische Projekt-ID-Vergabe**  
  Die Projekt-ID wird intern vergeben; der Benutzer muss sie nicht eingeben.
- **Tag-Regeln abgesichert**  
  Maximal 3 Tags, Bereinigung von Duplikaten, Validierung auf mindestens ein Tag.
- **Detailansicht fuer Info-Inhalte**  
  Eine eigene Ansicht zeigt lange Texte bzw. erlaubt das Oeffnen gespeicherter URLs im Browser.
- **Loeschfunktionen**  
  Informationen koennen aus dem Projekt entfernt werden; Projekte koennen per Kontextmenue geloescht werden.
- **Projektdetails in der UI**  
  Name, Kunde, Kernanforderungen und Projektleiter werden im Detailblock angezeigt.
- **Praesentationsfreundliche UI**  
  Start im maximierten Fenster sowie Scroll-Unterstuetzung fuer kleinere Aufloesungen.
---

## 5. Fazit

Die Zielsetzung der Projektarbeit wurde erreicht.  
Der Prototyp bildet die geforderten Geschaeftsprozesse der Aufgabenstellung funktional ab und ist durch Testfaelle nachvollziehbar validiert.  
Durch die gewaehlte Struktur (Domain + Services + Repository + MVVM) ist die Loesung klar aufgebaut und erweiterbar.

Fuer zukuenftige Ausbaustufen bieten sich vor allem folgende Punkte an:
- persistente Speicherung (z. B. Datenbank),
- differenzierteres Rollen-/Berechtigungskonzept,
- erweiterte Such- und Filterfunktionen,
- formale Internationalisierung (Localization) der UI-Texte.

