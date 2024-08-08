using YandexMobileAds;
using YandexMobileAds.Base;
using UnityEngine;
using System;

public class YandexBannerAds : MonoBehaviour
{
    private Banner banner;
    private bool _isBannerShowd;

    private void Start()
    {
        RequestStickyBanner();
    }

    private void Update()
    {
        ShowBanner();
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

        string adUnitId = "demo - banner - yandex"; // �������� �� "R-M-10949339-1"
        ;
        BannerAdSize bannerMaxSize = BannerAdSize.StickySize(GetScreenWidthDp());
        banner = new Banner(adUnitId, bannerMaxSize, AdPosition.BottomCenter);
        banner.OnAdLoaded += HandleAdLoaded;
        banner.OnAdFailedToLoad += HandleAdFailedToLoad;

        AdRequest request = new AdRequest.Builder().Build();
        banner.LoadAd(request);

    }

    private void ShowBanner()
    {
        if(banner != null && !_isBannerShowd)
        {
            _isBannerShowd = true;
            banner.Show();
        }
    }

    private void HandleAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("Banner loaded");
        banner.Show();
    }
}
