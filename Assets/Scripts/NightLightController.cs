using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightLightController : MonoBehaviour
{
    [SerializeField]
    private float intensityTransitionSpeed = 3f;

    [SerializeField]
    private bool smoothIntensity;

    private DayTimeController dayTimeController;
    private new Light light;
    private float initialIntensity;
    private float targetIntensity;

    private void Awake()
    {
        dayTimeController = FindObjectOfType<DayTimeController>();
        light = GetComponent<Light>();
        initialIntensity = light.intensity;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTargetIntensity();
        UpdateLightIntensity();
    }

    private void UpdateLightIntensity()
    {
        light.intensity = targetIntensity;
    }

    private void UpdateTargetIntensity()
    {
        targetIntensity = dayTimeController.IsDay ? 0f : initialIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTargetIntensity();

        if (smoothIntensity)
        {
            UpdateLightIntensitySmooth();
        }
        else
        {
            UpdateLightIntensity();
        }
    }

    private void UpdateLightIntensitySmooth()
    {
        light.intensity = Mathf.Lerp(light.intensity, targetIntensity, intensityTransitionSpeed * Time.deltaTime);
    }
}
