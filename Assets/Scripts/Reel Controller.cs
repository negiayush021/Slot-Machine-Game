using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReelController : MonoBehaviour
{
    float[] YPos;
    public int index;
    [SerializeField] private Animator an;
    [SerializeField] private float AnimationDuration;

    public bool spinningfinish = false;

    private void Start()
    {
        YPos = new float[4];
        YPos[0] = -0.5f;
        YPos[1] = 1f;
        YPos[2] = 2.5f;
        YPos[3] = 3.75f;
    }

    private void OnEnable()
    {
        HandleScript.OnHandleTrigger += GetRandomPos;
    }
    private void OnDisable()
    {
        HandleScript.OnHandleTrigger -= GetRandomPos;
    }

    void GetRandomPos()
    {
        spinningfinish = false;
        an.enabled = true;
        StartCoroutine(Getting());
;   }

    IEnumerator Getting()
    {
        // Animation
        an.SetBool("isTrigger" , true);
        yield return new WaitForSeconds(AnimationDuration);
        an.SetBool("isTrigger", false);
        an.enabled = false;

        index = RandomnumberGenerator.instance.GetRandomIndex(4);
        float pos = YPos[index];

        // child reference . the one who has animator
        Transform child = transform.GetChild(0);

        // reel down 0.1f 
        float duration = 0.25f;
        float elapsed = 0;
        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;
            child.position = Vector3.Lerp(
                child.position, 
                new Vector3(child.position.x, pos - 0.1f, child.position.z), 
                elapsed / duration
                );
            
            yield return null;
        }

        // reel up 0.1f
        elapsed = 0;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            child.position = Vector3.Lerp(
                child.position,
                new Vector3(child.position.x, pos, child.position.z),
                elapsed / duration
                );

            yield return null;
        }

        spinningfinish = true;

    }
}
