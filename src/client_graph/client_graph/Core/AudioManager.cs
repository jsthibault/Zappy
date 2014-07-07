using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*--------------------------------------------------------
 * AudioManager.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 03/07/2014 16:06:24
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client.Core
{
    public class AudioManager
    {
        #region FIELDS

        private static Object objLock = new Object();
        private static AudioManager instance;
        public static AudioManager Instance
        {
            get
            {
                lock (objLock) // thread safe
                {
                    if (instance == null)
                    {
                        instance = new AudioManager();
                    }
                    return instance;
                }
            }
        }

        private Dictionary<String, Song> Songs { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates the AudioManager instance
        /// </summary>
        public AudioManager()
        {
            this.Songs = new Dictionary<String, Song>();
			this.SetVolume(1.0f);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Add a new song with key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="song"></param>
        private void Add(String key, Song song)
        {
            if (this.Songs.ContainsKey(key) == false)
            {
                this.Songs.Add(key, song);
            }
        }

        /// <summary>
        /// Remove a song by key
        /// </summary>
        /// <param name="key"></param>
        private void Remove(String key)
        {
            if (this.Songs.ContainsKey(key) == true)
            {
                this.Songs.Remove(key);
            }
        }

        /// <summary>
        /// Stop the media player
        /// </summary>
        public void Stop()
        {
            MediaPlayer.Stop();
        }

        public Song this[String key]
        {
            get
            {
                if (this.Songs.ContainsKey(key) == true)
                {
                    return this.Songs[key];
                }
                return null;
            }
            set
            {
                if (this.Songs.ContainsKey(key) == false)
                {
                    this.Songs.Add(key, value);
                }
                else
                {
                    this.Songs[key] = value;
                }
            }
        }

		/// <summary>
		/// Sets the volume.
		/// </summary>
		/// <param name='value'>
		/// Value.
		/// </param>
		public void SetVolume(Single value)
		{
			MediaPlayer.Volume = value;
		}

        #endregion
    }

    public static class SongExt
    {
        /// <summary>
        /// Play a music
        /// </summary>
        /// <param name="song"></param>
        public static void Play(this Song song)
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }
    }
}
