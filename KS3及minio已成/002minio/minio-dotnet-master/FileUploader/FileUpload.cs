/*
 * Minio .NET Library for Amazon S3 Compatible Cloud Storage, (C) 2017 Minio, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Threading.Tasks;
using System.Net;
using Minio;

namespace FileUploader
{
    /// <summary>
    /// This example creates a new bucket if it does not already exist, and uploads a file
    /// to the bucket.
    /// </summary>
    class FileUpload
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                                                 | SecurityProtocolType.Tls11
                                                 | SecurityProtocolType.Tls12;
            var endpoint  = "172.16.131.38:9003";
            var accessKey = "LO47Y1RNP2LVJ1A495A3";
            var secretKey = "5nZWV/8v9WbuDd7Gvcdepqklp/P7D6S/hvIT19dV";
            try
            { 
                var minio = new MinioClient(endpoint, accessKey, secretKey).WithSSL();
                FileUpload.Run(minio).Wait();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        
        /// <summary>
        /// Task that uploads a file to a bucket
        /// </summary>
        /// <param name="minio"></param>
        /// <returns></returns>
        private async static Task Run(MinioClient minio)
        {
            // Make a new bucket called mymusic.
            var bucketName = "mymusic-folder"; //<==== change this
            //var location   = "us-east-1";
            // Upload the zip file
            var objectName = "test.doc";
            var filePath = "D:\\test.doc";
            var contentType = "application/msword";
            var endpoint = "172.16.131.38:9003";
            try
            {
                bool found = await minio.BucketExistsAsync(bucketName);
                if (!found)
                {
                    await minio.MakeBucketAsync(bucketName, endpoint);
                }
                await minio.PutObjectAsync(bucketName, objectName, filePath, contentType);  
                Console.Out.WriteLine("Successfully uploaded " + objectName );
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
            }
        }
   

    }
}
