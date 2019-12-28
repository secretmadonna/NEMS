using System.IO;
using System.Text;

namespace SecretMadonna.NEMS.UI.CustomHttpModule
{
    public class OutputStream : Stream
    {
        private readonly Stream InnerStream;
        private readonly MemoryStream CopyStream;
        private readonly Encoding Encoding;

        static OutputStream()
        { }
        public OutputStream(Stream innerStream, Encoding encoding)
        {
            this.InnerStream = innerStream;
            this.CopyStream = new MemoryStream();
            this.Encoding = encoding;
        }
        ~OutputStream()
        { }

        public string ReadToEnd()
        {
            lock (this.InnerStream)
            {
                if (!this.CopyStream.CanRead || !this.CopyStream.CanSeek || this.CopyStream.Length <= 0L)
                {
                    return string.Empty;
                }

                var pos = this.CopyStream.Position;
                this.CopyStream.Position = 0L;
                try
                {
                    return new StreamReader(this.CopyStream, this.Encoding).ReadToEnd();
                }
                finally
                {
                    try
                    {
                        this.CopyStream.Position = pos;
                    }
                    catch { }
                }
            }
        }

        #region override
        public override bool CanRead
        {
            get { return this.InnerStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return this.InnerStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return this.InnerStream.CanWrite; }
        }

        public override long Length
        {
            get { return this.InnerStream.Length; }
        }

        public override long Position
        {
            get { return this.InnerStream.Position; }
            set { this.CopyStream.Position = this.InnerStream.Position = value; }
        }

        public override void Flush()
        {
            this.InnerStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.InnerStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            this.CopyStream.Seek(offset, origin);
            return this.InnerStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            this.CopyStream.SetLength(value);
            this.InnerStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.CopyStream.Write(buffer, offset, count);
            this.InnerStream.Write(buffer, offset, count);
        }
        #endregion
    }
}
