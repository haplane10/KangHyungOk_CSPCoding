using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    public GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var obj in gameObjects)
        {
            DontDestroyOnLoad(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
