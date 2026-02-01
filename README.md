\# CardVault 🃏



CardVault ist eine Webanwendung zur Verwaltung von Yu-Gi-Oh!-Kartensammlungen.

Ziel ist es, \*\*Sets vollständig abzubilden\*\*, Karten einer eigenen Sammlung zuzuordnen

und Besitz pro Set visuell darzustellen.



Das Projekt befindet sich aktiv in Entwicklung.



---



\## ✨ Features (aktueller Stand)



\- ✅ Benutzer-Login (ASP.NET Identity)

\- ✅ Eigene Sammlungen anlegen / löschen

\- ✅ Karten manuell zur Sammlung hinzufügen

\- ✅ Set-Ansicht mit:

&nbsp; - Auswahl aller importierten Sets

&nbsp; - Anzeige aller Karten eines Sets

&nbsp; - Besitz-Check pro Karte (✅ / ❌)

\- ✅ Automatische Zuordnung:

&nbsp; - Eingabe z. B. `RP02` + Kartenname → `RP02-DE090`

&nbsp; - Eingabe z. B. `RP02-DE090` → Kartenname wird automatisch ergänzt

\- ✅ Live-Updates zwischen Sammlung ↔ Set-Ansicht (ohne Page Reload)



---



\## 🧱 Tech-Stack (Kurzfassung)



\- \*\*.NET 8\*\*

\- \*\*Blazor Server (InteractiveServer)\*\*

\- \*\*Entity Framework Core\*\*

\- \*\*SQLite\*\* (lokale Entwicklung)

\- \*\*ASP.NET Identity\*\*

\- \*\*GitHub\*\* (Versionsverwaltung)



---



\## 🗂️ Zentrale Datenmodelle



\- `CardSet`  

&nbsp; → Ein offizielles Set (z. B. \*RP02 – Retro Pack 2\*)



\- `Card`  

&nbsp; → Eine Karte (z. B. \*Alpha, Magnetkrieger\*)



\- `SetCard`  

&nbsp; → Verknüpfung Set ↔ Karte inkl.:

&nbsp; - SetNumber (`RP02-DE089`)

&nbsp; - SortOrder



\- `Collection` / `CollectionItem`  

&nbsp; → Eigene Sammlungen pro User



---



\## 📥 Datenimport (in Arbeit)



Geplant ist der Import über:

\- \*\*YGOPRODeck API\*\*

\- Mehrsprachige Karten (DE / EN)

\- Vollständige Sets:

&nbsp; - Booster

&nbsp; - Tins

&nbsp; - Structure Decks

&nbsp; - Special Editions



Sets sollen \*\*einzeln auswählbar\*\* bleiben (Dropdown),

nicht zusammengeworfen.



---



\## 🧭 Nächste Schritte (Roadmap)



1\. 🔄 \*\*Import-Service finalisieren\*\*

2\. 🌍 Sprachfilter (DE / EN)

3\. ✏️ Bearbeiten von Karten \& Sets

4\. 📊 Fortschrittsanzeige pro Set (% vollständig)

5\. 📦 Export / Backup der Sammlung



---



\## 🧠 Hinweis für KI-Assistenz (Claude / GPT)



\- Keine hardcodierten Karten oder Sets

\- Sets kommen ausschließlich aus der Datenbank

\- Besitz wird \*\*über SetNumber (z. B. RP02-DE090)\*\* geprüft

\- Änderungen sollen \*\*inkrementell \& erklärend\*\* erfolgen



---



\## 🚧 Status



🟡 \*\*Aktive Entwicklung\*\*  

Struktur steht, Import \& Skalierung folgen.





