using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using Superdepth.IO;
using FFMpegCore;
using FFMpegCore.Enums;

namespace Superdepth.Processor
{
    // https://qiita.com/kokeiro001/items/0e321c30cccc45ae44a4
    internal class FFMpegProcess
    {       
        // ffmpegを用いて、inputの動画を作業用一時フォルダーに、連番画像で展開する
        public static async Task VideoToImage(string inputPath, string outputDir, double frameRate)
        {
            await FFMpegArguments.FromFileInput(inputPath).OutputToFile($"{outputDir}\\image_%6d.png",false,options=>options.WithVideoCodec(VideoCodec.Png).WithFramerate(frameRate)).ProcessAsynchronously();
        }

        // ffmpegを用いて、作業用一時フォルダーoutput/内の連番画像を、動画に戻す
        public static async Task ImageToVideo(string outputDir, string videoOutDir, double frameRate, string outputFilename)
        {
            
            IEnumerable<string> inputPaths = Directory.EnumerateFiles(outputDir);
            await FFMpegArguments.FromConcatInput(inputPaths, option=>option.WithCustomArgument($"-framerate {frameRate}")).OutputToFile($"{videoOutDir}\\{outputFilename}.mp4", true, options => options.WithVideoCodec(VideoCodec.LibX264).WithFramerate(frameRate)).ProcessAsynchronously();
            
        }

        public static async Task<double> GetFrameRateAsync(string inputPath)
        {
            double fps = 0;
            var mediaInfo = await FFProbe.AnalyseAsync(inputPath);
            fps = mediaInfo.VideoStreams[0].FrameRate;

            return fps;
        }

        
    }
}
