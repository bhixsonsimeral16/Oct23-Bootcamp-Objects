using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorsAndScalars : MonoBehaviour
{
    public Vector2 position;
    public Vector3 rotationVector;
    public float rotation;
    public float scalar;
    public Transform obj;
    // Start is called before the first frame update
    void Start()
    {
        //obj.position = position;

        //obj.position = scalar * position;
    }

    // Update is called once per frame
    void Update()
    {
        obj.rotation = Quaternion.Euler(rotationVector);
    }
}
