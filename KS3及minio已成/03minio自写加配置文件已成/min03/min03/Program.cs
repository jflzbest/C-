using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Minio;
using System.Runtime.InteropServices;
using System.Text;

namespace FileUp
{
    public class FileUpload11
    {
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filepath);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder returnvalue, int buffersize, string filepath);

        static string IniFilePath;

        static string endpoint;
        static string accessKey;
        static string secretKey;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        //[STAThread]
        static void Main()
        {

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            //                                     | SecurityProtocolType.Tls11
            //                                     | SecurityProtocolType.Tls12;

            //string endpoint;
            //string accessKey;
            //string secretKey;

            //var endpoint = "172.16.131.38:9003";
            //var accessKey = "LO47Y1RNP2LVJ1A495A3";
            //var secretKey = "5nZWV/8v9WbuDd7Gvcdepqklp/P7D6S/hvIT19dV";

            string outString;
            try
            {
                GetValue("Information", "endpoint", out outString);
                endpoint = outString;
                GetValue("Information", "accessKey", out outString);
                accessKey = outString;
                GetValue("Information", "secretKey", out outString);
                secretKey = outString;
                //GetValue("Information", "Region", out outString);
                //textBox2.Text = outString;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            //var endpoint = "172.16.131.38:9003";
            //var accessKey = "LO47Y1RNP2LVJ1A495A3";
            //var secretKey = "5nZWV/8v9WbuDd7Gvcdepqklp/P7D6S/hvIT19dV";
            try
            {
                //var minio = new MinioClient(endpoint, accessKey, secretKey).WithSSL();
                var minio = new MinioClient(endpoint, accessKey, secretKey);
                FileUpload11.Run(minio).Wait();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            Console.ReadLine();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
        static  void GetValue(string section, string key, out string value)
        {
            IniFilePath = Application.StartupPath + "\\Config.ini";
            StringBuilder stringBuilder = new StringBuilder();
            GetPrivateProfileString(section, key, "", stringBuilder, 1024, IniFilePath);
            value = stringBuilder.ToString();
        }

        private async static Task Run(MinioClient minio)
        {
            // Make a new bucket called mymusic.
            var bucketName = "ai-medical1"; //<==== change this
            //var location = "172.16.131.38:9003/minio/login";
            // Upload the zip file
            var objectName = "11122test.doc";
            var filePath = "D:\\HE_20180612214954.doc";
            var contentType = "application/msword";
            //var endpoint = "172.16.131.38:9003";
            try
            {
                bool found = await minio.BucketExistsAsync(bucketName);
                if (!found)
                {
                    await minio.MakeBucketAsync(bucketName);
                }
                await minio.PutObjectAsync(bucketName, objectName, filePath, contentType);
                Console.Out.WriteLine("Successfully uploaded " + objectName);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
            }
        }
    }
}
