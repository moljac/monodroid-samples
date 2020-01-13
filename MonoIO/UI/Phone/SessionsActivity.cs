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
using ListFragment = AndroidX.Fragment.App.ListFragment;
using Fragment = AndroidX.Fragment.App.Fragment;

namespace MonoIO
{
	[Activity (Label = "@string/title_sessions")]
	[IntentFilter(new []{Intent.ActionView}, Categories =new[]{ Intent.CategoryDefault, Intent.CategoryTab }, DataMimeType = "vnd.android.cursor.dir/vnd.iosched.session")]
	public class SessionsActivity : BaseSinglePaneActivity
	{
		protected override Fragment OnCreatePane ()
		{
			return new SessionsFragment();
		}
		
		protected override void OnPostCreate (Bundle savedInstanceState)
		{
			base.OnPostCreate (savedInstanceState);
			ActivityHelper.SetupSubActivity();
		}
	}
}

