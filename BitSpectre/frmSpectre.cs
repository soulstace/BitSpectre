using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BitSpectre
{
    public partial class frmSpectre : Form
    {
        int spectreVal = 0;
        bool userModified = false;
        bool userSetHyperV = false;
        const string subkey = @"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management";
        const string subkey2 = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Virtualization";
        const string hyperval = "MinVmVersionForCpuBasedMitigations";
        //const string features = "FeatureSettings";
        const string _override = "FeatureSettingsOverride";
        const string _mask = "FeatureSettingsOverrideMask";
        const string s = "Decimal value: ";
        bool sessionEnding = false;

        public frmSpectre()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == 0x11) //WM_QUERYENDSESSION
                sessionEnding = true; /* avoid delaying a standard shutdown/restart */

            base.WndProc(ref msg);
        }

        protected override void OnActivated(EventArgs e)
        {
            spectreVal = 0;

            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            RegistryKey rkSp = Registry.LocalMachine.OpenSubKey(subkey, RegistryKeyPermissionCheck.ReadSubTree);
            object objSp = rkSp.GetValue(_override, null);
            bool exists = objSp != null;
            if (exists)
                spectreVal = (int)objSp;
            rkSp.Close();

            UpdateControls(spectreVal, exists);
        }

        void UpdateControls(int value, bool exists)
        {
            labelDecimalValue.Text = exists ? s + value.ToString() : s + "null";

            if (exists) //only check checkbox items if the registry value exists
            {
                if (value == 0)
                    checkedListBox1.SetItemChecked(0, true); //check 0
                else
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                    {
                        if (GetBinaryFlag(value, i))
                            checkedListBox1.SetItemChecked(i + 1, true); //the first item in the checkedlistbox is 0 and not a valid bit
                    }
                }
            }
        }

        private void frmSpectre_Load(object sender, EventArgs e)
        {
            cms1.Enabled = false;
            checkBoxHyperV.ForeColor = Color.Gray;

            RegistryKey rkHv = Registry.LocalMachine.OpenSubKey(subkey2, RegistryKeyPermissionCheck.ReadSubTree);
            if (rkHv != null)
            {
                checkBoxHyperV.Checked = rkHv.GetValue(hyperval, "").ToString() == "1.0" ? true : false;
                rkHv.Close();
            }
        }

        int SetBinaryFlag(int value, int index, bool check)
        {
            if (check)
            {
                return value | (1 << index);
            }
            return value & ~(1 << index);
        }

        bool GetBinaryFlag(int value, int index)
        {
            return (value & (1 << index)) != 0;
        }

        void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            userModified = true;

            if (checkedListBox1.SelectedIndex == 0) //the first item in the checkedlistbox is 0, not the first bit flag
            {
                spectreVal = 0; //zero the buffer

                for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                {
                    if (i > 0) //we selected 0 so uncheck all the other items
                        checkedListBox1.SetItemChecked(i, false);
                }
            }
            else //we selected a valid bit
            {
                checkedListBox1.SetItemChecked(0, false); //uncheck 0

                bool flag = checkedListBox1.GetItemCheckState(checkedListBox1.SelectedIndex) == CheckState.Checked;
                spectreVal = SetBinaryFlag(spectreVal, checkedListBox1.SelectedIndex - 1, flag); //the selected index is offset +1 from the first bit in the buffer
                                                                                                 //because the index 0 checkbox isn't used as a bit flag
            }

            if (spectreVal == 0)
                checkedListBox1.SetItemChecked(0, true);

            labelDecimalValue.Text = s + spectreVal.ToString();

            RegistryKey rkSp = Registry.LocalMachine.CreateSubKey(subkey, RegistryKeyPermissionCheck.ReadWriteSubTree);
            rkSp.SetValue(_override, spectreVal);
            rkSp.SetValue(_mask, 3);
            rkSp.Close();
        }

        void frmSpectre_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (userModified && checkBoxUnderstood.Checked)
            {
                if (userSetHyperV)
                {
                    RegistryKey rkHv = Registry.LocalMachine.CreateSubKey(subkey2, RegistryKeyPermissionCheck.ReadWriteSubTree);
                    if (checkBoxHyperV.Checked)
                        rkHv.SetValue(hyperval, "1.0", RegistryValueKind.String);
                    else
                        rkHv.DeleteValue(hyperval, false);
                    rkHv.Close();
                }

                //Prompt to restart
                if (!sessionEnding)
                {
                    if (DialogResult.Yes == MessageBox.Show("Your settings will not take effect until you reboot the system.\nWould you like to restart Windows now?", "Restart required", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        NativeMethods.DoExitWin(NativeMethods.EWX_REBOOT);
                    else
                        MessageBox.Show("Any changes you have made will be applied next time you restart Windows.", "Restart cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        void linkLabelMicrosoft_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            Process.Start("https://support.microsoft.com/en-us/help/4072698/windows-server-speculative-execution-side-channel-vulnerabilities");

        void checkBoxUnderstood_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox1.Enabled = checkBoxUnderstood.Checked;
            tpHyperV.Visible = !checkBoxUnderstood.Checked;
            checkBoxHyperV.ForeColor = !checkBoxUnderstood.Checked ? Color.Gray : Color.WhiteSmoke;
            cms1.Enabled = checkBoxUnderstood.Checked;
        }

        void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            Process.Start("https://github.com/soulstace/BitSpectre");

        void checkBoxHyperV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUnderstood.Checked)
            {
                userModified = true;
                userSetHyperV = true;
            }
        }
        void tsmDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("This will delete all Windows registry entries mentioned by the Microsoft reference article above. Not recommended unless you're striving for default settings (possibly unsafe).\n\nAre you sure?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3))
            {
                tryDelete(subkey, _override);
                tryDelete(subkey, _mask);
                tryDelete(subkey2, hyperval);
            }
            else showMsg("Nothing was deleted.");
        }

        void tryDelete(string key, string val)
        {
            RegistryKey r = Registry.LocalMachine.OpenSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree);
            try
            {
                r.DeleteValue(val, true);
                userModified = true;
                showMsg(val + " was deleted.");
            }
            catch (Exception x) { showMsg(x.Message + " " + val); }
            finally { userSetHyperV = false; }
            if (r != null) r.Close();
        }

        void showMsg(string msg) => 
            MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

        void labelDecimalValue_DoubleClick(object sender, EventArgs e) => JumpToKey();

        void tsmJump_Click(object sender, EventArgs e) => JumpToKey();

        void JumpToKey()
        {
            if (checkBoxUnderstood.Checked)
            {
                showMsg("Please note: the registry editor may not reflect your changes until you perform a F5 refresh.");

                RegistryKey rkLastkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Applets\Regedit", RegistryKeyPermissionCheck.ReadWriteSubTree);
                rkLastkey.SetValue("Lastkey", @"HKEY_LOCAL_MACHINE\" + subkey);
                rkLastkey.Close();

                Process.Start("regedit");
            }
        }
    }
}
