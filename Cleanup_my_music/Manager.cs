using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Manager(IEnumerable<string> pathList) {
            foreach (string path in pathList) {
                try {
                    File pending = File.Create(path);
                    if (pending.Properties.MediaTypes == MediaTypes.Audio) {

                        Tag songTags = pending.Tag;
                        TagLib.Properties songProperties = pending.Properties;

                        PropertyInfo[] songTagsProperties = songTags.GetType().GetProperties();
                        PropertyInfo[] songPropertiesProperties = songProperties.GetType().GetProperties();

                        List<MethodInfo> tagGetters = new List<MethodInfo> { };
                        List<MethodInfo> PropertyGetters = new List<MethodInfo> { };

                        foreach (PropertyInfo info in songTagsProperties) {
                            if (info.GetSetMethod() != null && info.GetGetMethod() != null) {
                                tagGetters.Add(info.GetGetMethod());
                            }
                        }

                        foreach (PropertyInfo info in songPropertiesProperties) {
                            if (info.GetGetMethod() != null) {
                                PropertyGetters.Add(info.GetGetMethod());
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

    }
}