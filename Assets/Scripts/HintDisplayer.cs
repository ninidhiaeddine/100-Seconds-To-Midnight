using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintDisplayer : MonoBehaviour
{
    public float timeBetweenHints = 10.0f;
    public GameObject[] hints;

    void Start()
    {
        StartCoroutine(DisplayHints());
    }

    private IEnumerator DisplayHints()
    {
        while(true)
        {
            for (int i = 0; i < hints.Length; i++)
            {
                hints[i].SetActive(true);                
                yield return new WaitForSeconds(timeBetweenHints);
                hints[i].SetActive(false);
            }
        }
    }
}
