using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaHouse_Assignment3
{
    public class Stage
    {
        public string StageName { get; set; }
        public double CostPerHour { get; set; }
        public double CleaningFee { get; set; }
        public string StageSection { get; set; }

        public Stage(string name, double hourlyRate, double cleaningFee, string stageSection)
        {
            this.StageName = name;
            this.CostPerHour = hourlyRate;
            this.CleaningFee = cleaningFee;
            this.StageSection = stageSection;
        }
    }
}