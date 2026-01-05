using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;

    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);

            // Press started
            if (Input.GetButtonDown("Submit"))
            {
                animator.SetBool("pressed", true);
            }

            // Press released (perfect sync point)
            if (Input.GetButtonUp("Submit"))
            {
                animator.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;

                // Notify action script (no input duplication)
                SendMessage("OnMenuSubmit", SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            animator.SetBool("selected", false);
            animator.SetBool("pressed", false);
        }
    }
}
