using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandRange : MonoBehaviour
{

    public GameObject Hand;
    private PlayerHand PlayerHand;

    private void Start()
    {
        PlayerHand = Hand.GetComponent<PlayerHand>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect Ball in range of player hand
        GameObject collidedGameObject = other.gameObject;
        if (collidedGameObject.tag == "Ball_Neu" && PlayerHand.HandIsEmpty())
        {
            this.gameObject.SetActive(false);
            // Make player hold that ball
            // Add key press later if needed
            PlayerHand.Carry(other.gameObject);
        }
    }
}
