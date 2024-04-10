using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Server_Wrapper.Services {
    public class Utils {

        public static void showFrm(Form frm, bool resize, bool diag) {
            if (frm != null) {
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (!resize) {
                    frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                }
                if (diag) {
                    frm.ShowDialog();
                } else {
                    frm.Show();
                }
            }
        }
        public static int getRamInMB() {
            int ram = Properties.Settings.Default.ramMax;
            string unit = Properties.Settings.Default.ramUnit;
            int total;
            if (ram > 0) {
                switch (unit) {
                    case "GB":
                    total = ram * 1024;
                    break;
                    case "MB":
                    total = ram;
                    break;
                    default:
                    throw new Exception("Unable to get RAM allocation.");
                }
            } else {
                throw new Exception("Unable to get RAM allocation.");
            }
            return total;
        }
        public static char getRamUnit() {
            string ramUnit = Properties.Settings.Default.ramUnit;
            char unit;
            switch (ramUnit) {
                case "GB":
                unit = 'G';
                break;
                case "MB":
                unit = 'M';
                break;
                default:
                throw new Exception("Unable to get RAM unit.");
            }
            return unit;
        }
        public static string timeStamp() {
            string time = DateTime.Now.ToString("HH:mm:ss");
            return time;
        }
        /*
        public static string removeColorCodes(string input) {
            string pattern = @"\x1B\[[^@-~]*[@-~]";
            return Regex.Replace(input , pattern , "");
        }
        */
        public static List<string> FindJavaInstallations() {
            string programFilesPath = @"C:\Program Files\";
            List<string> javaForks = new List<string> { "Java", "Eclipse Adoptium", "OpenJDK", "Amazon Corretto", "Zulu", "Liberica", "SapMachine" };
            List<string> directories = new List<string>();
            foreach (string javaFork in javaForks) {
                string forkPath = Path.Combine(programFilesPath, javaFork);
                if (Directory.Exists(forkPath)) {
                    directories.AddRange(Directory.GetDirectories(forkPath, "jdk*", SearchOption.TopDirectoryOnly));
                    directories.AddRange(Directory.GetDirectories(forkPath, "jre*", SearchOption.TopDirectoryOnly));
                    directories.AddRange(Directory.GetDirectories(forkPath, "zulu*", SearchOption.TopDirectoryOnly));
                }
            }
            return directories;
        }
    }
}
