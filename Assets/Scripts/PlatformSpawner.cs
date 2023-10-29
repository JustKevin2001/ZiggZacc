using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Attributes
    [SerializeField] GameObject platformPrefab;

    // Reference to last platform
    [SerializeField] Transform lastPlatform;
    private Vector3 lastPosition;

    private Vector3 newPos;

    private bool stop;

    [SerializeField] GameObject platformSpawner;

    void Start()
    {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());
    }

    IEnumerator SpawnPlatforms() 
    {

        while (!stop)
        {
            GeneratePosition();
        
            // Sau khi generate thi newPos se tro thanh lastPos; 
            GameObject newCube = Instantiate(platformPrefab, newPos, Quaternion.identity);

            lastPosition = newPos;

            newCube.transform.SetParent(platformSpawner.transform, false);

            // each time wait 0.1 second then execute those code
            yield return new WaitForSeconds(0.1f);  
        }

    }
    private void GeneratePosition()
    {   
        newPos = lastPosition;
        int rd = Random.Range(0, 2);

        if(rd > 0 )
        {
            newPos.x += 2;
        }
        else
        {
            newPos.z += 2;
        }
    }
}


/*
 * Code flow: 
 * 1. Get the position of the last platform
 * 2. Generate the position of the new Platform
 * 3. Spawn the platform at that point
 * 4. Use Coroutine to spawn the platform automatically
 */