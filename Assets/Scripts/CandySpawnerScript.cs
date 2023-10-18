using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawnerScript : MonoBehaviour
{
    [SerializeField]
    float maxX;

    [SerializeField] float spawnInterval;

    public GameObject[] Candies;

    // Start is called before the first frame updat


    public static CandySpawnerScript instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //SpawnCandy(); 
        StartSpwaningCandies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCandy()
    {
        int rand = Random.Range(0, Candies.Length);

        float randomX = Random.Range(-maxX, maxX);

        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(Candies[rand], randomPos, transform.rotation);
    }


    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpwaningCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawningCandies(){
        StopCoroutine("SpawnCandies");
    }
}
