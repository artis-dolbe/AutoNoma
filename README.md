Šī ir vienkārša automašīnu nomas sistēma, kas izstrādāta ar ASP.NET Core (Razor Pages) un Entity Framework, izmantojot InMemory datubāzi. Sistēmas mērķis ir nodrošināt lietotājiem ērtu veidu, kā apskatīt un rezervēt automašīnas, kā arī administratoram iespēju pārvaldīt piedāvājumu.

Sistēmas funkcionalitāte ietver:

  Automašīnu saraksta apskati.

  Jaunas rezervācijas izveidi konkrētam laikposmam.

  Rezervāciju saraksta pārskatu.

  Jaunu automašīnu pievienošanu.

  Rezervāciju dzēšanu.

Datu struktūra
Projektā tiek izmantotas trīs galvenās entītijas:

Lietotājs – rezervāciju veicējs (neobligāti).

Auto – transportlīdzeklis, ko iespējams iznomāt.

Rezervācija – sasaista konkrētu automašīnu ar rezervācijas periodu un, ja nepieciešams, ar lietotāju.

Katra rezervācija ir saistīta ar vienu automašīnu un, pēc izvēles, ar vienu lietotāju. Šī struktūra atspoguļo pamata nomas sistēmas loģiku.
