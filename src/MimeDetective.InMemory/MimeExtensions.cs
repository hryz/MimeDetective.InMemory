using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace MimeDetective.InMemory
{
    public static class MimeExtensions
    {
        public static FileType DetectMimeType(this Stream stream)
        {
            var tmp = MimeTypes.AllTypes.Select(x => x.HeaderOffset + x.Header.Length).OrderByDescending(x => x)
                .FirstOrDefault();
            var data = new byte[tmp];
            stream.Read(data, 0, data.Length);
            stream.Position = 0;

            IEnumerable<byte?> GetHeader(FileType t) => data
                .Skip(t.HeaderOffset)
                .Take(t.Header.Length)
                .Cast<byte?>();

            var comparer = new IgnoreNullComparer();

            var result = MimeTypes.AllTypes
                .OrderByDescending(t => t.Header.Length)
                .FirstOrDefault(t => t.Header.SequenceEqual(GetHeader(t), comparer));

            if (result == null)
                return null;

            if (!result.Equals(MimeTypes.ZIP))
                return result;

            return CheckForMsOfficeTypes(stream) ?? MimeTypes.ZIP;
        }

        public static FileType DetectMimeType(this byte[] file)
        {
            IEnumerable<byte?> GetHeader(FileType t) => file
                .Skip(t.HeaderOffset)
                .Take(t.Header.Length)
                .Cast<byte?>();

            var comparer = new IgnoreNullComparer();

            var result = MimeTypes.AllTypes
                .OrderByDescending(t => t.Header.Length)
                .FirstOrDefault(t => t.Header.SequenceEqual(GetHeader(t), comparer));

            if (result == null)
                return null;

            if (!result.Equals(MimeTypes.ZIP))
                return result;

            using (var ms = new MemoryStream(file))
            {
                return CheckForMsOfficeTypes(ms) ?? MimeTypes.ZIP;
            }
        }

        private static FileType CheckForMsOfficeTypes(Stream zip)
        {
            try
            {
                using (var zipFile = new ZipArchive(zip)) 
                {
                    if (zipFile.Entries.Any(e => e.FullName.StartsWith("word/")))
                        return MimeTypes.WORDX;

                    if (zipFile.Entries.Any(e => e.FullName.StartsWith("xl/")))
                        return MimeTypes.EXCELX;

                    if (zipFile.Entries.Any(e => e.FullName.StartsWith("ppt/")))
                        return MimeTypes.PPTX;

                    if (zipFile.Entries.Any(e => e.FullName.StartsWith("visio/")))
                        return MimeTypes.VSDX;

                    return CheckForMimeTypeFile(zipFile);
                }
            }
            catch (InvalidDataException)
            {
                return null;  //ZIP archive can be corrupted
            }

        }

        private static FileType CheckForMimeTypeFile(ZipArchive zipFile)
        {
            var ooMimeType = zipFile.Entries.FirstOrDefault(e => e.FullName == "mimetype");
            if (ooMimeType == null || ooMimeType.Length > 127) //zip bomb protection
                return CheckForNupkg(zipFile);

            using (var textReader = new StreamReader(ooMimeType.Open()))
            {
                var mimeType = textReader.ReadToEnd();

                if (mimeType == MimeTypes.ODT.Mime)
                    return MimeTypes.ODT;

                if (mimeType == MimeTypes.ODS.Mime)
                    return MimeTypes.ODS;

                if (mimeType == MimeTypes.EPUB.Mime)
                    return MimeTypes.EPUB;
            }

            return null;
        }

        private static FileType CheckForNupkg(ZipArchive zipFile)
        {
            if (zipFile.Entries.Any(x => x.Name.EndsWith(".nuspec")))
                return MimeTypes.NUPKG;
            
            return null;
        }

        private class IgnoreNullComparer : IEqualityComparer<byte?>
        {
            public int GetHashCode(byte? obj) => obj.HasValue ? obj.GetHashCode() : 0;

            public bool Equals(byte? x, byte? y) => !x.HasValue || !y.HasValue || x == y;
        }
    }
}
