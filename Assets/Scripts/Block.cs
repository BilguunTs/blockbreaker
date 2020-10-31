using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{   
    [SerializeField] AudioClip blockBreakAudio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(blockBreakAudio, Camera.main.transform.position);
        Destroy(gameObject, 0f);
    }
}
