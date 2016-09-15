using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1.IO;

namespace Assignment_1
{
    public interface MatchAlgorithms
    {
        LoadSaveStrategy Storage { get; set; }
        string InputFile { get; set; }
        string isAMatch();
    }
}
