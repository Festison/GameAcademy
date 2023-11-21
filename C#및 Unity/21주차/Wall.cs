using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IPlayerInteractionable
{
    public void Interaction(PlayerScript player)
    {
        GameObject.FindObjectOfType<GameManager>().GameOver();
    }
}
