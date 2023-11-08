using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lambda : MonoBehaviour
{
    public Action OnDie = null;
    private int hp = 100;

    public int HP
    {
        get
        {
            return hp;
        }

        set
        {
            value = hp;

            if (hp <= 0)
            {
                OnDie?.Invoke();
            }

        }
    }

    public void Start()
    {
        // 람다함수 : 무명 메서드 - 함수의 이름이 없고 함수를 즉석으로 생성된다.
        // 마치 오브젝트, 변수처럼 이리 저리 저장할 수 있는 값이 되기도 한다.
        // 즉 재사용을 하지않는 특정한 한 줄짜리 함수를 즉석으로 생성한다.
        // 형식 : (input-parameters) => expression
        OnDie += () => { Destroy(gameObject); };
    }

}
