using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPrefsExample : MonoBehaviour
{
    [SerializeField] TMP_InputField input;
    [SerializeField] TMP_Text txtDisplay;

    const string SAVED_DATA = "Saved_Data";
    public void SaveData()
    {
        PlayerPrefs.SetString(SAVED_DATA, input.text);
    }

    public void LoadData()
    {
        if(PlayerPrefs.HasKey(SAVED_DATA))
        {
            txtDisplay.SetText(PlayerPrefs.GetString(SAVED_DATA));
        }
        else
        {
            Debug.Log("No data saved");
        }
    }

    public void DeleteData()
    {
        if(PlayerPrefs.HasKey(SAVED_DATA))
        {
            PlayerPrefs.DeleteKey(SAVED_DATA);
        }
        else
        {
            Debug.Log("No data saved");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(SAVED_DATA) && PlayerPrefs.GetString(SAVED_DATA) != "")
        {
            txtDisplay.SetText(PlayerPrefs.GetString(SAVED_DATA));
        }
        else
        {
            txtDisplay.SetText("Sample Display");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
