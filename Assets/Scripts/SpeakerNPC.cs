using StarterAssets;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerNPC : MonoBehaviour
{
    public void TriggerDialogue()
    {
        string text = "Hello it's me the peseant";
        var dialogueBox = DialogueBox.Instance;

        if (!dialogueBox.IsOpen)
        {
            dialogueBox.Open();
            dialogueBox.DisplayDialogue(text, gameObject.name);
        }

        else if (dialogueBox.IsTyping)
        {
            dialogueBox.FastForward();
        }

        else
        {
            dialogueBox.Close();
        }
    }
}
