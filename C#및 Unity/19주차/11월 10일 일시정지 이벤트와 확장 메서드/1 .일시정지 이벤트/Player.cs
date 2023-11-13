using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    IEnumerator coolTimeCo = null;
    private void Start()
    {
        PauseManager.instance.onPause += () => { this.enabled = false; };
        PauseManager.instance.onResume += () => { this.enabled = true; };
        coolTimeCo = CoolTimeCo();
        StartCoroutine(coolTimeCo);
    }

    private void OnEnable()
    {
        if(coolTimeCo != null)
           StartCoroutine(coolTimeCo);
    }
    private void OnDisable()
    {
        if (coolTimeCo != null)
            StopCoroutine(coolTimeCo);
    }

    [SerializeField]
    bool isCool;
    IEnumerator CoolTimeCo()
    {
        float targetTime = 6f;
        float curTime = 0;
        while(true)
        {
            if(isCool)
            {
                yield return new WaitForEndOfFrame();
                curTime += Time.deltaTime;
                if(curTime >= targetTime)
                {
                    isCool = false;
                    curTime = 0;
                }
                Debug.Log(curTime);
            }
            yield return null;
        }
    }

    void Update()
    {

        transform.Translate(Vector3.up * Time.deltaTime);
    }
}
