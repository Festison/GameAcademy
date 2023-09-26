using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 싱글턴 게임 매니저 타입을 상속 받았다.
public class GameManager : SingleTon<GameManager>
{
    public GameObject playerObj;
    public GameObject enemySpawnerObj;
    public int curStageNum;
    public int score;

    // 자식에서 재정의가 되기 때문에 부모의 함수가 호출되지않는다.
    private void Awake()
    {
        // base를 이용해 부모의 함수를 먼저 호출 가능
        base.Awake();
        Debug.Log("게임매니저");
    }
}
