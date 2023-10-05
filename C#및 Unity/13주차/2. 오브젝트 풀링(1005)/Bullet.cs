using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.forward * 0.3f, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        ObjPooling.instance.ReturnPool(gameObject);
    }
}
