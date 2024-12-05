using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    

    
    public float range = 100f;
    public float gunDamage = 10f;
    public ParticleSystem muzzleFlash;
    public ParticleSystem impactEffect;
    public AudioClip gunSound;
    public AudioSource source;
    public GameObject AudioClip;
    public void Start()
    {
        AudioClip.SetActive(false);
    }




    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            fireGun();
            AudioClip.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(gunSound);
            //I was trying to create the audio replaying every time you shot the gun

        }
    }
    void fireGun()
    {
        muzzleFlash.Play();
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            //Debug.Log("Hit something");


            // Debug.Log(hit.transform.name);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Enemy darkness = hit.transform.GetComponent<Enemy>();

            if (darkness != null)

            {

                darkness.enemytakeDamage(gunDamage);
            }
            else {
            

            }
        }

          
       
    }
}
