using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySceneController : MonoBehaviour
{
    public Image musicImage;
    public Image danceImage;

    // Start is called before the first frame update
    void Start()
    {
        danceImage.sprite = null;
        musicImage.sprite = GameManager.Instance.musicImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int idx = 0;
    public void ChangeImage()
    {
        danceImage.sprite = GameManager.Instance.DanceImages[idx];
        idx++;
        if (idx >= GameManager.Instance.DanceImages.Count)
        {
            idx = 0;
        }
    }
}
