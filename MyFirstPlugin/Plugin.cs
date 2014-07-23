﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Altman.Model;
using PluginFramework;

namespace MyFirstPlugin
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IPlugin))]
    public class Plugin : IControlPlugin
    {
        private UserControl _userControl;
        private PluginInfo _pluginInfo;
        private IPluginSetting _pluginSetting;
        private IHost _host;

        [ImportingConstructor]
        public Plugin([Import("IHost")]IHost service)
        {
            _pluginInfo = new PluginInfo();
            _pluginSetting = new PluginSetting();
            _host = service;
        }

        public IPluginInfo PluginInfo
        {
            get { return _pluginInfo; }
        }

        public IPluginSetting PluginSetting
        {
            get { return _pluginSetting; }
        }

        public IHost Host
        {
            get { return _host; }
        }

        public UserControl GetUi(Shell data)
        {
             return _userControl = new MyFirstPlugin(_host,(Shell)data);
        }

        public void Dispose()
        {
            if(_userControl!=null)
                _userControl.Dispose();
        }
    }
}
