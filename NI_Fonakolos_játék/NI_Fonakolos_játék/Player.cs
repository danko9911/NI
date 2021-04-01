using System;
using System.Collections.Generic;
using System.Text;

namespace NI_Fonakolos_játék.Model
{
    public class Player
    {

        public string firstName { get; set; }
        public string lastName { get; set; }

        public string time { get; set; }

        public int Score { get; set; }

        public string FullName
        {
            get
            {
                return $"{firstName}{lastName}";
            }
        }

    }
}



