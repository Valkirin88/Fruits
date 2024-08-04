using YandexMobileAds;
using YandexMobileAds.Base;
using UnityEngine;
using System;

public class YandexBannerAds : MonoBehaviour
{
    private Banner banner;

    private void Start()
    {
        RequestStickyBanner();
        banner.OnAdLoaded += HandleAdLoaded;
        banner.OnAdFailedToLoad += HandleAdFailedToLoad;
    }

    private void HandleAdFailedToLoad(object sender, AdFailureEventArgs e)
    {
        Debug.Log(e.Message);
    }

    private int GetScreenWidthDp()
    {
        int screenWidth = (int)Screen.safeArea.width;
        return ScreenUtils.ConvertPixelsToDp(screenWidth);
    }

    private void RequestStickyBanner()
    {
        Debug.Log("Request banner");
        string adUnitId = "ID R-M-10931971-1"; // замените на "R-M-XXXXXX-Y"
        BannerAdSize bannerMaxSize = BannerAdSize.StickySize(GetScreenWidthDp());
        banner = new Banner(adUnitId, bannerMaxSize, AdPosition.BottomCenter);
    }

    private void HandleAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("Banner loaded");
        banner.Show();
    }
}
