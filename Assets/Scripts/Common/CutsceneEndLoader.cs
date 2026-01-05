using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(AudioSource))]
public class CutsceneEndLoader : MonoBehaviour
{
    [SerializeField] private string videoFileName;
    public int sceneIndexToLoad;

    private VideoPlayer videoPlayer;
    private AudioSource audioSource;

    void Awake()
    {
        LockCursor();
        videoPlayer = GetComponent<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();

        // AUDIO (WebGL safe)
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        // VIDEO
        videoPlayer.source = VideoSource.Url;
        videoPlayer.playOnAwake = false;
        videoPlayer.waitForFirstFrame = false;
        videoPlayer.skipOnDrop = true;
        videoPlayer.isLooping = false;

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void Start()
    {
        // IMPORTANT: WebGL needs explicit path format
        string url = Application.streamingAssetsPath + "/" + videoFileName;

        videoPlayer.url = url;
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnPrepared;
    }

    void OnPrepared(VideoPlayer vp)
    {
        vp.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
