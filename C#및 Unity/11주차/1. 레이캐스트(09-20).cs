using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float maxDistance = 1;

    public bool isGround;
    public bool isJumpable;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (isJumpable)
        {
            rb.AddRelativeForce(transform.up * 10, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        RaycastHit hit;
        isGround = Physics.Raycast(transform.position, -transform.up, out hit, maxDistance, (1 << 7 | 1 << 6));
        Debug.DrawLine(transform.position, transform.position + (-transform.up * maxDistance), Color.red);
        isJumpable = isGround;

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        Debug.Log(hit.collider.name);

        if (Input.GetKey(KeyCode.V))
        {
            RaycastHit enemyHit;
            Debug.DrawLine(transform.position, transform.position + (-transform.up * maxDistance), Color.blue);
            if (Physics.Raycast(transform.position, transform.forward, out enemyHit, maxDistance))
            {
                if (enemyHit.collider.GetComponent<Monster>() != null)
                {
                    enemyHit.collider.gameObject.GetComponent<Monster>().Hp -= 10;
                }
            }
        }

    }
}
