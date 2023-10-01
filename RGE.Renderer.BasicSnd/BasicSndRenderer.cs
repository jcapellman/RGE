﻿using RGE.Lib.Abstractions.Renderers;
using RGE.Lib.Objects.Config;

namespace RGE.Renderer.BasicSnd
{
    public class BasicSndRenderer : BaseSoundRenderer
    {
        public override string Name => "Basic Sound";

        public override bool Init(Configuration config)
        {
            return true;
        }
    }
}