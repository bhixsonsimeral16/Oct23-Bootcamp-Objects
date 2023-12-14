using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveToFile : MonoBehaviour
{
    JSONObject[] testObjects;
    string path;
    // Start is called before the first frame update
    void Start()
    {
        testObjects = new JSONObject[3];
        testObjects[0] = new JSONObject(69420, "Suzan", 98.52f, new int[]{1,3,5,9});
        testObjects[1] = new JSONObject(12348, "Brad", 92.2f, new int[]{1,5,7,9});
        testObjects[2] = new JSONObject(45714, "Lo'Pune", 52.124f, new int[]{2,3,5,7,9});

        path = Application.dataPath + "/JSONfolder/test.json";

        Debug.Log(path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        string data = JsonUtility.ToJson(testObjects[0]);
        System.IO.File.WriteAllText(path, data);
        Debug.Log("Saved");
    }
}
