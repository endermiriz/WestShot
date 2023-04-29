using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int PlayerHealth;
    public Healthbar healthbar;
    public MoneyManager moneyMan;
    public AudioClip coinSound;

    void Start()
    {
        PlayerHealth = 100;
        healthbar.SetMaxHealth(PlayerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTakeDamage(int damage)
    {
        PlayerHealth -= damage;
        healthbar.SetHealth(PlayerHealth);

        if (PlayerHealth <= 0) Invoke(nameof(DestroyPlayer), 0f);
    }

    public void PlayerTakeHeal(int heal)
    {
        if(PlayerHealth+heal <= 100)
        {
            PlayerHealth += heal;
            healthbar.SetHealth(PlayerHealth);
        }
        else
        {
            PlayerHealth = 100;
            healthbar.SetHealth(PlayerHealth);
        }

    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Healing")
        {   
            if(PlayerHealth < 100)
            {
                Destroy(collider.gameObject);
                PlayerTakeHeal(50);
            }
            
        }
        else if(collider.gameObject.tag == "Coin")
        {
            Debug.Log("Player taked Coin");
            moneyMan.SetMoney();
            AudioSource.PlayClipAtPoint(coinSound, collider.gameObject.transform.position);
            Destroy(collider.gameObject);
        }
    }
}
