using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCalculations : MonoBehaviour
{
    public float height;
    public float width;
    public float area;

    public static int randNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        CalculateRandomNumber();
        CalculateArea();
    }

    public static void CalculateRandomNumber()
    {
        randNum++;
        Debug.Log($"Random number is {randNum}");
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
