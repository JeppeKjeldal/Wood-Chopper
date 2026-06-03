using UnityEngine;

public class Interactor : MonoBehaviour
{
    private SpeakerNPC _currentNPC;

    // Called by StarterAssets / Player Input (OnInteract)
    private void OnInteract()
    {
        if (_currentNPC != null)
        {
            _currentNPC.TriggerDialogue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // When we enter the NPC's box collider
        if (other.TryGetComponent(out SpeakerNPC npc))
        {
            _currentNPC = npc;
            Debug.Log("In range of: " + npc.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // When we leave the NPC's box collider
        if (other.TryGetComponent(out SpeakerNPC npc))
        {
            // Only clear it if it's the NPC we were just talking to
            if (_currentNPC == npc)
            {
                _currentNPC = null;
                Debug.Log("Left range");
            }
        }
    }
}