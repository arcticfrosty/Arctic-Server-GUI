using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
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
        public static string removeColorCodes(string input) {
            string pattern = @"\x1B\[[^@-~]*[@-~]";
            return Regex.Replace(input, pattern, "");
        }
        //public static void applyMinecraftColorCodes(RichTextBox rtb, string text) {
        //    // Define color mappings
        //    Dictionary<string, Color> colors = new Dictionary<string, Color> {
        //        { "§0", Color.Black },      // Black
        //        { "§1", Color.DarkBlue },   // Dark Blue
        //        { "§2", Color.DarkGreen },  // Dark Green
        //        { "§3", Color.DarkCyan },   // Dark Aqua
        //        { "§4", Color.DarkRed },    // Dark Red
        //        { "§5", Color.DarkMagenta },// Dark Purple
        //        { "§6", Color.Gold },       // Gold
        //        { "§7", Color.Gray },       // Gray
        //        { "§8", Color.DarkGray },   // Dark Gray
        //        { "§9", Color.Blue },       // Blue
        //        { "§a", Color.Green },      // Green
        //        { "§b", Color.Aqua },       // Aqua
        //        { "§c", Color.Red },        // Red
        //        { "§d", Color.Magenta },    // Light Purple
        //        { "§e", Color.Yellow },     // Yellow
        //        { "§f", Color.White }       // White
        //    };

        //    // Split the text into parts
        //    string[] parts = Regex.Split(text, "(§.)");

        //    foreach (string part in parts) {
        //        // Determine the color for this part
        //        Color color;
        //        if (colors.ContainsKey(part)) {
        //            color = colors[part];
        //            continue;  // Skip color codes
        //        } else {
        //            color = Color.White;  // Default color
        //        }

        //        // Append the text with the appropriate color
        //        rtb.SelectionStart = rtb.TextLength;
        //        rtb.SelectionLength = 0;
        //        rtb.SelectionColor = color;
        //        rtb.AppendText(part);
        //        rtb.SelectionColor = rtb.ForeColor;
        //    }
        //}
    }
}
