using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public float passiveValue;

    public ReactiveProperty<float> uiValue = new ReactiveProperty<float>();

    public Image uiBar;

    public string _name;

    // Start is called before the first frame update
    void Start()
    {
        curValue = startValue;

        uiValue.DistinctUntilChanged().Subscribe(val =>
        {
            Debug.Log(_name+"°ª º¯°æ");
            uiBar.fillAmount = val / maxValue;

        }).AddTo(this);
        uiValue.Value = curValue;
    }


    private float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Add(float value)
    {
        uiValue.Value= Mathf.Min(uiValue.Value + value, maxValue);
    }

    public void Subtract(float value)
    {
        uiValue.Value= Mathf.Max(uiValue.Value - value, 0);
    }
}
