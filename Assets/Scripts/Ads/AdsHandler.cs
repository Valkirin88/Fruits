using System;
using UnityEngine;
using YandexMobileAds;
using YandexMobileAds.Base;

public class AdsHandler : MonoBehaviour
{

    private InterstitialAdLoader interstitialAdLoader;
    private Interstitial interstitial;
    string adUnitId = "R-M-5285862-1";
    AdRequestConfiguration adRequestConfiguration;

    void Start()
    {
        SetupLoader();
    }
    private void SetupLoader()
    {
        interstitialAdLoader = new InterstitialAdLoader();
        interstitialAdLoader.OnAdLoaded += HandleInterstitialLoaded;
        interstitialAdLoader.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
        RequestInterstitial();
    }

    public void HandleInterstitialLoaded(object sender, InterstitialAdLoadedEventArgs args)
    {
        // The ad was loaded successfully. Now you can handle it.

        interstitial = args.Interstitial;
        MonoBehaviour.print("Loaded");
        interstitial.OnAdClicked += HandleAdClicked;
        interstitial.OnAdShown += HandleInterstitialShown;
        interstitial.OnAdFailedToShow += HandleInterstitialFailedToShow;
        interstitial.OnAdDismissed += HandleInterstitialDismissed;


    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("Failed");
        DestroyInterstitial();
    }
    public void RequestInterstitial()
    {
        adRequestConfiguration = new AdRequestConfiguration.Builder(adUnitId).Build();
        interstitialAdLoader.LoadAd(adRequestConfiguration);


    }

    public void ShowInterstitial()
    {
        if (interstitial != null)
        {
            interstitial.Show();
            Debug.Log("Showing");
        }
    }

    public void HandleAdClicked(object sender, EventArgs args)
    {
        // Called when a click is recorded for an ad.
    }

    public void HandleInterstitialShown(object sender, EventArgs args)
    {
        // Called when ad is shown.
        Debug.Log("Shown");
        RequestInterstitial();
    }

    public void HandleInterstitialFailedToShow(object sender, AdFailureEventArgs args)
    {
        // Called when an InterstitialAd failed to show.
        DestroyInterstitial();
    }

    public void HandleInterstitialDismissed(object sender, EventArgs args)
    {
        // Called when ad is dismissed.
        DestroyInterstitial();
    }

    public void DestroyInterstitial()
    {
        if (interstitial != null)
        {
            interstitial.Destroy();
            interstitial = null;
        }
    }


}

