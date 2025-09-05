using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{
    public float size = 1;

    public void OnValidate()
    {
        transform.localScale = Vector3.one * size;
    }
}
