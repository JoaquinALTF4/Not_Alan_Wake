using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody enemyBody;
    public Collider enemyCollider;
    public float enemyHealth = 80;
    public float minenemyHealth = 0;
    public float shieldHealth = 100;
    public float shieldDamage = 20;
    public float minShieldHealth = 0;
    public float enemyDamage = 10;
    public Transform target;
    public float maxenemySpeed = 1.0f;
    public float minenemySpeed = 0.5f;
    public float avgEnemySpeed = 0.7f;
    private float enemySpeed = 1.0f;
    public GameObject Shield;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyBody = gameObject.GetComponent<Rigidbody>();
        enemyCollider = gameObject.GetComponent<Collider>();
        enemySpeed = maxenemySpeed;
        shieldHealth = gameObject.GetComponentInChildren<Enemy>().getShieldHealth();
    }
    public void takeDamage()
    {
          float Distance = Vector3.Distance(Flashlight.getFlashlightPosition(),transform.position);

        if(Distance < Flashlight.Instance.enemyDamageDistance)
        {
            shieldHealth -= shieldDamage * Time.deltaTime;
            if(shieldHealth <= minShieldHealth)
            {
                Destroy(Shield);
            }
      
            {
                
            }
        }
        Flashlight.getFlashlightPosition();
    }
    public void enemytakeDamage(float gunDamage)
    {
        
        enemyHealth -= enemyDamage * 2;
        if(enemyHealth <= minenemyHealth)
        {
            Die();
        }
        Debug.Log("enemyHealth" + enemyHealth);
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
            enemySpeed = avgEnemySpeed;
        }


    }
    void OnTriggerExit(Collider aCollider)
    {
        if(aCollider.CompareTag("Flashlight"))
        {
            enemySpeed = maxenemySpeed;
        }
    }
    float getShieldHealth()
    {
        return shieldHealth;
    }
    void Die()
    {
        Destroy(gameObject);
    }
    
}
