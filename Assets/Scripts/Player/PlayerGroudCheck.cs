using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroudCheck : MonoBehaviour
{
    [SerializeField]
    protected float groundCheckDistance;
    [SerializeField]
    // Collider
    Collider2D col;
    public bool isGrounded = true;
    [SerializeField]
    protected SpriteRenderer player;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        // Set hit as a RaycastHit2D variable
        RaycastHit2D hit;
        // Hit determines is the downward raycast is touching any other object 
        hit = Physics2D.Raycast(transform.position - new Vector3(0, player.bounds.extents.y + 0.01f, 0), Vector2.down, 0.1f);
    
        if (hit) // If Hit is touching another object we set the isGrounded bool to true
        {
            Debug.Log("we are on the Ground");
            isGrounded = true;
        }
        else // If Hit is not touching another object we set the isGrounded bool to false
        {
            Debug.Log("We are not on the Ground");
            isGrounded = false;
        }
    }    
}
