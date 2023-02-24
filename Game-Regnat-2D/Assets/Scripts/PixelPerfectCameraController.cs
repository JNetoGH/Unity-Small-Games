using UnityEngine.U2D;
using UnityEngine;

/// <summary>
/// This script makes real magic
/// Authored by João Mendes from Wild Horse Games
/// Follow us on Instagram @wildhorsegames
/// VAI BRASIL!!!!
/// </summary>

public class PixelPerfectCameraController : MonoBehaviour
{
    // pixel perfect camera features
    private PixelPerfectCamera pixelPerfectCamera;
    private int screenHeight;
    private int screenWidth;
    public int viewZoom;
    public bool allowRealTimeAutoScaling;
    

    // Camera moviment controlling;
    public bool moveTheCameraBasedOnTarget;
    public GameObject target;

    /* explainning the: AutoScaleScreen();
     * 16:9 resolution auto detect and auto scale based on 1080p viewable area
     * makes the game natively randered in the closest resolution to the screen as possible
     * uses the perfect pixel camera component to automaticaly crop and fit the aplication on screen of diferent aspect ration such as 21:9, 4:3, 16:10
     * mutiplying the view zoom by the growth variation to perfect render on the new screen 
     * |    w1: 1080p -> w2: 540p    =>    growth variation = 50% = 0.5    =>     viewZoom * 0.5    | 
     * there are a little bit of diference between the scales because the view Zoom will be casted to (int) loosing the decimal aspects */

    private void AutoScaleScreen()
    {

        // it's is required to reset those vars in order to rescale the scream in real time
        if (allowRealTimeAutoScaling)
        {
            screenHeight = Screen.height;
            screenWidth = Screen.width;
        }


        // the actual auto scale
        if (screenWidth >= 30720 && screenHeight >= 17280) // 17280p 32K (MAX RESOLUTION)
        {
            pixelPerfectCamera.refResolutionX = 30720;
            pixelPerfectCamera.refResolutionY = 17280;
            pixelPerfectCamera.assetsPPU = viewZoom * 15;
        }
        else if (screenWidth >= 15360 && screenHeight >= 8640) // 8640p 16K
        {
            pixelPerfectCamera.refResolutionX = 15360;
            pixelPerfectCamera.refResolutionY = 8640;
            pixelPerfectCamera.assetsPPU = viewZoom * 7;
        }
        else if (screenWidth >= 7680 && screenHeight >= 4320) // 4320p 8K
        {
            pixelPerfectCamera.refResolutionX = 7680;
            pixelPerfectCamera.refResolutionY = 4320;
            pixelPerfectCamera.assetsPPU = viewZoom * 4;
        }
        else if (screenWidth >= 5120 && screenHeight >= 2880) // 5120 x 2880 5K
        {
            pixelPerfectCamera.refResolutionX = 5120;
            pixelPerfectCamera.refResolutionY = 2880;
            pixelPerfectCamera.assetsPPU = (int) (viewZoom * 2.65);
        }
        else if (screenWidth >= 3840 && screenHeight >= 2160) // 2160p 4K
        {
            pixelPerfectCamera.refResolutionX = 3840;
            pixelPerfectCamera.refResolutionY = 2160;
            pixelPerfectCamera.assetsPPU = viewZoom * 2;
        }
        else if (screenWidth >= 3200 && screenHeight >= 1800) // 1800p WQXGA+
        {
            pixelPerfectCamera.refResolutionX = 3200;
            pixelPerfectCamera.refResolutionY = 1800;
            pixelPerfectCamera.assetsPPU = (int)(viewZoom * 1.66);
        }
        else if (screenWidth >= 2560 && screenHeight >= 1440) // 1440p QUAD HD
        {
            pixelPerfectCamera.refResolutionX = 2560;
            pixelPerfectCamera.refResolutionY = 1440;
            pixelPerfectCamera.assetsPPU = (int)(viewZoom * 1.33);
        }
        else if (screenWidth >= 2048 && screenHeight >= 1152) // 1152p QWXGA
        {
            pixelPerfectCamera.refResolutionX = 2048;
            pixelPerfectCamera.refResolutionY = 1152;
            pixelPerfectCamera.assetsPPU = (int)(viewZoom * 1.06);
        }
        else if (screenWidth >= 1920 && screenHeight >= 1080) // 1080p FULL HD
        {
            pixelPerfectCamera.refResolutionX = 1920;
            pixelPerfectCamera.refResolutionY = 1080;
            pixelPerfectCamera.assetsPPU = viewZoom;
        }
        else if (screenWidth >= 1600 && screenHeight >= 900) // 900p UXGA
        {
            pixelPerfectCamera.refResolutionX = 1600;
            pixelPerfectCamera.refResolutionY = 900;
            pixelPerfectCamera.assetsPPU = (int)(viewZoom*0.84);
        }
        else if (screenWidth >= 1366 && screenHeight >= 768) // 768p WXGA
        {
            pixelPerfectCamera.refResolutionX = 1366;
            pixelPerfectCamera.refResolutionY = 768;
            pixelPerfectCamera.assetsPPU = (int)(viewZoom * 0.72);
        }
        else if (screenWidth >= 1280 && screenHeight >= 720) // 720p HD
        {
            pixelPerfectCamera.refResolutionX = 1280;
            pixelPerfectCamera.refResolutionY = 720;
            pixelPerfectCamera.assetsPPU = (int)(viewZoom * 0.67);
        }
        else if (screenWidth >= 1024 && screenHeight >= 576) // 576p WSVGA
        {
            pixelPerfectCamera.refResolutionX = 1024;
            pixelPerfectCamera.refResolutionY = 576;
            pixelPerfectCamera.assetsPPU = (int)(viewZoom * 0.54);
        }
        else if (screenWidth >= 960 && screenHeight >= 540) // 540p qHD
        {
            pixelPerfectCamera.refResolutionX = 960;
            pixelPerfectCamera.refResolutionY = 540;
            pixelPerfectCamera.assetsPPU = (int)(viewZoom * 0.5);
        }
        else if (screenWidth >= 854 && screenHeight >= 480) // 480p FWVGA
        {
            pixelPerfectCamera.refResolutionX = 854;
            pixelPerfectCamera.refResolutionY = 480;
            pixelPerfectCamera.assetsPPU = (int)(viewZoom * 0.45);
        }
        else if (screenWidth >= 640 && screenHeight >= 360) // 360p nHD
        {
            pixelPerfectCamera.refResolutionX = 640;
            pixelPerfectCamera.refResolutionY = 360;
            pixelPerfectCamera.assetsPPU = (int)(viewZoom * 0.33);
        }
        else if (screenHeight >= 240 && Screen.height < 240) // nHD (Minumum resolution)
        {
            pixelPerfectCamera.refResolutionX = 426;
            pixelPerfectCamera.refResolutionY = 240;
            pixelPerfectCamera.assetsPPU = (int)(viewZoom * 0.23);
        }
    }

    private void Start()
    {
        // gets the screen aspect ratio
        screenHeight = Screen.height;
        screenWidth = Screen.width;

        // pixel perfect camera (turns everything on)
        pixelPerfectCamera = GetComponent<PixelPerfectCamera>();
        pixelPerfectCamera.upscaleRT = true;
        pixelPerfectCamera.cropFrameX = true;
        pixelPerfectCamera.cropFrameY = true;
        pixelPerfectCamera.stretchFill = true;

        // Vsync featrues
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;

        AutoScaleScreen();
    }

    private void Update()
    {
        if (allowRealTimeAutoScaling) AutoScaleScreen();
        // Camera movimentation based on a target execution axis z must be a costant in order to the camera do not transpass the grid
        if (moveTheCameraBasedOnTarget) this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
    }

   


}
