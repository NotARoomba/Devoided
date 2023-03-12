using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.SoundManagerNamespace
{
public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] musicSources;
    public AudioClip[] sfxSources;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public static MusicPlayer Instance;
   private void Awake()
{
    // start of new code
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    // end of new code

    Instance = this;
    DontDestroyOnLoad(gameObject);
}
    public bool persistToggle = true;

        public void PlaySound(int index) {
            sfxSource.clip = sfxSources[index];
            sfxSource.PlayOneShotSoundManaged(sfxSource.clip);

        }
        public void PlayMusic(int index)
        {
            musicSource.clip = musicSources[index];
            musicSource.PlayLoopingMusicManaged(1.0f, 1.0f, persistToggle);
        }

        void Start()
        {
            SoundManager.StopSoundsOnLevelLoad = !persistToggle;
            PlayMusic(0);
        }
}
}
