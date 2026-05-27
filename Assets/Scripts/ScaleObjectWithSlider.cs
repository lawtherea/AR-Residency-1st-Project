using UnityEngine;
using UnityEngine.UI;

public class ScaleObjectWithSlider : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private Slider scaleSlider;
    [SerializeField] private Transform objectToScale;

    [Header("Limites de tamanho")]
    [SerializeField] private float minimumMultiplier = 0.5f;
    [SerializeField] private float maximumMultiplier = 2.0f;

    private Vector3 initialScale;

    private void Awake()
    {
        if (scaleSlider == null || objectToScale == null)
        {
            Debug.LogError("Slider ou objeto a redimensionar não foi configurado.");
            enabled = false;
            return;
        }

        initialScale = objectToScale.localScale;

        scaleSlider.minValue = minimumMultiplier;
        scaleSlider.maxValue = maximumMultiplier;
        scaleSlider.wholeNumbers = false;
        scaleSlider.value = 1.0f;

        scaleSlider.onValueChanged.AddListener(ChangeScale);

        ChangeScale(scaleSlider.value);
    }

    private void ChangeScale(float multiplier)
    {
        objectToScale.localScale = initialScale * multiplier;
    }

    private void OnDestroy()
    {
        if (scaleSlider != null)
        {
            scaleSlider.onValueChanged.RemoveListener(ChangeScale);
        }
    }
}