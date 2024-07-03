using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BackLogException: Exception
    {
        public BackLogException(string message): base(message) 
        {
        }

        public BackLogException(string message, Exception innerException): base(message, innerException) 
        {
        
        
        }




    }
}
