using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class ads_Manager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    // Attributes
    public static ads_Manager instance;
    
    string gameID = "5458676";

    string interstialAdId = "Interstitial_Android";
    string bannedAdId = "";


    private void Awake()
    {
        MaKeInstance();

        InitializeAds();
    }

    void MaKeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void InitializeAds()
    {
        Advertisement.Initialize(gameID, false, this);
    }

    public void ShowAds()
    {
        Advertisement.Load(interstialAdId, this);

        Advertisement.Show(interstialAdId, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Initialized");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ads Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Ads Failed");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Ads Start");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Ads Clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Ads Complete");
    }
}
