using UnityEngine;

public class PressKeyAnimation : MonoBehaviour
{
    public Animator animator;
    public KeyCode pressKey = KeyCode.F;

    private bool isPlaying = false;

    void Update()
    {
        if (!isPlaying && Input.GetKeyDown(pressKey))
        {
            animator.Play("Press", 0, 0f);
            isPlaying = true;
        }

        // check if animation finished
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        if (isPlaying && state.IsName("Press") && state.normalizedTime >= 1f)
        {
            isPlaying = false;
        }
    }
}
