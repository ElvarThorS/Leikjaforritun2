using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float hitpoint = 150;
    private float maxHitpoint = 150;
    public GameObject player;
    private PlayerController2 PC;
    public Image currentHealtbar;
    public Text ratioText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthbar();
        PC = player.GetComponent<PlayerController2>();
    }

    public void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealtbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }

    public void TakeDamage(float damage)
    {
        hitpoint -= damage;
        if (hitpoint <= 0)
        {
            hitpoint = 0;
            Debug.Log("Dead!");
            PC.isDead = true;
        }
        UpdateHealthbar();
    }

    private void HealDamage(float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }
        UpdateHealthbar();
    }
 
}
