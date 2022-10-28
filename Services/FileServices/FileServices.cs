using InputDirectoriesConsole.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InputDirectoriesConsole.Services.FileServices
{
    public class FileServices
    {
        List<FileModel> _fileModels = new List<FileModel>();

        // Get all files in the directory selected
        private List<FileModel> GetAllFiles(string directory)
        {
            // Process the list of files found in the directory
            string[] fileEntries = Directory.GetFiles(directory);
            foreach (string fileName in fileEntries)
            {
                // Get the file info information from each file and
                // add it to the model that was created
                FileInfo fileInfo = new FileInfo(fileName);
                FileModel fileModel = new FileModel();
                fileModel.Name = fileName;
                fileModel.FileSize = fileInfo.Length;
                fileModel.FileDirectory = directory;
                // Insert information into a list
                _fileModels.Add(fileModel);
                //Console.WriteLine(fileModel.Name);
              
            }

            // Recurse into the subdirectores of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(directory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                GetAllFiles(subdirectory);
            }
            //foreach (var file in _fileModels)
            //{
            //    Console.WriteLine(file.Name);
            //}
            return _fileModels;
        }

        public void GetDirectoryInfo(string directory)
        {
            // set variable to add the size of all the files
            long total = 0;
            
            // call the method that gets the directory information
            var files = GetAllFiles(directory);
            foreach(var file in files)
            {
                // add file size to total
                total += file.FileSize;

                // print to the console the file name
                Console.WriteLine(file.Name);
            }

            // the average is the total / the total number of files
            long avgTotal = total / files.Count;
            Console.WriteLine("");
            Console.WriteLine("The total size of the directory is " + total + " bytes.");
            Console.WriteLine("The average size of a file in the directory is " + avgTotal + " bytes.");
        }
        public void GetAllFilesSearched()
        {
            // set variables
            string path1 = "";
            string path2 = "";
            string path3 = "";

            bool valid1 = false;
            bool valid2 = false;
            bool valid3 = false;
            bool validDir = false;
            string totalSearch = "";
            int totalSearchVal = 0;

            
            while (validDir == false)
            {
                Console.WriteLine("How many directories would you like to search?");
                Console.WriteLine("You can search up to three directories");

                // user input to decide how may directories to search
                totalSearch = Console.ReadLine();

                // check if the string is empty or not a number
                if (totalSearch != "" && totalSearch.Any(char.IsDigit))
                {

                    // convert string to int
                    totalSearchVal = Convert.ToInt32(totalSearch);

                    // if int is less than 1 or greater than 3,
                    // ask user to input again
                    if(totalSearchVal < 1 || totalSearchVal > 3)
                    {
                        Console.WriteLine("Please enter a number from 1-3 homie");
                    }
                    else
                    {
                        validDir = true;
                    }
                }
               
            }

            // switch statement
            switch (totalSearchVal)
            {
                case 1:
                    while (valid1 == false)
                    {
                        // Enter the first directory path
                        Console.WriteLine("Enter directory path to view files");

                        // Read user input and set it as a string
                        path1 = Console.ReadLine();

                        // If a file is entered, let the user know to enter a directory
                        if (File.Exists(path1))
                        {
                            Console.WriteLine("You entered a file, please enter a directory");
                        }

                        // If a directory is entered then continue
                        else if (Directory.Exists(path1))
                        {

                            //file.GetDirectoryInfo(path1);
                            valid1 = true;
                        }

                        // If neither is entered the let the user know it is invalid
                        else
                        {
                            Console.WriteLine(path1 + " is not a valid direcctory");
                        }
                    }
                    if (valid1 == true)
                    {
                        FileServices file = new FileServices();
                        Thread thread1 = new Thread(() => file.GetDirectoryInfo(path1));
                        thread1.Start();
                    }

                    break;
                case 2:
                    while (valid1 == false)
                    {
                        // Enter the first directory path
                        Console.WriteLine("Enter directory path to view files");

                        // Read user input and set it as a string
                        path1 = Console.ReadLine();

                        // If a file is entered, let the user know to enter a directory
                        if (File.Exists(path1))
                        {
                            Console.WriteLine("You entered a file, please enter a directory");
                        }

                        // If a directory is entered then continue
                        else if (Directory.Exists(path1))
                        {

                            //file.GetDirectoryInfo(path1);
                            valid1 = true;
                        }

                        // If neither is entered the let the user know it is invalid
                        else
                        {
                            Console.WriteLine(path1 + " is not a valid direcctory");
                        }
                    }
                    while (valid2 == false)
                    {
                        // Enter the first directory path
                        Console.WriteLine("Enter directory path to view files");

                        // Read user input and set it as a string
                        path2 = Console.ReadLine();

                        // If a file is entered, let the user know to enter a directory
                        if (File.Exists(path2))
                        {
                            Console.WriteLine("You entered a file, please enter a directory");
                        }

                        // If a directory is entered then continue
                        else if (Directory.Exists(path2))
                        {

                            //file.GetDirectoryInfo(path1);
                            valid2 = true;
                        }

                        // If neither is entered the let the user know it is invalid
                        else
                        {
                            Console.WriteLine(path2 + " is not a valid direcctory");
                        }
                    }
                    if (valid1 == true && valid2 == true)
                    {
                        FileServices file1 = new FileServices();
                        Thread thread1 = new Thread(() => file1.GetDirectoryInfo(path1));
                        thread1.Start();
                        FileServices file2 = new FileServices();
                        Thread thread2 = new Thread(() => file1.GetDirectoryInfo(path2));
                        thread2.Start();
                    }

                    break;
                case 3:
                    while (valid1 == false)
                    {
                        // Enter the first directory path
                        Console.WriteLine("Enter directory path to view files");

                        // Read user input and set it as a string
                        path1 = Console.ReadLine();

                        // If a file is entered, let the user know to enter a directory
                        if (File.Exists(path1))
                        {
                            Console.WriteLine("You entered a file, please enter a directory");
                        }

                        // If a directory is entered then continue
                        else if (Directory.Exists(path1))
                        {

                            //file.GetDirectoryInfo(path1);
                            valid1 = true;
                        }

                        // If neither is entered the let the user know it is invalid
                        else
                        {
                            Console.WriteLine(path1 + " is not a valid direcctory");
                        }
                    }
                    while (valid2 == false)
                    {
                        // Enter the first directory path
                        Console.WriteLine("Enter directory path to view files");

                        // Read user input and set it as a string
                        path2 = Console.ReadLine();

                        // If a file is entered, let the user know to enter a directory
                        if (File.Exists(path2))
                        {
                            Console.WriteLine("You entered a file, please enter a directory");
                        }

                        // If a directory is entered then continue
                        else if (Directory.Exists(path2))
                        {

                            //file.GetDirectoryInfo(path1);
                            valid2 = true;
                        }

                        // If neither is entered the let the user know it is invalid
                        else
                        {
                            Console.WriteLine(path2 + " is not a valid direcctory");
                        }
                    }
                    while (valid3 == false)
                    {
                        // Enter the first directory path
                        Console.WriteLine("Enter directory path to view files");

                        // Read user input and set it as a string
                        path3 = Console.ReadLine();

                        // If a file is entered, let the user know to enter a directory
                        if (File.Exists(path3))
                        {
                            Console.WriteLine("You entered a file, please enter a directory");
                        }

                        // If a directory is entered then continue
                        else if (Directory.Exists(path3))
                        {

                            //file.GetDirectoryInfo(path1);
                            valid3 = true;
                        }

                        // If neither is entered the let the user know it is invalid
                        else
                        {
                            Console.WriteLine(path3 + " is not a valid direcctory");
                        }
                    }
                    if (valid1 == true && valid2 == true && valid3 == true)
                    {
                        FileServices file1 = new FileServices();
                        Thread thread1 = new Thread(() => file1.GetDirectoryInfo(path1));
                        thread1.Start();
                        FileServices file2 = new FileServices();
                        Thread thread2 = new Thread(() => file2.GetDirectoryInfo(path2));
                        thread2.Start();
                        FileServices file3 = new FileServices();
                        Thread thread3 = new Thread(() => file3.GetDirectoryInfo(path3));
                        thread3.Start();
                    }

                    break;
            }

            Console.ReadKey();
        }
    }
}
