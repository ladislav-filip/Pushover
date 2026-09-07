# Pushover

Tento projekt poskytuje jednoduchý způsob odesílání notifikací pomocí služby Pushover. Obsahuje dvě hlavní části:

1. **PushoverAltair** - Webová aplikace s GraphQL rozhraním pro odesílání zpráv.
2. **PushoverConsole** - Konzolová aplikace pro odesílání zpráv přes REST API.

## Funkce

- Odesílání jednoduchých zpráv
- Odesílání zpráv do skupin
- Odesílání zpráv s obrázkem
- Podpora pro různé priority zpráv

## Technologie

- .NET 6.0
- Altairis.Pushover.Client
- GraphQL (pro Altair)
- REST API (pro konzolovou aplikaci)

## Instalace

1. Naklonuj repozitář
2. Otevři řešení `Pushover.sln` v Visual Studiu
3. Obnov balíčky (Restore Packages)
4. Nastav konfiguraci v `appsettings.json` (API token a User Key)

## Použití

### PushoverAltair

Spusť aplikaci a použij GraphQL rozhraní pro odesílání zpráv.

### PushoverConsole

Spusť konzolovou aplikaci, která odešle testovací zprávu.

## Přispění

Pro přispění do projektu prosím vytvoř fork repozitáře, proveď změny a pošli pull request.