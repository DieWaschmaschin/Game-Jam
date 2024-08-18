using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu()]
public class HandCards : ScriptableObject
{
    public List<Card> CurrentCards = new List<Card>();

    public delegate void OnHandCardsChangedHandler();
    public OnHandCardsChangedHandler OnHandCardsChanged;

    public void Add(Card card)
    {
        CurrentCards.Add(card);
        OnHandCardsChanged?.Invoke();
    }

    public void Add(IEnumerable<Card> cards)
    {
        CurrentCards.AddRange(cards);
        OnHandCardsChanged?.Invoke();
    }

    public void Remove(Card card)
    {
        CurrentCards.Remove(card);
        OnHandCardsChanged?.Invoke();
    }

    // RESET region resets the current cards when play mode is entered in unity editor. Otherwise you'd collect cards en masse.
    #region RESET
    private void OnEnable()
    {
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged += HandlePlayModeState;
#endif
    }

#if UNITY_EDITOR
    private void HandlePlayModeState(PlayModeStateChange state)
    {
        switch (state)
        {
            case PlayModeStateChange.ExitingPlayMode:
                CurrentCards.Clear();
                break;
            default:
                break;
        }
    }
#endif

    private void OnDisable()
    {
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged -= HandlePlayModeState;
#endif
    }
    #endregion
}
