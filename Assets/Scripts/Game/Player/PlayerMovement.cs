using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Audio")]
    public AudioSource walkAudioSource;   // loop enabled
    public AudioClip walkClip;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Audio setup safety
        if (walkAudioSource != null)
        {
            walkAudioSource.clip = walkClip;
            walkAudioSource.loop = true;
            walkAudioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized;

        if (animator != null)
        {
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
            animator.SetFloat("Speed", moveInput.sqrMagnitude);
        }

        HandleWalkingSound();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    void HandleWalkingSound()
    {
        if (walkAudioSource == null || walkClip == null) return;

        bool isMoving = moveInput.sqrMagnitude > 0.01f;

        if (isMoving && !walkAudioSource.isPlaying)
        {
            walkAudioSource.Play();
        }
        else if (!isMoving && walkAudioSource.isPlaying)
        {
            walkAudioSource.Stop();
        }
    }
}
