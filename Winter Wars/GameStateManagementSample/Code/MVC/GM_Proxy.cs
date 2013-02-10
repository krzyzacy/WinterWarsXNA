using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WWxna.Code.Environment;
using WWxna.Code.Game_Objects;

namespace WWxna.Code.MVC
{
    public sealed class GM_Proxy : iGame_Model
    {
        private Game_Model GM;

        private static GM_Proxy instance;
        private GM_Proxy()
        {
            //Initialization Stuff
        }

        public static GM_Proxy Instance
        {
            get
            {
                if (instance == null)
                    instance = new GM_Proxy();
                return instance;
            }
        }

       
    }
}
