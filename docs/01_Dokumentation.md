# 01 - Dokumentation

## 1. Analyse nach dem roten Faden

### 1.1 Ausgangslage

Die kleine IT-Firma Xarelto moechte die Zusammenarbeit in Projekten verbessern und ein einfaches Wissensmanagement einfuehren.  
Projektbezogene Informationen liegen oft verteilt vor und sind schwer wiederzufinden.  
Deshalb soll ein Prototyp entwickelt werden, mit dem Projektleiter und Projektmitarbeiter Informationen strukturiert in Projekten erfassen, mit Tags versehen, kommentieren, ergaenzen und nach Tags suchen koennen.

Im Rahmen der Aufgabenstellung werden folgende Informationen pro Projekt benoetigt:
- Name des Projekts
- Kunde
- Projektleiter
- Kernanforderungen

Zusaetzlich muessen Informationen in den Typen Text, Bild-URL und Dokument-URL verwaltet werden.

### 1.2 Stakeholder

Im Kontext dieser Projektarbeit sind folgende Stakeholder relevant:

| Stakeholder                  | Beschreibung                                                 | Interesse / Erwartung                                                                                         |
|------------------------------|--------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|
| Projektleiter (PL)           | Verantwortlich fuer die Planung und Steuerung eines Projekts | Moechte neue Projekte anlegen, Kernanforderungen erfassen und den Informationsstand ueberblicken              |
| Projektmitarbeiter           | Arbeiten aktiv innerhalb der Projekte                        | Moechten Informationen erfassen (Text, Bild-URL, Dokument-URL), mit Tags versehen, kommentieren und ergaenzen |
| Firma Xarelto (Auftraggeber) | Nutzt den Prototyp als internes Wissensmanagement-Werkzeug   | Moechte projektbezogenes Wissen strukturiert speichern und wiederfinden                                       |
| Dozent / Bewertungsperson    | Bewertet Umsetzung, Dokumentation und Praesentation          | Erwartet nachvollziehbare Analyse, klaren Loesungsansatz, Testnachweise und reflektierte Erkenntnisse         |

Die Stakeholder interagieren mit dem System, um projektbezogene Informationen zu erfassen, zu erweitern, zu suchen und zu verwalten.  
Der Prototyp unterstuetzt dabei den geforderten Ablauf der Aufgabenstellung und dient gleichzeitig als vorzeigbare Demonstrationsloesung.

### 1.3 Zielsetzung (messbar)

Ziel dieses Projekts ist die Entwicklung eines prototypischen Wissensmanagement-Systems
fuer Projektinformationen. Das System soll Projektleitern und Projektmitarbeitern
ermoeglichen, Informationen strukturiert zu erfassen, zu ergaenzen und ueber Tags
wiederzufinden.

#### Muss- und Wunschziele

Die Projektziele werden in Muss- und Wunschziele unterteilt und durch Testfaelle nachgewiesen.

| Ziel                           | Typ    | Beschreibung                                                                                            | Messkriterium / Nachweis                                                 |
|--------------------------------|--------|---------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------|
| Projekt erstellen              | Muss   | Ein Projektleiter kann ein neues Projekt mit Name, Kunde, Projektleiter und Kernanforderungen erstellen | Projekt wird gespeichert und in der Projektliste angezeigt               |
| Informationen hinzufuegen      | Muss   | Informationen koennen einem Projekt zugeordnet werden                                                   | Neuer Eintrag erscheint bei den Projektinformationen                     |
| Verschiedene Informationstypen | Muss   | Informationen werden als Text, Bild-URL oder Dokument-URL gespeichert                                   | Alle drei Typen lassen sich erfolgreich anlegen                          |
| Tags vergeben (max. 3)         | Muss   | Jeder Information koennen bis zu drei Tags zugeordnet werden                                            | Bei mehr als drei Tags werden nur maximal drei gueltige Tags uebernommen |
| Kommentare hinzufuegen         | Muss   | Benutzer koennen Informationen kommentieren                                                             | Kommentar wird gespeichert und angezeigt                                 |
| Revisionen hinzufuegen         | Muss   | Ergaenzungen zu Textinformationen sind klar vom Original unterscheidbar                                 | Revision wird separat gespeichert und als Revision angezeigt             |
| Suche nach Tags                | Muss   | Informationen koennen innerhalb eines Projekts ueber Tags gesucht werden                                | Trefferliste zeigt nur passende Informationen                            |
| Einfache Benutzeroberflaeche   | Wunsch | Bedienbare GUI fuer alle Kernfunktionen                                                                 | Kernaufgaben sind ohne technische Kenntnisse bedienbar                   |
| Erweiterbarkeit der Suche      | Wunsch | Suchfunktion soll spaeter ausgebaut werden koennen (z. B. mehrere Filter)                               | Architektur erlaubt Erweiterung ohne Grundumbau                          |

Aus den Muss- und Wunschzielen wurden systematisch Testfaelle abgeleitet.  
Die Ergebnisse der geplanten und durchgefuehrten Tests sind in `docs/02_Testfaelle.md` festgehalten und bilden den Nachweis der funktionalen Zielerreichung.

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

Wichtige Fachregeln wurden zentral in der Logik abgesichert (z. B. eindeutiger Projektname, maximal drei Tags, Revision nur fuer Textinformation), damit sie nicht nur von der UI abhaengen.

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
- Exportierte Grafik: `docs/diagrams/erläutertes_klassendiagramm.png und use_case_diagramm.png`

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
  - Tags (maximal 3)
  - Kommentare und Revisionen
  - Suche nach Tags
- Die geplanten Testfaelle wurden durchgefuehrt und bewertet.
- Nicht funktionierende Punkte wurden waehrend der Entwicklung korrigiert und erneut geprueft (z. B. Typ-Mapping in der UI, Anzeigeverhalten, Loesch-Workflows).

---

## 4. Besondere Realisationselemente

- **Eindeutiger Projektname**  
  Beim Erstellen wird geprueft, ob ein Projektname bereits existiert.
- **Automatische Projekt-ID-Vergabe**  
  Die Projekt-ID wird intern vergeben; der Benutzer muss sie nicht eingeben.
- **Tag-Regeln abgesichert**  
  Maximal drei Tags, Bereinigung von Duplikaten, Validierung auf mindestens ein Tag.
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
Durch die gewaehlte Struktur (Domain, Services, Repository, MVVM) ist die Loesung klar aufgebaut und erweiterbar.

Fuer zukuenftige Ausbaustufen bieten sich vor allem folgende Punkte an:
- persistente Speicherung (z. B. Datenbank),
- differenzierteres Rollen- und Berechtigungskonzept,
- erweiterte Such- und Filterfunktionen,
- formale Internationalisierung (Localization) der UI-Texte.

