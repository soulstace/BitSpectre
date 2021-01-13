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
        const string mmkey = @"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management";
        const string hypkey = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Virtualization";
        const string hypval = "MinVmVersionForCpuBasedMitigations";
        //const string features = "FeatureSettings";
        const string _override = "FeatureSettingsOverride";
        const string _mask = "FeatureSettingsOverrideMask";
        const string strDec = "Decimal value: ";
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

            for (int i = 0; i < clbox.Items.Count; ++i)
            {
                clbox.SetItemChecked(i, false);
            }

            RegistryKey rkSp = Registry.LocalMachine.OpenSubKey(mmkey, RegistryKeyPermissionCheck.ReadSubTree);
            object objSp = rkSp.GetValue(_override, null);
            bool exists = objSp != null;
            if (exists)
                spectreVal = (int)objSp;
            rkSp.Close();

            UpdateControls(spectreVal, exists);
        }

        void UpdateControls(int value, bool exists)
        {
            lbDecimal.Text = exists ? strDec + value.ToString() : strDec + "null";

            if (exists) //only check checkbox items if the registry value exists
            {
                if (value == 0)
                    clbox.SetItemChecked(0, true); //check 0
                else
                {
                    for (int i = 0; i < clbox.Items.Count; ++i)
                    {
                        if (GetBinaryFlag(value, i))
                            clbox.SetItemChecked(i + 1, true); //the first item in the checkedlistbox is 0 and not a valid bit
                    }
                }
            }
        }

        private void frmSpectre_Load(object sender, EventArgs e)
        {
            miJump.Enabled = false;
            miDelete.Enabled = false;
            miVersion.Enabled = false;
            cbHyperV.ForeColor = Color.Gray;
            miVersion.Text = GetType().Namespace + " v" + GetType().Assembly.GetName().Version.ToString();

            RegistryKey rkHv = Registry.LocalMachine.OpenSubKey(hypkey, RegistryKeyPermissionCheck.ReadSubTree);
            if (rkHv != null)
            {
                cbHyperV.Checked = rkHv.GetValue(hypval, "").ToString() == "1.0" ? true : false;
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

        void clbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            userModified = true;

            if (clbox.SelectedIndex == 0) //the first item in the checkedlistbox is 0, not the first bit flag
            {
                spectreVal = 0; //zero the buffer

                for (int i = 0; i < clbox.Items.Count; ++i)
                {
                    if (i > 0) //we selected 0 so uncheck all the other items
                        clbox.SetItemChecked(i, false);
                }
            }
            else //we selected a valid bit
            {
                clbox.SetItemChecked(0, false); //uncheck 0

                bool flag = clbox.GetItemCheckState(clbox.SelectedIndex) == CheckState.Checked;
                spectreVal = SetBinaryFlag(spectreVal, clbox.SelectedIndex - 1, flag); //the selected index is offset +1 from the first bit in the buffer
                                                                                                 //because the index 0 checkbox isn't used as a bit flag
            }

            if (spectreVal == 0)
                clbox.SetItemChecked(0, true);

            lbDecimal.Text = strDec + spectreVal.ToString();

            RegistryKey rkSp = Registry.LocalMachine.CreateSubKey(mmkey, RegistryKeyPermissionCheck.ReadWriteSubTree);
            rkSp.SetValue(_override, spectreVal);
            rkSp.SetValue(_mask, 3);
            rkSp.Close();
        }

        void frmSpectre_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (userModified && cbUnderstood.Checked)
            {
                if (userSetHyperV)
                {
                    RegistryKey rkHv = Registry.LocalMachine.CreateSubKey(hypkey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                    if (cbHyperV.Checked)
                        rkHv.SetValue(hypval, "1.0", RegistryValueKind.String);
                    else
                        rkHv.DeleteValue(hypval, false);
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

        void lbMS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            Process.Start("https://support.microsoft.com/en-us/help/4072698/windows-server-speculative-execution-side-channel-vulnerabilities");

        void cbUnderstood_CheckedChanged(object sender, EventArgs e)
        {
            clbox.Enabled = cbUnderstood.Checked;
            tphv.Visible = !cbUnderstood.Checked;
            miJump.Enabled = cbUnderstood.Checked;
            miDelete.Enabled = cbUnderstood.Checked;
            cbHyperV.ForeColor = !cbUnderstood.Checked ? Color.Gray : Color.WhiteSmoke;
        }

        void lbGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            Process.Start("https://github.com/soulstace/BitSpectre");

        void checkBoxHyperV_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnderstood.Checked)
            {
                userModified = true;
                userSetHyperV = true;
            }
        }

        void miDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("This will delete all Windows registry entries mentioned by the Microsoft reference article above. Not recommended unless you're striving for default settings (possibly unsafe).\n\nAre you sure?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3))
            {
                tryDelete(mmkey, _override);
                tryDelete(mmkey, _mask);
                tryDelete(hypkey, hypval);
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

        void lbDecimal_DoubleClick(object sender, EventArgs e) => JumpToKey();

        void miJump_Click(object sender, EventArgs e) => JumpToKey();

        void JumpToKey()
        {
            if (cbUnderstood.Checked)
            {
                showMsg("Please note: the registry editor may not reflect your changes until you perform a F5 refresh.");

                RegistryKey rkLastkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Applets\Regedit", RegistryKeyPermissionCheck.ReadWriteSubTree);
                rkLastkey.SetValue("Lastkey", @"HKEY_LOCAL_MACHINE\" + mmkey);
                rkLastkey.Close();

                Process.Start("regedit");
            }
        }

        void RunPSCmd(string args)
        {
            Process.Start(new ProcessStartInfo("PowerShell", "-NoExit " + args));
        }

        private void miFullPolicy_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-ProcessMitigation -FullPolicy");
        }

        private void miSystem_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-ProcessMitigation -System");
        }

        private void miRecurse_Click(object sender, EventArgs e)
        {
            RunPSCmd(@"Get-ChildItem Cert:\ -Recurse");
        }

        private void miLsStores_Click(object sender, EventArgs e)
        {
            RunPSCmd(@"ls Cert:\LocalMachine");
        }

        private void miGetMMAgent_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-MMAgent");
        }

        private void miGetExecutionPolicy_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-ExecutionPolicy -List");
        }

        private void miGetProcess_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-Process | Sort ProcessName");
        }

        private void miGetService_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-Service | Sort Name");
        }

        private void miGetDNS_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-DnsClientCache");
        }

        private void miComputerInfo_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-ComputerInfo");
        }

        private void miTPM_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-Tpm");
        }

        private void miGetSmbShare_Click_1(object sender, EventArgs e)
        {
            RunPSCmd("Get-SmbShare");
        }

        private void miGetSmbSession_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-SmbSession");
        }

        private void miGetAppx_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-AppxPackage -AllUsers | Select Name, PackageFamilyName, Version, Status | Sort Name");
        }

        private void miStdPackages_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-Package | Sort Name");
        }

        private void miSchedTasks_Click(object sender, EventArgs e)
        {
            RunPSCmd("Get-ScheduledTask");
        }

        private void cms1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            clbox.Enabled = cbUnderstood.Checked;
            //cbUnderstood.Visible = true;
        }

        private void cms1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clbox.Enabled = false;
            //cbUnderstood.Visible = false;
        }

        private void lbMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cms1.Show(Cursor.Position.X, Cursor.Position.Y);
        }
    }
}
