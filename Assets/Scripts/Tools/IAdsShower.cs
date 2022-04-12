using System;

namespace Tools.Ads
{
    internal interface IAdsShower
    {
        void ShowInterstitial();
        void ShowVideo(Action successShow);
    }
}