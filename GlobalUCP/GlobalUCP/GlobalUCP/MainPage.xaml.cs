using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Vision;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace GlobalUCP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        // var emotionKey = "3ea63bdad6ec41659989eaa0d260a73b";
        //var media = Plugin.Media.CrossMedia.Current;
        //await media.Initialize();
        //var file = await media.TakePhotoAsync(new StoreCameraMediaOptions { SaveToAlbum = false });

        //Img.Source = ImageSource.FromStream(() => file.GetStream());


        //var emotionclient = new EmotionServiceClient(emotionKey);
        //var result = await emotionclient.RecognizeAsync(file.GetStream());

        //var score = result.FirstOrDefault().Scores.ToRankedList().First().Key;

        //LblResult.Text = $"Your emotion is {score}";

        //file.Dispose();

        private async void BtnImage_OnClicked(object sender, EventArgs e)
        {

            var visionKey = "d5fdc78fad5b4cf98fce5df15146426d";

            var media = Plugin.Media.CrossMedia.Current;
            await media.Initialize();
            var file = await media.TakePhotoAsync(new StoreCameraMediaOptions { SaveToAlbum = false });
            Img.Source = ImageSource.FromStream(() => file.GetStream());
            var visionclient = new VisionServiceClient(visionKey);
            var result = await visionclient.DescribeAsync(file.GetStream());
            LblResult.Text = result.Description.Captions.First().Text;

            file.Dispose();

        }
    }
}
