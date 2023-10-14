using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSquish : MonoBehaviour
{
    [Header("Remapping curves")]
    public AnimationCurve yBounceCurve;
    public AnimationCurve xBounceCurve;
    public bool OnlyUseYCurve;

    
    public IEnumerator Bounce() {
        //debug
        Debug.Log("Bouncing");

        float duration = .4f;
        Vector3 originalSize = transform.localScale;
        
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / duration;
            Vector3 newSize = new Vector3();
            newSize.z = transform.localScale.z;
            newSize.x = xBounceCurve.Evaluate(t);
            newSize.y = yBounceCurve.Evaluate(t);
            transform.localScale = newSize;
            //transform.localScale = Vector3.Lerp(originalSize, newSize, t);
            yield return null;
        }
    }
}
