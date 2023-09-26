using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 싱글턴 사운드 매니저 타입을 상속받았다.
public class SoundManager : SingleTon<SoundManager>
{
    public GameObject soundPrefab;

    public void Play()
    {
        Instantiate(soundPrefab);
    }
}
