using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour
{
    public float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}