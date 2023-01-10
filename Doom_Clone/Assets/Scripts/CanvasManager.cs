using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI armor;
    [SerializeField] private TextMeshProUGUI ammo;
    [SerializeField] private Image healthIndicator;

    [SerializeField] private Sprite health1; //healthy
    [SerializeField] private Sprite health2;
    [SerializeField] private Sprite health3;
    [SerializeField] private Sprite health4; //dead

    [SerializeField] private GameObject redKey;
    [SerializeField] private GameObject blueKey;
    [SerializeField] private GameObject greenKey;


    private static CanvasManager _instance;
    public static CanvasManager Instance
    {
        get { return _instance; }
    }

    public void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    public void UpdateHealth(int healthValue)
    {
        health.text = healthValue.ToString() + "%";
        UpdateHealthIndicator(healthValue);
    }

    public void UpdateArmor(int armorValue)
    {
        armor.text = armorValue.ToString() + "%";
    }
    public void UpdateAmmo(int ammoValue)
    {
        ammo.text = ammoValue.ToString();
    }

    public void UpdateHealthIndicator(int healthValue)
    {
        if(healthValue >= 66)
        {
            healthIndicator.sprite = health1;
        }

        if(healthValue < 66 && healthValue >= 33)
        {
            healthIndicator.sprite = health2;
        }

        if(healthValue < 33 && healthValue > 0)
        {
            healthIndicator.sprite = health3;
        }

        if(healthValue <= 0)
        {
            healthIndicator.sprite = health4;
        }
    }

    public void UpdateKeys(string KeyColor)
    {
        if(KeyColor == "red")
        {
            redKey.SetActive(true);
        }

        if(KeyColor == "blue")
        {
            blueKey.SetActive(true);
        }

        if(KeyColor == "green")
        {
            greenKey.SetActive(true);
        }
    }

    public void ClearKey()
    {
        redKey.SetActive(false);
        blueKey.SetActive(false);
        greenKey.SetActive(false);
    }

}
