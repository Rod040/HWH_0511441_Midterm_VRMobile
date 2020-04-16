using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("燈光群組")]
    public GameObject groupLight;
    [Header("會動的寶箱")]
    public Transform chest;
    [Header("喇叭")]
    public AudioSource aud;
    [Header("木板上滑動音效")]
    public AudioClip soundWoodMove;
    [Header("會動的椅子")]
    public Transform chair;
    [Header("挪椅聲")]
    public AudioClip chairSound;
    [Header("敲門聲")]
    public AudioClip soundKnock;
    [Header("開門聲")]
    public AudioClip soundOpenDoor;
    [Header("開門動畫控制器")]
    public Animator aniDoor;

    private int countDoor;

    public void LookDoor()
    {
        countDoor++;

        if (countDoor == 1)
        {
            aud.PlayOneShot(soundKnock, 3);
        }
        else if (countDoor == 2)
        {
            aud.PlayOneShot(soundOpenDoor, 1);
            aniDoor.SetTrigger("開門觸發器");
        }
    }

    public IEnumerator LightEffect() 
    {
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        groupLight.SetActive(true);
        yield return new WaitForSeconds(0.43f);
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        groupLight.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        groupLight.SetActive(true);
        yield return new WaitForSeconds(0.9f);
    }

    public void StartMoveChest()
    {
        StartCoroutine(MoveChest());
    }
    
    public IEnumerator MoveChest()
    {
        chest.GetComponent<CapsuleCollider>().enabled = false;

        aud.PlayOneShot(soundWoodMove, 1);

        for (int i = 0; i < 15; i++)
        {
        chest.position -= chest.forward*0.2f;
        yield return new WaitForSeconds(0.1f);
        }
    }
    public void StartMoveChair()
    {
        StartCoroutine(MovetChair());
    }

    public IEnumerator MovetChair()
    {
        chair.GetComponent<MeshCollider>().enabled = false;

        aud.PlayOneShot(chairSound, 1);

        for (int i = 0; i < 10; i++)
        {
            chair.position -= chair.position* 0.01f;
            yield return new WaitForSeconds(0.001f);
        }
    }

    private void Start()
    {
        //LightEffect();
        StartCoroutine(LightEffect());
    }
}
