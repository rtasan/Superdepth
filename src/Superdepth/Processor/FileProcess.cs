using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superdepth.IO;

namespace Superdepth.Processor
{
    internal class FileProcess
    {
        // 全体のプロセス
        // InputFilePathを受け取り、各プロセッサーに流して処理
        public static void ProcessFile(string inputPath)
        {
            if (!File.Exists(inputPath) || String.IsNullOrEmpty(inputPath)) return; // check


            // inputPathと同階層に一時ディレクトリinputDir作成      
            string inputDir = Path.Join(Path.GetDirectoryName(inputPath), "tempInputSuperdepth");
            string outputDir = Path.Join(Path.GetDirectoryName(inputPath), "tempOutputSuperdepth");
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);
            Logger.Log(inputDir);
            Logger.Log(outputDir);
                       
            // inputPathで与えられる動画をFFMpegProcessで連番画像に変換->inputDirに保存


            // 一時ディレクトリ内のファイルを処理 AiProcess
            AiProcess.computeAI(inputDir, outputDir);
            // output内の連番画像を動画にする

        }
    }
}
