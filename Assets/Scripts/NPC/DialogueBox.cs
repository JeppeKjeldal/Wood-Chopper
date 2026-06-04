using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private float textSpeed = 10.0f;

    private string fullText;

    public bool IsTyping { get; private set; }

    public bool IsOpen { get => content.activeInHierarchy; }

    public static DialogueBox Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Close();
    }

    public void Open()
    {
        content.SetActive(true);
    }

    public void Close()
    {
        content.SetActive(false);
    }

    public void FastForward()
    {
        StopAllCoroutines();
        dialogueText.text = fullText;
        IsTyping = false;
    }

    public void DisplayDialogue(string fullText, string speakerName)
    {
        Open();
        this.speakerNameText.text = speakerName;
        this.fullText = fullText;
        IsTyping = true;
        StartCoroutine(TypeWriterEffectCoroutine());
    }

    private IEnumerator TypeWriterEffectCoroutine()
    {
        dialogueText.text = string.Empty;
        float delay = 1f / textSpeed;

        foreach (char character in fullText)
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(delay);
        }

        IsTyping = false;
    }
}
