using System.Windows;
using System;
using System.ComponentModel;
using NotifyIcon = System.Windows.Forms.NotifyIcon;
using PwmLib;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Container _components;
        private NotifyIcon _notifyIcon;
        private PwmManager _pwm;

        private MainWindow _mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _components = new Container();
            _notifyIcon = new NotifyIcon(_components)
            {
                ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(),
                Icon = Wpf.Properties.Resources.tray,
                Text = "PWM frequency manager",
                Visible = true
            };

            AddMenuItems(_notifyIcon.ContextMenuStrip.Items);

            _notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;

            // ToDo fix position
            // _notifyIcon.Click += (a, b) => _notifyIcon.ContextMenuStrip.Show();

            _pwm = new PwmManager();

            _pwm.OnFrequencySet +=
                (f, s) => _notifyIcon.ShowBalloonTip(
                    1000,
                    "PWM Tool",
                    $"PWM frequency set to {f}",
                    System.Windows.Forms.ToolTipIcon.Info);

            _pwm.OnError += (f, s) => _notifyIcon.ShowBalloonTip(
                    1000,
                    "PWM Tool",
                    s,
                    System.Windows.Forms.ToolTipIcon.Error);

            // by some reason _pwm.SetFrequency doesn't work if called from a background thread
            // _pwm.LookAfterFreq();
            CheckLastFrequency();
        }

        private void CheckLastFrequency()
        {
            var lastFreq = _pwm.LastFrequency;
            if (lastFreq != -1)
            {
                var restorFreqWindow = new RestoreFreqWindow(_pwm);
                if (restorFreqWindow.IsLoaded)
                {
                    restorFreqWindow.Show();
                }
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (_notifyIcon != null)
            {
                _notifyIcon.Dispose();
            }

            if (_components != null)
            {
                _components.Dispose();
            }

            base.OnExit(e);

        }

        private System.Windows.Forms.ToolStripLabel _currentFreqLabel;
        private System.Windows.Forms.ToolStripLabel _freqWatchStatus;
        private void AddMenuItems(System.Windows.Forms.ToolStripItemCollection items)
        {
            _currentFreqLabel = new System.Windows.Forms.ToolStripLabel("???");
            items.Add(_currentFreqLabel);

            _freqWatchStatus = new System.Windows.Forms.ToolStripLabel("???");
            items.Add(_freqWatchStatus);

            items.Add(new System.Windows.Forms.ToolStripSeparator());

            items.Add(new System.Windows.Forms.ToolStripMenuItem("Set PWM frequency", null, setFreq_Click));

            items.Add(new System.Windows.Forms.ToolStripSeparator());

            items.Add(new System.Windows.Forms.ToolStripMenuItem("Exit", null, onExit_Clicked));
        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = false;

            _currentFreqLabel.Text = $"Current: {_pwm.GetFrequencyString()} Hz";

            _freqWatchStatus.Text = $"Watching: {(_pwm.FreqWatch ? "enabled" : "disabled")}";
        }

        private void onExit_Clicked(object sender, EventArgs e)
        {
            Shutdown();
        }

        private void setFreq_Click(object sender, EventArgs e)
        {
            if (_mainWindow == null || !_mainWindow.IsLoaded)
            {
                _mainWindow = new MainWindow(_pwm);

                // carefull! we are modifying a var from different threads without synchronization
                _mainWindow.Closing += (s, args) => _mainWindow = null;
            }

            _mainWindow.Show();
        }
    }
}
