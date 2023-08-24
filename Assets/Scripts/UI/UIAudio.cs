using UnityEngine;

public class UIAudio : MonoBehaviour
{
    private static UIAudio instance;
    private AudioSource _audioSource;

    private UIAudio() {}

    private void CreateAudioSourceGameObject()
    {
        var gameObject = new GameObject("UIAudio");

        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.playOnAwake = false;
            
        DontDestroyOnLoad(gameObject);
    }
        
    public static UIAudio GetInstance() => instance ?? (instance = new UIAudio());

    public void PlayAudio(AudioClip clip)
    {
        if (_audioSource == null)
            CreateAudioSourceGameObject();
            
        _audioSource.clip = clip;
        _audioSource.PlayOneShot(clip);
    }
}
