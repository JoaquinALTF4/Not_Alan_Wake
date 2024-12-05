using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] ParticleSystem chokingDarknessVFX = null;

    public float enemyDamageDistance;
    public static Flashlight Instance;
    void Start()
    {
        //     chokingDarknessVFX = gameObject.getComponentInChildren<Enemy>(1);
        Instance = this;
    }

    void OnTriggerStay(Collider aCollider)
    {
        Enemy aEnemy = aCollider.GetComponent<Enemy>();
        if (aEnemy != null)
        {
            aEnemy.takeDamage();
            ChokeDarkness();


        }

    }
    public static Vector3 getFlashlightPosition()
    {
        return Instance.transform.position;
    }
    public void ChokeDarkness()
    {


        if (Flashlight.Instance != null)
        {
            chokingDarknessVFX.Play();
        }


        else
        {
            chokingDarknessVFX.Stop();
        }
    }
}
