using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class DeviceCamera : MonoBehaviour
{
    //WebCamTexture webCamTexture;
    [SerializeField] new MeshRenderer renderer;
    //[SerializeField] new SpriteRenderer renderer;
    private WebCamDevice frontCameraDevice;
    private WebCamTexture frontCameraTexture;
    private WebCamDevice backCameraDevice;
    private WebCamTexture backCameraTexture;
    private WebCamDevice activeCameraDevice;
    private WebCamTexture activeCameraTexture;

    Texture2D photo;
    [SerializeField] Image capturedImage;
    int photoCount;

    void Start()
    {
        GetImageFile();
    }

    public void OnCameraDeviceButtonClick()
    {

//#if PLATFORM_ANDROID
//        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
//        {
//            Permission.RequestUserPermission(Permission.Camera);
//        }

//        //if (WebCamTexture.devices.Length == 0)
//        //{
//        //    Debug.Log("No Webcam");
//        //    cameraText.text = "No devices cameras found";
//        //    return;
//        //}

//        frontCameraDevice = WebCamTexture.devices.Last();
//        //backCameraDevice = WebCamTexture.devices.First();

//        frontCameraTexture = new WebCamTexture(frontCameraDevice.name);
//        //backCameraTexture = new WebCamTexture(backCameraDevice.name);

//        frontCameraTexture.filterMode = FilterMode.Trilinear;
//        //backCameraTexture.filterMode = FilterMode.Trilinear;

//        activeCameraTexture = frontCameraTexture;
//        activeCameraDevice = WebCamTexture.devices.FirstOrDefault(device => device.name == frontCameraTexture.deviceName);

//        renderer.material.mainTexture = activeCameraTexture; //Add Mesh Renderer to the GameObject to which this script is attached to
//        activeCameraTexture.Play();
//#else

        if (WebCamTexture.devices.Length == 0)
        {
            Debug.Log("No Webcam");
            //cameraText.text = "No devices cameras found";
            return;
        }

        activeCameraTexture = new WebCamTexture();
        renderer.material.mainTexture = activeCameraTexture; //Add Mesh Renderer to the GameObject to which this script is attached to
        activeCameraTexture.Play();
//#endif
    }

    public void OnTakePhotoButtonClick()
    {
        StartCoroutine(TakePhoto());
    }
    IEnumerator TakePhoto()  // Start this Coroutine on some button click
    {

        // NOTE - you almost certainly have to do this here:

        yield return new WaitForEndOfFrame();

        // it's a rare case where the Unity doco is pretty clear,
        // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
        // be sure to scroll down to the SECOND long example on that doco page 

        photo = new Texture2D(activeCameraTexture.width, activeCameraTexture.height);
        photo.SetPixels(activeCameraTexture.GetPixels());
        photo.Apply();
        //photoOut.material.mainTexture = photo;

        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        File.WriteAllBytes(Application.persistentDataPath + "/UserPicture/photo.png", bytes);

        activeCameraTexture.Stop();
    }

    void GetImageFile()
    {
        
        if (!Directory.Exists(Application.persistentDataPath + "/UserPicture"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/UserPicture");
        }
        else
        {
            Debug.Log(Directory.GetFiles(Application.persistentDataPath + "/UserPicture").Length.ToString());
        }

        if (File.Exists(Application.persistentDataPath + "/UserPicture/photo.png")) {
            byte[] byteArray = File.ReadAllBytes(Application.persistentDataPath + "/UserPicture/photo.png");
            Texture2D texture = new Texture2D(8, 8);
            if (texture.LoadImage(byteArray))
            {
                capturedImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
            }
            //Sprite s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
        }
    }
}