﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/**
 * Controls one single letter thrown in the ThrowLetterSpell spell.
 */
public class ThrownLetter : MonoBehaviour
{
    public string letter;
    public GameObject hitEffect;
    SpriteRenderer sr;

    // letter movement
    float spd = 3f;
    float acceleration = 15f;
    float spinSpd = 720f;
    float shrinkMin = 0.4f;
    float shrinkSpd = 0.3f;

    MultiHitSpell spell;
    Vector2 targetPos;
    public void Initialize(string letter, Vector2 targetPos, MultiHitSpell spell)
    {
        this.letter = letter;
        this.spell = spell;
        this.targetPos = targetPos;
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = PuzzleLetterImages.Letters[letter].GetSprite(false, false);
    }

    void Update()
    {
        // move towards target
        transform.position = Vector2.MoveTowards(transform.position, targetPos, spd * GameTime.deltaTime);
        spd += acceleration * GameTime.deltaTime;
        // spin
        transform.localEulerAngles = new Vector3(0f, 0f, transform.localEulerAngles.z + spinSpd * GameTime.deltaTime);
        // shrink
        transform.localScale = new Vector3(ProjectileSpell.Decay(transform.localScale.x, shrinkSpd, shrinkMin),
            ProjectileSpell.Decay(transform.localScale.y, shrinkSpd, shrinkMin), 1f);
        // if at target
        if (Vector2.Distance(transform.position, targetPos) < 0.01f)
        {
            spell.Hit(gameObject);
            // create particles
            Instantiate(hitEffect, transform.position, transform.rotation);
            // destroy
            Destroy(gameObject);
        }
    }
}