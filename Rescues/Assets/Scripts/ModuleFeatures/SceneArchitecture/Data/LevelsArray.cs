using System;
using System.Collections.Generic;
using UnityEngine;


namespace Rescues
{
    [CreateAssetMenu(fileName = "LevelsDataArray", menuName = "Data/LevelsDataArray")]
    public class LevelsData : ScriptableObject
    {

        #region Fileds
        
        [Header("Default  load level")]
        [SerializeField] private string _defaultLevelName;
        [SerializeField] private string _defaultLocationName;
        [SerializeField] private int _defaultGateId;
        [Header("Last Level")]
        [SerializeField] private bool _loadFromLastLevel;
        [SerializeField] private string _lastLevelName;
        [SerializeField] private string _lastLocationName;
        [SerializeField] private int _lastGateId;
        [Header("Levels array")]
        [SerializeField] private List<string> _levelsNames;
        
        #endregion

        #region Properties
        
        public List<string> LevelsNames => _levelsNames;

        private IGate DefualtLoadGate => new GateData(_defaultLevelName, _defaultLocationName, _defaultGateId);
        
        public IGate GetGate => _loadFromLastLevel ? LastLoadGate : DefualtLoadGate;
        private IGate LastLoadGate
        {
            get
            {
                if (_lastLevelName == String.Empty || _lastLocationName == String.Empty || _lastGateId == 0)
                    return DefualtLoadGate;
                return new GateData(_lastLevelName, _lastLocationName, _lastGateId);
            }
        }

        public IGate SetLastLevelGate
        {
            set
            {
                _lastLevelName = value.GoToLevelName;
                _lastLocationName = value.GoToLocationName;
                _lastGateId = value.GoToGateId;
            }
        }
        
        #endregion
        
    }
}