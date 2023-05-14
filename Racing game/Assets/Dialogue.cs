using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textSpeed;
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    private int index;
    private Coroutine typingCoroutine;
    private Coroutine audioCoroutine;

    void Start()
    {
        textcomponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textcomponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textcomponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        typingCoroutine = StartCoroutine(TypeLine());
        audioCoroutine = StartCoroutine(PlayAudio());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    IEnumerator PlayAudio()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            audioSource.clip = audioClips[i];
            audioSource.Play();
            yield return new WaitForSeconds(audioClips[i].length);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textcomponent.text = string.Empty;
            StopCoroutine(typingCoroutine);
            StopCoroutine(audioCoroutine);
            typingCoroutine = StartCoroutine(TypeLine());
            audioCoroutine = StartCoroutine(PlayAudio());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
