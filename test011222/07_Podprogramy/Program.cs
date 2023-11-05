/*
1) Máte podprogram (metodu), která má 4 vstupní parametry:
podprogram1(p0, p1, p2, p3)
p0 .. celé číslo, p1 .. řetězec, p2 .. pole, p3 .. list
Jak se bude lišit použití/chování těchto vstupních parametrů od podprogramu (metody):
podprogram2(ref p0, ref p1, ref p2, ref p3)

2) Komponenty UI (např. Button) umožňují reagovat na různé události. Jedná se o delegáty?

3) Vytvořte (příklad) metody se 2 vstupními parametry:
1. parametr - seznam (list) celých čísel
2. parametr - delegát na metodu, která se aplikuje na všechny prvky seznamu

4) Jaké jsou výhody/nevýhody třídních a instančních metod?

5) Uveďte příklady využití lambda operátorů (C#).
 */

/*
1) Máte podprogram (metodu), která má 4 vstupní parametry:
podprogram1(p0, p1, p2, p3)
p0 .. celé číslo, p1 .. řetězec, p2 .. pole, p3 .. list
Jak se bude lišit použití/chování těchto vstupních parametrů od podprogramu (metody):
podprogram2(ref p0, ref p1, ref p2, ref p3)
*/
//--------------------------------------------------------------------------------------------------------------------------
using System.Collections.Generic;

int MyInt = 10;
string MyString = "hello";
int[] MyArray = {0,1,2,3};
List<string> MyList = new List<string> { "test0", "test1", "test2"};
Console.WriteLine("No Ref");
Console.WriteLine(MyInt);
Console.WriteLine(MyString);
Console.WriteLine(Combine(MyInt, MyString, MyArray, MyList));
Console.WriteLine(MyInt);
Console.WriteLine(MyString);

Console.WriteLine("Ref");
Console.WriteLine(MyInt);
Console.WriteLine(MyString);
Console.WriteLine(CombineRef(ref MyInt, ref MyString, ref MyArray, ref MyList));
Console.WriteLine(MyInt);
Console.WriteLine(MyString);
static string Combine(int p0, string p1, int[] p2, List<string> p3)
{
    p0++;
    p1 = "world";
    return $"Číslo {p0}, Řetězec {p1}, První prvek pole {p2[0]}, První prvek listu {p3[0]}";
}
static string CombineRef(ref int p0, ref string p1, ref int[] p2, ref List<string> p3)
{
    p0++;
    p1 = "world";
    return $"Číslo {p0}, Řetězec {p1}, První prvek pole {p2[0]}, První prvek listu {p3[0]}";
}

// použitím ref máme k dispozici přímo proměnou
// když ref nepožijeme máme k dispozici pouze kopii proměné a zásah v podrpogramu nám neovlívní přímo proměnou
//--------------------------------------------------------------------------------------------------------------------------

//2) Komponenty UI (např. Button) umožňují reagovat na různé události. Jedná se o delegáty?
//Ano
//--------------------------------------------------------------------------------------------------------------------------

//3) Vytvořte (příklad) metody se 2 vstupními parametry:
//1.parametr - seznam(list) celých čísel
//2. parametr - delegát na metodu, která se aplikuje na všechny prvky seznamu
List<int>  nums= new List<int> { 10, 20, 30, 40, 50 };
Del handler = DelegateMethod;
TwoParams(nums, handler);
static void TwoParams(List<int> numIn, Del func){
    string numString = "";
    foreach(var n in numIn)
    {
        numString+= n + " ";
    }
    func(numString);
}
//--------------------------------------------------------------------------------------------------------------------------

//4) Jaké jsou výhody/nevýhody třídních a instančních metod?
//Class metody nemusíme vytvářet instanci před použitím (static)
// od instanční metody musíme vytvořit instanci před použitím




//5) Uveďte příklady využití lambda operátorů (C#).
int[] numbers = { 2, 3, 4, 5 };
var squaredNumbers = numbers.Select(x => x * x);
Console.WriteLine(string.Join(" ", squaredNumbers));

//3-----------------------------------------------
static void DelegateMethod(string message)
{
    Console.WriteLine(message);
}
public delegate void Del(string message);
//-----------------------------------------------