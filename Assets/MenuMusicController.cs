using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicController : MonoBehaviour {
    public AudioSource titleMusic;
    public AudioClip menuHum;
    private AudioClip titleIntro;

    private float TitleClipLength;

    private bool IsPlayingTitle = true;

	// Use this for initialization
	void Start () {
        titleIntro = titleMusic.clip;
        TitleClipLength = titleIntro.length - .3f;
        StartCoroutine("MusicLoopChanger", TitleClipLength);

	}

    IEnumerator MusicLoopChanger(float timer)
    {
        yield return new WaitForSeconds(timer);
        titleMusic.Stop();
        if (IsPlayingTitle) {
            titleMusic.clip = menuHum;
            IsPlayingTitle = false;
        } else {
            titleMusic.clip = titleIntro;
            IsPlayingTitle = true;
        }

        TitleClipLength = titleMusic.clip.length;
        titleMusic.Play();
        StartCoroutine("MusicLoopChanger", TitleClipLength);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
