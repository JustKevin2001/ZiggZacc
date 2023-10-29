using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeColor : MonoBehaviour
{
    [SerializeField] Color[] backgroundColors;
    void Start()
    {
        StartCoroutine("ColorChange");
    }
    
    IEnumerator ColorChange()
    {
        while(true)
        {
            yield return new WaitForSeconds(10f);

            int randomColor = Random.Range(0, backgroundColors.Length);

            Camera.main.backgroundColor = backgroundColors[randomColor];

        }
    }
}
