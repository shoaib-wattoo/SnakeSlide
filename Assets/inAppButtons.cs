using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inAppButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void fourHundred()
    {
        IAPManager.Instance.Buy50Gold();
        IAPManager.Instance.BuyNoAds();
    }
    public void Thousand()
    {
        IAPManager.Instance.Buy100Gold();
        IAPManager.Instance.BuyNoAds();
    }
    public void thirtytwothousand()
    {
        IAPManager.Instance.Buy200Gold();
        IAPManager.Instance.BuyNoAds();
    }
    public void seventyTwoThousand()
    {
        IAPManager.Instance.Buy400Gold();
        IAPManager.Instance.BuyNoAds();
    }
    public void NoADDS()
    {
        IAPManager.Instance.BuyNoAds();
    }
}
