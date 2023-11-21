using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject objects;

    public TextMesh scoreLabel;
    public static int score;

    public event Action onRoundStart;
    public event Action onRoundEnd;

    public int Score
    {
        set
        {
            score = value;

            scoreLabel.text = Score.ToString();
        }
        get
        {
            return score;
        }
    }

    void Start()
    {
        score = 0;

        onRoundStart += () =>
        {
            InvokeRepeating("CreateObjects", 1, 2);
            { Debug.Log("로드"); }                    // 데이터 로드
            { Debug.Log("제트카라 상태 초기화"); }     // PlayerScripts에 존재
                                                     //제트 카라의 hp, mp, exp, gold와 같은 상태 초기화
            { Debug.Log("음악 시작"); }               // AudioMananger에 존재
        };

        onRoundEnd += () =>
        {
            { Debug.Log("결과 세이브"); }
            { Debug.Log("제트카라 상태 저장"); }      // 제트 카라의 Level 저장
            { Debug.Log("음악 종료"); }
        };

        RoundStart();
    }

    public void GameOver()
    {
        if (onRoundEnd != null)
        {
            onRoundEnd();
        }
    }

    void RoundStart()
    {
        // onRoundStart가 널이 아닐때 실행
        onRoundStart?.Invoke();
        Debug.Log("스코어 0으로 초기화");
    }

    void CreateObjects()
    {
        Instantiate(objects, new Vector3(7.5f, UnityEngine.Random.Range(-2f, 2.1f), 0), Quaternion.identity);
    }
}
