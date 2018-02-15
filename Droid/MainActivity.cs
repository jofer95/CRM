using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace ejmeplo1.Droid
{
    [Activity(Label = "Menu principal", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button btnAddContacto = FindViewById<Button>(Resource.Id.btnAddContacto);
            Button button = FindViewById<Button>(Resource.Id.myButton);

            btnAddContacto.Click += delegate {
                var activityAddContacto = new Intent(this, typeof(AddContacto));
                activityAddContacto.PutExtra("MyData", "Data from Activity1");
                StartActivity(activityAddContacto);
            };

            button.Click += delegate { button.Text = $"{count++} clicks!"; };
        }
    }
}

