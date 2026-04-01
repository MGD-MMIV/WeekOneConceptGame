using System.Collections;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public PickupSpawningScript HealthSpawner;
    [SerializeField] float HealthInterval;

    public PickupSpawningScript AlienSpawner;
    [SerializeField] float AlienInterval;
    [SerializeField] float AlienAmount = 1f;



    private bool Ispaused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        if ((int)Time.time % HealthInterval == 0 && (int)Time.time != 0 && Ispaused == false)
        {
            HealthSpawner.SpawnObject();
            //Debug.Log("Spawn");
            StartCoroutine("TempPause");
        }
        if ((int)Time.time % AlienInterval == 0 && (int)Time.time != 0 && Ispaused == false)
        {
            for(int i = 0; i < AlienAmount; i++)
            AlienSpawner.SpawnObject();
            //Debug.Log("Spawn");
            StartCoroutine("TempPause");
            AlienAmount += 1;
        }
    }


    IEnumerator TempPause()
    {
        Ispaused = true;
        yield return new WaitForSeconds(1);
        Ispaused = false;
    }
}
