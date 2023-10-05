using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 어댑터 패턴 : 한 클래스의 인터페이스를 클라이언트에서 사용하고자 하는 다른 인터페이스로 변환한다.
// 인터페이스 호환성 문제 때문에 같이 쓸 수 없는 클래스들을 연결해서 쓸 수가 있다.
public class AdapterPattern : MonoBehaviour, IHitable
{
    Wall wall;

    private void Start()
    {
        wall = GetComponent<Wall>();
    }

    public void Hit(IAttackable attackable)
    {
        wall.WallDestory();
    }
}
