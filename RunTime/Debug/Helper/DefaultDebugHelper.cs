﻿using UnityEngine;

namespace HT.Framework
{
    /// <summary>
    /// 默认的调试管理器助手
    /// </summary>
    public sealed class DefaultDebugHelper : IDebugHelper
    {
        private DebugManager _module;
        private Debugger _debugger;
        private bool _isEnableDebugger = false;

        /// <summary>
        /// 调试管理器
        /// </summary>
        public InternalModuleBase Module { get; set; }
        /// <summary>
        /// 当前的帧率
        /// </summary>
        public int FPS
        {
            get
            {
                if (_debugger != null)
                {
                    return _debugger.FPS;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 初始化助手
        /// </summary>
        public void OnInitialization()
        {
            _module = Module as DebugManager;
        }
        /// <summary>
        /// 助手准备工作
        /// </summary>
        public void OnPreparatory()
        {

        }
        /// <summary>
        /// 刷新助手
        /// </summary>
        public void OnRefresh()
        {
            if (_isEnableDebugger != _module.IsEnableDebugger)
            {
                _isEnableDebugger = _module.IsEnableDebugger;
                if (_debugger != null)
                {
                    _debugger.RefreshMaskState();
                }
            }
        }
        /// <summary>
        /// 终结助手
        /// </summary>
        public void OnTermination()
        {
            if (_debugger != null)
            {
                _debugger.OnTermination();
                _debugger = null;
            }
        }
        /// <summary>
        /// 暂停助手
        /// </summary>
        public void OnPause()
        {

        }
        /// <summary>
        /// 恢复助手
        /// </summary>
        public void OnUnPause()
        {

        }

        /// <summary>
        /// 初始化调试器
        /// </summary>
        /// <param name="debuggerSkin">调试器皮肤</param>
        public void OnInitDebugger(GUISkin debuggerSkin)
        {
            if (_module.IsEnableDebugger)
            {
                _debugger = new Debugger();
                _debugger.OnInitialization(debuggerSkin);
            }
        }
        /// <summary>
        /// 调试器UI刷新
        /// </summary>
        public void OnDebuggerGUI()
        {
            if (_module.IsEnableDebugger)
            {
                if (_debugger != null)
                {
                    _debugger.OnDebuggerGUI();
                }
            }
        }
    }
}