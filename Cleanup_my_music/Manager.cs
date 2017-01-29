using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TagLib;

namespace Cleanup_my_music {

    ///<summary>
    ///This class should deal with meta data management things. 
    ///Ideally [MaT1g3R] wants this to report the numbers and the list of songs missing metadata, and some sort of mass set options.
    ///</summary>
    class Manager {

        /// <summary>
        /// The master song list
        /// </summary>
        private Dictionary<string, Dictionary<string, object>> masterSongList = new Dictionary<string, Dictionary<string, object>> { };
        /// <summary>
        /// The master path list
        /// </summary>
        private IEnumerable<string> masterPathList = new string[] { };

        /// <summary>
        /// Gets or sets the master path list.
        /// </summary>
        /// <value>
        /// The master path list.
        /// </value>
        public IEnumerable<string> MasterPathList {
            get {
                return masterPathList;
            }

            set {
                masterPathList = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="inputPathList">The input path list.</param>
        public Manager(IEnumerable<string> inputPathList) {
            foreach (string path in inputPathList) {
                try {
                    File pending = File.Create(path);
                    if (pending.Properties.MediaTypes == MediaTypes.Audio) {//We know it's an audio file
                        this.MasterPathList = this.MasterPathList.Concat(new string[] { path });//Add the path to the master path list
                        this.masterSongList.Add(path, new Dictionary<string, object> { });
                        //Then add the song's properties and tags as a dictionary to the master song list, with it's path as key?
                        //Get the tag and properties from the audio file
                        Tag songTag = pending.Tag;
                        TagLib.Properties songProperties = pending.Properties;

                        //Create two lists to hold the *CLASS PROPERTIES* of the tag and properties class
                        IEnumerable<PropertyInfo> tagClassProperties = songTag.GetType().GetProperties();
                        IEnumerable<PropertyInfo> songPropertiesClassProperties = songProperties.GetType().GetProperties();

                        //Get two lists of getter methods of the Tag and properties class
                        IEnumerable<MethodInfo> tagGetters = new MethodInfo[] { };
                        IEnumerable<MethodInfo> PropertyGetters = new MethodInfo[] { };

                        foreach (PropertyInfo p in tagClassProperties) {
                            if (p.GetGetMethod() != null && p.GetSetMethod() != null) {
                                tagGetters = tagGetters.Concat(new MethodInfo[] { p.GetGetMethod() });
                            }
                        }

                        foreach (PropertyInfo p in songPropertiesClassProperties) {
                            if (p.GetGetMethod() != null) {
                                PropertyGetters = PropertyGetters.Concat(new MethodInfo[] { p.GetGetMethod() });
                            }
                        }

                        //Now call all the getters and store the info in the dict
                        foreach (MethodInfo m in tagGetters) {
                            try {
                                var invokedValue = m.Invoke(songTag, null);
                                string methodName = m.Name.Substring(4);
                                this.masterSongList[path].Add(methodName, invokedValue);
                            } catch (ArgumentNullException) { }
                        }

                        foreach (MethodInfo m in PropertyGetters) {
                            try {
                                var invokedValue = m.Invoke(songProperties, null);
                                string methodName = m.Name.Substring(4);
                                this.masterSongList[path].Add(methodName, invokedValue);
                            } catch (ArgumentNullException) { }
                        }

                    }
                } catch (UnsupportedFormatException) { }//Catch error if file format isn't supported by the lib

            }

        }

        /// <summary>
        /// Gets the song attribute value.
        /// </summary>
        /// <param name="path">The path of the song.</param>
        /// <param name="attr">The desired attribute of the song.</param>
        /// <returns> The value of the desitred attribute </returns>
        public object getSongAttributes(string path, string attr) {
            var tmpSong = new Dictionary<string, object> { };
            if (!this.masterSongList.TryGetValue(path, out tmpSong)) {
                return null;
            }

            dynamic tmpVal;
            if (!tmpSong.TryGetValue(attr, out tmpVal)) {
                return null;
            }

            return tmpVal;
        }

    }
}