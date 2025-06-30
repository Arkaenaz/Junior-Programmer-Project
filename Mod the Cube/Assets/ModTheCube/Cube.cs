using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float ticks = 0.0f;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        Material material = Renderer.material;
        ticks += Time.deltaTime;

        material.color = new Color(0.5f, Mathf.Sin(ticks), 0.3f, 0.4f);
        transform.localScale = Vector3.one * (1.0f + 0.3f * Mathf.Sin(ticks * 2.0f));
    }
}
