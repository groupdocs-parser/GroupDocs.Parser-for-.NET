using GroupDocs.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Text_for_.NET
{
    public class Common
    {
        //ExStart:commonutilities
        public const string SOURCE_PATH = "../../../../Data/Storage/";
        public const string LICENSE_PATH = "D:/GroupDocs.Total.lic";
        //ExEnd:commonutilities

        /// <summary>
        /// Apply license
        /// </summary>
        public static void ApplyLicense()
        {
            //ExStart:applylicense
            try
            {
                License lic = new License();
                lic.SetLicense(LICENSE_PATH);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //ExEnd:applylicense
        }

        /// <summary>
        /// Get source file path
        /// </summary>
        /// <param name="emailMessage"></param>
        /// <returns></returns>
        public static String GetFilePath(string fileName)
        {
            //ExStart:getfilepath
            String fileLocation = SOURCE_PATH + fileName;
            return fileLocation;
            //ExEnd:getfilepath
        }

        /// <summary>
        /// Shows how to set metered public and private key for Dynabic.Metered account
        /// </summary>
        public static void SetMeteredKey()
        {
            //ExStart:SetMeteredKey
            Metered matered = new Metered();
            matered.SetMeteredKey("PublicKey", "PrivateKey");
            //ExEnd:SetMeteredKey
        }
    }
}
