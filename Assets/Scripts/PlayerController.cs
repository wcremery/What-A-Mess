using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private float _movementSpeed = 5f;
    private string _playerCollideWith = "";

    public string PlayerCollideWith => _playerCollideWith;

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        if (_horizontalInput < -.5f && !CheckForCollision(Vector3.left))
        {
            transform.position += Vector3.left * (_movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        else if (_horizontalInput > .5f && !CheckForCollision(Vector3.right))
        {
            transform.position += Vector3.right * (_movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (_verticalInput < -.5f && !CheckForCollision(Vector3.down))
        {
            transform.position += Vector3.down * (_movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }

        else if (_verticalInput > .5f && !CheckForCollision(Vector3.up))
        {
            transform.position += Vector3.up * (_movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    private bool CheckForCollision(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direction.x, direction.y), 2f);

        if (hit.collider != null)
        {
            _playerCollideWith = hit.collider.gameObject.tag;
            Debug.Log("Hit " + _playerCollideWith);
            return true;
        }

        _playerCollideWith = "none";
        return false;
    }
}