using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class weaponColliderEventSender : MonoBehaviour
{
    public enum Type
    {
        Mons,
        Player
    }

    public enum AttackState
    {
        Default,
        Skill1,
        Skill2,
        Skill3,
        Skill4
    }

    public Type CharacterType = Type.Player;

    public PlayerController playerRoot;
    public Mon_Bass monsterRoot;
    public AttackState attackState = AttackState.Default;

    public List<GameObject> HittedObjectList = new List<GameObject>();

    void Start()
    {
        switch (CharacterType)
        {
            case Type.Mons:
                monsterRoot = this.transform.root.transform.GetComponent<Mon_Bass>();
                break;
            case Type.Player:
                playerRoot = this.transform.root.transform.GetComponent<PlayerController>();
                break;
        }
    }

    void OnEnable()
    {
        if (HittedObjectList.Count > 0)
        {
            HittedObjectList.Clear();
        }
    }

    void OnDisable()
    {
        HittedObjectList.Clear();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!HittedObjectList.Contains(other.gameObject))
        {
            HittedObjectList.Add(other.gameObject);
        }
        else
        {
            return;
        }

        switch (CharacterType)
        {
            case Type.Mons:
                switch (attackState)
                {
                    case AttackState.Default:
                        monsterRoot.DefaulAttack_Collider(other.gameObject);
                        break;
                    case AttackState.Skill1:
                        monsterRoot.Skill_1Attack_Collider(other.gameObject);
                        break;
                    case AttackState.Skill2:
                        monsterRoot.Skill_2Attack_Collider(other.gameObject);
                        break;
                    case AttackState.Skill3:
                        monsterRoot.Skill_3Attack_Collider(other.gameObject);
                        break;
                    case AttackState.Skill4:
                        monsterRoot.Skill_4Attack_Collider(other.gameObject);
                        break;
                }
                break;

            case Type.Player:
                switch (attackState)
                {
                    case AttackState.Default:
                        playerRoot.DefaulAttack_Collider(other.gameObject);
                        break;
                    case AttackState.Skill2:
                        playerRoot.Skill_2Attack_Collider(other.gameObject);
                        break;
                }
                break;
        }
    }
}