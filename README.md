# P4-project

Dit is een work-in-progress prototype platform geschreven voor de Digitale Werkplaats Fryslân.

Om verder te werken met dit project heb je de volgende dingen nodig:
- JetBrains Rider (of een andere IDE)
- MySQL Server (Versie 8.0.25 of nieuwer)
- MySQL Workbench (Versie 8.0.25 of nieuwer)

Stappenplan voor het project:
1. Clone het project naar je computer.
2. Maak een wachtwoord aan voor je MySQL server.
3. In de MySQL Workbench, open je local server instance.
4. Onder 'Schemas' maak een schema aan genaamd 'portaaldwf'.
5. Onder 'Administration' klik op 'Data Import/Restore'.
6. Onder 'Import from Dump Project Folder' klik op de folder 'Database' in het project.
7. Klik nu onderaan op 'Start Import'.
8. Open het project in Rider en klik rechts op de knop 'Database'.
9. Klik dan op het '+' icoontje en klik vervolgens onder 'Data Source' op 'MySQL'.
10. Vul onder 'User' je gebruikersnaam in van je database (root is default) en onder 'Password' je database wachtwoord in.
11. Type in het vakje 'Database' de tekst 'portaaldwf'.
12. Klik op 'Test Connection' en waarschijnlijk moet je nog wat invullen onder 'Time Zone', dit is verder niet van belang.
13. Als de connectie werkt klik op 'Apply' en 'OK'
14. Nu is het project klaar voor gebruik, de standaard user logins en opdrachten zijn te vinden in de database.
