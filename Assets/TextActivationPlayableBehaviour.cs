using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TextActivationPlayableBehaviour : PlayableBehaviour
{
    public TextTimelineEvent textTimelineEvent;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        textTimelineEvent.ShowText("Your Text");
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        textTimelineEvent.HideText();
    }
}