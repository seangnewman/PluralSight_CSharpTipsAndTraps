using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ClassLibrary.Tests
{
    public class FileProcessorShould
    {
        #region Path
        [Fact]
        public void GetInputFilePath()
        {
            FileProcessor sut = new FileProcessor();
            string path = sut.GetInputFilePath();
            Assert.Equal(@"C:\Users\Sean\Source\Repos\PluralSight_CSharpTipsAndTraps\text.txt", path);
        }
       

        [Fact]
        public void UsefulPathMethods()
        {
            string path = @"C:\Users\Sean\Source\Repos\PluralSight_CSharpTipsAndTraps\text.txt";

            path = Path.ChangeExtension(path, "bak");
            string dirName = Path.GetDirectoryName(path);
            string ext = Path.GetExtension(path);
            string file = Path.GetFileName(path);
            string fileNoExt = Path.GetFileNameWithoutExtension(path);
            bool hasExt = Path.HasExtension(path);
        }
        [Fact]
        public void UsefulGeneralMethods()
        {
            char[] invalidNameChars = Path.GetInvalidFileNameChars();

            string rndFileName = Path.GetRandomFileName();

            string rndTempFile = Path.GetTempFileName();
            string userTempPath = Path.GetTempPath();

            char platformSpecificDirSeparator = Path.DirectorySeparatorChar;

        }

        [Fact]
        public void PathCombinePeculiarities()
        {
            //Note that this results in c:\temp... the data component is excluded
            string result = Path.Combine(@"\data", @"c:\temp");

            // The directory name begins with a /, which is treated as absolute 
            result = Path.Combine(@"c:\temp", @"\data");

            // Removing the / from the directory provides the desired result
            result = Path.Combine(@"c:\temp", @"data");

            // Using the static method will also remove the directory separator
            result = Path.Combine(@"c:\temp", @"\data".TrimStart(Path.DirectorySeparatorChar));

            // using the ".." to refer to parent directory
            result = Path.Combine(@"c:\temp\data", @"..");
            result = Path.GetFullPath(result);

        }
        #endregion
        #region Uri
        [Fact]
        public void GetUploadUri()
        {
            FileProcessor sut = new FileProcessor();

            string uri = sut.GetUploadUri();

            //Assert.Equal("http://dontcodetired.com/", uri);
            Assert.Equal("http://dontcodetired.com/blog", uri);
        }

        [Fact]
        public void NonHttpUris()
        {
            Uri localFile = new Uri(@"c:\temp\somefile.bin");
            Uri uncLanFile = new Uri(@"\\sompc\shareddocs\somefile.txt");

        }

        [Fact]
        public void CreatingRelativeAndAbsolute()
        {
            Uri dct1 = new Uri("http://dontcodetired.com"); // Assumes absolute
            Uri dct2 = new Uri("http://dontcodetired.com", UriKind.Absolute);

            Uri relativeUri = new Uri("/index.html", UriKind.Relative);
            Uri relativeOrAbsolutte = new Uri("/blog/", UriKind.RelativeOrAbsolute);

            Uri baseUri = new Uri("http://dontcodetired.com");
            Uri fullUri = new Uri(baseUri, relativeUri);

        }
        [Fact]
        public void UriParts()
        {
            Uri dct = new Uri("http://dontcodetired.com:8080/blog/?tag=code#somefragment");
            string scheme = dct.Scheme;
            string authority = dct.Authority;           // Host name + port number
            string authorityHost = dct.Host;                    // Domain name or IP address (no port)
            int port = dct.Port;

            string pathAndQuery = dct.PathAndQuery;
            string absolutePath = dct.AbsolutePath;
            string query = dct.Query;

            string fragment = dct.Fragment;
        }

        [Fact]
        public void ModifyingAUri()
        {
            Uri dct = new Uri("http://dontcodetired.com:8080/blog/?tag=code#somefragment");

            // These properties in Uri are read-only
            //dct.Fragment = "newfrag";  
            //dct.Port = 9090;

            UriBuilder builder = new UriBuilder(dct);
            builder.Port = 9090;
            builder.Fragment = "newfrag";

            Uri modifiedDct = builder.Uri;
            string modified = modifiedDct.ToString();

        }
        [Fact]
        public void SomeOtherUsefulThings()
        {
            Uri dct = new Uri("http://dontcodetired.com:8080/blog/?tag=code#somefragment");

            bool isDefaultPort = dct.IsDefaultPort;
            bool isFile = dct.IsFile;
            bool isUnc = dct.IsUnc;

            Uri localFile = new Uri("file://c:/temp/somefile.bin");
            string path = localFile.LocalPath;
            isFile = localFile.IsFile;
            isUnc = localFile.IsUnc;
        }
        #endregion
        #region Zip
        private const string inputDirectory = @"C:\Users\Sean\Source\Repos\PluralSight_CSharpTipsAndTraps";
        private const string outputZipFile = @"C:\Users\Sean\Source\Repos\PluralSight_CSharpTipsAndTraps\somefiles1.zip";


        [Fact]
        public void ZipFiles()
        {
            File.Delete(outputZipFile);
            FileProcessor sut = new FileProcessor();

            sut.ZipDirectory(inputDirectory, outputZipFile);

            Assert.True(File.Exists(outputZipFile));
        }
        [Fact]
        public void UnZipFiles()
        {
            ZipFiles();
            string unzipDestinationDir = Path.Combine(inputDirectory, @"..\unzip");
            unzipDestinationDir = Path.GetFullPath(unzipDestinationDir);

            if (Directory.Exists(unzipDestinationDir))
            {
                Directory.Delete(unzipDestinationDir, true);
            }

            FileProcessor sut = new FileProcessor();
            sut.Unzip(outputZipFile, unzipDestinationDir);
            
        }

        [Fact]
        public void AddFile()
        {
            ZipFiles();

            FileProcessor sut = new FileProcessor();

            sut.AddToZip(outputZipFile, @"C:\Users\Sean\Source\Repos\PluralSight_CSharpTipsAndTraps\AnExtraFile.txt");

        }

        [Fact]
        public void RemoveFile()
        {
            ZipFiles();

            FileProcessor sut = new FileProcessor();

            sut.RemoveFromZip(outputZipFile, @"C:\Users\Sean\Source\Repos\PluralSight_CSharpTipsAndTraps\text1.txt");
        }


        #endregion Zip files

        #region in-memory Compression
        [Fact]
        public void CompressDecompress()
        {
            const string originalString = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras imperdiet nisi et leo iaculis, in congue felis condimentum. Nunc feugiat nisl nisl, nec venenatis nisi imperdiet vitae. Praesent blandit enim est, et luctus diam vestibulum quis. Curabitur elementum, nunc ac ullamcorper porta, felis purus ornare orci, et sollicitudin ante nunc ac purus. Nunc venenatis, orci quis pretium varius, est ipsum blandit magna, et porta erat orci nec ligula. Suspendisse posuere malesuada risus, dapibus cursus tortor. Proin bibendum laoreet maximus. Suspendisse quis nibh sed lorem suscipit auctor. Sed et placerat sem. Pellentesque ut odio viverra, sagittis nulla quis, porta dolor. Morbi tempor maximus ultricies. Sed lobortis tincidunt dui, in pharetra urna gravida in";

            byte[] originalBytes = Encoding.ASCII.GetBytes(originalString);

            FileProcessor sut = new FileProcessor();

            // Compress
            byte[] compressedBytes = sut.Compress(originalBytes);

            int originalSize = originalBytes.Length;
            int compressedSize = compressedBytes.Length;
            int sizeDifference = originalSize - compressedSize;

            // Decompress
            byte[] decompressedBytes = sut.Decompress(compressedBytes);
            string decompressedString = Encoding.ASCII.GetString(decompressedBytes);

            Assert.Equal(originalBytes, decompressedBytes);
            Assert.Equal(originalString, decompressedString);
        }

        #endregion

    }




}
