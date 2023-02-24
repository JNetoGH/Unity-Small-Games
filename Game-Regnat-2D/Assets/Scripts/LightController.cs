using UnityEngine;

/// <summary>
///  Authored by João Mendes from Wild Horse Games
/// </summary>

public class LightController : MonoBehaviour
{
    public GameObject lightController;
    public Light sunLight;
    public float sunLightBrightness, lampBrightness;
    public bool AllowRealTimeLightRegulation;
    private Light[] lights;

    public float LampLightsRange;

    public bool[] lightDefaultSets = new bool[4];
    public float[] lampIntensityDefaultSets = {0F,   0F,    1F,    1.5F}; 
    public float[] sunIntensityDefaultSets =  {1.5F, 1.25F, 0.75F, 0.5F};
  
    public bool allowChageDefaultSetByInput;
    public string inputCode;
    private int currentDefaultSet = 0;
    private bool isGettingEalier = true;
    private bool isGettingLater;

    private void SetLightsBrightness()
    {
        // Input Instructions
        if (Input.GetButtonDown(inputCode) && allowChageDefaultSetByInput)
        {
            if (isGettingEalier)
            { 
                currentDefaultSet++;
                if (currentDefaultSet >= lightDefaultSets.Length)
                {
                    currentDefaultSet--;
                    isGettingLater = true;
                    isGettingEalier = false;
                }
            }

            if (isGettingLater)
            {
                currentDefaultSet--;
                if (currentDefaultSet <= 0)
                {
                    isGettingEalier = true;
                    isGettingLater = false;
                }
            }

            for (int i = 0; i < lightDefaultSets.Length; i++) lightDefaultSets[i] = false;
            lightDefaultSets[currentDefaultSet] = true;
        }

        // Change Deafult Sets Instructions
        for (int i = 0; i < lightDefaultSets.Length; i++)
        {
            if (lightDefaultSets[i])
            {
                lampBrightness = lampIntensityDefaultSets[i];
                sunLightBrightness = sunIntensityDefaultSets[i];
            }
            lightDefaultSets[i] = false; // muda tudo para false, para que possa haver mudança
        }

        foreach (Light light in lights) light.intensity = lampBrightness; // muda as intensidades das lampadas para o valor dejesado
        sunLight.intensity = sunLightBrightness;  // muda a intensidade do sol para o valor desejado
    }

    void Start()
    {
        lights = lightController.GetComponentsInChildren<Light>();
        foreach (Light light in lights) light.range = LampLightsRange;
        SetLightsBrightness();
    }

    void Update()
    {
        if (AllowRealTimeLightRegulation) SetLightsBrightness();
    }
}
