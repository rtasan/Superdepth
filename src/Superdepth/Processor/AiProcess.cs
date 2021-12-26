using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Cysharp.Diagnostics;
using System.IO;
using Superdepth.IO;
using System.Reflection;

namespace Superdepth.Processor
{
    internal class AiProcess
    {
        // 作業用一時フォルダーに展開された連番画像を処理する
        public static async Task ComputeAI(string inputDir, string outputDir)
        {
            Logger.Log("Start computing depth map");
            string PythonPath = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "bin", "Python", "pythonenv", "python.exe");
            string ScriptPath = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "bin", "Python", "MiDaS", "run.py");
            string ModelPath = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "bin", "Python", "MiDaS", "weights", "dpt_large-midas-2f21e586.pt");
            try
            {
                await foreach (string item in ProcessX.StartAsync($"{PythonPath} {ScriptPath} -i {inputDir} -o {outputDir} -m {ModelPath}"))
                {
                    Logger.Log(item);
                }
            }
            catch (ProcessErrorException ex)
            {

                Logger.Log(ex.ToString());
            }
            

        }

        
        // inputFolderとoutputFolderをprocessで渡して、python側で処理する
        // 出来ればprogresBarを実装したいので、プロセス間通信の方法を考える
    }
}
