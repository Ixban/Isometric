using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject healthBar;

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
            yield return null;
        }

        healthBar.transform.localScale = new Vector3(normalicedValue, 1);
    }
}
