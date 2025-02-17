using BGD.Agents;
using BGD.StatSystem;
using UnityEngine;

namespace BGD.Players
{
    public class PlayerMover : AgentMover
    {
        [Header("StatSetting")]
        public StatSO jumpCntStat;

        private float _currentJumpCnt;
        private float _maxJumpCnt;
        public bool CanJump => _currentJumpCnt > 0;

        public override void AfterInit()
        {
            base.AfterInit();
            jumpCntStat = _agentStat.GetStat(jumpCntStat);
            _maxJumpCnt = jumpCntStat.Value;
        }
    }
}
