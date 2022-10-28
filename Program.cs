using InputDirectoriesConsole.Services.FileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace InputDirectoriesConsole
{
    public class Program
    {
        static void Main(string[] args)
        {

            // call the class to start program
            FileServices file = new FileServices();
            file.GetAllFilesSearched();
        }          
        }

    }

