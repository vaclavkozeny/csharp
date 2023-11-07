using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavrhoveVzory2
{
    public enum Typ
    {
        VRTANI,
        BROUSENI,
        SVAROVANI,
        REZANI
    }
    internal class Modul
    {
        public Typ typ { get; set; }
        protected Modul()
        { 
        }

        public static Modul getInstance(Typ typ)
        {
            if(typ == Typ.VRTANI)
            {
                return new VRTANI();
            }
            else if (typ == Typ.BROUSENI)
            {
                return new BROUSENI();
            }
            else if (typ == Typ.SVAROVANI)
            {
                return new SVAROVANI();
            }
            else
            {
                return new REZANI();
            }

        }
        public Typ getTyp()
        {
            if(this is VRTANI)
            {
                return Typ.VRTANI;
            }
            if (this is BROUSENI)
            {
                return Typ.BROUSENI;
            }
            if (this is SVAROVANI)
            {
                return Typ.SVAROVANI;
            }
            if (this is REZANI)
            {
                return Typ.REZANI;
            }
            return default;

        }

    }
    class VRTANI : Modul
    {
        public override string ToString()
        {
            return "VRTANI";
        }
    }
    class BROUSENI : Modul
    {
        public override string ToString()
        {
            return "BROUSENI";
        }
    }
    class SVAROVANI : Modul
    {
        public override string ToString()
        {
            return "SVAROVANI";
        }
    }
    class REZANI : Modul
    {
        public override string ToString()
        {
            return "REZANI";
        }
    }
}
