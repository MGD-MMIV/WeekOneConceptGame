using UnityEngine;

public class PickupSpawningScript : MonoBehaviour
{
    public Transform[] SpawnPos;
    public GameObject PickupObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        Instantiate(PickupObject, SpawnPos[Random.Range(0,SpawnPos.Length)].position, Quaternion.identity);
    }
}
