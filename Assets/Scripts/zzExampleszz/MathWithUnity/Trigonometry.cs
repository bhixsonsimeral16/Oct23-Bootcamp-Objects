using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigonometry : MonoBehaviour
{
    public Transform obj;
    public Vector2 startPosition;
    public float amplitude, frequency;

    public Vector2 elipseAmplitude, elipseFrequency;

    enum TrigFunction
    {
        Sine,
        Cosine,
        Tangent,
        Elipse
    }
    
    [SerializeField] TrigFunction trigFunction;
    // Start is called before the first frame update
    void Start()
    {
        trigFunction = TrigFunction.Sine;
    }

    // Update is called once per frame
    void Update()
    {
        switch (trigFunction)
        {
            case TrigFunction.Sine:
                Sine();
                break;
            case TrigFunction.Cosine:
                Cosine();
                break;
            case TrigFunction.Tangent:
                Tangent();
                break;
            case TrigFunction.Elipse:
                Elipse();
                break;
        }
    }

    void Sine()
    {
        float xPos = (startPosition.x + Time.timeSinceLevelLoad)%10;
        float yPos = startPosition.y + amplitude * Mathf.Sin(frequency * Time.timeSinceLevelLoad);

        obj.position = new Vector2(xPos, yPos);
    }

    void Cosine()
    {
        float xPos = (startPosition.x + Time.timeSinceLevelLoad)%10;
        float yPos = startPosition.y + amplitude * Mathf.Cos(frequency * Time.timeSinceLevelLoad);;

        obj.position = new Vector2(xPos, yPos);
    }

    void Tangent()
    {
        float xPos = (startPosition.x + Time.timeSinceLevelLoad)%10;
        float yPos = startPosition.y + amplitude * Mathf.Tan(frequency * Time.timeSinceLevelLoad);

        obj.position = new Vector2(xPos, yPos);
    }

    void Elipse()
    {
        float xPos = startPosition.x + elipseAmplitude.x * Mathf.Sin(elipseFrequency.x * Time.timeSinceLevelLoad);
        float yPos = startPosition.y + elipseAmplitude.y * Mathf.Cos(elipseFrequency.y * Time.timeSinceLevelLoad);

        obj.position = new Vector2(xPos, yPos);
    }
}
