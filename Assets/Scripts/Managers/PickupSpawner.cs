using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] PickupSpawn[] pickups;
    
    [Range(0,1)]
    [SerializeField] float pickupProbability; 

    List<Pickup> pickupPool = new List<Pickup>();
    Pickup pickupToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        foreach (PickupSpawn pickup in pickups)
        {
            for (int i = 0; i < pickup.spawnWeight; i++)
            {
                pickupPool.Add(pickup.pickup);
            }
        }
    }

    public void SpawnPickup(Vector2 position)
    {
        if (pickupPool.Count == 0)
        {
            return;
        }

        if (Random.Range(0f, 1f) < pickupProbability)
        {
            pickupToSpawn = pickupPool[Random.Range(0, pickupPool.Count)];
            Instantiate(pickupToSpawn, position, Quaternion.identity);
        }
    } 
}

[System.Serializable]
public struct PickupSpawn
{
    public Pickup pickup;
    public int spawnWeight;
}
