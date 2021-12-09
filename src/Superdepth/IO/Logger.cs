using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Superdepth;

namespace Superdepth.IO
{
    internal class Logger
    {
        public static TextBox logTextBox;

        public static void Log(string message)
        {
            
            logTextBox.AppendText(message + "\n");
            logTextBox.ScrollToEnd();
        }
    }
}
