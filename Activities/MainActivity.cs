using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Activities {
	[Activity(Label = "Activities", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.MyButton);
			button.Click += delegate {
				//start a plain activity
				StartActivity(typeof(Activity2));
			};

			
			Button button2 = FindViewById<Button>(Resource.Id.button2);
			button2.Click += delegate {
				//start a new activity and expect a result intent
				var resultIntent = new Intent(this, typeof(Activity3));
				StartActivityForResult(resultIntent, 0); // 0 is an arbitrary code... this should be used more effectively in real apps
			};
		}

		//handles results from activities that are called for a result
		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {
			base.OnActivityResult(requestCode, resultCode, data);

			if (resultCode == Result.Ok) {
				//get the info from the intent and slap it on our TextView
				var resultText = FindViewById<TextView>(Resource.Id.textViewResult);
				resultText.SetText(data.GetStringExtra("result"), TextView.BufferType.Normal);
			}
		}
	}
}

