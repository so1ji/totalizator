using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Totalizator.Util.Exeptions
{
    public class WrongPageNumberExeption : Exception
    {
        public WrongPageNumberExeption(string message) : base(message)
        {
        }
    }
}