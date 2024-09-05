using System;
using JetBrains.Annotations;
using UdonSharp;
using UnityEngine;

namespace VRChatAerospaceUniversity.DesktopInteraction {
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [RequireComponent(typeof(Collider))]
    public class DesktopInteractionControl : UdonSharpBehaviour {
        public string controlName;

        [SerializeField] private UdonSharpBehaviour _targetBehaviour;

        [SerializeField] private string _leftClickEventName;
        [SerializeField] private string _rightClickEventName;
        [SerializeField] private string _middleClickEventName;
        [SerializeField] private string _scrollUpEventName;
        [SerializeField] private string _scrollDownEventName;

        public bool IsLeftClickEnabled => !string.IsNullOrWhiteSpace(_leftClickEventName);
        public bool IsRightClickEnabled => !string.IsNullOrWhiteSpace(_rightClickEventName);
        public bool IsMiddleClickEnabled => !string.IsNullOrWhiteSpace(_middleClickEventName);
        public bool IsScrollUpEnabled => !string.IsNullOrWhiteSpace(_scrollUpEventName);
        public bool IsScrollDownEnabled => !string.IsNullOrWhiteSpace(_scrollDownEventName);

        [PublicAPI]
        public void InteractControl(DesktopInteractionType type) {
            Debug.Log("Interacted " + controlName + " with " + ConvertTypeToString(type));

            switch (type) {
                case DesktopInteractionType.LeftClick:
                    SendCustomEventToTarget(_leftClickEventName);
                    break;
                case DesktopInteractionType.RightClick:
                    SendCustomEventToTarget(_rightClickEventName);
                    break;
                case DesktopInteractionType.MiddleClick:
                    SendCustomEventToTarget(_middleClickEventName);
                    break;
                case DesktopInteractionType.ScrollUp:
                    SendCustomEventToTarget(_scrollUpEventName);
                    break;
                case DesktopInteractionType.ScrollDown:
                    SendCustomEventToTarget(_scrollDownEventName);
                    break;
            }
        }

        private void SendCustomEventToTarget(string eventName) {
            if (!string.IsNullOrWhiteSpace(eventName))
                _targetBehaviour.SendCustomEvent(eventName);
        }

        private static string ConvertTypeToString(DesktopInteractionType type) {
            switch (type) {
                case DesktopInteractionType.LeftClick:
                    return "Left Click";
                case DesktopInteractionType.RightClick:
                    return "Right Click";
                case DesktopInteractionType.MiddleClick:
                    return "Middle Click";
                case DesktopInteractionType.ScrollUp:
                    return "Scroll Up";
                case DesktopInteractionType.ScrollDown:
                    return "Scroll Down";
                default:
                    return "Unknown";
            }
        }
    }

    [Flags]
    public enum DesktopInteractionType {
        None = 0,
        LeftClick = 1 << 1,
        RightClick = 1 << 2,
        MiddleClick = 1 << 3,
        ScrollUp = 1 << 4,
        ScrollDown = 1 << 5
    }
}
