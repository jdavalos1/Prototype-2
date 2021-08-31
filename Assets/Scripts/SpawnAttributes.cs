using UnityEngine;
using UnityEngine.UI;

public class SpawnAttributes : MonoBehaviour
{
    public Slider hungerBar;

    private float full = 3;
    private float hunger = 0;

    void Start()
    {
        hungerBar.minValue = 0;
        hungerBar.maxValue = full;
        hungerBar.value = hunger;
    }

    public void DecreaseHunger()
    {
        hunger++;
        hungerBar.value = hunger;

        if(hunger >= full)
        {
            GameObject.Find("Player").GetComponent<PlayerAttributes>().IncreaseScore();
            Destroy(gameObject);
        }
    }
}
