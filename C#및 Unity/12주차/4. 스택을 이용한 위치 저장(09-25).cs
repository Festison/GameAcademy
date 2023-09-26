using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    Stack<Vector3> stackPos = new Stack<Vector3>();
    Vector3 prevPos;
    bool isReturn = false;

    private void Start()
    {
        prevPos = transform.position;
        StartCoroutine(ReturnCo());
    }
    void Update()
    {
        if (isReturn)
        {
            return;
        }
        if (prevPos!=transform.position)
        {

            stackPos.Push(transform.position);
            prevPos = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isReturn = true;
        }
    }

    IEnumerator ReturnCo()
    {
        while (true)
        {
            if (isReturn)
            {
                for (int i = 0; i < 100; i++)
                {
                    Vector3 tempPos;
                    if (stackPos.TryPop(out tempPos))
                    {
                        transform.position = tempPos;
                    }
                    else
                    {
                        break;
                    }
                    yield return null;
                }
                isReturn = false;
                stackPos.Clear();
            }

            yield return null;
        }
    }
}
