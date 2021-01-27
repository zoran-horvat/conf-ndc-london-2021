using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Demo.Logging
{
    public class LogSink
    {
        private List<string> Rows { get; }
        public IEnumerable<string> Content => this.Rows;

        public IEnumerable<IEnumerable<string>> PrintableContent =>
            this.Content.Select(line => line.Replace("\r", "\n").Split("\n", StringSplitOptions.RemoveEmptyEntries));

        public LogSink()
        {
            this.Rows = new List<string>();
        }

        public void Append(string line)
        {
            if (string.IsNullOrEmpty(line)) return;
            this.Rows.Add(line);
        }

        public void AppendMethodCalled([CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(memberName)) return;
            this.Append($"{Path.GetFileNameWithoutExtension(filePath)}.{memberName}");
        }

        public void Purge() => 
            this.Rows.Clear();
    }
}
