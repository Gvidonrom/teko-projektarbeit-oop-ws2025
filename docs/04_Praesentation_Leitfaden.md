# 04 – Präsentation (5–7 Minuten)

## Ziel der Präsentation
In 5–7 Minuten soll klar gezeigt werden:
- welche Ausgangslage vorlag,
- welche Ziele verfolgt wurden,
- wie die Lösung aufgebaut ist,
- wie die Funktionen getestet wurden,
- welche Erfahrungen aus der Umsetzung entstanden sind.

---

## Zeitplan (Vorschlag)

### 1) Ausgangslage und Aufgabenverständnis (ca. 45 Sekunden)
Die Firma Xarelto benötigt ein einfaches Wissensmanagement für Projekte.  
Projektinformationen liegen oft verteilt vor und sind schwer auffindbar.  
Die Aufgabenstellung fordert deshalb einen Prototyp, mit dem Projektleiter und Mitarbeiter Informationen strukturiert erfassen, mit Tags versehen, kommentieren, ergänzen und nach Tags durchsuchen können.

### 2) Zielsetzung (ca. 45 Sekunden)
Die wichtigsten messbaren Ziele waren:
- Projektanlage mit Name, Kunde, Projektleiter, Kernanforderungen
- Informationstypen: Text, Bild-URL, Dokument-URL
- maximal 3 Tags pro Information
- Kommentare und Revisionen
- Suche nach Tags
- Nachweis der Funktionalität durch geplante und durchgeführte Testfälle

### 3) Lösungsansatz / Architektur (ca. 60 Sekunden)
Die Lösung wurde als WPF-Anwendung mit MVVM umgesetzt und in Schichten getrennt:
- **Domain** (Fachlogik und Modelle)
- **Application** (Services)
- **Infrastructure** (InMemory-Repository)
- **Presentation** (WPF + ViewModel)

Vorteil: klare Trennung von Verantwortlichkeiten, gute Nachvollziehbarkeit und einfache Erweiterbarkeit.

### 4) Live-Demo (ca. 120 Sekunden)
Vorgehen in der Demo:
1. Projekt anlegen
2. Informationen in verschiedenen Typen hinzufügen
3. Tags vergeben und nach Tags suchen
4. Kommentar und Revision hinzufügen
5. Info-Detailfenster öffnen (Text lesen / URL im Browser öffnen)
6. Information und Projekt löschen (inkl. Kontextmenü)

### 5) Testresultate (ca. 60 Sekunden)
Die Testfälle wurden vorab geplant und anschließend praktisch durchgeführt.  
Alle Kernfälle sind bestanden:
- Projektanlage
- eindeutiger Projektname
- Informationserfassung
- Tag-Regeln
- Kommentare/Revisionen
- Suche
- Löschfunktionen
- Detailansicht

Nicht funktionierende Punkte wurden im Verlauf korrigiert und anschließend erneut getestet.

### 6) Planung, Controlling und Learnings (ca. 45 Sekunden)
Der Gesamtaufwand lag über der ursprünglichen Planung, vor allem wegen UI-Feinschliff und Dokumentation.  
Wichtigste Erkenntnisse:
- Geschäftsregeln zentral in Domain/Services absichern
- UI-Entwicklung realistisch mit Puffer planen
- Dokumentation parallel zur Entwicklung pflegen
- iteratives Vorgehen führt zu stabileren Ergebnissen

---

## Abschlusssatz (10–15 Sekunden)
Der Prototyp erfüllt die geforderte Funktionalität der Aufgabenstellung, ist nachvollziehbar dokumentiert und durch Testfälle belegt.  
Damit ist eine solide Grundlage für eine spätere Erweiterung mit persistenter Datenhaltung geschaffen.