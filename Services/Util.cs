using System;
using System.Windows.Forms;

namespace Server_Wrapper.Services {
    public class Util {

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
    }
}
