using System.Collections;          // list of objects
using System.Collections.Generic; // list of birds(class name)
using UnityEngine;

public class Bird : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        
    }

    private void OnMouseUp()
    {
        GetComponent <SpriteRenderer>().color = Color.green;
    }
}
