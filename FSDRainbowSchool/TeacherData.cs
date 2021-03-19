using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDRainbowSchool
{

    class Teacher
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public Teacher(string ID, string Name, string Class, string Section)
        {
            this.ID = ID;
            this.Name = Name;
            this.Class = Class;
            this.Section = Section;
        }

        // textfile path 
        static string dir = @"C:\Users\j_reddy\source\repos\FSDProject_JReddy\FSDRainbowSchool";
        static string file = Path.Combine(dir, "TeacherData.txt");

        public static void WriteDataIntoTextfile(List<Teacher> teacherlist)
        {
           List<string> data;

            Console.WriteLine("Before Appending Record");
            Console.WriteLine("----------------------------------");
            foreach (var item in teacherlist)
            {
                Console.WriteLine("{0} : {1} : {2} : {3}", item.ID, item.Name, item.Class, item.Section);
                data = new List<string>() { item.ID, item.Name, item.Class, item.Section };
                

                // To write to a file using StreamWriter
                using (StreamWriter writer = new StreamWriter(file, true))
                {
                    foreach (string input in data)
                      writer.WriteLine(input);
                }
            }
        }

        public static void AppendDatatoTextfile(List<Teacher> teacherlist)
        {
            teacherlist.Add(new Teacher("105", "Teacher5", "Class7", "Seaction-C"));
            int count = (teacherlist.Count)-1;
            List<string> data = new List<string>() { teacherlist[count].ID, teacherlist[count].Name, teacherlist[count].Class, teacherlist[count].Section };
            File.AppendAllLines(file, data);
        }

        // To display current contents of the file 
        public static void DisplayTextfile()
        {
            Console.WriteLine("After Appending Record Displaying data from text file");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine(File.ReadAllText(file));
        }

    }

        
    class TeacherData
    {
        static void Main(string[] args)
        {
            List<Teacher> teacherList = new List<Teacher>();
            teacherList.Add(new Teacher("101", "Teacher1", "Class10", "Seaction-A"));
            teacherList.Add(new Teacher("102", "Teacher2", "Class10", "Seaction-B"));
            teacherList.Add(new Teacher("103", "Teacher3", "Class9" , "Seaction-A"));
            teacherList.Add(new Teacher("104", "Teacher4", "Class8" , "Seaction-B"));

            Teacher.WriteDataIntoTextfile(teacherList);
            Teacher.AppendDatatoTextfile(teacherList);
            Console.WriteLine();
            Teacher.DisplayTextfile();
            Console.ReadKey();
        }

    }
    
}
