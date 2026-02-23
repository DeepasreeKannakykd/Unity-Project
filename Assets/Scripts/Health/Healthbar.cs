using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Health playerHealth;
    public Image healthbarTotal;
    public Image healthbarCurrent;

    private void Start()
    {
        healthbarTotal.fillAmount = playerHealth.currentHealth / 10;
    }
    private void Update()
    {
        healthbarCurrent.fillAmount = playerHealth.currentHealth / 10;
    }
}