using UnityEngine;
using System.Collections;
using  System.Collections.Generic;

public class WinSfx : MonoBehaviour
{
    AudioSource winSound;
    public void OnEnableSfx() => EventManager.OnPlayerWin += PlayerWin;
    public void OnDisableSfx() => EventManager.OnPlayerWin += PlayerWin;
    private void PlayerWin() => winSound.Play();
}
