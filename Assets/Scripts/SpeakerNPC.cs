using UnityEngine;

public class SpeakerNPC : MonoBehaviour
{
    public string npcName = "Peasant";
    [SerializeField] private GameObject choicePanel; // Drag your ChoicePanel here

    public enum QuestState { NotStarted, InProgress, Completed }
    public QuestState currentState = QuestState.NotStarted;

    public void TriggerDialogue()
    {
        var db = DialogueBox.Instance;

        if (db.IsTyping)
        {
            db.FastForward();
            return;
        }

        if (db.IsOpen && !choicePanel.activeInHierarchy)
        {
            db.Close();
            return;
        }

        if (!db.IsOpen)
        {
            RunQuestLogic();
        }
    }

    private void RunQuestLogic()
    {
        var db = DialogueBox.Instance;

        switch (currentState)
        {
            case QuestState.NotStarted:
                db.DisplayDialogue("Hello! I need 500 gold. Can you help?", npcName);
                choicePanel.SetActive(true);
                ToggleCursor(true);
                break;

            case QuestState.InProgress:
                db.DisplayDialogue("Do you have the gold?", npcName);
                choicePanel.SetActive(true);
                ToggleCursor(true);
                break;

            case QuestState.Completed:
                db.DisplayDialogue("Thanks for the help! I'm debt-free now.", npcName);
                break;
        }
    }

    public void OnClickYes()
    {
        choicePanel.SetActive(false);

        if (currentState == QuestState.NotStarted)
        {
            currentState = QuestState.InProgress;
            DialogueBox.Instance.DisplayDialogue("Great. I will be waiting.", npcName);
        }
        else if (currentState == QuestState.InProgress)
        {
            if (ResourceManager.Instance.TrySpendGold(500))
            {
                currentState = QuestState.Completed;
                DialogueBox.Instance.DisplayDialogue("Thank you for the gold!", npcName);
            }
            else
            {
                DialogueBox.Instance.DisplayDialogue("You're lying! You don't have 500 gold.", npcName);
            }
        }
        ToggleCursor(false);
    }

    public void OnClickNo()
    {
        choicePanel.SetActive(false);

        if (currentState == QuestState.NotStarted)
            DialogueBox.Instance.DisplayDialogue("Too bad. Come back if you change your mind.", npcName);
        else
            DialogueBox.Instance.DisplayDialogue("Then go collect some more!", npcName);
        ToggleCursor(false);
    }

    private void ToggleCursor(bool isEnabled)
    {
        Cursor.visible = isEnabled;
        Cursor.lockState = isEnabled ? CursorLockMode.None : CursorLockMode.Locked;
    }
}