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

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

}
