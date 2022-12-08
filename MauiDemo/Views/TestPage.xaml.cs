namespace MauiDemo.Views;

public partial class TestPage : ContentPage
{
    public TestPage()
    {
        InitializeComponent();

        RotateImage();
    }


    private async void RotateImage()
    {
        
        while (true)
        {
            GraphicLabel.Text =
                "Executing code: await SwirlImage.RotateTo(SwirlImage.Rotation + 360, 5000, Easing.Linear);";
            await SwirlImage.RotateTo(SwirlImage.Rotation + 360, 5000, Easing.Linear);

            GraphicLabel.Text =
                "Executing code: await SwirlImage.RotateTo(SwirlImage.Rotation - 360, 5000, Easing.Linear);";
            await SwirlImage.RotateTo(SwirlImage.Rotation - 360, 5000, Easing.Linear);
            
            GraphicLabel.Text =
                "await SwirlImage.RotateTo(SwirlImage.Rotation + 360, 5000, Easing.SpringIn);";
            await SwirlImage.RotateTo(SwirlImage.Rotation + 360, 5000, Easing.SpringIn);

            GraphicLabel.Text =
                "await SwirlImage.RotateTo(SwirlImage.Rotation - 360, 5000, Easing.SpringIn);";
            await SwirlImage.RotateTo(SwirlImage.Rotation - 360, 5000, Easing.SpringIn);
        }
    }
}