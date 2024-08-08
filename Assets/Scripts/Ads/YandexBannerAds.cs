using YandexMobileAds;
using YandexMobileAds.Base;
using UnityEngine;
using System;

public class YandexBannerAds : MonoBehaviour
{
    private Banner banner;

    private void Start()
    {
        banner.OnAdLoaded += HandleAdLoaded;
        banner.OnAdFailedToLoad += HandleAdFailedToLoad;
        RequestStickyBanner();
    }

    private void HandleAdFailedToLoad(object sender, AdFailureEventArgs e)
    {
        Debug.Log(e.Message);
        Debug.Log("Ads failed load");
    }

    private int GetScreenWidthDp()
    {
        int screenWidth = (int)Screen.safeArea.width;
        return ScreenUtils.ConvertPixelsToDp(screenWidth);
    }

    private void RequestStickyBanner()
    {

        Debug.Log("Request banner");

        string adUnitId = "demo - banner - yandex"; // замените на "R-M-10949339-1"
        ;
        BannerAdSize bannerMaxSize = BannerAdSize.StickySize(GetScreenWidthDp());
        banner = new Banner(adUnitId, bannerMaxSize, AdPosition.BottomCenter);


        AdRequest request = new AdRequest.Builder().Build();
        banner.LoadAd(request);

    }

    private void HandleAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("Banner loaded");
        banner.Show();
    }
}
