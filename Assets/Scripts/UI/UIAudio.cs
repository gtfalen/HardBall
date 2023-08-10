using UnityEngine;

public class UIAudio : MonoBehaviour
{
    private static UIAudio instance;
    private AudioSource _audioSource;

    private UIAudio() {}

    private void CreateAudioSource()
    {
        var gameObject = new GameObject();
        gameObject.name = "UIAudio";
        
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.playOnAwake = false;
            
        DontDestroyOnLoad(gameObject);
    }
        
    public static UIAudio GetInstance() => instance ?? (instance = new UIAudio());

    public void PlayAudio(AudioClip clip)
    {
        if (_audioSource == null)
            CreateAudioSource();
            
        _audioSource.clip = clip;
        _audioSource.PlayOneShot(clip);
    }
}
