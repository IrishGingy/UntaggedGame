using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CloseEyesTransition : MonoBehaviour
{
    [SerializeField] Material screenTransitionMaterial;
    [SerializeField] float transitionTime = 1f;
    [SerializeField] string propertyName = "_Progress";
    [SerializeField] Image transitionImage;

    public UnityEvent OnTransitionDone;

    // Start is called before the first frame update
    void Start()
    {
        transitionImage.enabled = true;
        StartCoroutine(ReverseTransitionCoroutine());
    }

    private IEnumerator ReverseTransitionCoroutine()
    {
        float currentTime = transitionTime;
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            screenTransitionMaterial.SetFloat(propertyName, Mathf.Clamp(currentTime / transitionTime, 0, transitionTime));
            yield return null;
        }
        OnTransitionDone?.Invoke();
    }
}
