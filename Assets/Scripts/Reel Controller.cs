using System.Collections;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    float[] YPos;
    Animator an;

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
        StartCoroutine(Getting());
;    }

    IEnumerator Getting()
    {
        an = GetComponent<Animator>();
        an.SetBool("isTrigger" , true);

        yield return new WaitForSeconds(3);

        an.SetBool("isTrigger", false);
        an.enabled = false;
        int index = RandomnumberGenerator.instance.GetRandomIndex(4);
        float pos = YPos[index];

        float duration = 0.5f;
        float elapsed = 0;
        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(transform.position.x, pos - 0.2f, transform.position.z), 
                elapsed / duration
                );
            
            yield return null;
        }
        elapsed = 0;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(transform.position.x, pos, transform.position.z),
                elapsed / duration
                );

            yield return null;
        }

    }
}
