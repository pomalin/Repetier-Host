﻿/*
   Copyright 2012 repetier repetierdev@googlemail.com

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RepetierHost.view.utils;

namespace RepetierHost.view
{
    public partial class SoundConfig : Form
    {
        public static SoundConfig config = null;
        string filePrintFinished = "";
        string filePrintPaused = "";
        string fileError = "";
        string fileSoundCommand = "";

        public SoundConfig()
        {
            InitializeComponent();
            config = this;
            filePrintFinished = RegMemory.GetString("soundPrintFinished", filePrintFinished);
            filePrintPaused = RegMemory.GetString("soundPrintPaused", filePrintPaused);
            fileError = RegMemory.GetString("soundError", fileError);
            fileSoundCommand = RegMemory.GetString("soundSoundCommand", fileSoundCommand);
            checkPrintFinished.Checked = RegMemory.GetBool("soundPrintFinishedEnabled", checkPrintFinished.Checked);
            checkPrintPaused.Checked = RegMemory.GetBool("soundPrintPausedEnabled", checkPrintPaused.Checked);
            checkError.Checked = RegMemory.GetBool("soundErrorEnabled", checkError.Checked);
            checkSoundCommand.Checked = RegMemory.GetBool("soundSoundCommandEnabled", checkSoundCommand.Checked);
            labelPrintFinished.Text = "File:" + filePrintFinished;
            labelPrintPaused.Text = "File:" + filePrintPaused;
            labelError.Text = "File:" + fileError;
            labelSoundCommand.Text = "File:" + fileSoundCommand;
        }
        public void saveSettings()
        {
            RegMemory.SetString("soundPrintFinished", filePrintFinished);
            RegMemory.SetString("soundPrintPaused", filePrintPaused);
            RegMemory.SetString("soundError", fileError);
            RegMemory.SetString("soundSoundCommand", fileSoundCommand);
            RegMemory.SetBool("soundPrintFinishedEnabled", checkPrintFinished.Checked);
            RegMemory.SetBool("soundPrintPausedEnabled", checkPrintPaused.Checked);
            RegMemory.SetBool("soundErrorEnabled", checkError.Checked);
            RegMemory.SetBool("soundSoundCommandEnabled", checkSoundCommand.Checked);
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            saveSettings();
            Close();
        }

        static public void PlayPrintFinished(bool force)
        {
            if (!File.Exists(config.filePrintFinished)) return;
            if (force || config.checkPrintFinished.Checked)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(config.filePrintFinished);
                player.Play();
            }
        }
        static public void PlayPrintPaused(bool force)
        {
            if (!File.Exists(config.filePrintPaused)) return;
            if (force || config.checkPrintPaused.Checked)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(config.filePrintPaused);
                player.Play();
            }
        }
        static public void PlayError(bool force)
        {
            if (!File.Exists(config.fileError)) return;
            if (force || config.checkError.Checked)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(config.fileError);
                player.Play();
            }
        }
        static public void PlaySoundCommand(bool force)
        {
            if (!File.Exists(config.fileSoundCommand)) return;
            if (force || config.checkSoundCommand.Checked)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(config.fileSoundCommand);
                player.Play();
            }
        }

        private void buttonBrowsePrintFinsihed_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filePrintFinished = openFile.FileName;
                labelPrintFinished.Text = "File:" + filePrintFinished;
            }
        }

        private void buttonPlayPrintFinished_Click(object sender, EventArgs e)
        {
            PlayPrintFinished(true);
        }

        private void buttonPlayPrintPaused_Click(object sender, EventArgs e)
        {
            PlayPrintPaused(true);
        }

        private void buttonPlayError_Click(object sender, EventArgs e)
        {
            PlayError(true);
        }

        private void buttonPlaySoundCommand_Click(object sender, EventArgs e)
        {
            PlaySoundCommand(true);
        }

        private void buttonBrowsePrintPaused_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filePrintPaused = openFile.FileName;
                labelPrintPaused.Text = "File:" + filePrintPaused;
            }
        }

        private void buttonBrowseError_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileError = openFile.FileName;
                labelError.Text = "File:" + fileError;
            }
        }

        private void buttonBrowseSoundCommand_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileSoundCommand = openFile.FileName;
                labelSoundCommand.Text = "File:" + fileSoundCommand;
            }
        }
    }
}
