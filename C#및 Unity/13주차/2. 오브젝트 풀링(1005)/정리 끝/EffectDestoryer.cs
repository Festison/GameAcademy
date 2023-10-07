using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestoryer : MonoBehaviour 
{
    public float DestroyTime = 5;

	void Start () 
    {
        StartCoroutine(EffectDestroy());
	}

    IEnumerator EffectDestroy()
    {
        yield return new WaitForSeconds(DestroyTime);

        Destroy(this.gameObject);
    }
}
