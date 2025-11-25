using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;
   public int startLife = 10;
   private int _currentlife;
   public bool destroyOnKill = false;
    private bool _isDead= false;
    public float delayToKill = 0f;

    [SerializeField]private FlashColors _flashColor;

    private void Awake()
    {
      Init();
      if (_flashColor == null)
        {
            _flashColor = GetComponent<FlashColors>();
        }
    }

    private void Init()
    {
        _currentlife = startLife;
        _isDead = false;
    }
    public void Damage(int damage)
    {
       if (_isDead) return;
        _currentlife -= damage;

        if (_currentlife<= 0)
        {
         Kill();   
        }

        if(_flashColor == null)
        {
            _flashColor.Flash();
        }
    }

    private void Kill()
    {
        _isDead = true;
        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
        OnKill?.Invoke();
    }


}
