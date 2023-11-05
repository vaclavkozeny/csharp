
//Co se stane v případě, že:
//a) zapíšete hodnotu 32bit do 16bit
int a = 32769;
short b = (short)a;
Console.WriteLine(b);
// preteče a dostaneme zápornou hodnotu sníženou o tolik o kolik původní hodnota přetekla

//b) float do int
//1b:do int se uloží jenom část před desetinou čárkou

//c) záporné číslo do proměnné pouze pro kladná čísla
//uint c = -10;
//nelze

//Jak velký je datový typ bool?
//1 byte

//Je datový typ string roven poli znaků (char)?

//Patří struktury (struct) mezi kolekce?
//ano

//Je možné nahradit ternární operátor ?: pomocí if-else? (příklad)
//ano
int n = 10;
if(n > 100)
{
    Console.WriteLine("T");
}
else
{
    Console.WriteLine("F");
}
Console.WriteLine(n > 100 ? "T" : "F");

//Kdy lze použít operátor , (čárka)? (příklad)
//v oddělení prvků v poli 
string[] test = { "a", "h", "o", "j" };
//při volání a deklarování funcke s parametry
static int Add(int a, int b)
{
    return a + b;
}
Add(1, 2);
//Pokud bude mít proměnná index stejnou hodnotu, budou tyto 2 příkazy pracovat se stejným prvkem pole?


//pole[++index] a pole[index--]
//arr[++i] -> zvýší hodnotu o 1 a pak až jí použije
//arr[i++] -> použije hodnotu a pak až jí zvýší o 1
//s arr[--i] a arr[i--] je to stejné, ale místo inc se provede dec

//Napište stejný cyklus pomocí while, do-while, for a for-each.
string[] arr = { "a", "h", "o", "j" };
int w = 0;
while(w < arr.Length)
{
    Console.WriteLine(arr[w++]);
}

int dw = 0;
do
{
    Console.WriteLine(arr[dw++]);
} while(dw < arr.Length);

for(int f = 0; f< arr.Length; f++)
{
    Console.WriteLine(arr[f]);
}

foreach(var fe in arr)
{
    Console.WriteLine(fe);
}

//Napište část kódu reprezentující rozdíl mezi hodnotovým a referenčním datovým typem.






