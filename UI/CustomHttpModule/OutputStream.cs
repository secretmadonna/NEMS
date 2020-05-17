using System.IO;
using System.Text;

namespace SecretMadonna.NEMS.UI.CustomHttpModule
{
    public class OutputStream : Stream
    {
        private readonly Stream InnerStream;
        private readonly MemoryStream CopyStream;
        private readonly Encoding Encoding;

        public OutputStream(Stream innerStream, Encoding encoding)
        {
            InnerStream = innerStream;
            CopyStream = new MemoryStream();
            Encoding = encoding;
        }
        ~OutputStream()
        { }

        public string ReadToEnd()
        {
            lock (InnerStream)
            {
                if (!CopyStream.CanRead || !CopyStream.CanSeek || CopyStream.Length <= 0L)
                {
                    return string.Empty;
                }

                var pos = CopyStream.Position;
                CopyStream.Position = 0L;
                try
                {
                    return new StreamReader(CopyStream, Encoding).ReadToEnd();
                }
                finally
                {
                    try
                    {
                        CopyStream.Position = pos;
                    }
                    catch { }
                }
            }
        }

        #region override
        public override bool CanRead
        {
            get { return InnerStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return InnerStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return InnerStream.CanWrite; }
        }

        public override long Length
        {
            get { return InnerStream.Length; }
        }

        public override long Position
        {
            get { return InnerStream.Position; }
            set { CopyStream.Position = InnerStream.Position = value; }
        }

        public override void Flush()
        {
            InnerStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return InnerStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            CopyStream.Seek(offset, origin);
            return InnerStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            CopyStream.SetLength(value);
            InnerStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            CopyStream.Write(buffer, offset, count);
            InnerStream.Write(buffer, offset, count);
        }
        #endregion
    }
}
