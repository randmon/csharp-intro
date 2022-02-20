using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExercise
{
    public abstract class Logger
    {
        public abstract void Log(string message);
        public virtual void Close() {}
    }

    public class StreamLogger : Logger
    {
        private readonly StreamWriter writer;

        public StreamLogger(StreamWriter writer)
        {
            this.writer = writer;
        }

        public override void Log(string message)
        {
            writer.WriteLine(message);
            writer.Flush();
        }
    }

    public class FileLogger : StreamLogger
    {
        private readonly FileStream fileStream;

        public FileLogger(FileStream fileStream) : base(new StreamWriter(fileStream))
        {
            this.fileStream = fileStream;
        }

        public static FileLogger Create(string filename)
        {
            FileStream fileStream = File.OpenWrite(filename);
            return new FileLogger(fileStream);
        }

        public override void Close()
        {
            fileStream.Close();
        }
    }

    public class NullLogger : Logger
    {
        public override void Log(string message)
        {
            //Do nothing in case we are not interested in the log messages
        }
    }

    public class LogBroadcaster : Logger
    {
        private readonly IEnumerable<Logger> loggers;

        public LogBroadcaster(IEnumerable<Logger> loggers)
        {
            this.loggers = loggers;
        }

        public override void Log(string message)
        {
            foreach (Logger l in loggers)
            {
                l.Log(message);
            }
        }

        public override void Close()
        {
            foreach (Logger l in loggers)
            {
                l.Close();
            }
        }
    }
}
