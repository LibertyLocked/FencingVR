using UnityEngine;
using System.Collections;

public class OpponentSwordController : MonoBehaviour
{
    public AudioClip ParryClip;
    public AudioClip StabClip;

    OpponentController opponentController;
    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        opponentController = GameObject.FindGameObjectWithTag("Opponent").GetComponent<OpponentController>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerWeapon")
        {
            // Parried by player
            AudioSource.PlayClipAtPoint(ParryClip, transform.position);
            opponentController.Stagger();
            Destroy(transform.gameObject);
        }
        else if (other.name.Contains("Opponent"))
        {
            // Do nothing
        }
        else if (other.name == "Player Head")
        {
            // Player loses
            AudioSource.PlayClipAtPoint(StabClip, transform.position);
            gameController.Lose();
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }
}
