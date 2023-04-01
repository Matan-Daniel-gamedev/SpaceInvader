using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarAnimation : MonoBehaviour
{
    float currentVelocity = 0f;
    bool currentlyAnimating = false;
    float animationDuration;

    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentlyAnimating){
            float currentValue =  Mathf.SmoothDamp(slider.value, 1.0f,ref currentVelocity, animationDuration);
            slider.value = currentValue;
        }
    }

    void animation(float duration){
        currentlyAnimating = true;
        slider.value=0f;
        animationDuration=duration;
    }
}
