using System;
using Unity.VisualScripting;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private _Level _level;
    
    void Start()
    {
        _level = GameObject.Find("EventSystem").GetComponent<_Level>();
    }

    private void Update()
    {
        if (_level.health == 0 || !_level.IsGameStart)
            Kill();
    }

    // Если яйцо касается мертвой зоны, то отнимается жизнь, а если касается корзины, то прибавляется очко
    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.transform.name)
        {
            case "Player":
                _level.points++;
                Kill();
                break;
            
            case "Death Collider 1" or "Death Collider 2":
                _level.health--;
                Kill();
                break;
        }
    }

    // Уничтожает яйцо
    private void Kill()
    {
        Destroy(transform.GameObject());
    }
}
