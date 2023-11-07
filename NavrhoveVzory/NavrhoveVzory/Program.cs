using NavrhoveVzory;

var a = Osoba.GetInstance(7, 0, "Pepa");
Osoba.GetInstance(10, 1, "Marta");
Osoba.GetInstance(55, 1, "Marek");
Osoba.GetInstance(55, 1, "Marek");
Osoba.GetInstance(55, 1, "Marek");
Osoba.GetInstance(56, 1, "Mirek");
Console.WriteLine(Osoba.GetInstance(55, 1, "Marek"));
Console.WriteLine(a);
/*
Console.WriteLine("Age");
int age = int.Parse(Console.ReadLine());
Console.WriteLine("Gender(0 = men, 1 = women): ");
int gender = int.Parse(Console.ReadLine());
Console.WriteLine("Name: ");
string s_name = Console.ReadLine();

var a = Osoba.GetInstance(age, gender, s_name);
Console.WriteLine(a.ToString());
Console.WriteLine("Změna věku");
int old_param = int.Parse(Console.ReadLine());
a = a.Old(old_param);
Console.WriteLine(a.ToString());
*/