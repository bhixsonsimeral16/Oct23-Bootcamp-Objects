using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCalculations : MonoBehaviour
{
    public float height;
    public float width;
    public float area;
    // Start is called before the first frame update
    void Start()
    {
        CalculateArea();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateArea()
    {
        area = height * width;
        Debug.Log("Area is " + area);
    }
}
