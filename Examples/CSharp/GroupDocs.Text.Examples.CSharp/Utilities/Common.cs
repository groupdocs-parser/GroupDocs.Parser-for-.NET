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
        public const string sourcePath = "../../../../Data/Storage/";
        public const string licensePath = "D:/Aspose Projects/License/GroupDocs.Total.lic";
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
                lic.SetLicense(licensePath);
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
        public static String getFilePath(string fileName)
        {
            //ExStart:getfilepath
            String fileLocation = sourcePath + fileName;
            return fileLocation;
            //ExEnd:getfilepath
        } 
    }
}
