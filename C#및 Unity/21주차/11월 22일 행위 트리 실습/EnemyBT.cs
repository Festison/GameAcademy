using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BT
{
    public interface INode
    {
        public enum STATE
        {
            RUN, SUCCESS, FAIL
        }

        public STATE Evaluate();
    }

    public class ActionNode : INode
    {
        public Func<INode.STATE> actionNode;

        public ActionNode(Func<INode.STATE> action)
        {
            this.actionNode = action;
        }

        public INode.STATE Evaluate()
        {
            if (actionNode==null)
            {
                return INode.STATE.FAIL;
            }
            else
            {
                return actionNode();
            }
        }

    }

    public class SelectorNode : INode
    {
        List<INode> childs;

        public SelectorNode()
        {
            childs = new List<INode>();
        }

        public void Add(INode node)
        {
            childs.Add(node);
        }

        public INode.STATE Evaluate()
        {
            if (childs.Count <= 0)
                return INode.STATE.FAIL;

            foreach (INode childNode in childs)
            {
                switch (childNode.Evaluate())
                {
                    case INode.STATE.SUCCESS:
                        return INode.STATE.SUCCESS;
                    case INode.STATE.RUN:
                        return INode.STATE.RUN;
                }               
            }
            return INode.STATE.FAIL;
        }
    }

    public class SequenceNode : INode
    {
        List<INode> childs;

        public SequenceNode()
        {
            childs = new List<INode>();
        }

        public void Add(INode node)
        {
            childs.Add(node);
        }

        public INode.STATE Evaluate()
        {
            if (childs.Count <= 0)
                return INode.STATE.FAIL;

            foreach (INode childNode in childs)
            {
                switch (childNode.Evaluate())
                {
                    case INode.STATE.SUCCESS:
                        continue;
                    case INode.STATE.RUN:
                        return INode.STATE.RUN;
                    case INode.STATE.FAIL:
                        return INode.STATE.FAIL;
                }
            }
            return INode.STATE.SUCCESS;
        }
    }

    public class EnemyBT : MonoBehaviour
    {
        [Header("������ ���")]
        SelectorNode rootNode;                       // ��Ʈ ���
        SelectorNode attackSortSelector;             // ���� ��� ������
        SelectorNode targetSettingSelector;          // Ÿ�� ���� ������

        [Header("������ ���")]
        SequenceNode attackSequence;                 // ���� ������
        SequenceNode detectiveSequence;              // Ž�� ������

        [Header("�׼� ���")]
        ActionNode returnAction;                     // ��ȯ �׼�
        ActionNode idleAction;                       // ��� �׼�

        Transform target = null;
        Vector3 originPos;       

        void Start()
        {
            originPos = transform.position;
            SetBT();
        }

        public void SetBT()
        {
            // ��Ʈ ��� : ���� �ൿ ��� ������
            rootNode = new SelectorNode();                     

            // ���� ������
            attackSequence = new SequenceNode();                                    // ���� ������ ����
            rootNode.Add(attackSequence);                                           // ���� �������� ��Ʈ��忡 �߰�

            // Ž�� ������
            detectiveSequence = new SequenceNode();                                 // Ž�� ������ ����
            rootNode.Add(detectiveSequence);                                        // Ž�� �������� ��Ʈ ��忡 �߰�

            // ��ȯ �׼�
            returnAction = new ActionNode(ReturnAction);                            // ��ȯ �׼��� ����
            rootNode.Add(returnAction);                                             // ��ȯ �׼��� ��Ʈ ��忡 �߰�

            // ��� �׼�
            idleAction = new ActionNode(IdleAction);                                // ��� �׼��� ����
            rootNode.Add(idleAction);                                               // ��� �׼��� ��Ʈ ��忡 �߰�

            attackSequence.Add(new ActionNode(AttackRangeCheckAction));             // ���ݹ��� üũ �׼��� ���� �� ���� �������� �߰�
                                                                                    // 
            attackSortSelector = new SelectorNode();                                // ���� ��� ������ ����
            attackSequence.Add(attackSortSelector);                                 // ���� ��� �����͸� ���� �������� �߰�

            detectiveSequence.Add(new ActionNode(DetectiveRangeCheckAction));       // Ž�� ���� üũ �׼��� Ž�� �������� �߰�

            targetSettingSelector = new SelectorNode();                             // Ÿ�� ���� ������ ����
            detectiveSequence.Add(targetSettingSelector);                           // Ÿ�� ���� �����͸� Ž�� �������� �߰�

            detectiveSequence.Add(new ActionNode(TraceAction));                     // ���� �׼��� Ž�� �������� �߰�

            // ���� ��� ������
            attackSortSelector.Add(new ActionNode(SkillAttackAction));              // ��ų �����ϱ� �׼��� ���� �����Ϳ��߰�
            attackSortSelector.Add(new ActionNode(DefaultAttackAction));            // �⺻ �����ϱ� �׼��� ���� �����Ϳ� �߰�
                             
            // Ÿ�� ���� ������      
            targetSettingSelector.Add(new ActionNode(LongEnemyTargetAction));       // ���Ÿ��� Ÿ�� �׼��� Ÿ�� ���� �����Ϳ� �߰�
            targetSettingSelector.Add(new ActionNode(CloseEnemyTargetAciton));      // �ٰŸ��� Ÿ�� �׼��� Ÿ�� ���� �����Ϳ� �߰�                 
        }

        #region �׼� ��忡 �� �Լ�

        INode.STATE SkillAttackAction()
        {
            Debug.Log("��ų ���� ��");
            return INode.STATE.RUN;
        }

        INode.STATE DefaultAttackAction()
        {
            Debug.Log("�⺻ ���� ��");
            return INode.STATE.RUN;
        }

        INode.STATE LongEnemyTargetAction()
        {
            Debug.Log("���Ÿ� �� Ÿ�� ��");
            return INode.STATE.RUN;
        }

        INode.STATE CloseEnemyTargetAciton()
        {
            Debug.Log("�ٰŸ� �� Ÿ�� ��");
            return INode.STATE.RUN;
        }

        public int attackableRange;
        INode.STATE AttackRangeCheckAction()
        {
            if (target == null)
                return INode.STATE.FAIL;

            if (Vector3.Distance(transform.position, target.position) < attackableRange)
            {
                Debug.Log("���� ���� ���� ��");
                return INode.STATE.SUCCESS;
            }

            return INode.STATE.FAIL;
        }    

        public int defectiveRange;
        INode.STATE DetectiveRangeCheckAction()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, defectiveRange, LayerMask.GetMask("Player"));
            if (cols.Length > 0)
            {
                Debug.Log("Ž�� ��");
                target = cols[0].transform;
                return INode.STATE.SUCCESS;
            }
            return INode.STATE.FAIL;
        }

        INode.STATE TraceAction()
        {
            if (Vector3.Distance(transform.position, target.position) >= 0.1f)
            {
                Debug.Log("���� ��");
                transform.forward = (target.position - transform.position).normalized;
                transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
                return INode.STATE.RUN;
            }
            else
                return INode.STATE.FAIL;
        }

        INode.STATE ReturnAction()
        {
            if (Vector3.Distance(transform.position, originPos) >= 0.1f)
            {
                Debug.Log("��ȯ ��");
                transform.forward = (originPos - transform.position).normalized;
                transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
                return INode.STATE.RUN;
            }
            else
                return INode.STATE.FAIL;
        }

        INode.STATE IdleAction()
        {
            Debug.Log("��� ��");
            return INode.STATE.RUN;
        }
        #endregion

        void Update()
        {
            rootNode.Evaluate();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, defectiveRange);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackableRange);
        }
    }
}

