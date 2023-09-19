namespace RGE.Lib.Abstractions
{
    public abstract class BaseGame
    {
        public abstract string GameHeaderStr { get; }

        public abstract string GameVersionStr { get; }

        public string TitleBarStr => $"{GameHeaderStr} (Version {GameVersionStr})";
    }
}