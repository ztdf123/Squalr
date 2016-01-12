﻿using Binarysharp.MemoryManagement;
using Binarysharp.MemoryManagement.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anathema
{
    interface ISettingsView : IView
    {
        // Methods invoked by the presenter (upstream)

    }

    interface ISettingsModel : IModel
    {
        // Events triggered by the model (upstream)

        // Functions invoked by presenter (downstream)
        void UpdateStateSettings(Boolean Commit, Boolean Reserve, Boolean Free);
        void UpdateTypeSettings(Boolean Private, Boolean Mapped, Boolean Image);
        void UpdateProtectionSettings(Boolean NoAccess, Boolean ReadOnly, Boolean ReadWrite, Boolean WriteCopy, Boolean Execute,
           Boolean ExecuteRead, Boolean ExecuteReadWrite, Boolean ExecuteWriteCopy, Boolean Guard, Boolean NoCache, Boolean WriteCombine);

        Boolean[] GetStateSettings();
        Boolean[] GetTypeSettings();
        Boolean[] GetProtectionSettings();

        Int32 GetFreezeInterval();
        Int32 GetRescanInterval();
        Int32 GetResultReadInterval();
        Int32 GetTableReadInterval();

        void UpdateFreezeInterval(Int32 FreezeInterval);
        void UpdateRescanInterval(Int32 RescanInterval);
        void UpdateResultReadInterval(Int32 ResultReadInterval);
        void UpdateTableReadInterval(Int32 TableReadInterval);
    }

    class SettingsPresenter : Presenter<ISettingsView, ISettingsModel>
    {
        protected new ISettingsView View { get; set; }
        protected new ISettingsModel Model { get; set; }

        public SettingsPresenter(ISettingsView View, ISettingsModel Model) : base(View, Model)
        {
            this.View = View;
            this.Model = Model;

            // Bind events triggered by the model
        }

        #region Method definitions called by the view (downstream)

        public void UpdateStateSettings( Boolean Commit, Boolean Reserve, Boolean Free)
        {
            Model.UpdateStateSettings(Commit, Reserve, Free);
        }

        public void UpdateTypeSettings(Boolean Private, Boolean Mapped, Boolean Image)
        {
            Model.UpdateTypeSettings(Private, Mapped, Image);
        }

        public void UpdateProtectionSettings(Boolean NoAccess, Boolean ReadOnly, Boolean ReadWrite, Boolean WriteCopy, Boolean Execute,
            Boolean ExecuteRead, Boolean ExecuteReadWrite, Boolean ExecuteWriteCopy, Boolean Guard, Boolean NoCache, Boolean WriteCombine)
        {
            Model.UpdateProtectionSettings(NoAccess, ReadOnly, ReadWrite, WriteCopy, Execute, ExecuteRead, ExecuteReadWrite, ExecuteWriteCopy, Guard, NoCache, WriteCombine);
        }

        public void UpdateFreezeInterval(String FreezeInterval)
        {
            Model.UpdateFreezeInterval(Int32.Parse(FreezeInterval));
        }

        public void UpdateRescanInterval(String RescanInterval)
        {
            Model.UpdateRescanInterval(Int32.Parse(RescanInterval));
        }

        public void UpdateResultReadInterval(String ResultReadInterval)
        {
            Model.UpdateResultReadInterval(Int32.Parse(ResultReadInterval));
        }

        public void UpdateTableReadInterval(String TableReadInterval)
        {
            Model.UpdateTableReadInterval(Int32.Parse(TableReadInterval));
        }

        public Boolean[] GetStateSettings()
        {
            return Model.GetStateSettings();
        }

        public Boolean[] GetTypeSettings()
        {
            return Model.GetTypeSettings();
        }

        public Boolean[] GetProtectionSettings()
        {
            return Model.GetProtectionSettings();
        }

        public String GetFreezeInterval()
        {
            return Model.GetFreezeInterval().ToString();
        }

        public String GetRescanInterval()
        {
            return Model.GetRescanInterval().ToString();
        }

        public String GetResultReadInterval()
        {
            return Model.GetResultReadInterval().ToString();
        }

        public String GetTableReadInterval()
        {
            return Model.GetTableReadInterval().ToString();
        }

        #endregion

        #region Event definitions for events triggered by the model (upstream)

        #endregion
    }
}