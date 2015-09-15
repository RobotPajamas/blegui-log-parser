using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RobotPajamas
{
    public partial class LogParser : Form
    {
        private String _filterString = "";
        Logger _logger = new Logger();
        Timer _timer = new Timer();

        public LogParser()
        {
            InitializeComponent();
            bool result = false;

            // If logger isn't initialized, app won't work
            do
            {
                result = _logger.Initialize();
                if (!result)
                {
                    var boxResult = MessageBox.Show("Please make sure Bluegiga BLEGUI is open",
                        "Bluegiga not open",
                        MessageBoxButtons.RetryCancel);
                    if (boxResult == DialogResult.Cancel)
                    {
                        Application.Exit();
                        throw new ApplicationException();
                    }
                }
            } while (!result);


            _timer.Tick += new EventHandler(OnTimedEvent);
            _timer.Interval = 5000;
            _timer.Enabled = false;
        }

        private void OnTimedEvent(object source, EventArgs e)
        {
            if (handleRadioButton.Checked)
            {
                _filterString = "atthandle: " + handleTextbox.Text;
            }
            else if (macRadioButton.Checked)
            {
                var macAddress = macTextbox.Text;
                var macParts = macAddress.Split(':');

                // Re-assemble backwards
                var macFilter = "";
                for (int i = macParts.Length - 1; i >= 0; --i)
                {
                    macFilter += macParts[i];
                }

                _filterString = "sender:" + macFilter;
            }
            else
            {
                _filterString = "::Debugger::";
            }

            loggingTextbox.Text = _logger.ProcessCapture(_logger.Capture(), _filterString);
        }

        private void loggingButton_Click(object sender, EventArgs e)
        {
            if (_logger.IsLogging())
            {
                _logger.Stop();
                loggingButton.Text = "Start Logging";
                _timer.Enabled = false;
            }
            else
            {
                _logger.Start();
                loggingButton.Text = "Stop Logging";
                loggingTextbox.Text = _logger.ProcessCapture(_logger.Capture(), _filterString);

                var interval = numericUpDown.Value;
                if (interval <= 1)
                {
                    interval = 1;
                }

                _timer.Interval = (int)(interval * 1000);
                _timer.Enabled = true;
            }
        }


        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (handleRadioButton.Checked)
            {
                _filterString = "atthandle: " + handleTextbox.Text;
                handleTextbox.Enabled = true;
                macTextbox.Enabled = false;
            }
            else if (macRadioButton.Checked)
            {
                var macAddress = macTextbox.Text;
                var macParts = macAddress.Split(':');

                // Re-assemble backwards
                var macFilter = "";
                for (int i = macParts.Length - 1; i >= 0; --i)
                {
                    macFilter += macParts[i];
                }

                _filterString = "sender:" + macFilter;
                handleTextbox.Enabled = false;
                macTextbox.Enabled = true;
            }
            else
            {
                _filterString = "::Debugger::";
                handleTextbox.Enabled = false;
                macTextbox.Enabled = false;
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            var interval = numericUpDown.Value;
            if (interval <= 1)
            {
                interval = 1;
            }

            _timer.Interval = (int)(interval * 1000);
        }
    }
}
