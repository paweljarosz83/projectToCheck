using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdsController : MonoBehaviour {

	private static AdsController adsController;
	private BannerView bannerView;

	void Awake(){
		Object.DontDestroyOnLoad (gameObject);
		adsController = this;
		RequestBanner ();
	}

	public void RequestBanner(){
		Debug.Log ("request banner");
		#if UNITY_ANDROID
		string adUnitId = "cefdwer00635";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		//AdRequest request = new AdRequest.Builder().Build();

		AdRequest request = new AdRequest.Builder()
		.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
		.AddTestDevice("2399c5ff7e2ab0c2")  // My test device.
		.Build();

		bannerView.LoadAd(request);
	}

	public void showBanner(){
		if (bannerView != null) {
			bannerView.Show ();
		}
	}

	public void hideBanner(){
		if (bannerView != null) {
			bannerView.Hide ();
		}
	}

	public void destroyBanner(){
		if (bannerView != null) {
			bannerView.Destroy ();
			bannerView = null;
		}
	}
}
