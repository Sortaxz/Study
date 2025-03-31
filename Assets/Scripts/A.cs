using UnityEngine;

public class DynamicAspectRatio : MonoBehaviour
{
    public float targetAspectRatioWidth = 20f;
    public float targetAspectRatioHeight = 9f;

    public KeyCode set20by9Key = KeyCode.C;
    public KeyCode set1by1Key = KeyCode.Q;
    public KeyCode setFullScreenKey = KeyCode.S;
    public KeyCode setWindowedKey = KeyCode.W;

    public int defaultWindowWidth = 1280;
    public int defaultWindowHeight = 720;

    void Update()
    {
        if (Input.GetKeyDown(set20by9Key))
        {
            SetWindowAspectRatio(20f, 9f);
        }

        if (Input.GetKeyDown(set1by1Key))
        {
            SetWindowAspectRatio(1f, 1f);
        }

        if (Input.GetKeyDown(setFullScreenKey))
        {
            SetFullScreen();
        }

        if (Input.GetKeyDown(setWindowedKey))
        {
            SetWindowed();
        }
    }

    void SetWindowAspectRatio(float widthRatio, float heightRatio)
    {
        int screenWidth = Screen.currentResolution.width;
        float aspectRatio = widthRatio / heightRatio;
        int targetHeight = Mathf.RoundToInt(screenWidth / aspectRatio);

        Screen.SetResolution(screenWidth, targetHeight, false);
        Debug.Log($"Pencere Boyutu ({widthRatio}:{heightRatio}): {screenWidth}x{targetHeight}");
    }

    void SetFullScreen()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        Debug.Log("Tam Ekran");
    }

    void SetWindowed()
    {
        Screen.SetResolution(defaultWindowWidth, defaultWindowHeight, false);
        Debug.Log($"Pencere Modu: {defaultWindowWidth}x{defaultWindowHeight}");
    }
}