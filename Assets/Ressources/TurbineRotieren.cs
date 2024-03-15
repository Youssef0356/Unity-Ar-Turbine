using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurbineRotieren : MonoBehaviour
{
    public GameObject wholeObject; // The whole Turbine (to call it for scaling)
    public Vector3 rotAxis; // Rotation axis of the turbine gear
    public Toggle description; 
    public Canvas desc1;
    public Canvas desc2; 
    public Slider sizeSlider; // UI slider to control the scaling size
    public Slider speedSlider; // UI slider to control the rotation speed
    public float sizeSliderMaxValue = 20; // Maximal scaling of the turbine
    public float speedSliderMaxValue = 300; // Maximal speed of the turbine gear
    public float m_Speed; // in degree/second
    public bool drehen; // should the turbine gear rotate right now

    void Start() // happens at the start of the programm
    {
        sizeSlider.maxValue = sizeSliderMaxValue; // Set the posible max values of the sliders
        speedSlider.maxValue = speedSliderMaxValue;
    }

    void Update() // happens every frame
    {
        //Rotate the turbine gear a little every frame around the rotation axis if the bool allows it. 
        if (drehen)
            transform.Rotate(rotAxis * speedSlider.value * Time.deltaTime);

        wholeObject.transform.localScale = new Vector3(0.1f * sizeSlider.value, 
            0.1f * sizeSlider.value, 0.1f * sizeSlider.value); // scales the whole turbine for the slider value

        desc1.enabled = description.isOn;
        desc2.enabled = description.isOn;
    }
    public void DrehrichtungWechseln() // changes the direction of the rotation axis
    {
        rotAxis.x = rotAxis.x * (-1);
    }
    public void DrehenStart() // function to start the rotation
    {
        drehen = true;
    }
    public void DrehenStop() // function to stopp the rotation
    {
        drehen = false;
    }
}
