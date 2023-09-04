using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 1. 코루틴 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CoolTimeCo());
    }

    void Update()
    {
        // 스페이스를 누를때 마다 각각 다른 서브루틴의 코루틴이 호출
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(CoolTimeCo());
        }
    }

    IEnumerator CoolTimeCo()
    {
        while (true)
        {
            Debug.Log("코루틴 테스트1");

            // yield return + 조건 : return과 다르게 조건이 만족 할시 다시 코루틴 함수안으로 돌아온다.

            // 1. yield return null; : 다음 프레임에 실행 됨.
            // 2. yield return new WaitForSeconds(float);  : 유니티 시간 매개변수로 입력한 숫자에 해당하는 초만 큼 기다렸다가 실행됨.
            // 3 .yield return new WaitForSecondsRealtime(flaot);  : 현실 시간 매개변수로 입력한 숫자에 해당하는 초만큼 기다렸다가 실행됨.

            // 코루틴의 장점 : 코루틴에서 반복문을 사용하면 Update와는 별도로 동작하기 때문에 모든 스크립트가 정상적으로 동작하게 된다.
            yield return new WaitForSeconds(1);
        }
    }
}
