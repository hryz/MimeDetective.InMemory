using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace MimeDetective.InMemory
{
    public static class MimeExtensions
    {
        public static FileType DetectMimeType(this byte[] file)
        {
            IEnumerable<byte?> GetHeader(FileType t) => file
                .Skip(t.HeaderOffset)
                .Take(t.Header.Length)
                .Cast<byte?>();

            var comparer = new IgnoreNullComparer();

            var result = MimeTypes.AllTypes
                .FirstOrDefault(t => t.Header.SequenceEqual(GetHeader(t), comparer));

            if (result == null)
                return null;

            if (!result.Equals(MimeTypes.ZIP))
                return result;

            using (var ms = new MemoryStream(file))
            {
                return CheckForDocxAndXlsxAndPptx(ms) ?? MimeTypes.ZIP;
            }
        }

        private static FileType CheckForDocxAndXlsxAndPptx(Stream zip)
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

                    return CheckForOdtAndOds(zipFile);
                }
            }
            catch (InvalidDataException)
            {
                return null;  //ZIP archive can be corrupted
            }

        }

        private static FileType CheckForOdtAndOds(ZipArchive zipFile)
        {
            var ooMimeType = zipFile.Entries.FirstOrDefault(e => e.FullName == "mimetype");
            if (ooMimeType == null || ooMimeType.Length > 127) //zip bomb protection
                return null;

            using (var textReader = new StreamReader(ooMimeType.Open()))
            {
                var mimeType = textReader.ReadToEnd();

                if (mimeType == MimeTypes.ODT.Mime)
                    return MimeTypes.ODT;

                if (mimeType == MimeTypes.ODS.Mime)
                    return MimeTypes.ODS;
            }

            return null;
        }

        private class IgnoreNullComparer : IEqualityComparer<byte?>
        {
            public int GetHashCode(byte? obj) => obj.HasValue ? obj.GetHashCode() : 0;

            public bool Equals(byte? x, byte? y) => !x.HasValue || !y.HasValue || x == y;
        }
    }
}
