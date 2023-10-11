using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator = null;

    [Header("상태 체크")]
    public bool isRun;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        PlayerInput();
    }

    public void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isRun)
        {
            isRun = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && isRun)
        {
            isRun = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("WalkTrigger");
            animator.SetFloat("WalkState", 0.5f);
        }
        else if (Input.GetKey(KeyCode.W) && isRun)
        {
            animator.SetTrigger("WalkTrigger");
            animator.SetFloat("WalkState", 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("JumpTrigger");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("AttackTrigger");
        }
    }

    public void AttackStart()
    {
        Debug.Log("공격 시작");
    }

    public void WalkStart()
    {
        Debug.Log("걷기 시작");
    }

    public void RunStart()
    {
        Debug.Log("달리기 시작");
    }


}
