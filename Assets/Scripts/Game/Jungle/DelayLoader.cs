using UnityEngine;

public class DelayedHierarchyToggle : MonoBehaviour
{
    public static DelayedHierarchyToggle Instance;

    [SerializeField] private float delay = 7f;
    [SerializeField] private GameObject objectToDisable;
    [SerializeField] private GameObject objectToEnable;

    private float timer;
    private bool running;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void OnEnable()
    {
        ResetTimer();
    }

    void Update()
    {
        if (!running) return;

        timer += Time.unscaledDeltaTime;

        if (timer >= delay)
        {
            running = false;

            if (objectToDisable != null)
                objectToDisable.SetActive(false);

            if (objectToEnable != null)
                objectToEnable.SetActive(true);
        }
    }

    public void ResetTimer()
    {
        timer = 0f;
        running = true;
    }
}
