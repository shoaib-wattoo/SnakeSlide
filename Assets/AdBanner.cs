using UnityEngine;
using System.Collections;

public class AdBanner : MonoBehaviour
{
    public static AdBanner current;
    public GoogleMobileAdsDemoScript myadds;

    void Awake()
    {
        current = this;
    }
    void Start()
    {
        Invoke("CreateBanner", 1f);
        DontDestroyOnLoad(gameObject);
    }
    private void CreateBanner()
    {
        Debug.Log("Create Banner Request Send");
        myadds.RequestBanner();
        Invoke("ShowBanner", 2f);
    }
    private void ShowBanner()
    {
        Debug.Log("Show Banner Request Send");
        myadds.ShowBanner();
    }
    public void CreateInterstitial()
    {
        Debug.Log("Create Interstitial Request Send");
        myadds.RequestInterstitial();
    }
    public void ShowInterstital()
    {
        Debug.Log("Show Interstitial Request Send");
        myadds.ShowInterstitial();
    }
}
