using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superdepth.IO;

namespace Superdepth.Processor
{
    internal class AiProcess
    {
        // 作業用一時フォルダーに展開された連番画像を処理する
        public static void computeAI(string inputDir, string outputDir)
        {
            Logger.Log("Start computing depth map");
        }
        // inputFolderとoutputFolderをprocessで渡して、python側で処理する
        // 出来ればprogresBarを実装したいので、プロセス間通信の方法を考える
    }
}
