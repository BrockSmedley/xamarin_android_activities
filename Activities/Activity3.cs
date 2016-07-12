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
			//setting our special layout as this activity's content view
			SetContentView(Resource.Layout.GetInfo);

			Button sendButton = FindViewById<Button>(Resource.Id.buttonSend);
			EditText textBox = FindViewById<EditText>(Resource.Id.editText1);
			
			sendButton.Click += delegate {
				//create a new intent to send back with the result
				Intent intent = new Intent(this, typeof(MainActivity));
				//get value from textbox
				string value = textBox.Text;
				//send this value with the intent
				intent.PutExtra("result", value);
				//set result code; lets calling activity know whether the process worked
				SetResult(Result.Ok, intent);
				//close out this activity; send result
				Finish(); 
			};
		}
	}
}