using UnityEngine;

public class EnterKeyAnimatorTrigger : MonoBehaviour
{
    public GameObject mainMenu;

    [SerializeField] private Animator[] animators;

    private static readonly int EnterPressed = Animator.StringToHash("EnterPressed");

    private bool triggered = false;

    void Update()
    {
        if (triggered)
            return;

        if (Input.GetMouseButtonDown(0)) // Left Mouse Button
        {
            triggered = true;

            mainMenu.SetActive(true);
            foreach (Animator anim in animators)
            {
                if (anim != null)
                    anim.SetBool(EnterPressed, true);
            }
            

            // ❌ Optional: disable script permanently
            this.enabled = false;
        }
    }
}
