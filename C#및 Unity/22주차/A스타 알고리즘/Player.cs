using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Point playerPoint;
    public Point targetPoint;
    public AStarController aStarController;
    public Queue<NodeComponent> pathQueue;

    private void Start()
    {
        pathQueue = new Queue<NodeComponent>();
        StartCoroutine(MoveDestinationCo());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetDestination();
        }
    }

    IEnumerator MoveDestinationCo()
    {
        while(true)
        {

            if(pathQueue.Count > 0)
            {
                Vector3 movePos = pathQueue.Dequeue().transform.position;
                movePos.y = transform.position.y;
                transform.position = movePos;
                yield return new WaitForSeconds(0.1f);
            }
    
            yield return null;
        }
    }

    public void PlayerPointSet()
    {
        
        if(Physics.Raycast(transform.position,Vector3.down,out RaycastHit hit,5,1<<8))
        {
            if (hit.collider.TryGetComponent(out NodeComponent nc))
            {
                playerPoint.x = nc.p.x;
                playerPoint.y = nc.p.y;
            }
        }
    }
    public void SetDestination()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,Mathf.Infinity, 1 << 8))
        {
            if (hit.collider.TryGetComponent(out NodeComponent nc))
            {
                if (nc.CostType == 1)
                {
                    Debug.Log("이동 할 수 없습니다.");
                    return;
                }

                PlayerPointSet();
                Debug.Log(nc.p.x + "," + nc.p.y + "..." + nc.CostType);
                targetPoint = nc.p;

                if(aStarController.PathFinding(playerPoint, targetPoint, pathQueue))
                    Debug.Log("목적지로 이동합니다.");
                else
                    Debug.Log("목적지에 도달 할 수 없습니다.");   
            }
        }
    }
}
