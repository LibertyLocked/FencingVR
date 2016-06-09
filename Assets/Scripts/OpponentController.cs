using UnityEngine;
using System.Collections;

public class OpponentController : MonoBehaviour
{
    public GameObject SwordPrefab;
    public float AttackInterval = 0.6f;
    public float SwordSpeed = 5f;

    GameController gameController;
    GameObject attackPlane;
    GameObject player;

    float timeSinceLastAttack = 0f;

    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        attackPlane = GameObject.Find("Attack Plane");
        player = GameObject.Find("Player Head");

        attackPlane.GetComponent<MeshRenderer>().enabled = false;
    }

    void Update()
    {
        if (gameController.GameState == GameState.Playing)
        {
            timeSinceLastAttack += Time.deltaTime;
            if (timeSinceLastAttack >= AttackInterval)
            {
                timeSinceLastAttack = 0;
                Attack();
            }
        }
    }

    GameObject Attack()
    {
        // Get distance vector to player
        Vector3 distanceToPlayer = player.transform.position - attackPlane.transform.position;
        // Spawn a sword on a random position on the plane
        var opponentSword = Instantiate(SwordPrefab, attackPlane.transform.position,
            Quaternion.LookRotation(-distanceToPlayer.normalized))
            as GameObject;
        Rigidbody swordRb = opponentSword.GetComponent<Rigidbody>();
        swordRb.velocity = distanceToPlayer.normalized * SwordSpeed;

        return opponentSword;
    }

    public void Stagger()
    {
        timeSinceLastAttack = -AttackInterval;
    }
}

