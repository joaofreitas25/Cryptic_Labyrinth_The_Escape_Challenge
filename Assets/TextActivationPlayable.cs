using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TextActivationPlayable : PlayableAsset, ITimelineClipAsset
{
    public ExposedReference<TextTimelineEvent> textTimelineEvent;

    public ClipCaps clipCaps => ClipCaps.Extrapolation;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable = ScriptPlayable<TextActivationPlayableBehaviour>.Create(graph);

        TextActivationPlayableBehaviour behaviour = playable.GetBehaviour();
        behaviour.textTimelineEvent = textTimelineEvent.Resolve(graph.GetResolver());

        return playable;
    }
}
