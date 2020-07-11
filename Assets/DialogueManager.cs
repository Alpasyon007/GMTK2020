using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;

	//public Animator animator;

	private Queue<string> sentences;

	// Use this for initialization
	void Start() {
		sentences = new Queue<string>();
	}

	private void Update() {
		if (Input.GetKeyDown("return")) {
			DisplayNextSentence();
		}
	}

	public void StartDialogue(Dialogue dialogue) {
		//animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue(sentence);
		}
		
		DisplayNextSentence();
	}

	public void DisplayNextSentence() {
		if (sentences.Count == 0) {
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence) {
		dialogueText.text = "";
		yield return new WaitForSeconds(0.25f*Time.deltaTime);
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return new WaitForSeconds(0.1f*Time.deltaTime);
		}
	}

	public void EndDialogue() {
		SceneManager.LoadScene("Game");
	}

	//IEnumerator DeleteSentence(string sentence) {
	//	foreach (char letter in sentence.ToCharArray()) {
	//		dialogueText.text = dialogueText.text.Replace(letter, '\0');
	//		yield return new WaitForEndOfFrame();
	//	}
	//}

}
