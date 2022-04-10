using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true; 

    public GameObject sheepPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>(); 
    public float timeBetweenSpawns; 

    private List<GameObject> sheepList = new List<GameObject>(); 

   
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }


    void Update()
    {
        
    }
    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position; // 1
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation); // 2
        sheepList.Add(sheep); 
        sheep.GetComponent<Sheep>().SetSpawner(this); 
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }


    private IEnumerator SpawnRoutine() 
    {
        while (canSpawn) 
        {
            SpawnSheep(); 
            yield return new WaitForSeconds(timeBetweenSpawns); 
        }
    }

    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList) 
        {
            Destroy(sheep); 
        }

        sheepList.Clear();
    }


}
