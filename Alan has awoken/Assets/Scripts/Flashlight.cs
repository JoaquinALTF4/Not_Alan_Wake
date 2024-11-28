using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float enemyDamageDistance;
    public static Flashlight Instance;
    void Start()
    {
        Instance = this;
    }

    void OnTriggerStay(Collider aCollider)
    {
        Enemy aEnemy = aCollider.GetComponent<Enemy>();
        if(aEnemy != null)
        {
            aEnemy.takeDamage();
        }
    }
    public static Vector3 getFlashlightPosition()
    {
        return Instance.transform.position;
    }
}
