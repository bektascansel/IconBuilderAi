﻿using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using MextFullstackSaaS.Application.Common.Interfaces;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class GoogleObjectStorageManager : IObjectStorageService
    {
        private const string BucketName = "iconbuilderia-cansel-us";
        private readonly GoogleCredential _credential;

        public GoogleObjectStorageManager()
        {
            _credential = GoogleCredential.FromFile("C:\\Users\\CANSEL BEKTAS\\Downloads\\golden-rush-428107-n0-164d12539c06.json");
        }
        public async Task<string> UploadImageAsync(string imageData, CancellationToken cancellationToken)
        {
            // Convert the base64 string to byte array
            var imageBytes = Convert.FromBase64String(imageData);

            // Create a new MemoryStream
            using var imageStream = new MemoryStream(imageBytes);

            // Create a new Google Cloud Storage client
            using var storage = await StorageClient.CreateAsync(_credential);

            // Generate a unique filename
            string fileName = $"{Guid.NewGuid()}.jpg";

            // Upload the file to Google Cloud Storage
            var uploadedObject = await storage.UploadObjectAsync(
                BucketName,
                fileName,
                "image/jpeg",
                imageStream,
                cancellationToken: cancellationToken);

            // Return the public URL of the uploaded image
            //return $"https://storage.googleapis.com/{BucketName}/{fileName}";
            return fileName;


        }

        public async Task<List<string>> UploadImagesAsync(List<string> imagesData, CancellationToken cancellationToken)
        {
            var uploadTasks = imagesData.Select(imagesData => UploadImageAsync(imagesData, cancellationToken));

            var results = await Task.WhenAll(uploadTasks);

            return results.ToList();
        }




    }
}