using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AndroidX.ViewPager.Widget;

using FragmentManager = AndroidX.Fragment.App.FragmentManager;

namespace ViewPagerIndicator
{
	[Activity (Label = "Tabs/Styled", Theme = "@style/StyledIndicators")]
	[IntentFilter (new[]{Intent.ActionMain}, Categories = new[]{ "mono.viewpagerindicator.sample" })]
	public class SampleTabsStyled : BaseSampleActivity
	{
		public static string[] CONTENT = new string[] { "Recent", "Artists", "Albums", "Songs", "Playlists", "Genres" };

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.simple_tabs);
	
			mAdapter = new GoogleMusicAdapter (SupportFragmentManager);
	
			mPager = FindViewById<ViewPager> (Resource.Id.pager);
			mPager.Adapter = mAdapter;
	
			mIndicator = FindViewById<TabPageIndicator> (Resource.Id.indicator);
			mIndicator.SetViewPager (mPager);
		}
		
		public class GoogleMusicAdapter : TestFragmentAdapter, TitleProvider
		{
			public GoogleMusicAdapter (FragmentManager fm) : base(fm)
			{
			}
			
			public override AndroidX.Fragment.App.Fragment GetItem (int position)
			{
				return new TestFragment (SampleTabsDefault.CONTENT [position % SampleTabsDefault.CONTENT.Length]);
			}
			
			public override int Count {
				get {
					return SampleTabsDefault.CONTENT.Length;
				}
			}

			public string GetTitle (int position)
			{
				return  SampleTabsDefault.CONTENT [position % SampleTabsDefault.CONTENT.Length].ToUpper ();
			}
		}
	}
}


