using GroupDocs.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Parser_for_.NET
{
    public class Common
    {
        //ExStart:commonutilities
        public const string SOURCE_PATH = "../../../Data/Storage/";
        public const string LICENSE_PATH = "D:/GroupDocs.Total.NET.lic";
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

        /// <summary>
        /// Returns connection string of the database file
        /// </summary>
        public static string GetConnectionString(string FileName)
        {
            //ExStart:GetConnectionString
            string FilePath = Path.Combine(Path.GetFullPath(@"..\..\..\"), @"Data\Storage", FileName);
            return @"Data Source=" + FilePath + "; Version=3; FailIfMissing=True; Foreign Keys=True;";
            //ExEnd:GetConnectionString
        }

        //ExStart:CopyStream_18.10
        /// <summary>
        /// Copies the source stream into destination stream
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        public static void CopyStream(Stream source, Stream dest)
        {
            byte[] buffer = new byte[4096];
            source.Position = 0;

            int r = 0;
            do
            {
                r = source.Read(buffer, 0, buffer.Length);
                if (r > 0)
                {
                    dest.Write(buffer, 0, r);
                }
            }
            while (r > 0);
        }
        //ExEnd:CopyStream_18.10
    }
}
