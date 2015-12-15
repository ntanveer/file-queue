using System;
using System.Collections.Generic;

namespace FileQueueProcessing
{
    public class QueueItem
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
        public DateTime LastTouched { get; set; }
    }
}
