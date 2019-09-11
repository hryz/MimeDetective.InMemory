using System;

namespace MimeDetective.InMemory
{
    public class FileType : IEquatable<FileType>
    {
        public FileType(byte?[] header, string extension, string mime)
            : this(header, extension, mime, string.Empty)
        {
        }

        public FileType(byte?[] header, string extension, string mime, string description)
            : this(header, 0, extension, mime, description)
        {
        }


        public FileType(byte?[] header, int offset, string extension, string mime)
            : this(header, offset, extension, mime, string.Empty)
        {
        }

        public FileType(byte?[] header, int offset, string extension, string mime, string description)
        {
            Header = null;
            Header = header;
            HeaderOffset = offset;
            Extension = extension;
            Mime = mime;
            Description = description;
        }

        public byte?[] Header { get; }
        public int HeaderOffset { get; }
        public string Extension { get; }
        public string Mime { get; }
        public string Description { get; set; }

        public override string ToString() => Extension;

        public override int GetHashCode()
        {
            unchecked { return ((Extension?.GetHashCode() ?? 0) * 397) ^ (Mime?.GetHashCode() ?? 0); }
        }

        public override bool Equals(object other) => other is FileType ft && Equals(ft);

        public bool Equals(FileType other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return string.Equals(Extension, other.Extension, StringComparison.OrdinalIgnoreCase)
                   && string.Equals(Mime, other.Mime, StringComparison.OrdinalIgnoreCase)
                   && string.Equals(Description, other.Description, StringComparison.OrdinalIgnoreCase);
        }
    }
}
