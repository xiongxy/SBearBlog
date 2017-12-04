using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SBear.Framework.Util
{
    public class StaticWrite
    {
        public static void WriteBlogToMd(string fileName, byte[] fileContent)
        {
            var nowDate = DateTime.Now.ToString("yyyy-MM-dd");
            WriteFile(Path.Combine("archives", nowDate), fileName + ".md", fileContent);
        }
        public static void UpdateBlogToMd(string fileName, DateTime dateTime, byte[] fileContent)
        {
            var nowDate = dateTime.ToString("yyyy-MM-dd");
            UpdateFile(Path.Combine("archives", nowDate), fileName + ".md", fileContent);
        }
        private static void WriteFile(string filePath, string fileName, byte[] fileContent)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            FileStream fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.CreateNew);
            fileStream.Write(fileContent, 0, fileContent.Length);
            fileStream.Close();
        }
        private static void UpdateFile(string filePath, string fileName, byte[] fileContent)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            FileStream fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.OpenOrCreate);
            fileStream.Write(fileContent, 0, fileContent.Length);
            fileStream.Close();
        }
    }
}
