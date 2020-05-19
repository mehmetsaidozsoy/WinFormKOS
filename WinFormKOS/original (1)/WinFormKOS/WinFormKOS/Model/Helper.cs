using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormKOS.Model
{
    class Helper
    {
        public static string profilPath(int okuyucuId)
        {
            string path = Application.StartupPath + "/profil/" + okuyucuId + ".jpg";
            if (File.Exists(path))
            {
                return path;
            }
            return Application.StartupPath + "/profil/user_profile.png";
        }
    }
}
