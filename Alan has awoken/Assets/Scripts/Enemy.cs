using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody enemyBody;
    public Collider enemyCollider;
    public float enemyHealth = 100;
    public float enemyDamage = 10;
    public Transform target;
    public float maxenemySpeed = 1.0f;
    public float minenemySpeed = 0.5f;
    private float enemySpeed = 1.0f;
    public GameObject Shield;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyBody = gameObject.GetComponent<Rigidbody>();
        enemyCollider = gameObject.GetComponent<Collider>();
        enemySpeed = maxenemySpeed;
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
        FollowPlayer();
    }
    void FollowPlayer()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);

        
    }
    void OnTriggerEnter(Collider aCollider)
    {
        if(aCollider.CompareTag("Flashlight"))
        {
            enemySpeed = minenemySpeed;
        }


    }
    void OnTriggerExit(Collider aCollider)
    {
        if(aCollider.CompareTag("Flashlight"))
        {
            enemySpeed = maxenemySpeed;
        }
    }
}
