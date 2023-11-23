using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

namespace EnemyBT
{
    public interface INode
    {
        public enum STATE
        {
            RUN,
            SUCCESS,
            FAIL
        }

        public INode.STATE Evaluate();
    }

    //ActionNode�� �׻� �ܸ��� ��ġ�ؾ�������, �ڽ��� �־ �ȵ�.
    public class ActionNode : INode
    {
        public Func<INode.STATE> action;

        public ActionNode(Func<INode.STATE> action)
        {
            this.action = action;
        }

        public INode.STATE Evaluate()
        {
            if (action == null)
                return INode.STATE.FAIL;
            else
                return action();

        }
    }


    public class SelectorNode : INode
    {

        List<INode> childs = null;
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
                INode.STATE nState = childNode.Evaluate();
                switch (nState)
                {
                    case INode.STATE.RUN:
                        return INode.STATE.RUN;
                    case INode.STATE.SUCCESS:
                        return INode.STATE.SUCCESS;
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
                    case INode.STATE.RUN:
                        return INode.STATE.RUN;
                    case INode.STATE.SUCCESS:
                        continue;
                    case INode.STATE.FAIL:
                        return INode.STATE.FAIL;
                }
            }
            return INode.STATE.SUCCESS;
        }
    }


    public class Enemy : MonoBehaviour
    {

        public int defectiveRange;
        public int attackableRange;

        SelectorNode rootNode;

        SequenceNode attackSequence;
        SequenceNode defectiveSequence;
        ActionNode idleAction;
        ActionNode returnAction;

        Transform target = null;
        Vector3 originPos;
        // Start is called before the first frame update
        void Start()
        {
            originPos = transform.position;
            SetBT();
        }

        public void SetBT()
        {

            //���� ������//
            attackSequence = new SequenceNode();
            attackSequence.Add(new ActionNode(CheckInAttackRange));
            attackSequence.Add(new ActionNode(Attack));

            //���� ������//
            defectiveSequence = new SequenceNode();
            defectiveSequence.Add(new ActionNode(CheckInDetectiveRange));
            defectiveSequence.Add(new ActionNode(TraceTarget));

            //��ȯ �׼�//
            returnAction = new ActionNode(ReuturnOriginPos);

            //��� �׼�//
            idleAction = new ActionNode(IdleAction);

            rootNode = new SelectorNode();
            rootNode.Add(attackSequence);
            rootNode.Add(defectiveSequence);
            rootNode.Add(returnAction);
            rootNode.Add(idleAction);
        }


        INode.STATE Attack()
        {
            Debug.Log("���� ��");
            return INode.STATE.RUN;
        }
        INode.STATE CheckInAttackRange()
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

        INode.STATE TraceTarget()
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

        INode.STATE CheckInDetectiveRange()
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

        INode.STATE ReuturnOriginPos()
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
            Debug.Log("����Ѵ�");
            return INode.STATE.RUN;
        }


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
