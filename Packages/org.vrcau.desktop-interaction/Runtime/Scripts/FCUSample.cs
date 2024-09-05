using System;
using TMPro;
using UdonSharp;
using UnityEngine;

namespace VRChatAerospaceUniversity.DesktopInteraction {
    public class FCUSample : UdonSharpBehaviour {
        [SerializeField] private TextMeshProUGUI _speedText;
        [SerializeField] private TextMeshProUGUI _headingText;
        [SerializeField] private TextMeshProUGUI _altitudeText;
        [SerializeField] private TextMeshProUGUI _verticalSpeedText;

        private int _speed = 250;
        private bool _isSpeedManaged;

        private int _heading = 360;
        private bool _isHeadingManaged;

        private int _altitude = 2000;
        private bool _isAltitudeManaged;
        private bool _isAltitudePer100;

        private int _verticalSpeed;
        private bool _isVerticalSpeedManaged;

        private void LateUpdate() {
            _speedText.text = "<size=12>" + (_isSpeedManaged ? "MANAGED" : "MANUEL") + "</size>\n" + _speed;
            _headingText.text = "<size=12>" + (_isHeadingManaged ? "MANAGED" : "MANUEL") + "</size>\n" + _heading;
            _altitudeText.text = "<size=12>" + (_isAltitudeManaged ? "MANAGED" : "MANUEL") + " " +
                                 (_isAltitudePer100 ? "100" : "1000") + "</size>\n" + _altitude;
            _verticalSpeedText.text = "<size=12>" + (_isVerticalSpeedManaged ? "MANAGED" : "MANUEL") + "</size>\n" +
                                      _verticalSpeed;
        }

        public void SetSpeedManaged() {
            _isSpeedManaged = true;
        }

        public void SetSpeedManuel() {
            _isSpeedManaged = false;
        }

        public void SetHeadingManaged() {
            _isHeadingManaged = true;
        }

        public void SetHeadingManuel() {
            _isHeadingManaged = false;
        }

        public void SetAltitudeManaged() {
            _isAltitudeManaged = true;
        }

        public void SetAltitudeManuel() {
            _isAltitudeManaged = false;
        }

        public void SetVerticalSpeedManaged() {
            _isVerticalSpeedManaged = true;
        }

        public void SetVerticalSpeedManuel() {
            _isVerticalSpeedManaged = false;
        }

        public void _ToggleAltitudePer100() {
            _isAltitudePer100 = !_isAltitudePer100;
        }

        public void _IncreaseSpeed() {
            _speed += 1;
        }

        public void _DecreaseSpeed() {
            _speed -= 1;
        }

        public void _IncreaseHeading() {
            _heading += 1;
        }

        public void _DecreaseHeading() {
            _heading -= 1;
        }

        public void _IncreaseAltitude() {
            _altitude += _isAltitudePer100 ? 100 : 1000;
        }

        public void _DecreaseAltitude() {
            _altitude -= _isAltitudePer100 ? 100 : 1000;
        }

        public void _IncreaseVerticalSpeed() {
            _verticalSpeed += 100;
        }

        public void _DecreaseVerticalSpeed() {
            _verticalSpeed -= 100;
        }
    }
}
