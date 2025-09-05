using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    public float size = 1;

    private void OnValidate()
    {
        transform.localScale = Vector3.one * size;
    }
}
