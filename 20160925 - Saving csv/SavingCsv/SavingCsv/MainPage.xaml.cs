using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SavingCsv
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private StringBuilder _stringBuilder = new StringBuilder();
        private string _beginDate = "2015-01-01";
        private string _endDate = DateTime.Now.ToString("yyyy-MM-dd");
        private string _endDateIncorrect = DateTime.Now.ToString("yyyy/MM/dd");

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await SaveUsingFolderPicker("2015-01-01", "2017-01-01"); // correct
            await SaveUsingFolderPicker("2015-01-01", "2017/01/01"); // incorrect
        }

        private async Task SaveUsingFolderPicker(string beginDate, string endDate)
        {
            var picker = new Windows.Storage.Pickers.FolderPicker();
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".csv"); //add any extension to avoid exception

            var folder = await picker.PickSingleFolderAsync();

            if (folder != null)
            {
                string strFilename = beginDate + "_To_" + endDate + ".csv";

                StorageFile file =
                    await folder.CreateFileAsync("Rpt" + strFilename, CreationCollisionOption.ReplaceExisting);

                _stringBuilder.Append("Some data");
                //foreach (var m in FlightData)
                //{
                //    _stringBuilder.Append(m.Id + "," + m.Date + "," + m.Price + "," + ...... + "\r\n");
                //}

                await FileIO.AppendLinesAsync(file, new List<string>() {_stringBuilder.ToString()});
            }
        }
    }
}
