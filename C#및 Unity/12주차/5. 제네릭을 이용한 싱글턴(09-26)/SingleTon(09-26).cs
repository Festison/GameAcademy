using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 싱글턴 패턴 : 메모리측면 및 데이터 공유의 이점을 위해 객체의 인스턴스가 오직 1개만 생성되게하는 패턴이다.
// 유니티에서는 씬전환을 통해 새로운 데이터를 불러오기 떄문에 기존에 있던 데이터가 하나만 존재하도록 싱글턴 패턴을 이용한다.
// 싱글턴 패턴을 여러가지 매니저에 상속해주기 위해서 제네릭 사용
// where을 사용해 싱글톤을 상속받는 클래스만 T타입에 들어갈 수 있다는 제한사항을 걸어줍니다.
public class SingleTon<T> : MonoBehaviour where T : SingleTon<T>
{
    // T에 상속해준 데이터 타입이 들어간다.
    public static T instance = null;

    // 상속을 위해 접근제한자를 protected로 설정
    protected void Awake()
    {
        // 인스터스가 비어있을시
        if (instance == null)
        {
            // 서로 다른 인스턴스들을 넣어주기 위해서 캐스팅을 통해서 인스턴스에 타입을 넣어준다.
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        // 인스턴스가 이미 있을시
        else
        {
            // 객체의 인스턴스가 1개만 생성되게 하기 위해 파괴
            Destroy(this.gameObject);
        }

        Debug.Log("싱글턴 패턴");
    }
}
