using UnityEngine;
using System.Collections;

public class OpponentBodyController : MonoBehaviour
{
    GameController gameController;
    Rigidbody rb;
    Collider myCollider;

    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (gameController.GameState == GameState.Playing && other.tag == "PlayerWeapon")
        {
            Destroy(transform.gameObject);
            gameController.Win();
        }
    }
}
