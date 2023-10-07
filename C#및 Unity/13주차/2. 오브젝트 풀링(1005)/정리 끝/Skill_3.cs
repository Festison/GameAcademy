using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_3 : MonoBehaviour
{
    public float movingSpeed = 10f;
    public float destroyTime = 2f;
    public float Damage = 0;

    bool UpdateCheck = true;
    public void Fire(Vector3 dir, float damage)
    {
        UpdateCheck = true;
        this.transform.right = dir;
        Damage = damage;
        StartCoroutine(destroyObj());
    }

    void Update()
    {
        if(UpdateCheck)
        this.transform.Translate(-Vector2.right * movingSpeed * Time.deltaTime);
    }
   
    IEnumerator destroyObj()
    {
        yield return new WaitForSeconds(destroyTime);
        UpdateCheck = false;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log("other::" + other.gameObject.transform.root);
            other.gameObject.transform.root.GetComponent<Mon_Bass>().Damaged(Damage, Vector2.zero, 0.1f);
        }
    }
}
