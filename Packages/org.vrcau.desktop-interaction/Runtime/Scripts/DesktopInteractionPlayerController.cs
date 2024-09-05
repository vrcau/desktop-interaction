using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace VRChatAerospaceUniversity.DesktopInteraction {
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class DesktopInteractionPlayerController : UdonSharpBehaviour {
        private VRCPlayerApi _localPlayer;

        private Collider _targetCollider;
        private DesktopInteractionControl _targetControl;

        [SerializeField] private TextMeshProUGUI _controlNameText;
        [SerializeField] private GameObject _tooltipGameObject;

        [SerializeField] private GameObject _leftClickTooltipGameObject;
        [SerializeField] private GameObject _rightClickTooltipGameObject;
        [SerializeField] private GameObject _middleClickTooltipGameObject;
        [SerializeField] private GameObject _scrollUpTooltipGameObject;
        [SerializeField] private GameObject _scrollDownTooltipGameObject;

        // Default is "DesktopInteraction"
        [SerializeField] private LayerMask _layerMask = 134217728;

        private void Start() {
            _localPlayer = Networking.LocalPlayer;

            _tooltipGameObject.SetActive(false);

            if (_localPlayer.IsUserInVR()) {
                gameObject.SetActive(false);
            }
        }

        private void FixedUpdate() {
            var startPoint = _localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);

            Debug.DrawRay(startPoint.position, startPoint.rotation * Vector3.forward * 5, Color.red);

            if (!Physics.Raycast(startPoint.position, startPoint.rotation * Vector3.forward, out var hit, 5f,
                    _layerMask)) {
                _targetCollider = null;
                _targetControl = null;

                OnTargetLost();
            }

            // Compare Reference
            if (hit.collider == _targetCollider)
                return;

            _targetCollider = hit.collider;
            _targetControl = hit.collider.GetComponent<DesktopInteractionControl>();

            if (!_targetControl)
                return;

            OnTargetGot();
        }

        private void OnTargetGot() {
            _tooltipGameObject.SetActive(true);
            _controlNameText.text = _targetControl.controlName;

            _leftClickTooltipGameObject.SetActive(_targetControl.IsLeftClickEnabled);
            _rightClickTooltipGameObject.SetActive(_targetControl.IsRightClickEnabled);
            _middleClickTooltipGameObject.SetActive(_targetControl.IsMiddleClickEnabled);
            _scrollUpTooltipGameObject.SetActive(_targetControl.IsScrollUpEnabled);
            _scrollDownTooltipGameObject.SetActive(_targetControl.IsScrollDownEnabled);
        }
        private void OnTargetLost() {
            _tooltipGameObject.SetActive(false);
            _controlNameText.text = "No Control";
        }

        private void LateUpdate() {
            if (!_targetControl)
                return;

            if (Input.GetMouseButtonDown(0))
                _targetControl.InteractControl(DesktopInteractionType.LeftClick);

            if (Input.GetMouseButtonDown(1))
                _targetControl.InteractControl(DesktopInteractionType.RightClick);

            if (Input.GetMouseButtonDown(2))
                _targetControl.InteractControl(DesktopInteractionType.MiddleClick);

            var mouseWheelAxis = Input.GetAxis("Mouse ScrollWheel");

            if (mouseWheelAxis > 0)
                _targetControl.InteractControl(DesktopInteractionType.ScrollUp);

            if (mouseWheelAxis < 0)
                _targetControl.InteractControl(DesktopInteractionType.ScrollDown);
        }
    }
}
