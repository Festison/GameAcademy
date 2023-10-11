using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private int hp;
    public int Hp
    {
        get { return hp; }
        set { hp = value;

            if (hp <= 0)
                Destroy(gameObject);
        }
    }

    [SerializeField]
    private bool isParring;
    public bool IsParring
    {
        get { return isParring; }
        set
        {
            isParring = value;
            characterRenderer.material.color = isParring ? Color.blue : originCharColor;
        }
    }

    public GameObject attackZoneObj;
    private Renderer attackZoneRen;

    [SerializeField]
    private Renderer characterRenderer;
    private Color originColor;
    private Color originCharColor;

    public void Start()
    {
        attackZoneRen = attackZoneObj.GetComponent<Renderer>();
        originColor = attackZoneRen.material.color;
        originCharColor = characterRenderer.material.color;
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        AttackZone attackZone = other.GetComponent<AttackZone>();
        if (attackZone != null)
        {
            if(attackZone.monster.IsAttacking)
            {
                if(IsParring)
                {
                    Debug.Log("�̷��� ������ ���ƹ��Ƚ��ϴ�.");
                }
                else
                {
                    Hp -= 10;
                    
                }
            }
            attackZone.monster.IsAttacking = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            animator.SetTrigger("ParryTrigger");
        }
    }

    public void ParryStart()
    {
        IsParring = true;
    }
    public void ParryEnd()
    {
        IsParring = false;
    }
    public void AttackStart(int num)
    {
        Debug.Log(num+"���ý����ߴ�");
        attackZoneRen.material.color = Color.red;
    }

    public void AttackEnd()
    {
        Debug.Log("���ó�����");
        attackZoneRen.material.color = originColor;
    }

    public void SoundTest()
    {
        Debug.Log("�ǰ��ǰ�");
    }
}
