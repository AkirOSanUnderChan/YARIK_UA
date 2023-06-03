using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.TextCore.Text;

public class FOGCHANGER : MonoBehaviour
{

    public PostProcessVolume postProcessVolume; // Посилання на об'єкт Post Processing Volume
    private ColorGrading colorGrading; // Компонент Color Grading



    void Start()
    {
        RenderSettings.fogDensity = 0;
        postProcessVolume.profile.TryGetSettings(out colorGrading);

    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.fogDensity = 2;
        colorGrading.saturation.value = 1.15f;
        colorGrading.contrast.value = 0.18f;
        colorGrading.temperature.value = 6000f;
    }
}
