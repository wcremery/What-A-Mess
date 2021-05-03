using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private float movementSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput < -.5f && !CheckForCollision(Vector3.left))
        {
            transform.position += Vector3.left * (movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0,0,180);
        }

        else if (horizontalInput > .5f && !CheckForCollision(Vector3.right))
        {
            transform.position += Vector3.right * (movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0,0,0);
        }

        if (verticalInput < -.5f && !CheckForCollision(Vector3.down))
        {
            transform.position += Vector3.down * (movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0,0,270);
        }

        else if (verticalInput > .5f && !CheckForCollision(Vector3.up))
        {
            transform.position += Vector3.up * (movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0,0,90);
        }
    }

    private bool CheckForCollision(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direction.x, direction.y), 1.5f);

        if (hit.collider != null)
        {
            Debug.Log("Hit " + hit.collider.gameObject.name);
            return true;
        }

        return false;
    }
}