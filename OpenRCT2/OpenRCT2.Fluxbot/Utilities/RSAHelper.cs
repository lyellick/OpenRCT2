using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OpenRCT2.Fluxbot.Utilities
{
    public static class RSAHelper
    {
        public static string ExportPrivateKey(this RSA rsa)
        {
            var builder = new StringBuilder("-----BEGIN RSA PRIVATE KEY");
            builder.AppendLine("-----");

            byte[]? privateKeyBytes = rsa.ExportRSAPrivateKey();
            string? base64PrivateKeyString = Convert.ToBase64String(privateKeyBytes);
            int offset = 0;
            const int LINE_LENGTH = 64;

            while (offset < base64PrivateKeyString.Length)
            {
                int lineEnd = Math.Min(offset + LINE_LENGTH, base64PrivateKeyString.Length);
                builder.AppendLine(base64PrivateKeyString.Substring(offset, lineEnd - offset));
                offset = lineEnd;
            }

            builder.Append("-----END RSA PRIVATE KEY");
            builder.AppendLine("-----");
            return builder.ToString();
        }

        public static string ExportPublicKey(this RSA rsa)
        {
            var builder = new StringBuilder("-----BEGIN RSA PUBLIC KEY");
            builder.AppendLine("-----");

            byte[]? privateKeyBytes = rsa.ExportRSAPrivateKey();
            string? base64PrivateKeyString = Convert.ToBase64String(privateKeyBytes);
            int offset = 0;
            const int LINE_LENGTH = 64;

            while (offset < base64PrivateKeyString.Length)
            {
                int lineEnd = Math.Min(offset + LINE_LENGTH, base64PrivateKeyString.Length);
                builder.AppendLine(base64PrivateKeyString.Substring(offset, lineEnd - offset));
                offset = lineEnd;
            }

            builder.Append("-----END RSA PUBLIC KEY");
            builder.AppendLine("-----");
            return builder.ToString();
        }
    }
}
