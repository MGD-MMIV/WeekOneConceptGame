using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    public float weaponDamage = 10.0f;
    public float weaponRange = 50.0f;
    public float fireRate = 20f;
    public float nextFire = 0.0f;
    public Camera fpsCamera;

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, weaponRange))
        {
            if (hit.transform.gameObject.tag == "Alien")
            {
                //apply damage
               
                hit.collider.GetComponent<AlienScript>().Health -= weaponDamage;
                Debug.Log(hit.collider.name);
            }

        }
    }

    public void FireShot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && Time.time >= nextFire)
        {
            nextFire = Time.time + 1.0f /fireRate;
            Shoot();
        }
    }
}
