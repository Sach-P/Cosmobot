using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Text health; 

    public void SetHealth(int _cur, int _max)
    {
        health.text = _cur + "HP";
        if (_cur <= 40)
        {
            health.color = Color.red;
        }
        else{
            health.color = Color.green;
        }
    }
}
