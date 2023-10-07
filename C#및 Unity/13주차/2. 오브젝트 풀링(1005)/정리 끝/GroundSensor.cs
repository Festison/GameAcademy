using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour 
{
    public PlayerController player;

    void Start()
    {
        player = this.transform.root.GetComponent<PlayerController>();       
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Block"))
        {
            if (other.CompareTag("Ground"))
            {
                player.Is_DownJump_GroundCheck = true;
            }
            else
            {
                player.Is_DownJump_GroundCheck = false;
            }
            // 바닥에 닿을시 현재 점프값을 0으로 만들어 준다.
            if (player.rigidbody.velocity.y <= 0)
            {
                player.IsGrounded = true;
                player.currentJumpCount = 0;
            }         
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        player.IsGrounded = false;
    }
}
