using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace BlaseballStlats.Util
{
    public static class CompressionUtil
    {
        // https://stackoverflow.com/a/14297207
        public static void WriteGzipBytes(string fileName, byte[] bytes)
        {
            using var fs = new FileStream(fileName, FileMode.Create);
            using var zipStream = new GZipStream(fs, CompressionLevel.Optimal, false);
            zipStream.Write(bytes, 0, bytes.Length);
        }

        public static void WriteGzipText(string fileName, string text)
            => WriteGzipBytes(fileName, Encoding.UTF8.GetBytes(text));

        public static byte[] ReadGzipBytes(string fileName)
            => File.OpenRead(fileName).ReadGzipBytes();

        public static byte[] ReadGzipBytes(this Stream stream)
        {
            using var zipStream = new GZipStream(stream, CompressionMode.Decompress, false);
            using var outputStream = new MemoryStream();
            zipStream.CopyTo(outputStream);
            return outputStream.ToArray();
        }

        public static string ReadGzipText(this Stream stream)
            => Encoding.UTF8.GetString(stream.ReadGzipBytes());

        public static string ReadGzipText(string fileName)
            => Encoding.UTF8.GetString(ReadGzipBytes(fileName));

        public static void AddFileToZip(string zipPath, string filePath, string fileNameInZip = null)
        {
            if (string.IsNullOrEmpty(fileNameInZip))
                fileNameInZip = filePath.Split('\\').Last().Split('/').Last();

            using var archive = new ZipArchive(new FileStream(zipPath, FileMode.OpenOrCreate), ZipArchiveMode.Update);
            archive.CreateEntryFromFile(filePath, fileNameInZip, CompressionLevel.Optimal);
        }

        public static IEnumerable<ZipArchiveEntry> GetEntriesFromZip(string zipPath)
        {
            using var archive = new ZipArchive(new FileStream(zipPath, FileMode.Open), ZipArchiveMode.Read);
            foreach (var entry in archive.Entries)
            {
                yield return entry;
            }
        }
    }
}
