using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private bool isAttacking;
    public bool IsAttacking
    {
        get { return isAttacking; }
        set { 
            
            isAttacking = value;

            attackZoneRen.material.color = isAttacking ? Color.red : originColor;
            /*if (isAttacking)
                attackZoneRen.material.color = Color.red;
            else
                attackZoneRen.material.color = originColor;*/

        }
    }

    public GameObject attackZoneObj;
    private Renderer attackZoneRen;
    private Color originColor;

    public void Start()
    {
        attackZoneRen = attackZoneObj.GetComponent<Renderer>();
        originColor = attackZoneRen.material.color;
    }

    public void AttackStart(int num)
    {
        IsAttacking = true;
    }

    public void AttackEnd()
    {
        IsAttacking = false;
    }
}
