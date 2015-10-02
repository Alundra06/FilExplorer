using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Amazon.S3;
using Amazon.S3.Model;

namespace FilExplorer.Controllers.AWS
{
  
        public class S3Controller : Controller, IS3Controller
        {
            private static readonly string awsAccessKey = ConfigurationManager.AppSettings["AWSAccessKey"];
            private static readonly string awsSecretKey = ConfigurationManager.AppSettings["AWSSecretKey"];
            private static readonly string bucketName = ConfigurationManager.AppSettings["AWSBucketname"];
            private IFileController fileController;

            public S3Controller()
            {
                fileController = new FileController();
            }
            public S3Controller(IFileController _fileController)
            {
                fileController = _fileController;
            }
            [HttpPost]
            public void UploadFileToS3(HttpPostedFileBase uploadFile,string folderName,string folderID)
            {
               
                    IAmazonS3 client;
                    using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(awsAccessKey, awsSecretKey))
                    {
                        try
                        {
                            PutObjectRequest fileRequest = new PutObjectRequest();
                            var delimiter = "/";
                            fileRequest.BucketName = string.Concat(bucketName,delimiter,folderName);
                            var folderKey = uploadFile.FileName;
                            fileRequest.Key = folderKey;
                            fileRequest.InputStream = uploadFile.InputStream;
                            PutObjectResponse folderResponse = client.PutObject(fileRequest);
                            fileController.InsertFile(folderKey,folderID);
                        }
                        catch (AmazonS3Exception e)
                        {
                            Console.WriteLine("Folder creation has failed.");
                            Console.WriteLine("Amazon error code: {0}",
                                string.IsNullOrEmpty(e.ErrorCode) ? "None" : e.ErrorCode);
                            Console.WriteLine("Exception message: {0}", e.Message);
                        }
                    }
                RedirectToAction("ListFolders", "Home");

            }
            public ActionResult CreateNewFolder(string folderName, string bucketPath)
            {

                IAmazonS3 client;
                using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(awsAccessKey, awsSecretKey))
                {
                    try
                    {
                        PutObjectRequest folderRequest = new PutObjectRequest();
                        var delimiter = "/";
                        folderRequest.BucketName = bucketPath;
                        var folderKey = string.Concat(folderName, delimiter);
                        folderRequest.Key = folderKey;
                        folderRequest.InputStream = new MemoryStream(new byte[0]);
                        PutObjectResponse folderResponse = client.PutObject(folderRequest);
                    }
                    catch (AmazonS3Exception e)
                    {
                        Console.WriteLine("Folder creation has failed.");
                        Console.WriteLine("Amazon error code: {0}",
                            string.IsNullOrEmpty(e.ErrorCode) ? "None" : e.ErrorCode);
                        Console.WriteLine("Exception message: {0}", e.Message);
                    }
                }
                return View();
            }
            public ActionResult CreateDefaultFolders(string UserID, List<string> FoldersNames)
            {
                var bucketPath = string.Concat(ConfigurationManager.AppSettings["AWSBucketname"], "/", UserID);
                foreach (var folderName in FoldersNames)
                {
                    CreateNewFolder(folderName, bucketPath);
                }
                return View();
            }
        }
}
