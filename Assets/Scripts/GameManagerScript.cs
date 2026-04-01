using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public PickupSpawningScript HealthSpawner;
    [SerializeField] float HealthInterval;

    public PickupSpawningScript AlienSpawner;
    [SerializeField] float AlienInterval;
    [SerializeField] float AlienAmount = 1f;
    [SerializeField] private Image HealthBar;
    [SerializeField] public GameObject player;


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

        if ((int)Time.time % 3 == 0 && (int)Time.time != 0 && Ispaused == false)
        {
            player.GetComponent<PlayerScript>().PlayerHealth -= 10f;
            StartCoroutine("TempPause");
            HealthBar.fillAmount = player.GetComponent<PlayerScript>().PlayerHealth / 100;
        }
    }


    IEnumerator TempPause()
    {
        Ispaused = true;
        yield return new WaitForSeconds(1);
        Ispaused = false;
    }
}
