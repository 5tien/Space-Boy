using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private GameObject path;
    void Start()
    {
        foreach (Transform child in path.transform)
        {
            print(child);
        }
    }
}
