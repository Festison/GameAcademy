using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

[Serializable]
public class State
{
    public PlayerScript player;
    public State(PlayerScript player)
    {
        this.player = player;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}

[Serializable]
public class AliveState : State
{
    public AliveState(PlayerScript player) : base(player)
    {
        player.dead = false;
    }

    public override void Enter()
    {

    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {

    }
}

[Serializable]
public class DieState : State
{
    public DieState(PlayerScript player) : base(player)
    {
        player.dead = true;
    }

    public override void Enter()
    {

    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {

    }
}

public interface IPlayerInteractionable
{
    void Interaction(PlayerScript player);
}

public class PlayerScript : MonoBehaviour
{
    public bool dead;
    public AudioClip[] auClip;
    public GameObject fire;

    [Header("현재 상태")]
    public State curState;

    void Start()
    {      
        curState = new AliveState(this);
        GetComponent<AudioSource>().clip = auClip[0];
        GameObject.FindObjectOfType<GameManager>().onRoundEnd += Die;
        GameObject.FindObjectOfType<GameManager>().onRoundEnd += () => { Debug.Log("세이브 "); };
    }

    void Update()
    {
        curState.Update();

        if (Input.GetMouseButtonDown(0) && !dead)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider == null)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        fire.SetActive(true);
        GetComponent<AudioSource>().Play();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        IPlayerInteractionable interactionable = col.GetComponent<IPlayerInteractionable>();

        if (!dead)
        {
            if (interactionable != null)
                interactionable.Interaction(this);
        }
    }

    void Die()
    {
        dead = true;
        GetComponent<AudioSource>().clip = auClip[1];
        GetComponent<AudioSource>().Play();
        Invoke("BackToMain", 1.5f);        
    }

    void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
