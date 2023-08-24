using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 4. OCP : MonoBehaviour
{
    public int hp = 100;
    public int atk = 10;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    //충돌체(Collider)의 충돌이 발생했을 때 호출 되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "콜리전 충돌일어남");
        // 나랑 부딪힌 게임오브젝트의 태그가 Enemy일때만 TakeDamage(10) 호출.

        // 드래곤은 충돌했을 때 내 체력이 40이 달게하고싶고,
        // 스켈레톤은 충돌했을 때 내 체력이 10이 달게하고싶음.

        // 태그를 통해 분기를 나누면, 태그의 종류가 추가될때마다,
        // 아래부분이 계속 변경이 일어나야한다.
        // 즉, 개방폐쇄의 원칙(OCP)에 위배가된다.
        // OCP란 확장에 열려있고 변경에 닫혀있다는 뜻이다. 즉 한번짠 소스는 다시 수정하지않는것이 좋은 소스다.

        // OCP를 이용한 코드
        // 업 캐스팅이 일어나서 몬스터를 상속받은 드래곤, 스켈레톤 등을 가져 올 수 있다.
        Monster monster = collision.gameObject.GetComponent<Monster>();

        if (monster != null)
        {
            hp -= monster.atk;
            monster.TakeDamage(10);
        }            
        // tag를 이용한 코드
        /*
        if(collision.gameObject.tag == "Skeleton") 
        {
            TakeDamage(10);
        }
        if (collision.gameObject.tag == "Dragon")
        {
            TakeDamage(40);
        }
        */       
    }
}
