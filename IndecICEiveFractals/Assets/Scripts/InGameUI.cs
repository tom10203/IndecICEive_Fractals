using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public Gradient gradient; //HealthBar color change

    public Image fill;


    public void SetMaxHealth(int health) //healthbar max health
    {
        slider.maxValue = health;
        slider.value = health;


        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health) //Controlls healthbar
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}
