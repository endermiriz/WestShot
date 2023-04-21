using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //public int EnemyHealth = EnemyPage.health;
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }



    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAiTutorial>().TakeDamage(10);
            //if(EnemyHealths == 100)
            //{
            //    Destroy(collision.gameObject);
            //}
            
            Destroy(gameObject);
            
        }



    }
}
