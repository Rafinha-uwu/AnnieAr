using System.Collections;
using System.IO;
using UnityEngine;

public class Lighta : MonoBehaviour
{
    public float captureInterval = 1f; 

    Manager manager;
    public GameObject Man;

    private bool Once = true;

    private bool Starts = false;

    private bool run = true;

    public float averageBrightness = 1;

    void Start()
    {
        manager = Man.GetComponent<Manager>();

       

    }
    private void Update()
    {
        if (manager.Fase == 27 && Once == true) { StartCoroutine(MeasureScreenBrightness()); Once = false; }

        if (manager.Fase == 27 && averageBrightness < 0.1f && Starts == true) { run = false; manager.Butt = "Next"; }
    }

    IEnumerator MeasureScreenBrightness()
    {
        while (run)
        {
            yield return new WaitForSeconds(captureInterval);

            ScreenCapture.CaptureScreenshot("screenshot.png");

            yield return new WaitForEndOfFrame();

            Texture2D texture = new Texture2D(Screen.width, Screen.height);
            texture.LoadImage(File.ReadAllBytes("screenshot.png"));

            float totalBrightness = 0;
            Color[] pixels = texture.GetPixels();

            foreach (Color pixel in pixels)
            {
                float grayscaleValue = pixel.grayscale; 
                totalBrightness += grayscaleValue;
            }

            averageBrightness = totalBrightness / pixels.Length;    

            Debug.Log("Average Brightness: " + averageBrightness);

            File.Delete("screenshot.png");

            Starts = true;
        }
    }
}
