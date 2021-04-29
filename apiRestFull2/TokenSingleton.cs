using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestFull2
{
    public class TokenSingleton
    {
      private static TokenSingleton instance = null;
        public string mensaje = "";
            protected TokenSingleton()
        {
            mensaje = "hola";
        }

        public static TokenSingleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new TokenSingleton();


                return instance;
            }
           
        }
    }
}
