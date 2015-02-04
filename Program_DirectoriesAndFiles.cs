using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace VehicleSimulator
{
    static partial class Program
    {
        private static string m_strAppRootDirectory = null;
        public static string Directory_AppRoot
          {
             get
             {
                if (Program.m_strAppRootDirectory == null)
                {
                   string strPath 
                      = System
                        .IO
                        .Path
                        .GetDirectoryName(System
                                          .Reflection
                                          .Assembly
                                          .GetExecutingAssembly()
                                          .GetName().CodeBase);

                   strPath = strPath.Replace(@"file:\", @"");
                   strPath = strPath.Replace(@"\bin\Debug", @"\");
                   strPath = strPath.Replace(@"\bin\Release", @"\");
                   strPath = strPath.Replace(@"\bin", @"\");

                   Program.m_strAppRootDirectory = strPath;
                }
                return Program.m_strAppRootDirectory;
             }
          }


        private static string m_strGlobalDataRootDirectory = null;
        public static string Directory_GlobalDataRoot
        {
            get
            {
                if (Program.m_strGlobalDataRootDirectory == null)
                {
                    Program.m_strGlobalDataRootDirectory
                       = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                                      @"Cadec Global");

                    if (!Directory.Exists(Program.m_strGlobalDataRootDirectory))
                    {
                        Directory.CreateDirectory(Program.m_strGlobalDataRootDirectory);
                    }
                }

                return Program.m_strGlobalDataRootDirectory;
            }
        }



        private static string m_strAppDataRootDirectory = null;
        public static string Directory_AppDataRoot
        {
            get
            {
                if (Program.m_strAppDataRootDirectory == null)
                {
                    Program.m_strAppDataRootDirectory 
                        = Path.Combine(Program.Directory_GlobalDataRoot, 
                                       Application.ProductName);

                    if (!Directory.Exists(Program.m_strAppDataRootDirectory))
                    {
                        Directory.CreateDirectory(Program.m_strAppDataRootDirectory);
                    }
                }

                return Program.m_strAppDataRootDirectory;
            }
        }




        private static string m_strDirectory_AppDataRoot_Routes = null;
        public static string Directory_AppDataRoot_Routes
        {
            get
            {
                if (Program.m_strDirectory_AppDataRoot_Routes == null)
                {
                    Program.m_strDirectory_AppDataRoot_Routes
                       = Path.Combine(Directory_AppDataRoot, "Routes");

                    if (!Directory.Exists(Program.m_strDirectory_AppDataRoot_Routes))
                    {
                        Directory.CreateDirectory(Program.m_strDirectory_AppDataRoot_Routes);
                    }
                }

                return Program.m_strDirectory_AppDataRoot_Routes;
            }
        }


        private static string m_strDirectory_AppDataRoot_Logs = null;
        public static string Directory_AppDataRoot_Logs
        {
            get
            {
                if (Program.m_strDirectory_AppDataRoot_Logs == null)
                {
                    Program.m_strDirectory_AppDataRoot_Logs
                       = Path.Combine(Directory_AppDataRoot, "Logs");

                    if (!Directory.Exists(Program.m_strDirectory_AppDataRoot_Logs))
                    {
                        Directory.CreateDirectory(Program.m_strDirectory_AppDataRoot_Logs);
                    }
                }

                return Program.m_strDirectory_AppDataRoot_Logs;
            }
        }

    }


}
