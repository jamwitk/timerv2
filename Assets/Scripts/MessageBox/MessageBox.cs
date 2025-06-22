using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using TMPro;

public class MessageBox : Singleton<MessageBox>
{
    
    public Button yesButton;
    public Button noButton;
    public GameObject messageBoxObject;
    
    private RewardedInterstitialAd rewardedInterstitialAd;
    

    private IEnumerator StartCountTextOfYesButton()
    {
        const float duration = 3f;
        var normalizedTime = 0f;
        yesButton.interactable = false;
        while (normalizedTime <=  duration)
        {
            normalizedTime += Time.unscaledDeltaTime;
            yesButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Video starting in "+(duration - (int)normalizedTime);
            
            yield return null;
        }
        yesButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Yes";
        yesButton.interactable = true;
    }
    private void Start()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
            string adUnitId = "unexpected_platform";
        #endif
       
        // Create an empty ad request.
        var request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        RewardedInterstitialAd.LoadAd(adUnitId, request, ADLoadCallback);
    }

    private void ADLoadCallback(RewardedInterstitialAd arg1, AdFailedToLoadEventArgs arg2)
    {
        print("showed");
        if (arg2 == null)
        {
            rewardedInterstitialAd = arg1!;
        }
    }

    private void ShowAd()
    {
        rewardedInterstitialAd.Show(reward => {} );
    }
    public void Show()
    {
        StartCoroutine(StartCountTextOfYesButton());
        messageBoxObject.SetActive(true);
        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(ShowAd);
        yesButton.onClick.AddListener(ClosePanel);
        

       
        noButton.onClick.RemoveAllListeners();
        noButton.onClick.AddListener(ClosePanel);
    }
    
    private void ClosePanel()
    {
        messageBoxObject.SetActive(false);
        //Change players position to the deafult position
        //Set clock's rotation to 0
        
        
    }
}