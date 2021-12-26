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
        public static async Task ProcessFile(string inputPath)
        {
            if (!File.Exists(inputPath) || String.IsNullOrEmpty(inputPath)) return; // check


            // inputPathと同階層に一時ディレクトリinputDir作成      
            string inputDir = Path.Join(Path.GetDirectoryName(inputPath), "tempInputSuperdepth");
            string outputDir = Path.Join(Path.GetDirectoryName(inputPath), "tempOutputSuperdepth");
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);
            Logger.Log("Successfully created input directory:"+inputDir);
            Logger.Log("Successfully created output directory:"+outputDir);

            //動画のfps取得
            double fps = await FFMpegProcess.GetFrameRateAsync(inputPath);
            Logger.Log("Framerate:"+fps.ToString()); ;
                       
            // inputPathで与えられる動画をFFMpegProcessで連番画像に変換->inputDirに保存
            await FFMpegProcess.VideoToImage(inputPath, inputDir, fps);


            // 一時ディレクトリ内のファイルを処理 AiProcess
            await AiProcess.ComputeAI(inputDir, outputDir);

            // output内の連番画像を動画にする
            string videoOutDir = Path.GetDirectoryName(inputPath);
            await FFMpegProcess.ImageToVideo(outputDir, videoOutDir, fps, "output");

            // 後処理
            Directory.Delete(inputDir, true);
            Directory.Delete(outputDir, true);

        }
    }
}
