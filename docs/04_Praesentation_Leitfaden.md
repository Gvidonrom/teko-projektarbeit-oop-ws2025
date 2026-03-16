# 04 - Praesentation (5-7 Minuten)

## Ziel der Praesentation
In 5-7 Minuten soll klar gezeigt werden:
- welche Ausgangslage vorlag,
- welche Ziele verfolgt wurden,
- wie die Loesung aufgebaut ist,
- wie die Funktionen getestet wurden,
- welche Erfahrungen aus der Umsetzung entstanden sind.

---

## Zeitplan (Vorschlag)

### 1) Ausgangslage und Aufgabenverstaendnis (ca. 45 Sekunden)
Die Firma Xarelto benoetigt ein einfaches Wissensmanagement fuer Projekte.  
Projektinformationen liegen oft verteilt vor und sind schwer auffindbar.  
Die Aufgabenstellung fordert deshalb einen Prototyp, mit dem Projektleiter und Mitarbeiter Informationen strukturiert erfassen, mit Tags versehen, kommentieren, ergaenzen und nach Tags durchsuchen koennen.

### 2) Zielsetzung (ca. 45 Sekunden)
Die wichtigsten messbaren Ziele waren:
- Projektanlage mit Name, Kunde, Projektleiter, Kernanforderungen
- Informationstypen: Text, Bild-URL, Dokument-URL
- maximal 3 Tags pro Information
- Kommentare und Revisionen
- Suche nach Tags
- Nachweis der Funktionalitaet durch geplante und durchgefuehrte Testfaelle

### 3) Loesungsansatz / Architektur (ca. 60 Sekunden)
Die Loesung wurde als WPF-Anwendung mit MVVM umgesetzt und in Schichten getrennt:
- **Domain** (Fachlogik und Modelle)
- **Application** (Services)
- **Infrastructure** (InMemory-Repository)
- **Presentation** (WPF + ViewModel)

Vorteil: klare Trennung von Verantwortlichkeiten, gute Nachvollziehbarkeit, einfache Erweiterbarkeit.

### 4) Live-Demo (ca. 120 Sekunden)
Vorgehen in der Demo:
1. Projekt anlegen
2. Informationen in verschiedenen Typen hinzufuegen
3. Tags vergeben und nach Tags suchen
4. Kommentar und Revision hinzufuegen
5. Info-Detailfenster oeffnen (Text lesen / URL im Browser oeffnen)
6. Information und Projekt loeschen (inkl. Kontextmenue)

### 5) Testresultate (ca. 60 Sekunden)
Die Testfaelle wurden vorab geplant und anschliessend praktisch durchgefuehrt.  
Alle Kernfaelle sind bestanden:
- Projektanlage
- Eindeutiger Projektname
- Informationserfassung
- Tag-Regeln
- Kommentare/Revisionen
- Suche
- Loeschfunktionen
- Detailansicht

Nicht funktionierende Punkte wurden im Verlauf korrigiert und erneut getestet.

### 6) Planung, Controlling und Learnings (ca. 45 Sekunden)
Der Gesamtaufwand lag ueber der urspruenglichen Planung, vor allem wegen UI-Feinschliff und Dokumentation.  
Wichtigste Erkenntnisse:
- Geschaeftsregeln zentral in Domain/Services absichern
- UI-Entwicklung realistisch mit Puffer planen
- Dokumentation parallel zur Entwicklung pflegen
- Iteratives Vorgehen bringt stabile Ergebnisse

---

## Abschluss-Satz (10-15 Sekunden)
Der Prototyp erfuellt die geforderte Funktionalitaet der Aufgabenstellung, ist nachvollziehbar dokumentiert und durch Testfaelle belegt.  
Damit ist eine solide Grundlage fuer eine spaetere Erweiterung mit persistenter Datenhaltung geschaffen.

---

## Erwartbare Fragen und kurze Antworten

### Warum wurde keine Datenbank verwendet?
Die Aufgabenstellung fordert einen Prototyp fuer kleine Datenmengen (bis ca. 100 Eintraege).  
InMemory ist dafuer ausreichend und reduziert die technische Komplexitaet.

### Wie wird die Tag-Regel abgesichert?
Durch Validierung in der Logik (maximal 3 Tags, Duplikatbereinigung), nicht nur in der UI.

### Wie werden Originaltext und Ergaenzungen getrennt?
Ergaenzungen werden als eigene `Revision`-Objekte gespeichert und damit klar vom Original unterscheidbar gemacht.