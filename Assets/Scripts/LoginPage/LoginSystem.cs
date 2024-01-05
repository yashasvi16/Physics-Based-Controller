using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LoginSystem : MonoBehaviour
{
    public GameObject loginPanel, registerPanel, invalidPanel;
    public TMP_InputField usernameInput, passwordInput, usernameRegister, passwordRegister, emailRegister;
    public LoginPageUI UserLoginObj;

    private int countUsers = 1;
    // Start is called before the first frame update
    void Start()
    {
        LoginPanel();
    }

    public void LoginPanel()
    {
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);
        invalidPanel.SetActive(false);
    }

    public void RegisterPanel()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
        invalidPanel.SetActive(false);
    }
    public void InvalidPanel()
    {
        invalidPanel.SetActive(true);
    }
    public void OnLogin()
    {
        if(string.IsNullOrEmpty(usernameInput.text) || string.IsNullOrEmpty(passwordInput.text)) 
        {
            InvalidPanel();
        }

        for(int i = 0; i <= countUsers; i++)
        {
            if ((UserLoginObj.username[i] == usernameInput.text) && (UserLoginObj.password[i] == passwordInput.text))
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if(i == countUsers - 1)
            {
                InvalidPanel();
            }
        }
           
    }

    public void OnRegister()
    {
        //LoginPageUI asset = ScriptableObject.CreateInstance<LoginPageUI>();

        //AssetDatabase.CreateAsset(asset, "Assets/Scripts/LoginPage/Users/User1.asset");

        UserLoginObj.username[countUsers] = usernameRegister.text;
        UserLoginObj.password[countUsers] = passwordRegister.text;
        UserLoginObj.email[countUsers] = emailRegister.text;

        countUsers++;

        //AssetDatabase.SaveAssets();

        //EditorUtility.FocusProjectWindow();

        //Selection.activeObject = asset;

        LoginPanel();
    }

}
