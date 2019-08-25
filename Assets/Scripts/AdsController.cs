using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsController : MonoBehaviour
{
    #if UNITY_IOS
    public const string gameID = "3267970";
    #elif UNITY_ANDROID
    public const string gameID = "3267971";
    #elif UNITY_EDITOR
    public const string gameID = "1111111";
    #endif

    public string bannerPlacement = "BannerAD";
    public bool testMode = false;
    void Start () {
        Advertisement.Initialize (gameID, testMode);
        StartCoroutine (ShowBannerWhenReady ());
    }

    IEnumerator ShowBannerWhenReady () {
        while (!Advertisement.IsReady (bannerPlacement)) {
            yield return new WaitForSeconds (0.5f);
        }
        Advertisement.Show (bannerPlacement);
    }
  
}
