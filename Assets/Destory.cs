using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public AudioClip collisionSound; // ���ʉ���AudioClip
    private AudioSource audioSource; // AudioSource�R���|�[�l���g


    void Start()
    {
        // AudioSource�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();

        // AudioClip��AudioSource�ɐݒ肳��Ă��Ȃ��ꍇ�͌x��
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

            //���ʉ����Đ�
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