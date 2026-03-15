# TEKO Projektarbeit OOP (WS2025/26)

Wissensmanagement-Prototyp fuer Projektinformationen in C# WPF (MVVM).

## Projektkontext

Diese Arbeit wurde im Rahmen der TEKO-Projektarbeit OOP (Wintersemester 2025/2026) erstellt.  
Ziel ist ein einfaches Verwaltungssystem fuer Informationen in Projekten (Firma Xarelto, Fallstudie).

## Umgesetzte Funktionalitaet

- Projekt anlegen mit:
  - Name
  - Kunde
  - Projektleiter
  - Kernanforderungen
- Informationen einem Projekt zuordnen:
  - Text
  - Bild (URL)
  - Dokument (URL)
- Tags pro Information:
  - maximal 3
  - Duplikate werden bereinigt
- Kommentare und Revisionen:
  - Kommentare fuer alle Informationstypen
  - Revisionen nur fuer Textinformationen
- Suche nach Tags innerhalb eines Projekts
- Loeschfunktionen:
  - Information loeschen
  - Projekt loeschen (Kontextmenue)
- Detailansicht fuer Info-Inhalte:
  - lange Texte lesbar
  - URL direkt im Browser oeffnen
- UI-Erweiterungen:
  - Projektdetails sichtbar (Name, Kunde, Kernanforderungen, PM)
  - Start im maximierten Fenster mit Scroll-Unterstuetzung

## Architektur

- **Domain**: Fachmodelle (`Project`, `Information`, `Tag`, `Comment`, `Revision`, ...)
- **Application**: Services + Requests (`ProjectService`, `InformationService`)
- **Infrastructure**: In-Memory-Repository
- **Presentation**: WPF + MVVM (`MainViewModel`, Commands, Bindings)

## Technischer Rahmen

- .NET 8
- WPF
- C#

## Projekt starten

```bash
dotnet build
dotnet run
