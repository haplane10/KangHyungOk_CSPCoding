using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelect : MonoBehaviour
{
    public AudioClip musicClip;
    public Sprite musicImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMusicButtonClick()
    {
        GameManager.Instance.musicClip = musicClip;
        GameManager.Instance.musicImage = musicImage;
    }
}
