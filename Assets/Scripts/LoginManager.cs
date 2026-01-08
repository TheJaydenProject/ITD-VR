using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections; // Required for IEnumerator and Coroutines

public class LoginManager : MonoBehaviour
{
    [Header("Input Fields")]
    [SerializeField] private TMP_InputField usernameField;
    [SerializeField] private TMP_InputField passwordField;

    [Header("Feedback UI")]
    [SerializeField] private GameObject errorMessage;
    [SerializeField] private GameObject successMessage;

    // Hardcoded credentials for CA3 demo
    private const string TargetUser = "jayden21";
    private const string TargetPass = "pass123";

    public void ValidateLogin()
    {
        // Reset feedback state
        if (errorMessage) errorMessage.SetActive(false);
        if (successMessage) successMessage.SetActive(false);

        // Validation logic
        if (usernameField.text == TargetUser && passwordField.text == TargetPass)
        {
            if (successMessage) successMessage.SetActive(true); //
            
            // Start the delay timer instead of loading immediately
            StartCoroutine(DelayedSceneLoad("SampleScene", 2f));
        }
        else
        {
            if (errorMessage) errorMessage.SetActive(true); //
        }
    }

    private IEnumerator DelayedSceneLoad(string sceneName, float delay)
    {
        // Wait for the specified amount of seconds
        yield return new WaitForSeconds(delay);

        // Now transition to the next scene
        SceneManager.LoadScene(sceneName);
    }
}