using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Totalizator.Util.Exeptions
{
    public class WrongIdExeption : Exception
    {
        public WrongIdExeption(string message): base(message)
        {
        }
    }
}