using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public float Damage { get; }
    public void Attack(IHitable hitable);
}
public interface IHitable
{
    public float Hp { get; set; }
    public void Hit(IAttackable attackable);
}

// 인터페이스란 약속및 상호작용이다.
// 인터페이스는 클래스가 다중상속을 할 수 없는 단점을 보완하기 위해 만들어진 개념이다.
// 즉, 클래스는 인터페이스를 여러 개 상속받을 수 있다.
// 인터페이스를 상속받는 클래스는 인터페이스에서 정의한멤버를 무조건 구현 해야 한다는 약속이있다.
// 인터페이스의 구조는 추상클래스와 비슷한데 공통점은 추상화를 사용한다는 것이다.
// 추상 클래스는 확장의 의미를 가지고 인터페이스는 실체화의 의미를 가진다.
// 인터페이스 이름은 클래스명과 구별할 수 있도록 이름 앞에 대문자 I (아이) 를 붙여 만든다.
// 메서드, 프라퍼티(property 속성), 인덱서(indexer) 등을 멤버로 가질 수 있다.
// 멤버는 모두 추상화만 가능하다. 즉, 멤버 선언만 할 수 있다.
// 추상 클래스와 마찬가지로 인스턴스(객체) 를 생성할 수 없다.
// 인터페이스를 사용하는 이유 : 아이템이 수십개, 수백개일 경우 아이템마다 GetComponent 해 와서 if문 처리를 하면 코드가 길어지고 복잡해질 것이다.
public class Player : MonoBehaviour, IAttackable, IHitable
{
    [SerializeField]
    private float hp;
    [SerializeField]
    private float atk;
    public float Damage
    {
        get 
        { 
            return atk; 
        }
    }

    public float Hp
    {
        get => hp;

        set
        {
            hp = value;

            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Attack(IHitable hitable)
    {
        hitable.Hit(this);
    }

    public void Hit(IAttackable attackable)
    {
        Hp -= attackable.Damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<IHitable>() != null)
        {
            Attack(collision.transform.GetComponent<IHitable>());
        }
    }
}
