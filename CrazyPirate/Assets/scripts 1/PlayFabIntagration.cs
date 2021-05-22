using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;

public class PlayFabIntagration : MonoBehaviour
{
    
    
    public GameObject nameWindows;
    public GameObject mainWindows;
    public InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        Login();
       
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }

    };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }

    private void OnError(PlayFabError obj)
    {
        throw new NotImplementedException();
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Успешное создание аккаунта");
        string name = null;
        if(result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        if (name == null)
        {
            nameWindows.SetActive(true);
            
        }
        else
        {
            mainWindows.SetActive(true);
            
        }

    }

    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }
   
    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated name!");
        nameWindows.SetActive(false);
        mainWindows.SetActive(true);
    }
   
}
