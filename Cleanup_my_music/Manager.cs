using System;
using System.Collections.Generic;
using System.Linq;
using TagLib;
using System.Reflection;

namespace Cleanup_my_music {

    ///<summary>
    ///This class should deal with meta data management things. 
    ///For example getting and setting genres. The exact implementation should be handled by [KingGuppie]. 
    ///Ideally [MaT1g3R] wants this to report the numbers and the list of songs missing metadata, and some sort of mass set options.
    ///</summary>
    class Manager {

        private Dictionary<String, Dictionary<string, IEnumerable<string>>> songDict = new Dictionary<String, Dictionary<string, IEnumerable<string>>> { };

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="pathList">The path list.</param>
        public Manager(IEnumerable<string> pathList) {
            foreach (string path in pathList) {
                try {
                    File pending = File.Create(path);
                    if (pending.Properties.MediaTypes == MediaTypes.Audio) {

                        Tag songTags = pending.Tag;

                        PropertyInfo[] songTagsProperties = songTags.GetType().GetProperties();

                        List<MethodInfo> tagGetters = new List<MethodInfo> { };

                        foreach (PropertyInfo info in songTagsProperties) {
                            if (info.GetSetMethod() != null && info.GetGetMethod() != null) {
                                tagGetters.Add(info.GetGetMethod());
                            }
                        }

                        foreach (MethodInfo getter in tagGetters) {
                            try {
                                IEnumerable<string> pathIEnumerable = new string[] { path };
                                string tagName = getter.Name.Substring(4);
                                var tagValueC = getter.Invoke(songTags, null);
                                if (tagValueC.GetType() == typeof(string[])) {
                                    string tmpVal = "";
                                    foreach (string s in (string[])tagValueC) {
                                        tmpVal += s + ",";
                                    }
                                    tagValueC = tmpVal.Substring(0, tmpVal.Length - 1);
                                }

                                string tagValue = (string)tagValueC;
                                tagValue = tagValue.ToLower();

                                if (!this.songDict.ContainsKey(tagName)) {
                                    Dictionary<string, IEnumerable<string>> subDict = new Dictionary<string, IEnumerable<string>> { };
                                    subDict.Add(tagValue, pathIEnumerable);
                                    this.songDict.Add(tagName, subDict);
                                } else {
                                    if (this.songDict[tagName].ContainsKey(tagValue)) {
                                        this.songDict[tagName][tagValue] = this.songDict[tagName][tagValue].Concat(pathIEnumerable);
                                    } else {
                                        this.songDict[tagName].Add(tagValue, pathIEnumerable);
                                    }
                                }

                            } catch { ArgumentNullException ex; }
                        }
                    }
                } catch (TagLib.UnsupportedFormatException) { }
            }
        }

        /// <summary>
        /// Gets the songs by tag.
        /// </summary>
        /// <param name="tag">The tag type.(for example "Genre")</param>
        /// <param name="value">The tag value.(for example "Rock")</param>
        /// <returns></returns>
        public IEnumerable<string> getSongsByTag(string tag, string value) {
            tag = tag.ToLower(); value = value.ToLower();
            return this.songDict[tag][value];
        }












    }
}