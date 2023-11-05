
      /*
      1)Vytvořte co nejjednodušší příklad demonstrující alespoň 2 rozdíly mezi struct a class.
      */
        CLS testcls = new CLS("init");
        testcls.Change();
        // hodnota Name je NEW;
        //---------------------------------------
        

        void ChangeMyStruct(MyStruct input)
        {
            input.MyProperty = "new value";
        }
        MyStruct testStruct = new MyStruct { MyProperty = "initial value" };
        ChangeMyStruct(testStruct);
//hodnota MyProperty je porad "initial value"

/*
2)Vytvořte generickou třídu implementující Sk1) frontu Sk2) zásobník pomocí pole. 
Konstruktor bude mít parametr - počáteční kapacita. 
Třída bude kromě konstruktoru obsahovat metody pro vkládání, odebírání, zjištění počtu prvků a změnu velikosti (Resize s parametrem nová kapacita). 
 */
public class CLS
{
    public CLS(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public void Change()
    {
        Name = "NEW";
    }
}
public struct MyStruct
{
    public string MyProperty { get; set; }
}
public class Fronta<T>
        {
            public int Size { get; set; }
            public T[] Array { get; set; }
            public Fronta(int size)
            {
                Size = size;
                Array = new T[size];
            }
            public void AddToQueue(T input)
            {
                Array.Append(input);
            }
            public T GetFromQueue()
            {
                if(Array.Length != 0)
                {
                    return Array.First();
                }
                return default(T);
            }
            public int GetSize()
            {
                return Array.Length;
            }


        }


