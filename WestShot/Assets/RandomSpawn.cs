using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] objects;                // The prefab to be spawned.
    public float spawnTime = 6f;            // How long between each spawn.
    private Vector3 spawnPosition;
    public Transform userPlayer;

    // Use this for initialization
    void Start()
    {
        userPlayer = GameObject.Find("PlayerObj").transform;
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);



    }

    void Spawn()
    {
        spawnPosition.x = Random.Range(-50, 20);
        spawnPosition.y = 0.5f;
        spawnPosition.z = Random.Range(-35, 40);
        NavMeshHit hit;
        NavMesh.SamplePosition(spawnPosition, out hit, Mathf.Infinity, NavMesh.AllAreas);
        Vector3 myRandomPositionInsideNavMesh = hit.position;
        

        if (userPlayer != null)
        {
            Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)], myRandomPositionInsideNavMesh, Quaternion.identity);
        }

    }


}
