using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material material;
    private Color color = new Color(0, 0, 0, 0.4f);
    
    void Start()
    {
        transform.position = new Vector3(Random.Range(2, 4), Random.Range(3, 5), Random.Range(0, 1));
        transform.localScale = Vector3.one * Random.Range(1f, 5f);
        
        material = Renderer.material;
    }
    
    void Update()
    {
        transform.Rotate(Random.Range(8f, 12f) * Time.deltaTime, Random.Range(0f, 2f) * Time.deltaTime, Random.Range(0f, 1f) * Time.deltaTime);
        color = new Color(color.r + Random.Range(-0.01f, 0.01f), color.g + Random.Range(-0.01f, 0.01f), color.b + Random.Range(-0.01f, 0.01f), color.a);
        material.color = color;
    }
}
