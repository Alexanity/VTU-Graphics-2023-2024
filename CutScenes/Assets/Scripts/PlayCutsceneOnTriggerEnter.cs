using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayCutsceneOnTriggerEnter : MonoBehaviour
{
    public PlayableDirector director; // Reference to the PlayableDirector for the cutscene
    public string cutsceneName; // Name or identifier of the cutscene to play
    public Camera cutsceneCamera; // Reference to the cutscene camera
    public Camera playerCamera; // Reference to the player's camera
    public GameObject player; // Reference to the player GameObject

    private FirstPersonController playerMovement; // Reference to the player movement script

    private void Start()
    {
        // Assuming the PlayerMovement script is attached to the player GameObject
        playerMovement = player.GetComponent<FirstPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the collided object is the player
            PlayCutscene();
        }
    }

    private void PlayCutscene()
    {
        // Ensure a director is assigned and a cutscene name is provided
        if (director != null && !string.IsNullOrEmpty(cutsceneName))
        {
            // Disable player movement
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            // Disable the player's camera
            playerCamera.gameObject.SetActive(false);

            // Enable the cutscene camera
            cutsceneCamera.gameObject.SetActive(true);

            // Play the cutscene using PlayableDirector
            director.Play();

            // Start a coroutine to monitor the cutscene's duration
            StartCoroutine(WaitForCutsceneToEnd());
        }
        else
        {
            Debug.LogWarning("Director reference or cutscene name is missing.");
        }
    }

    private System.Collections.IEnumerator WaitForCutsceneToEnd()
    {
        // Wait for the cutscene to finish playing
        while (director.state != PlayState.Paused)
        {
            yield return null;
        }

        // Cutscene has finished playing
        // Enable player movement
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        // Disable the cutscene camera
        cutsceneCamera.gameObject.SetActive(false);

        // Enable the player's camera
        playerCamera.gameObject.SetActive(true);
    }
}
