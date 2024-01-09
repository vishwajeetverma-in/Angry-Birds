using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // if enemy has collided with enemy or bird or any other thing
    private void OnCollisionEnter2D(Collision2D collision)
    {
         // if the other object is having a BIRD component then destroy the enemy
       Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Destroy(gameObject);
            return;   // becauses once enemy is destroyed no need to check anything because anyway enemy.cs will be destroyed also
        }

        // if hit is with ENEMY dont do anything just dont do anything
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        // other than bird and enemy means crushed by crate

       if (collision.contacts[0].normal.y < -0.5    // contacts is an array with which script is colliding, zero means first contact jiske sath hua hai
                                                    // normal meaning upar se hit hua h ya side se meaning direction of hit
)
        {
            Destroy(gameObject );
        }
    }
}
