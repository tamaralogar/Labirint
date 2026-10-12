# Labirint

2D labirintna igra razvita v Unity (C#).

Igralec se premika skozi labirint (5 ročno zasnovanih levelov), pobira zaklad, se izogiba nevarnim stenam in ob koncu vsakega levela obišče trgovino, kjer kupi nadgradnje.

## Kako zagnati

**Zahteve:** Unity 6000.3.7f1

1. Kloniraj repozitorij
2. Odpri projekt v Unity Hubu (Add → izberi mapo projekta)
3. Odpri sceno Assets/Scenes/SampleScene.unity
4. Pritisni **Play**

## Struktura levelov

Leveli so definirani kot JSON datoteke v Assets/StreamingAssets/. Vsak level vsebuje matriko, kjer vsaka številka predstavlja element:
 - 0 - Prazna pot 
 - 1 - Navadna stena (brez učinka) 
 - 2 - Rdeča stena (odbitje zdravja) 
 - 3 - Modra stena (teleport na start) 
 - 4 - Zelena stena (zdravljenje) 
 - 5 - Zaklad (denar) 
 - 8 - Start (začetna pozicija igralca) 
 - 9 - Cilj (konec levela) 

### Vzorec levela (level1.json)
```json
{
  "level": "level1",
  "sirina": 15,
  "visina": 10,
  "matrika": [
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [1, 8, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1],
    [1, 0, 1, 1, 0, 2, 0, 3, 3, 3, 3, 0, 1, 0, 1],
    [1, 0, 1, 5, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 1],
    [1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 3, 0, 1, 0, 1],
    [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1],
    [1, 0, 4, 4, 4, 4, 0, 1, 1, 1, 1, 1, 1, 0, 1],
    [1, 0, 4, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 1],
    [1, 0, 0, 0, 2, 2, 2, 5, 5, 5, 5, 9, 5, 5, 1],
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
  ]
}
```

## Koncepti in vzorci

- **Singleton** — GameMaster hrani globalno stanje igre (level, denar, nadgradnje) in preživi med scenami (DontDestroyOnLoad)
- **Factory** — ElementFactory ustvarja Unity objekte glede na vrednost iz JSON matrike
- **Decorator** — IgralecDekorator omogoča dinamično dodajanje nadgradenj igralcu (zdravje, hitrost, denar, zdravljenje), vsaka nadgradnja ovije prejšnjo
- **Abstraktni razred** — LabirintElement definira skupno logiko zaznave trkov; vsak element implementira le svojo metodo IzvrsiUcinek()
- **Vmesnik** — IPoberljivo definira vedenje za objekte, ki se ob interakciji poberejo/uničijo (Zaklad, Cilj)
- **Async/Await** — LevelBuilder gradi labirint asinhrono in med nalaganjem prikaže loading panel
- **JSON deserializacija** — leveli se berejo iz .json datotek z Newtonsoft.Json

## Trgovina in nadgradnje

Ob koncu vsakega levela se odpre trgovina. Nadgradnje se kupijo z denarjem, zbranim ob pobiranju zakladov:

| Nadgradnja | Cena | Maksimalno število nakupov | Učinek |
|------------|------|---------------|--------|
| Zdravje | 50 | 3× | +10 max zdravja na nakup (osnova 20) |
| Hitrost | 30 | 2× | +2 hitrosti na nakup (osnova 1) |
| Denar | 60 | 2× | +50% vrednosti zaklada na nakup |
| Zdravljenje | 40 | 1× | ×2 zdravljenja zelene stene (osnova 5) |

## TO DO

- **Shranjevanje napredka (SQLite)** — podatki (level, denar, kupljene nadgradnje) se že shranijo v JSON strukturo; manjka še zapis v SQLite bazo ( ShranjevanjeNapredka.cs je že dodan, ampak je trenutno prazen)
- Nalaganje shranjenega napredka ob zagonu igre
