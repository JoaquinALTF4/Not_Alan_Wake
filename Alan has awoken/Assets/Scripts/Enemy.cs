using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody enemyBody;
    public Collider enemyCollider;
    public float enemyHealth = 100;
    public float enemyDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        enemyBody = gameObject.GetComponent<Rigidbody>();
        enemyCollider = gameObject.GetComponent<Collider>();
    }
    public void takeDamage()
    {
          float Distance = Vector3.Distance(Flashlight.getFlashlightPosition(),transform.position);

        if(Distance < Flashlight.Instance.enemyDamageDistance)
        {
            enemyHealth -= enemyDamage * Time.deltaTime;
        }
        Flashlight.getFlashlightPosition();
    }
      

    // Update is called once per frame
    void Update()
    {
        
    }
}
