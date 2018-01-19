using System;
using System.IO;
using SharpCompress;
using SharpCompress.Archives;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Readers;
using SharpCompress.Writers;

namespace TudouSharp
{
    public class Compress
    {
        static public byte[] Decompress7Zip(byte[] CompressedBuffer)
        {
            byte[] DecompressBuffer = new byte[] { };
            using (MemoryStream stream = new MemoryStream(CompressedBuffer))
            {
                var archive = SevenZipArchive.Open(stream);
                foreach (var item in archive.Entries)
                {
                    using (MemoryStream itemStream = new MemoryStream())
                    {
                        item.OpenEntryStream().CopyTo(itemStream);
                        DecompressBuffer = itemStream.ToArray();
                    }
                    break;
                }
            }
            return DecompressBuffer;
        }

        static public byte[] Decompress(byte[] CompressedBuffer)
        {
            using (MemoryStream stream = new MemoryStream(CompressedBuffer))
            {
                if (SevenZipArchive.IsSevenZipFile(stream))
                {
                    return Decompress7Zip(CompressedBuffer);
                }
                else
                {
                    return DecompressZip(CompressedBuffer);
                }
            }
        }

        static public byte[] CompressZip(byte[] OriginalBuffer)
        {
            using (var archive = SharpCompress.Archives.Zip.ZipArchive.Create())
            {
                using (MemoryStream CompressStream = new MemoryStream())
                {
                    MemoryStream stream = new MemoryStream(OriginalBuffer);
                    archive.AddEntry("default", stream);
                    archive.SaveTo(CompressStream, new WriterOptions(CompressionType.LZMA));
                    return CompressStream.ToArray();
                }
            }
        }

        static public byte[] DecompressZip(byte[] CompressedBuffer)
        {
            using (MemoryStream DecompressBuffer = new MemoryStream())
            {
                using (MemoryStream stream = new MemoryStream(CompressedBuffer))
                {
                    using (var reader = ReaderFactory.Open(stream))
                    {
                        reader.MoveToNextEntry();
                        reader.WriteEntryTo(DecompressBuffer);
                        return DecompressBuffer.ToArray();
                    }
                }
            }
        }
    }
}