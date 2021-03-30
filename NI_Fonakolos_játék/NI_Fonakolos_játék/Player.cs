using System;
using System.Collections.Generic;
using System.Text;

namespace NI_Fonakolos_játék
{
    public class Player
    {

        public string firstName { get; set; }
        public string lastName { get; set; }

        public string time { get; set; }

        public int bestScore { get; set; }

        public string FullName
        {
            get
            {
                return $"{firstName}{lastName}";
            }
        }

    }
}



