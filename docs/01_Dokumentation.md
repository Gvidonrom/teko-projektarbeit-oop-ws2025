# 01 – Dokumentation

## 1. Analyse nach dem roten Faden

### 1.1 Ausgangslage

Die kleine IT-Firma Xarelto möchte die Zusammenarbeit in Projekten verbessern und ein einfaches Wissensmanagement einführen.  
Projektbezogene Informationen liegen häufig verteilt vor und sind nur schwer wiederzufinden.  
Daher soll ein Prototyp entwickelt werden, mit dem Projektleiter und Projektmitarbeiter Informationen strukturiert erfassen, mit Tags versehen, kommentieren, ergänzen und nach Tags durchsuchen können.

Im Rahmen der Aufgabenstellung werden folgende Informationen pro Projekt benötigt:
- Name des Projekts
- Kunde
- Projektleiter
- Kernanforderungen

Zusätzlich müssen Informationen in den Typen Text, Bild-URL und Dokument-URL verwaltet werden.

### 1.2 Stakeholder

Im Kontext dieser Projektarbeit sind folgende Stakeholder relevant:

| Stakeholder                  | Beschreibung                                                | Interesse / Erwartung                                                                                       |
|------------------------------|-------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------|
| Projektleiter (PL)           | Verantwortlich für die Planung und Steuerung eines Projekts | Möchte neue Projekte anlegen, Kernanforderungen erfassen und den Informationsstand überblicken              |
| Projektmitarbeiter           | Arbeiten aktiv innerhalb der Projekte                       | Möchten Informationen erfassen (Text, Bild-URL, Dokument-URL), mit Tags versehen, kommentieren und ergänzen |
| Firma Xarelto (Auftraggeber) | Nutzt den Prototyp als internes Wissensmanagement-Werkzeug  | Möchte projektbezogenes Wissen strukturiert speichern und wiederfinden                                      |
| Dozent / Bewertungsperson    | Bewertet Umsetzung, Dokumentation und Präsentation          | Erwartet nachvollziehbare Analyse, klaren Lösungsansatz, Testnachweise und reflektierte Erkenntnisse        |

Die Stakeholder interagieren mit dem System, um projektbezogene Informationen zu erfassen, zu erweitern, zu suchen und zu verwalten.  
Der Prototyp unterstützt dabei den geforderten Ablauf der Aufgabenstellung und dient gleichzeitig als vorzeigbare Demonstrationslösung.

### 1.3 Zielsetzung (messbar)

Ziel dieses Projekts ist die Entwicklung eines prototypischen Wissensmanagement-Systems für Projektinformationen.  
Das System soll Projektleitern und Projektmitarbeitern ermöglichen, Informationen strukturiert zu erfassen, zu ergänzen und über Tags wiederzufinden.

#### Muss- und Wunschziele

Die Projektziele werden in Muss- und Wunschziele unterteilt und durch Testfälle nachgewiesen.

| Ziel                           | Typ    | Beschreibung                                                                                            | Messkriterium / Nachweis                                               |
|--------------------------------|--------|---------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------|
| Projekt erstellen              | Muss   | Ein Projektleiter kann ein neues Projekt mit Name, Kunde, Projektleiter und Kernanforderungen erstellen | Projekt wird gespeichert und in der Projektliste angezeigt             |
| Informationen hinzufügen       | Muss   | Informationen können einem Projekt zugeordnet werden                                                    | Neuer Eintrag erscheint bei den Projektinformationen                   |
| Verschiedene Informationstypen | Muss   | Informationen werden als Text, Bild-URL oder Dokument-URL gespeichert                                   | Alle drei Typen lassen sich erfolgreich anlegen                        |
| Tags vergeben (max. 3)         | Muss   | Jeder Information können bis zu drei Tags zugeordnet werden                                             | Bei mehr als drei Tags werden nur maximal drei gültige Tags übernommen |
| Kommentare hinzufügen          | Muss   | Benutzer können Informationen kommentieren                                                              | Kommentar wird gespeichert und angezeigt                               |
| Revisionen hinzufügen          | Muss   | Ergänzungen zu Textinformationen sind klar vom Original unterscheidbar                                  | Revision wird separat gespeichert und als Revision angezeigt           |
| Suche nach Tags                | Muss   | Informationen können innerhalb eines Projekts über Tags gesucht werden                                  | Trefferliste zeigt nur passende Informationen                          |
| Einfache Benutzeroberfläche    | Wunsch | Bedienbare GUI für alle Kernfunktionen                                                                  | Kernaufgaben sind ohne technische Vorkenntnisse bedienbar              |
| Erweiterbarkeit der Suche      | Wunsch | Suchfunktion soll später ausgebaut werden können (z. B. mehrere Filter)                                 | Architektur erlaubt Erweiterung ohne Grundumbau                        |

Aus den Muss- und Wunschzielen wurden systematisch Testfälle abgeleitet.  
Die Ergebnisse der geplanten und durchgeführten Tests sind in `docs/02_Testfaelle.md` festgehalten und bilden den Nachweis der funktionalen Zielerreichung.

### 1.4 Lösungsansatz

Die Lösung wurde als WPF-Anwendung mit MVVM-Struktur umgesetzt und in logische Schichten getrennt:

- **Domain-Schicht**  
  Fachobjekte wie `Project`, `Information`, `TextInformation`, `ImageInformation`, `DocumentInformation`, `Tag`, `Comment` und `Revision`.
- **Application-Schicht**  
  Anwendungslogik in Services (`ProjectService`, `InformationService`) sowie Request-Modelle für Use-Cases.
- **Infrastructure-Schicht**  
  Speicherung über ein `InMemoryProjectRepository`.  
  Diese Variante ist für den geforderten Prototypen mit kleiner Datenmenge ausreichend.
- **Presentation-Schicht (WPF/MVVM)**  
  `MainViewModel` steuert Commands und Datenbindung, die Views bilden die Bedienoberfläche.

Wichtige Fachregeln wurden zentral in der Logik abgesichert (z. B. eindeutiger Projektname, maximal drei Tags, Revision nur für Textinformationen), damit sie nicht nur in der Oberfläche gelten.

### 1.5 Lehren / Erkenntnisse

Aus der Umsetzung wurden folgende Erkenntnisse gewonnen:

- Eine klare Trennung in Schichten (Domain, Application, Infrastructure, UI) macht den Code wartbarer.
- Geschäftsregeln sollten in Services/Domain abgesichert werden, nicht nur in der Oberfläche.
- Frühe und konkrete Testfälle helfen, Fehler schneller zu finden (z. B. bei Bindings und Typzuordnung).
- Kleine iterative Verbesserungen führen schneller zu einem stabilen Prototyp als ein großer Einmal-Wurf.
- Für UI-Themen (Layout, Lesbarkeit, Interaktion) sollte von Anfang an Zeitpuffer eingeplant werden.

---

## 2. Erläutertes Klassendiagramm

Das Klassendiagramm wurde in PlantUML erstellt und als Grafik exportiert.

- PlantUML-Datei: `docs/diagrams/klassendiagramm.puml`
- Exportierte Grafik: `docs/diagrams/klassendiagramm.png`

### Erläuterung zum Diagramm

- `Project` ist das zentrale Aggregat und enthält mehrere `Information`-Einträge.
- `Information` ist abstrakt und besitzt die konkreten Typen:
  - `TextInformation`
  - `ImageInformation`
  - `DocumentInformation`
- Jede Information kann mit `Tag`-Objekten versehen und mit `Comment` kommentiert werden.
- Nur `TextInformation` unterstützt `Revision`-Einträge zur nachvollziehbaren Ergänzung.
- `ProjectService` und `InformationService` kapseln die Use-Case-Logik.
- Das `IProjectRepository` entkoppelt die Fachlogik vom Speicher; aktuell ist die Implementierung `InMemoryProjectRepository`.

---

## 3. Anforderungen und Testfälle (geplant und durchgeführt)

Die detaillierte Testfallliste ist in `docs/02_Testfaelle.md` dokumentiert.

### Zusammenfassung

- Alle Kernanforderungen der Aufgabenstellung wurden in der Anwendung umgesetzt:
  - Projektanlage
  - Informationserfassung (Text/Bild-URL/Dokument-URL)
  - Tags (maximal 3)
  - Kommentare und Revisionen
  - Suche nach Tags
- Die geplanten Testfälle wurden durchgeführt und bewertet.
- Fehlerhafte Punkte wurden während der Entwicklung korrigiert und erneut geprüft (z. B. Typ-Mapping in der UI, Anzeigeverhalten, Lösch-Workflows).

---

## 4. Besondere Realisationselemente

- **Eindeutiger Projektname**  
  Beim Erstellen wird geprüft, ob ein Projektname bereits existiert.
- **Automatische Projekt-ID-Vergabe**  
  Die Projekt-ID wird intern vergeben; der Benutzer muss sie nicht manuell eingeben.
- **Tag-Regeln abgesichert**  
  Maximal drei Tags, Bereinigung von Duplikaten, Validierung auf mindestens ein Tag.
- **Detailansicht für Info-Inhalte**  
  Eine eigene Ansicht zeigt lange Texte bzw. erlaubt das Öffnen gespeicherter URLs im Browser.
- **Löschfunktionen**  
  Informationen können aus dem Projekt entfernt werden; Projekte können per Kontextmenü gelöscht werden.
- **Projektdetails in der UI**  
  Name, Kunde, Kernanforderungen und Projektleiter werden im Detailblock angezeigt.
- **Präsentationsfreundliche UI**  
  Start im maximierten Fenster sowie Scroll-Unterstützung für kleinere Auflösungen.

---

## 5. Fazit

Die Zielsetzung der Projektarbeit wurde erreicht.  
Der Prototyp bildet die geforderten Geschäftsprozesse der Aufgabenstellung funktional ab und ist durch Testfälle nachvollziehbar validiert.  
Durch die gewählte Struktur (Domain, Services, Repository, MVVM) ist die Lösung klar aufgebaut und erweiterbar.

Für zukünftige Ausbaustufen bieten sich vor allem folgende Punkte an:
- persistente Speicherung (z. B. Datenbank),
- differenzierteres Rollen- und Berechtigungskonzept,
- erweiterte Such- und Filterfunktionen,
- formale Internationalisierung (Localization) der UI-Texte.

