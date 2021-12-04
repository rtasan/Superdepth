using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using MahApps.Metro.Controls;
using Superdepth.Processor;
using Superdepth.IO;

namespace Superdepth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private AppViewModel ViewModel = new AppViewModel();

        public MainWindow()
        {
            DataContext = ViewModel;
            InitializeComponent();
            Logger.logTextBox = LogTextBox;
        }

        private void OnBrowseInputClick(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog { InitialDirectory= Directory.GetCurrentDirectory() , IsFolderPicker=false};
            if (openFileDialog.ShowDialog()==CommonFileDialogResult.Ok)
            { 
                ViewModel.InputFilePath = openFileDialog.FileName;
            }
        }

        private void OnRunClick(object sender, RoutedEventArgs e)
        {
            FileProcess.ProcessFile(ViewModel.InputFilePath);
            // LogTextBox.AppendText(ViewModel.InputFilePath+"\n");
            // LogTextBox.ScrollToEnd();
        }

        private void InputFileDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                ViewModel.InputFilePath = files[0];
            }
        }

        private void InputFileDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }
    }
}
