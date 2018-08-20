using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using KS3;
using KS3.Auth;
using KS3.Http;
using KS3.Model;
using KS3.Internal;
using KS3.KS3Exception;
using System.Xml.Linq;
using System.Web;
namespace KS3Sample
{
    class KS3Sample
    {
        static String accessKey = "AKLTCz8pC3FHTRSaKSbqXRkkLQ";
        static String secretKey = "OGiJDX8Qf10u1kUmgbqIuib8gq8fdV8RqJq+qtB9L2MP6aY3nGMJmfAmspOtfU6niQ==";
        // KS3 Operation class 
        static KS3Client ks3Client = null;
        static String bucketName = "ai-medical";
        static String endPoint = "ks3-cn-beijing.ksyun.com";
        //static String objKeyNameMemoryData = "short-content";
        static String objKeyNameFileData = "test1.doc";
        
        static void Main(string[] args)
        {
            initClient();
            createBucket();
            putObject();
            Console.WriteLine("\n==========  End  ==========");
        }
        private static void initClient()
        {
            ClientConfiguration config = new ClientConfiguration();
            config.setTimeout(5 * 1000);
            config.setReadWriteTimeout(5 * 1000);
            config.setMaxConnections(20);

            //String accessKey = "AKLTCz8pC3FHTRSaKSbqXRkkLQ";
            //String secretKey = "OGiJDX8Qf10u1kUmgbqIuib8gq8fdV8RqJq+qtB9L2MP6aY3nGMJmfAmspOtfU6niQ==";
            
            /**
             * 设置服务地址</br>
             * 中国（北京）| ks3-cn-beijing.ksyun.com
             * 中国（上海）| ks3-cn-shanghai.ksyun.com
             * 中国（香港）| ks3-cn-hk-1.ksyun.com
             */
            //String endPoint = "ks3-cn-beijing.ksyun.com";    //此处以北京region为例

            ks3Client = new KS3Client(accessKey, secretKey);
            ks3Client.setEndpoint(endPoint);
        }
        private static bool createBucket()
        {
            // Create Bucket
            try
            {
                Console.WriteLine("--- Create Bucket: ---");
                Console.WriteLine("Bucket Name: " + bucketName);
                Bucket bucket = ks3Client.createBucket(bucketName);
                Console.WriteLine("Success.");
                Console.WriteLine("----------------------\n");
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Create Bucket Fail! " + e.ToString());
                return false;
            }

            return true;
        }
        private static bool putObject()
        {
            try
            {
                Console.WriteLine("--- Upload a File ---");
                
                FileInfo file = new FileInfo("H:/haixt111/201615477-3-1@4.tif");//  d:/test1.doc
                PutObjectRequest putObjectRequest = new PutObjectRequest(bucketName, objKeyNameFileData, file);

                //CannedAccessControlList cannedAcl = new CannedAccessControlList(CannedAccessControlList.PRIVATE);
                //putObjectRequest.setCannedAcl(cannedAcl);

                SampleListener sampleListener = new SampleListener(file.Length);
                putObjectRequest.setProgressListener(sampleListener);
                PutObjectResult putObjectResult = ks3Client.putObject(putObjectRequest);

                Console.WriteLine("Upload Completed. eTag=" + putObjectResult.getETag() + ", MD5=" + putObjectResult.getContentMD5());
                Console.WriteLine("---------------------\n");
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            return true;
        }
    }
    class SampleListener : ProgressListener
    {
        long size = -1;
        long completedSize = 0;
        int rate = 0;
        bool cancled = false;
        public SampleListener() { }
        public SampleListener(long size)
        {
            this.size = size;
        }
        public void progressChanged(ProgressEvent progressEvent)
        {
            int eventCode = progressEvent.getEventCode();

            if (eventCode == ProgressEvent.STARTED)
                Console.WriteLine("Started.");
            else if (eventCode == ProgressEvent.COMPLETED)
                Console.WriteLine("Completed.");
            else if (eventCode == ProgressEvent.FAILED)
                Console.WriteLine("Failed.");
            else if (eventCode == ProgressEvent.CANCELED)
                Console.WriteLine("Cancled.");
            else if (eventCode == ProgressEvent.TRANSFERRED)
            {
                this.completedSize += progressEvent.getBytesTransferred();
                int newRate = (int)((double)completedSize / size * 100 + 0.5);
                if (newRate > this.rate)
                {
                    this.rate = newRate;
                    Console.WriteLine("Processing ... " + this.rate + "%");
                }
            }
        } // end of progressChanged
        public bool askContinue()
        {
            return !this.cancled;
        }
    }
}