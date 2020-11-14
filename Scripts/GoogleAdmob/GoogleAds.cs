using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GoogleAds : MonoBehaviour
{
    public BannerView bannerView;

    // Use this for initialization
    void Start()
    {

#if UNITY_ANDROID
            string appId = "ca-app-pub-8474299524643903~3183363358";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-8474299524643903~9973052852";
#else
        string appId = "unexpected_platform";
#endif
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-8474299524643903/3954385516";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-8474299524643903/1519793866";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Create a 320x50 banner at the top of the screen.
        AdSize adSize = new AdSize(320, 250);

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            adSize = new AdSize(320, 100);
        }

        bannerView = new BannerView(adUnitId, adSize, AdPosition.Bottom);//Adsize.Banner

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

    }
    public void StopBanner()
    {
        bannerView.Hide();
        bannerView.Destroy();
    }
}
