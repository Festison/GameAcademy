using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : PlayerController
{ 
    private void Start()
    {
        CapsulleCollider  = this.transform.GetComponent<CapsuleCollider2D>();
        Anime = this.transform.Find("model").GetComponent<Animator>();
        rigidbody = this.transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();

        if (rigidbody.velocity.magnitude > 30)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x - 0.1f, rigidbody.velocity.y - 0.1f);
        }
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Anime.Play("Demo_Skill_1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Anime.Play("Demo_Skill_2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Anime.Play("Demo_Skill_3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Anime.Play("Demo_Die");        
        }   

        if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Skill_2"))
        {
            if (IsRushState)
            {
                transform.transform.Translate(new Vector3(-transform.localScale.x * 25f * Time.deltaTime, 0, 0));
            }
            else
            {
                if (m_MoveX < 0)
                {
                    if (transform.localScale.x > 0)
                    {
                        transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));
                    }                      
                }
                else if (m_MoveX > 0)
                {
                    if (transform.localScale.x < 0)
                    {
                        transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));
                    }
                }
            }
        }

        if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Skill_1") 
            || Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Skill_2")
            || Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Skill_3"))
        {
          
            return;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Anime.Play("Demo_Guard");
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))  //아래 버튼 눌렀을때. 
        {
            IsSit = true;
            Anime.Play("Demo_Sit");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Anime.Play("Demo_Idle");
            IsSit = false;
        }

        // sit나 die일때 애니메이션이 돌때는 다른 애니메이션이 되지 않게 한다. 
        if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Sit") || Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Die"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentJumpCount < JumpCount)
                {
                    DownJump();
                }
            }
            return;
        }

        m_MoveX = Input.GetAxis("Horizontal");

        // 공격 상태가 아닐 때
        if (!Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Anime.Play("Demo_Attack");
            }
            else
            {
                if (m_MoveX == 0)
                {
                    if (!OnceJumpRayCheck)
                    {
                        Anime.Play("Demo_Idle");
                    }                     
                }
                else
                {
                    Anime.Play("Demo_Run");
                }
            }
        }

        // 우측 이동
        if (Input.GetKey(KeyCode.D))
        {
            if (IsGrounded)  // 땅바닥에 있었을때. 
            {
                if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Attack"))
                {
                    return;
                }

                transform.transform.Translate(Vector2.right* m_MoveX * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));
            }
            if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Attack"))
            {
                return;
            }
            if (!Input.GetKey(KeyCode.A))
            {
                Filp(false);
            }
        }

        // 좌측 이동
        else if (Input.GetKey(KeyCode.A))
        {
            if (IsGrounded)  // 땅바닥에 있었을때. 
            {
                if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Attack"))
                {
                    return;
                }

                transform.transform.Translate(Vector2.right * m_MoveX * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));
            }
            if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Attack"))
            {
                return;
            }
            if (!Input.GetKey(KeyCode.D))
            {
                Filp(true);
            }
        }

        // 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Attack"))
            {
                return;
            }
            if (currentJumpCount < JumpCount)
            {
                if (!IsSit)
                {
                    prefromJump();
                }
                else
                {
                    DownJump();
                }
            }
        }
    }
    
    // 달리지 않고 공격하지 않는 상태일시 가만히 있는 애니메이션 재생
    protected override void IdleState()
    {
        if (!Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Run") && !Anime.GetCurrentAnimatorStateInfo(0).IsName("Demo_Attack"))
        {
            Anime.Play("Demo_Idle");
        }
    }

    public override void DefaulAttack_Collider(GameObject obj) 
    {
        if (obj.CompareTag("Monster"))
        {
            Mon_Bass tmp_Player = obj.transform.root.GetComponent<Mon_Bass>();
            Vector2 dir = new Vector2(0, 0);
            tmp_Player.Damaged(10, dir, 0.1f);
        }
    }

    public override void Skill_2Attack_Collider(GameObject obj) 
    {
        if (obj.CompareTag("Monster"))
        {
            Mon_Bass tmp_Player = obj.transform.root.GetComponent<Mon_Bass>();
            Vector2 dir = new Vector2(0, 0);
            tmp_Player.Damaged(20, dir, 0.1f);
        }
    }

    [Space(10)]
    [Header("플레이어 기술")]
    public GameObject Skill1Prefab;
    public GameObject Skill2Prefab;
    public GameObject Skill3Prefab;

    // 에너지 드레인 기술
    public override void SkillAttack_Anim_1_Enter()
    {
        for (int i = 0; i < Demo_GM.Gm.MonsterList.Count; i++)
        {
            GameObject tmpobj = Instantiate(Skill1Prefab, Demo_GM.Gm.MonsterList[i].transform.position, Quaternion.identity);
            tmpobj.GetComponent<Skill_1>().Fire(5);
            Demo_GM.Gm.MonsterList[i].GetComponent<Mon_Bass>().Damaged(5, Vector2.zero, 0.1f);
        }
    }

    // 돌진 기술
    public override void SkillAttack_Anim_2_Enter()
    {
        IsRushState = true;
        GameObject rush = Instantiate(Skill2Prefab, transform.position, Quaternion.identity);
        rush.transform.localScale = new Vector3(-1*transform.localScale.x, 1, 1);
        rush.transform.SetParent(this.transform);
        rush.transform.localPosition= new Vector3(-1.37f, 0.179f, 1);
    }

    public override void SkillAttack_Anim_2_Exit()
    {   
        IsRushState = false;
    }

    // 오러 블레이드
    public override void SkillAttack_Anim_3_Enter()
    {   
        GameObject tmpobj = Instantiate(Skill3Prefab, transform.position, Quaternion.identity);
        Vector3 tmpDir = transform.localScale.x * this.transform.right;
        tmpobj.GetComponent<Skill_3>().Fire(tmpDir,20);
    }

    public override void Anim_Die_Enter()
    {
        Instantiate(BloodPrefab,this.transform.localPosition,Quaternion.identity);
    }
}
