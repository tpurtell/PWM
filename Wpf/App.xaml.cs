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
        private PWM _pwm = new PWM();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _components = new Container();
            _notifyIcon = new NotifyIcon(_components)
            {
                ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(),
                Icon = Wpf.Properties.Resources.tray,
                Text = "trololo",
                Visible = true
            };

            AddMenuItems(_notifyIcon.ContextMenuStrip.Items);

            _notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
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
        private void AddMenuItems(System.Windows.Forms.ToolStripItemCollection items)
        {
            _currentFreqLabel = new System.Windows.Forms.ToolStripLabel("???");
            items.Add(_currentFreqLabel);
            items.Add(new System.Windows.Forms.ToolStripButton("Set PWM frequency", null, setFreq_Click));
            items.Add(new System.Windows.Forms.ToolStripSeparator());
            items.Add(new System.Windows.Forms.ToolStripButton("Exit", null, onExit_Clicked));

        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = false;

            int a = 0, currentFreq = 0;
            if (_pwm.GetFrequency(ref a, ref currentFreq) == 0)
            {
                _currentFreqLabel.Text = currentFreq.ToString();
            }
            else
            {
                _currentFreqLabel.Text = "driver error";
            }
        }

        private void onExit_Clicked(object sender, EventArgs e)
        {
            Shutdown();
        }

        private void setFreq_Click(object sender, EventArgs e)
        {
            var form = new MainWindow(_pwm);
            form.Show();
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("you double clicked me", "Fuck!", MessageBoxButton.YesNo);
        }
    }
}
