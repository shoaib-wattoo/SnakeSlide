using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class admanager : MonoBehaviour
{
    public static admanager instance;
    public string InterstitialAdID_Android;
    public string InterstitialAdID_Ios;
    public string RewardedAdid_Android;
    public string RewardedAdid_Ios;
    public string banner_Android;
    public string banner_Ios;
    public Text gems;
    InterstitialAd myInterstitialAd;
    RewardBasedVideoAd MyRewarVideoAd;
    BannerView MyBannerView;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBannerAd();
      //  LoadIntersTitialAd();
     //   LoadVideoAd();
        ShowBannerAd();
      //  LoadIntersTitialAd();
   //     LoadVideoAd();
     //   ShowBannerAd();
        MyRewarVideoAd = RewardBasedVideoAd.Instance;
#if UNITY_ANDROID
        myInterstitialAd = new InterstitialAd(InterstitialAdID_Android);
      

#elif UNITY_IPHONE
          myInterstitialAd = new InterstitialAd(InterstitialAdID_Ios);
#endif


    }
    public void LoadIntersTitialAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        myInterstitialAd.LoadAd(request);
    }
    public void showInterstitialAd()
    {
        if (myInterstitialAd.IsLoaded())
        {
            myInterstitialAd.Show();

        }
        else
        {
            LoadIntersTitialAd();
        }
    }
    public void LoadVideoAd()
    {
        if(!myInterstitialAd.IsLoaded())
        {
            AdRequest request = new AdRequest.Builder().Build();
#if UNITY_ANDROID
            MyRewarVideoAd.LoadAd(request, RewardedAdid_Android);

#elif UNITY_IPHONE
             MyRewarVideoAd.LoadAd(request, RewardedAdid_Ios);
#endif
        }
    }
    public  void ShowVideoAd()
    {
        if(MyRewarVideoAd.IsLoaded())
        {
            MyRewarVideoAd.Show();
            PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems")+10);
            gems.text = (PlayerPrefs.GetInt("Gems") + 10).ToString();

        }
        else
        {
            LoadVideoAd();
        }
    }
    void LoadBannerAd()
    {
#if UNITY_ANDROID
        this.MyBannerView = new BannerView(banner_Android, AdSize.Banner, AdPosition.Top);
#elif UNITY_IPHONE
        this.MyBannerView = new BannerView(banner_Ios, AdSize.Banner, AdPosition.Top);
#endif
        AdRequest request = new AdRequest.Builder().Build();
        this.MyBannerView.LoadAd(request);
    }
    public void ShowBannerAd()
    {
        this.MyBannerView.Show();
    }
    public void HideBannerAd()
    {
        this.MyBannerView.Hide();
    }
    public void destroyBanner()
    {
        this.MyBannerView.Destroy();
    }

}