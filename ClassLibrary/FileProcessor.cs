using System;
using System.IO;
using System.IO.Compression;

namespace ClassLibrary
{
    public class FileProcessor
    {
        public void Process()
        {
            string inputFilePath = GetInputFilePath();
            // Perform some file processing
            string uploadUri = GetUploadUri();
            // upload file
        }

        public string GetUploadUri()
        {
            //Uri uploadUri = new Uri("http://dontcodetired.com");
            //Note that when the page is specified the uri does NOT return trailing /
            Uri uploadUri = new Uri("http://dontcodetired.com/blog");
            return uploadUri.ToString();
        }

        public string GetInputFilePath()
        {

            // Note that the combine method in Path requires trailing slash!
            var drive = @"C:";
            var dir = @"Users\Sean\Source\Repos\PluralSight_CSharpTipsAndTraps\";
            var file = "text.txt";

            //var fullPath = drive;
            //fullPath += dir;

            //if (!dir.EndsWith(@"\")) ;
            //  fullPath += @"\";

            //fullPath += file;

            //return fullPath;
            string thePath = Path.Combine(drive, dir, file);
            return thePath;

        }

        public void ZipDirectory(string dirToZip, string outputZipFilePath)
        {
            ZipFile.CreateFromDirectory(dirToZip, outputZipFilePath, CompressionLevel.Fastest, true);
        }

        public void Unzip(string zipFilePath, string outputDir)
        {
            ZipFile.ExtractToDirectory(zipFilePath, outputDir);
        }

        public void RemoveFromZip(string zipFilePath, string fileToRemove)
        {
            using (ZipArchive zip = ZipFile.Open(zipFilePath, ZipArchiveMode.Update))
            {
                var f1 = zip.GetEntry(fileToRemove);
            }
        }

        public void AddToZip(string outputZipFile, string extraFilePath)
        {
            using (ZipArchive zip = ZipFile.Open(extraFilePath, ZipArchiveMode.Update)) 
            {
                 zip.CreateEntryFromFile(extraFilePath, Path.GetFileName(extraFilePath));
            }
        }

        public byte[] Compress(byte[] originalBytes)
        {
            using (var compressionStream = new MemoryStream())
            {
                using (var gzs = new GZipStream(compressionStream, CompressionMode.Compress))
                {
                    gzs.Write(originalBytes, 0, originalBytes.Length);
                }
                byte[] compressedBytes = compressionStream.ToArray();
                return compressedBytes;
            }
        }

        public byte[] Decompress(byte[] compressedBytes)
        {
            using (var compressedStream = new MemoryStream(compressedBytes))
              using (var decompressedSteam = new MemoryStream())
                using (var gzs = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    gzs.CopyTo(decompressedSteam);
                    byte[] decompressedBytes = decompressedSteam.ToArray();
                    return decompressedBytes;
                 }
        }
    }
}
