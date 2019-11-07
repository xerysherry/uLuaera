using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

public class LZMA
{
#if !UNITY_EDITOR && (UNITY_ANDROID||UNITY_IPHONE)
#else
    public static byte[] Compress(byte[] src)
    {
        if(src == null)
            return null;

        SevenZip.Compression.LZMA.Encoder coder = new SevenZip.Compression.LZMA.Encoder();
        MemoryStream input = new MemoryStream(src);
        MemoryStream output = new MemoryStream();

        coder.WriteCoderProperties(output);
        output.Write(BitConverter.GetBytes(input.Length), 0, 8);

        coder.Code(input, output, input.Length, -1, null);
        output.Flush();
        input.Flush();

        var bytes = output.ToArray();
        output.Close();
        input.Close();
        output.Dispose();
        input.Dispose();

        return bytes;
    }
#endif

    public static void Decompress(Stream input, Stream output)
    {
        SevenZip.Compression.LZMA.Decoder coder = new SevenZip.Compression.LZMA.Decoder();

        byte[] properties = new byte[5];
        input.Read(properties, 0, 5);

        byte[] bytes = new byte[8];
        input.Read(bytes, 0, 8);
        long size = BitConverter.ToInt64(bytes, 0);

        // Decompress the file.
        coder.SetDecoderProperties(properties);
        coder.Code(input, output, input.Length, size, null);
        output.Flush();
        input.Flush();
    }

    public static byte[] Decompress(byte[] src)
    {
        if(src == null)
            return null;

        SevenZip.Compression.LZMA.Decoder coder = new SevenZip.Compression.LZMA.Decoder();
        MemoryStream input = new MemoryStream(src);
        MemoryStream output = new MemoryStream();

        byte[] properties = new byte[5];
        input.Read(properties, 0, 5);

        byte[] bytes = new byte[8];
        input.Read(bytes, 0, 8);
        long size = BitConverter.ToInt64(bytes, 0);

        // Decompress the file.
        coder.SetDecoderProperties(properties);
        coder.Code(input, output, input.Length, size, null);
        output.Flush();
        input.Flush();

        bytes = output.ToArray();

        output.Close();
        input.Close();

        return bytes;
    }
}

