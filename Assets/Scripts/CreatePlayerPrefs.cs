using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerPrefs : MonoBehaviour
{
    public string key;
    public string value;

    void SaveIfNullPlayerPrefs(){
        if (!PlayerPrefs.HasKey(key)) {
            PlayerPrefs.SetString(key, value);
        }
    }
}
