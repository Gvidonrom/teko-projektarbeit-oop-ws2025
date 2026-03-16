# TEKO Projektarbeit OOP (WS2025/26)

Wissensmanagement-Prototyp für Projektinformationen  
implementiert in **C# / WPF (MVVM)**.

---

## Projektkontext

Diese Arbeit wurde im Rahmen der **TEKO Projektarbeit OOP (Wintersemester 2025/2026)** erstellt.

Ziel ist die Entwicklung eines einfachen Systems zur Verwaltung von Projektinformationen
für die Fallstudie der Firma **Xarelto**.

Das System dient als **Prototyp für ein Wissensmanagement-System**, mit dem Projektleiter
und Projektmitarbeiter Informationen strukturiert speichern, ergänzen und wiederfinden können.

---

## Umgesetzte Funktionalität

### Projektverwaltung
Ein Projekt kann angelegt werden mit:

- Name
- Kunde
- Projektleiter
- Kernanforderungen

---

### Projektinformationen

Informationen können einem Projekt zugeordnet werden als:

- **Text**
- **Bild (URL)**
- **Dokument (URL)**

---

### Tags

- maximal **3 Tags pro Information**
- doppelte Tags werden automatisch bereinigt

---

### Kommentare und Revisionen

- **Kommentare** für alle Informationstypen möglich
- **Revisionen** nur für Textinformationen
- Ergänzungen sind klar vom Originaltext getrennt

---

### Suche

- Suche nach **Tags innerhalb eines Projekts**

---

### Löschfunktionen

- Information löschen
- Projekt löschen (Kontextmenü)

---

### Detailansicht

- lange Texte können vollständig gelesen werden
- URLs können direkt im Browser geöffnet werden

---

### UI-Erweiterungen

- Projektdetails sichtbar (Name, Kunde, Anforderungen, Projektleiter)
- Anwendung startet maximiert
- Scroll-Unterstützung für größere Inhalte

---

## Architektur

Die Anwendung ist in mehrere Schichten aufgeteilt:

- **Domain**  
  Fachmodelle wie `Project`, `Information`, `Tag`, `Comment`, `Revision`
- **Application**  
  Geschäftslogik und Services (`ProjectService`, `InformationService`)
- **Infrastructure**  
  In-Memory-Repository für die Datenhaltung
- **Presentation**  
  WPF Benutzeroberfläche mit **MVVM**  
  (`MainViewModel`, Commands, Bindings)

Diese Struktur ermöglicht eine klare Trennung von Verantwortlichkeiten
und erleichtert Erweiterungen.

---

## Technischer Rahmen

- .NET 8
- C#
- WPF
- MVVM Pattern

---

## Projekt starten

```bash
dotnet build
dotnet run