﻿using UnityEngine;
using System.Collections;

public class FunkEverybody : MonoBehaviour {

	public void StartTheFunk() {
		FunkyBlink[] funkyBlinks = GetComponentsInChildren<FunkyBlink> ();
		foreach (FunkyBlink funkyBlink in funkyBlinks) {
			funkyBlink.tentacleAnimator.DoFunkyColors (true);
		}
	}
}
