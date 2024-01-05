using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "User", menuName = "Login")]
public class LoginPageUI : ScriptableObject
{
    public string[] username;
    public string[] password;
    public string[] email;
}
