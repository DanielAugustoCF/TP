using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public interface IDado
    {
        bool Equals(IDado obj);

        int CompareTo(IDado obj);

        string ToString();
    }
}
