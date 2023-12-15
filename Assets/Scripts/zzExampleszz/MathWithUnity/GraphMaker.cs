using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphMaker : MonoBehaviour
{
    [SerializeField] GameObject graphMarkerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        MakeGraph();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeGraph()
    {
        for (int i = -10; i < 10; i++)
        {
            GameObject graphMarker1 = Instantiate(graphMarkerPrefab, new Vector3(i, 0, 0), Quaternion.identity);
            graphMarker1.gameObject.transform.SetParent(this.gameObject.transform);
            if (i != 0)
            {
                GameObject graphMarker2 = Instantiate(graphMarkerPrefab, new Vector3(0, i, 0), Quaternion.identity);
                graphMarker2.gameObject.transform.SetParent(this.gameObject.transform);
            }
        }
    }
}
