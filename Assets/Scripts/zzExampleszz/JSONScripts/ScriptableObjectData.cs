using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectData : MonoBehaviour
{
    public ScriptableObjectSample sample;

    void Start()
    {
        if(sample == null) return;

        Debug.Log(sample.objectName);
        Debug.Log(sample.score);
        Debug.Log(sample.startPos);
    }
}
