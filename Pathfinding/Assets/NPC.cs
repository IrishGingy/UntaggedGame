using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] DialogueItem dI;

    GameManager gm;
    DialogueManager dm;
    bool canInteract;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>(); 
        dm = gm.GetComponent<DialogueManager>();

        dI.played = false;
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            dm.PlayDialogue(dI);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
