using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Structural
{
    public interface IDVDPlayer
    {
        void On();

        void Off();

        void Play();

        void Pause();
    }

    public interface IProjector
    {
        void Show();

        void Hide();
    }

    public interface ISoundSystem
    {
        void IncreaseVolume();

        void DecreaseVolume();
    }

    public class DVDPlayer : IDVDPlayer
    {
        public void Off()
        {

        }

        public void On()
        {

        }

        public void Pause()
        {

        }

        public void Play()
        {

        }
    }

    public class Projector : IProjector
    {
        public void Hide()
        {

        }

        public void Show()
        {

        }
    }

    public class SoundSystem : ISoundSystem
    {
        public void DecreaseVolume()
        {

        }

        public void IncreaseVolume()
        {

        }
    }


    public interface ITheatreFacade
    {
        void WatchMovie();
    }

    public class TheatreFacade : ITheatreFacade
    {
        private readonly SoundSystem soundSystem;
        private readonly Projector projector;
        private readonly DVDPlayer dVDPlayer;

        public TheatreFacade(SoundSystem sound, Projector projector, DVDPlayer dvdplayer)
        {
            this.soundSystem = sound;
            this.projector = projector;
            this.dVDPlayer = dvdplayer;
        }

        public void WatchMovie()
        {
            this.dVDPlayer.On();
            this.dVDPlayer.Play();
            this.projector.Show();
            this.soundSystem.IncreaseVolume();
        }
    }
}
