using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int PlayerHealth;
    public Healthbar healthbar;

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
        PlayerHealth += heal;
        healthbar.SetHealth(PlayerHealth);
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
                PlayerTakeHeal(100);
            }
            
        }   
    }
}
