using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AnimController : MonoBehaviour
{
    public PlayerController playerAnimation;

    void Start ()
    { 
        playerAnimation = this.transform.root.transform.GetComponent<PlayerController>();
    }

    public void Anim_AttackSkill_1_Enter()
    {
        playerAnimation.SkillAttack_Anim_1_Enter();
    }

    public void Anim_AttackSkill_2_Enter()
    {

        playerAnimation.SkillAttack_Anim_2_Enter();
    }

    public void Anim_AttackSkill_2_Exit()
    {
        playerAnimation.SkillAttack_Anim_2_Exit();
    }

    public void Anim_AttackSkill_3_Enter()
    {
        playerAnimation.SkillAttack_Anim_3_Enter();
    }

    public void Anim_Die_Enter()
    {
        playerAnimation.Anim_Die_Enter();
    }
}
