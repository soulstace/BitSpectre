using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BitSpectre
{
    public partial class frmSpectre : Form
    {
        int spectreVal = 0;
        bool regValExists = false;
        bool userModified = false;
        bool userSetHyperV = false;
        const string subkey = @"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management";
        const string hyperval = "MinVmVersionForCpuBasedMitigations";

        public frmSpectre()
        {
            InitializeComponent();
        }

        private void frmSpectre_Load(object sender, EventArgs e)
        {
            RegistryKey rkSp = Registry.LocalMachine.OpenSubKey(subkey, RegistryKeyPermissionCheck.ReadSubTree);
            //if (rkSp != null) /* this won't be null on any current version of Windows */
            //{
            object objSp = rkSp.GetValue("FeatureSettingsOverride", null);
            if (objSp != null)
            {
                regValExists = true;
                spectreVal = (int)objSp;
            }
            rkSp.Close();
            //}

            labelDecimalValue.Text = "Decimal value: " + spectreVal.ToString();

            if (regValExists) //only check checkbox items if the registry value exists
            {
                if (spectreVal == 0)
                    checkedListBox1.SetItemCheckState(0, CheckState.Checked); //check 0
                else
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                    {
                        if (GetBinaryFlag(spectreVal, i))
                            checkedListBox1.SetItemCheckState(i + 1, CheckState.Checked); //the first item in the checkedlistbox is 0 and not a valid bit
                    }
                }
            }

            RegistryKey rkHv = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Virtualization",
                RegistryKeyPermissionCheck.ReadSubTree);
            checkBoxHyperV.Checked = rkHv.GetValue(hyperval, "").ToString() == "1.0" ? true : false;
            rkHv.Close();
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
                        checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            else //we selected a valid bit
            {
                checkedListBox1.SetItemCheckState(0, CheckState.Unchecked); //uncheck 0

                bool flag = checkedListBox1.GetItemCheckState(checkedListBox1.SelectedIndex) == CheckState.Checked;
                spectreVal = SetBinaryFlag(spectreVal, checkedListBox1.SelectedIndex - 1, flag); //the selected index is offset +1 from the first bit in the buffer
                                                                                                //because the index 0 checkbox isn't used as a bit flag
            }

            labelDecimalValue.Text = "Decimal value: " + spectreVal.ToString();
        }

        void frmSpectre_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (userModified && checkBoxUnderstood.Checked)
            {
                RegistryKey rkSp = Registry.LocalMachine.CreateSubKey(subkey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                rkSp.SetValue("FeatureSettingsOverride", spectreVal);
                rkSp.SetValue("FeatureSettingsOverrideMask", 3);
                rkSp.Close();

                if (userSetHyperV)
                {
                    RegistryKey rkHv = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Virtualization",
                            RegistryKeyPermissionCheck.ReadWriteSubTree);
                    if (checkBoxHyperV.Checked)
                        rkHv.SetValue(hyperval, "1.0", RegistryValueKind.String);
                    else
                        rkHv.DeleteValue(hyperval, false);
                    rkHv.Close();
                }

                //Prompt to restart
                if (DialogResult.Yes == MessageBox.Show("Your settings will not take effect until you reboot the system.\nWould you like to restart Windows now?", "Restart required", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    //try
                    //{
                        NativeMethods.DoExitWin(NativeMethods.EWX_REBOOT);
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("You do not have the necessary priviledges to shut down this system.", "Restart failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}
                }
                else
                {
                    MessageBox.Show("Any changes you have made will be applied next time you restart Windows.", "Restart cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        void linkLabelMicrosoft_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://support.microsoft.com/en-us/help/4072698/windows-server-speculative-execution-side-channel-vulnerabilities");
        }

        void checkBoxUnderstood_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox1.Enabled = checkBoxUnderstood.Checked;
            checkBoxHyperV.Enabled = checkBoxUnderstood.Checked;
        }

        void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/soulstace/BitSpectre");
        }

        private void checkBoxHyperV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUnderstood.Checked)
            {
                userModified = true;
                userSetHyperV = true;
            }
        }
    }
}
