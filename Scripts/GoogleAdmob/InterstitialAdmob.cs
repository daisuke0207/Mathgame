using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


//広告イベント 説明
//OnAdLoaded OnAdLoaded イベントは、広告の読み込みが完了すると実行されます。
//OnAdFailedToLoad OnAdFailedToLoad イベントは、広告の読み込みに失敗すると呼び出されます。Message パラメータは、発生した障害のタイプを示します。
//OnAdLeavingApplication OnAdOpened の後にユーザーが別のアプリ（Google Play ストアなど）を起動し、現在のアプリがバックグラウンドに移動すると、このメソッドが呼び出されます。


public class InterstitialAdmob : MonoBehaviour
{
    public OverLine OverLine;
    public OverLine2 OverLine2;

    public UnityEvent OnOpeningAd;//inspectorでイベントが表示される
    public UnityEvent OnClosedAd;

    [HideInInspector] public InterstitialAd interstitial;

    public GameObject gameadshow;

    public static bool showbo = true;

    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8474299524643903/3982359579";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-8474299524643903/4720726172";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)//広告を開いた時に実行したいこと。
    {
        MonoBehaviour.print("HandleAdOpened event received");
        OnOpeningAd.Invoke();//追加
        showbo = false;
        GameAdControl.gameCount = 0;
    }

    public void HandleOnAdClosed(object sender, EventArgs args)//広告を閉じた時に実行したいこと。
    {
        DestroyInterstitialAd();//追加したメソッド
        RequestInterstitial();//追加
        MonoBehaviour.print("HandleAdClosed event received");
        OnClosedAd.Invoke();//追加
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }


    public void ShowInterstitialAd() //広告表示
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else//追加した処理 読み込めなかった時の処理
        {
            
        }
    }

    public void DestroyInterstitialAd() 
    {
        interstitial.Destroy();
    }

    void Start()
    {
        if (GameAdControl.gameCount >= 2)
        {
            RequestInterstitial();
            showbo = true;
        }
    }
   

    void Update()
    {       
        if(gameadshow.activeSelf == true && showbo)
        {
            ShowInterstitialAd();
            if (SceneManager.GetActiveScene().name == "MathBattle")
            {
                OverLine.OverLineSou.Stop();
            }
            if (SceneManager.GetActiveScene().name == "MathBattle1")
            {
                OverLine2.OverLineSou.Stop();
            }
        }
    }
}
