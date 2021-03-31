using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace NI_Fonakolos_játék.Model
{
    public class Discs
    {
        public SolidColorBrush color { get; set; }
        public float size_in_d { get; set; }
        public bool Player { get; set; }
        public float position_x { get; set; }
        public float position_y { get; set; }

        public Discs()
        {

        }
    }
}
