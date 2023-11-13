using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private void Start()
    {
        PauseManager.instance.onPause += () => { this.enabled = false; };
        PauseManager.instance.onResume += () => { this.enabled = true; };
    }
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
