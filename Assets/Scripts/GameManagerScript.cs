using System.Collections;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public PickupSpawningScript HealthSpawner;


    [SerializeField] float HealthInterval = 5;
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
    }


    IEnumerator TempPause()
    {
        Ispaused = true;
        yield return new WaitForSeconds(1);
        Ispaused = false;
    }
}
