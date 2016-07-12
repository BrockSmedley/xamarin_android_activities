using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Activities {
	[Activity(Label = "Activity3")]
	public class Activity3 : Activity {
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.GetInfo);

			Button sendButton = FindViewById<Button>(Resource.Id.buttonSend);
			EditText textBox = FindViewById<EditText>(Resource.Id.editText1);
			
			sendButton.Click += delegate {
				Intent intent = new Intent(this, typeof(MainActivity));
				string value = textBox.Text;
				intent.PutExtra("result", value);
				SetResult(Result.Ok, intent);
				Finish(); //close out this activity; send result
			};
		}
	}
}