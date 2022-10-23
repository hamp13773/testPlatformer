using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFInisher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Hero>(out Hero hero))
        {
            Debug.Log("Level complete!");
        }
    }
}
