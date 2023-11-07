/*
RUR
Vytvořte implementaci:
Třídy:
Robot - umí v jednom okamžiku provádět pouze jednu ze 4 činností
Ovladac - slouží pro komunikaci s robotem
Moduly - výměnné moduly, které umožňují robotovi specializované činnosti - VRTANI, BROUSENI, SVAROVANI, REZANI
(Moduly maji spolecneho predchudce a pretizenou metodu pro provádění činnosti.)
Povel - slouží pouze jako obalující třída pro zprávy předávané z ovladače do robota
(Obsah zprávy by neměl být modifikován.) 

Pravidla:
Ovladač předává robotovi povely pomocí zpráv obsahujících: typ činnosti, dobu a místo.
Robot na začátku nemá žádný modul.
V jedné chvíli může mít pouze jeden nebo žádný modul.
Při výměně modulu musí odebrat ten stávající.
Jeden ovladač může posílat povely libovolnému robotovi.
Robot potvrzuje provedení činnosti.
Robot eviduje celkový odpracovaný čas (případně čas dle jednotlivých činností).
*/

using NavrhoveVzory2;

var m = Modul.getInstance(Typ.REZANI);
var v = Modul.getInstance(Typ.VRTANI);
var s = Modul.getInstance(Typ.SVAROVANI);
var o = new Ovladac();
var p = new Povel(Typ.REZANI, 10, "Hala");
var p2 = new Povel(Typ.SVAROVANI, 20, "Venkovni");

var r = new Robot();
var r2 = new Robot();
//-----------------------
r.AddModul(m);
r2.AddModul(v);
Console.WriteLine(o.PosliPozadavek(p, r));
Console.WriteLine(o.PosliPozadavek(p2, r2));
r2.SwitchModul(s);
Console.WriteLine(o.PosliPozadavek(p, r));
Console.WriteLine(o.PosliPozadavek(p2, r2));