using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrDecoder
{
    public static class ZipHelper
    {
        // Token: 0x060009C3 RID: 2499 RVA: 0x000468FC File Offset: 0x00044AFC
        public static byte[] Compress(byte[] input)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(input))
            {
                using (MemoryStream memoryStream2 = new MemoryStream())
                {
                    using (DeflateStream deflateStream = new DeflateStream(memoryStream2, CompressionMode.Compress))
                    {
                        memoryStream.CopyTo(deflateStream);
                    }
                    result = memoryStream2.ToArray();
                }
            }
            return result;
        }

        // Token: 0x060009C4 RID: 2500 RVA: 0x00046978 File Offset: 0x00044B78
        public static byte[] Decompress(byte[] input)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(input))
            {
                using (MemoryStream memoryStream2 = new MemoryStream())
                {
                    using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress))
                    {
                        deflateStream.CopyTo(memoryStream2);
                    }
                    result = memoryStream2.ToArray();
                }
            }
            return result;
        }

        // Token: 0x060009C5 RID: 2501 RVA: 0x000469F4 File Offset: 0x00044BF4
        public static string Zip(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            string result;
            try
            {
                result = Convert.ToBase64String(SolrDecoder.ZipHelper.Compress(Encoding.UTF8.GetBytes(input)));
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }

        // Token: 0x060009C6 RID: 2502 RVA: 0x00046A40 File Offset: 0x00044C40
        public static string Unzip(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            string result;
            try
            {
                byte[] bytes = SolrDecoder.ZipHelper.Decompress(Convert.FromBase64String(input));
                result = Encoding.UTF8.GetString(bytes);
            }
            catch (Exception)
            {
                result = input;
            }
            return result;
        }
    }
}
