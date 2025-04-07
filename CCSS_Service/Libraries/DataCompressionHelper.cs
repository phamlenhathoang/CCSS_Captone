using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Libraries
{
    public static class DataCompressionHelper
    {
        public static string CompressAndEncodeData(string data)
        {
            // Chuyển chuỗi thành mảng byte
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            using (var memoryStream = new MemoryStream())
            {
                // Sử dụng GZip để nén dữ liệu
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gzipStream.Write(dataBytes, 0, dataBytes.Length);
                }

                // Lấy dữ liệu đã nén và mã hóa thành Base64
                byte[] compressedData = memoryStream.ToArray();
                return Convert.ToBase64String(compressedData);
            }
        }

        // Giải mã và giải nén dữ liệu từ chuỗi Base64
        public static string DecodeAndDecompressData(string compressedBase64)
        {
            // Giải mã Base64 thành mảng byte
            byte[] compressedBytes = Convert.FromBase64String(compressedBase64);

            using (var memoryStream = new MemoryStream(compressedBytes))
            {
                using (var outputStream = new MemoryStream())
                {
                    // Sử dụng GZip để giải nén dữ liệu
                    using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        gzipStream.CopyTo(outputStream);
                    }

                    // Chuyển mảng byte thành chuỗi
                    byte[] decompressedBytes = outputStream.ToArray();
                    return Encoding.UTF8.GetString(decompressedBytes);
                }
            }
        }
    }
}
