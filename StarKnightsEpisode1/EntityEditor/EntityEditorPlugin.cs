﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinePlugins;
using System.Windows;
using System.Windows.Forms;
namespace EntityEditor
{
    public class EntityEditorPlugin : CinePlugin
    {

        public override Control GetUI()
        {
            return new EntityEditorControl();
        }

        public override string GetName()
        {
            return "EntityEditorPlugin";
        }

    }

    public class AnimEditorPlugin : CinePlugin
    {

        public override Control GetUI()
        {
            return new AnimEditorControl();
        }

        public override string GetName()
        {
            return "AnimEditorPlugin";
        }

    }

    public static class PluginEntry
    {

        public static CinePlugin[] GetPlugin()
        {

            CinePlugin[] pr = new CinePlugin[2];
            pr[0] = new EntityEditorPlugin();
            pr[1] = new AnimEditorPlugin();
            return pr;

        }


    }

}
