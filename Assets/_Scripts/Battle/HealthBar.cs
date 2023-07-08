using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject healthBar;
    public Color BarColor{
        get{
            var localScale = healthBar.transform.localScale.x;
            if(localScale < 0.15f){
                return new Color(193f/255, 45f/255, 45/255);
            }
            else if(localScale < 0.5f){
                return new Color(211f/255, 211f/255, 29/255);
            }
            else{
                return new Color(176/255, 233/255, 85/255);
            }
        }
    }
    // private void Start(){
    //     healthBar.transform.localScale = new Vector3(0.5f, 1.0f);
    // }
    
    /// <summary>
    /// Actualiza la barra de vida a partir del valor normalizado de la misma
    /// </summary>
    /// <param name="normalizedValue">Valor de la vida normalizado entre 0 y 1</param>
     public void SetHP(float normalicedValue){
        healthBar.transform.localScale = new Vector3(normalicedValue, 1.0f);

    }

    public IEnumerator SetSmoothHp(float normalicedValue){
        float currentScale = healthBar.transform.localScale.x;
        float updateQuantity = currentScale - normalicedValue;
        while (currentScale - normalicedValue > Mathf.Epsilon)
        {
            currentScale -= updateQuantity*Time.deltaTime;
            healthBar.transform.localScale = new Vector3(currentScale, 1);
            healthBar.GetComponent<Image>().color = BarColor;
            yield return null;
        }

        healthBar.transform.localScale = new Vector3(normalicedValue, 1);
    }
}
