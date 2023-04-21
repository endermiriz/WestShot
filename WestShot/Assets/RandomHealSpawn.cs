using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHealSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] objects;                // The prefab to be spawned.
    public float spawnTime = 6f;            // How long between each spawn.
    private Vector3 spawnPosition;
    public Transform userPlayer;
    public PlayerSetting playerSetting;


    // Use this for initialization
    void Start()
    {

        userPlayer = GameObject.Find("PlayerObj").transform;
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        




    }

    void Spawn()
    {
        if(userPlayer != null)
        {
            spawnPosition.x = Random.Range(userPlayer.position.x - 17, userPlayer.position.x + 17);
            spawnPosition.y = 0.5f;
            spawnPosition.z = Random.Range(userPlayer.position.z - 17, userPlayer.position.x + 17);

            if (playerSetting.PlayerHealth < 80 && GameObject.FindGameObjectsWithTag("Healing").Length < 3)
            {
                Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)], spawnPosition, Quaternion.identity);
            }
        }

    }

}
