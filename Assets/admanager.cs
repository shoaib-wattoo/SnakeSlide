﻿using System.Collections;
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

	public bool isProUser = false;

	void Awake(){
		if (PlayerPrefs.GetInt ("noads", 0) == 1) {
			isProUser = true;
		}
	}

    // Use this for initialization
    void Start()
    {
       // PlayerPrefs.DeleteAll();
        DontDestroyOnLoad(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBannerAd();
      //  LoadIntersTitialAd();
     //   LoadVideoAd();
      
      //  LoadIntersTitialAd();
   //     LoadVideoAd();
     //   ShowBannerAd();
        MyRewarVideoAd = RewardBasedVideoAd.Instance;
        if (PlayerPrefs.GetInt("noads") == 0)
        { ShowBannerAd(); }
#if UNITY_ANDROID
        myInterstitialAd = new InterstitialAd(InterstitialAdID_Android);
      

#elif UNITY_IPHONE
        myInterstitialAd = new InterstitialAd(InterstitialAdID_Ios);
#endif


    }
    public void LoadIntersTitialAd()
    {
		if (isProUser)
			return;
		
        AdRequest request = new AdRequest.Builder().Build();
        myInterstitialAd.LoadAd(request);
    }
    public void showInterstitialAd()
    {
		if (isProUser)
			return;
		
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
		if (isProUser)
			return;

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
		if (isProUser)
			return;
		
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
		if (isProUser)
			return;
		
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
		if (isProUser)
			return;
		
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