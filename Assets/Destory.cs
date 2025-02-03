using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public AudioClip collisionSound; // 効果音のAudioClip
    private AudioSource audioSource; // AudioSourceコンポーネント


    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();

        // AudioClipがAudioSourceに設定されていない場合は警告
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Sphere"))
        {
            Debug.Log("Collision with Sphere detected. Deactivating objects.");
            collision.gameObject.SetActive(true); // Deactivate the Sphere object
            Debug.Log("Sphere object active status: " + collision.gameObject.activeSelf);
            gameObject.SetActive(false); // Deactivate the Cube object (this object)
            Debug.Log("Cube object active status: " + gameObject.activeSelf);

            //効果音を再生
            PlayCollisionSound();
        }
    }


    void PlayCollisionSound()
    {
        if (audioSource != null && collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
        else
        {
            Debug.LogError("Collision sound or AudioSource is not set.");
        }
    }
}