using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start() {
        StartCoroutine(StartDialogue());
    }

    IEnumerator StartDialogue() {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<DialogueManager>().StartDialogue(dialogue);
    }
}
