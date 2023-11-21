using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour, IPlayerInteractionable
{
    public void Interaction(PlayerScript player)
    {
        GameObject.FindObjectOfType<GameManager>().Score++;
        Destroy(gameObject);
    }
}
