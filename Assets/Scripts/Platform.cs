using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Attributes
    private Rigidbody rb;

    [Header("Collectable Items")]
    [SerializeField] GameObject diamond;
    [SerializeField] GameObject biggerDiamond;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SpawnDiamonds();
    }

    
    private void SpawnDiamonds()
    {
        int randDiamond = Random.Range(0, 20); // return 0 -> 4

        Vector3 diamondPos = transform.position;
        diamondPos.y += 1f;

        if (randDiamond < 5)
        {
            // Spawn diamonds
            GameObject newDiamond = Instantiate(diamond, diamondPos, diamond.transform.rotation);
            newDiamond.transform.SetParent(gameObject.transform);
        }
        else if (randDiamond == 19) 
        {
            GameObject newDiamond = Instantiate(biggerDiamond, diamondPos, diamond.transform.rotation);
            newDiamond.transform.SetParent(gameObject.transform);
        }
    }
    


    // Call whenever 2 things exit from colliding
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", 0.2f);
        }
    }

    private void Fall()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 1f);
    }
}

// Whenever the car fall => The platform fall down
