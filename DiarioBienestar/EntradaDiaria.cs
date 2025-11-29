using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioBienestar
{
    public class EntradaDiaria
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Activity { get; set; }  // Slider 0-10
        public int Energy { get; set; }       // Stepper 1-5
    }
}
