using UnityEngine;

public class AlienScript : MonoBehaviour
{

    public Transform player;
    public float Health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, 3f * Time.deltaTime);
        transform.LookAt(player.position);

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
