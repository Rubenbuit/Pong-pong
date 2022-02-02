using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public Material[] material;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        int colorIndex = Random.Range(0, material.Length +1);  
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        
        rend.sharedMaterial = material[colorIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
