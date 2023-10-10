using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        // -1�� ������ �ݴ�� ����.
        if(Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("Speed", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("Speed", -1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("AttackTrigger");
        }
   
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name+"�浹 ��.");
    }
}
